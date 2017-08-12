// -----------------------------------------------------------------------
//  <copyright file="LoggingTest.cs" company="Phoenix Game Studios, LLC">
//      Copyright (c) 2017 Phoenix Game Studios, LLC. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/PhoenixGameStudios/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------
namespace Dangr.Framework.Logging
{
    using System;
    using System.IO;
    using System.ServiceModel;
    using System.Threading;
    using Dangr.Core.Configuration;
    using Dangr.Core.Configuration.Sources;
    using Dangr.Core.Logging;
    using Dangr.Core.Logging.Loggers;
    using Dangr.Core.Logging.Wcf;
    using Dangr.Core.Test;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class LoggingTest
    {
        [TestMethod]
        public void Logging_Test()
        {
            const int messagesToLog = 100;
            const int expectedCount = messagesToLog * 14;
            const int maxMemoryLoggerEntries = expectedCount / 2;
            TestEndpoint testEndpoint = new TestEndpoint();
            MemoryLogger memoryLogger = new MemoryLogger();
            TestUtils.TestForError<ArgumentOutOfRangeException>(
                () => memoryLogger.MaxNumEntries = -1,
                "Should not allow a negative value for MaxNumEntries.");
            memoryLogger.MaxNumEntries = maxMemoryLoggerEntries;
            
            using (ConsoleLogger consoleLogger = new ConsoleLogger())
            using (TextLogger textLogger = new TextLogger())
            using (LogService logger = new LogService())
            {
                textLogger.MaxLogFileEntries = maxMemoryLoggerEntries;

                logger.RegisterEndpoint(testEndpoint);
                logger.RegisterEndpoint(consoleLogger);
                logger.RegisterEndpoint(new DebugTraceLogger());
                logger.RegisterEndpoint(memoryLogger);
                logger.RegisterEndpoint(textLogger);
                logger.AddFeature("Test Feature");
                logger.AddFeature("Test Feature2");
                logger.RemoveFeature("Test Feature2");
                ConsoleLogger removeLogger = new ConsoleLogger();
                logger.RegisterEndpoint(removeLogger);
                logger.UnregisterEndpoint(removeLogger);
                logger.RegisterInternalEndpoint(removeLogger);
                logger.UnregisterInternalEndpoint(removeLogger);

                logger.RegisterEndpoint(
                    new TextLogger(
                        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "TestLogs"),
                        "TestLogs_"));

                for (int i = 0; i < messagesToLog; i++)
                {
                    logger.LogInfo($"Test info message {i}");
                    logger.LogInfo("Test Feature", $"Test feature info message {i}");

                    logger.LogDebug($"Test debug message {i}");
                    logger.LogDebug("Test Feature", $"Test feature debug message {i}");

                    logger.LogVerbose($"Test verbose message {i}");
                    logger.LogVerbose("Test Feature", $"Test feature verbose message {i}");

                    logger.LogStatus($"Test status message {i}");
                    logger.LogStatus("Test Feature", $"Test feature status message {i}");

                    logger.LogWarning($"Test warning message {i}");
                    logger.LogWarning("Test Feature", $"Test feature warning message {i}");

                    logger.LogCritical($"Test critical message {i}");
                    logger.LogCritical("Test Feature", $"Test feature critical message {i}");

                    logger.LogFatal($"Test fatal message {i}");
                    logger.LogFatal("Test Feature", $"Test feature fatal message {i}");
                }

                logger.SignalShutDown(TimeSpan.FromSeconds(5));
                logger.SignalShutDown();
            }

            Assert.AreEqual(expectedCount, testEndpoint.NumMessagesLogged);
            Assert.AreEqual(maxMemoryLoggerEntries, memoryLogger.Entries.Count);
        }

        [Ignore]
        [TestMethod]
        public void Wcf_Logging_Test()
        {
            const int numMessagesToLog = 21;

            var baseAddresses = new[] {DefaultWcfEndpoints.GetNetNamedPipeUri()};

            DefaultWcfEndpoints.GetHttpEndpointAddress();
            DefaultWcfEndpoints.GetNetTcpEndpointAddress();
            DefaultWcfEndpoints.GetMsmqEndpointAddress();
            
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

                using (WcfLogService.ServiceHolder serviceHolder = WcfLogService.Run(
                    destLogger,
                    baseAddresses,
                    DefaultWcfEndpoints.DefaultNamedPipeServiceName,
                    new NetNamedPipeBinding()))
                {
                    Assert.IsTrue(serviceHolder.IsRunning);

                    // Wait for the WCF service to spin up.
                    while (internalEndpoint.NumMessagesLogged == 0)
                    {
                        Thread.Sleep(16);
                    }

                    WcfLoggerConfigView configView = new WcfLoggerConfigView();
                    DebugConfigurationSource configSource = new DebugConfigurationSource();
                    Configuration config = new Configuration();
                    config.RegisterConfigurationSource(configSource);
                    config.RegisterConfigurationView(configView);

                    configSource.TryAddOrUpdateSetting("binding", "netHttp");
                    configSource.TryAddOrUpdateSetting("logfiledirectory", "dir");
                    configSource.TryAddOrUpdateSetting("logfileprefix", "prefix");
                    configSource.TryAddOrUpdateSetting("servicename", "service");
                    configSource.TryAddOrUpdateSetting("uri", "uri");
                    using (new WcfLogger(
                        destLogger,
                        new BasicHttpBinding(), 
                        new EndpointAddress("http://FakeEndpoint")))
                    {
                    }

                    using (WcfLogger wcfLogger = new WcfLogger(
                        destLogger,
                        new NetNamedPipeBinding(),
                        DefaultWcfEndpoints.GetNetNamedPipeEndpointAddress(),
                        10,
                        TimeSpan.FromMilliseconds(250)))
                    {
                        sourceLogger.RegisterEndpoint(consoleLogger);
                        sourceLogger.RegisterEndpoint(sourceEndpoint);
                        sourceLogger.RegisterEndpoint(wcfLogger);

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

                    serviceHolder.Shutdown(TimeSpan.FromMilliseconds(-1));
                }
            }

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