// -----------------------------------------------------------------------
//  <copyright file="LoggingTest.cs" company="DangerDan9631">
//      Copyright (c) 2017 Dan Garvey. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/Dangerdan9631/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.Framework.Logging
{
    using System;
    using System.IO;
    using System.ServiceModel;
    using System.Threading;
    using Dangr.Logging;
    using Dangr.Logging.Loggers;
    using Dangr.Logging.Wcf;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class LoggingTest
    {
        [TestMethod]
        public void Logging_Test()
        {
            TestEndpoint testEndpoint = new TestEndpoint();
            using (LogService logger = new LogService())
            {
                logger.RegisterEndpoint(testEndpoint);
                logger.RegisterEndpoint(new ConsoleLogger());
                logger.RegisterEndpoint(
                    new TextLogger(
                        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "TestLogs"),
                        "TestLogs_"));

                for (int i = 0; i < 1000; i++)
                {
                    logger.LogInfo($"Test message {i}");
                }

                logger.SignalShutDown(TimeSpan.FromSeconds(5));
            }

            Assert.AreEqual(1000, testEndpoint.NumMessagesLogged);
        }

        [Ignore]
        [TestMethod]
        public void Wcf_Logging_Test()
        {
            const int numMessagesToLog = 21;

            var baseAddresses = new[] {DefaultWcfEndpoints.GetNetNamedPipeUri()};

            WcfLogService.ServiceHolder serviceHolder;
            TestEndpoint internalEndpoint = new TestEndpoint();
            ConsoleLogger consoleLogger = new ConsoleLogger();
            TestEndpoint destEndpoint = new TestEndpoint();
            TestEndpoint sourceEndpoint = new TestEndpoint();

            using (LogService destLogger = new LogService())
            using (LogService sourceLogger = new LogService())
            {
                destLogger.RegisterInternalEndpoint(internalEndpoint);
                destLogger.RegisterEndpoint(consoleLogger);
                destLogger.RegisterEndpoint(destEndpoint);

                serviceHolder = WcfLogService.Run(
                    destLogger,
                    baseAddresses,
                    DefaultWcfEndpoints.DefaultNamedPipeServiceName,
                    new NetNamedPipeBinding());

                // Wait for the WCF service to spin up.
                while (internalEndpoint.NumMessagesLogged == 0)
                {
                    Thread.Sleep(16);
                }

                sourceLogger.RegisterEndpoint(consoleLogger);
                sourceLogger.RegisterEndpoint(sourceEndpoint);
                sourceLogger.RegisterEndpoint(
                    new WcfLogger(
                        destLogger,
                        new NetNamedPipeBinding(),
                        DefaultWcfEndpoints.GetNetNamedPipeEndpointAddress(),
                        10,
                        TimeSpan.FromMilliseconds(250)));

                Random r = new Random();
                for (int i = 0; i < numMessagesToLog; i++)
                {
                    sourceLogger.LogInfo($"Test message {i}");
                    Thread.Sleep(r.Next(50));
                }

                while (destEndpoint.NumMessagesLogged < numMessagesToLog)
                {
                }

                sourceLogger.SignalShutDown(TimeSpan.FromSeconds(5));
                destLogger.SignalShutDown(TimeSpan.FromSeconds(5));
            }

            serviceHolder?.Shutdown(TimeSpan.FromMilliseconds(-1));

            Assert.AreEqual(numMessagesToLog, destEndpoint.NumMessagesLogged);
        }
        
        [Ignore]
        [TestMethod]
        public void Log_Viewer_Test()
        {
            // This test should be manually verified by running Log Viewer
            const int numMessagesToLog = 100;

            ConsoleLogger consoleLogger = new ConsoleLogger();
            TestEndpoint sourceEndpoint = new TestEndpoint();

            using (LogService sourceLogger = new LogService())
            {
                sourceLogger.RegisterEndpoint(sourceEndpoint);
                sourceLogger.RegisterEndpoint(consoleLogger);
                sourceLogger.RegisterEndpoint(
                    new WcfLogger(
                        sourceLogger,
                        new NetNamedPipeBinding(),
                        DefaultWcfEndpoints.GetNetNamedPipeEndpointAddress(),
                        10,
                        TimeSpan.FromMilliseconds(250)));

                Random r = new Random();
                for (int i = 0; i < numMessagesToLog; i++)
                {
                    sourceLogger.LogInfo($"Test message {i}");
                    Thread.Sleep(r.Next(50));
                }

                while (sourceEndpoint.NumMessagesLogged < numMessagesToLog)
                {
                    Thread.Sleep(16);
                }

                Thread.Sleep(1000);

                sourceLogger.SignalShutDown();
            }
        }
    }
}