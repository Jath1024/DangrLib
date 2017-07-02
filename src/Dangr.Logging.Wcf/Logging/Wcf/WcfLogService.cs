// -----------------------------------------------------------------------
//  <copyright file="WcfLogService.cs" company="DangerDan9631">
//      Copyright (c) 2017 Dan Garvey. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/Dangerdan9631/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.Logging.Wcf
{
    using System;
    using System.Collections.Generic;
    using System.Reactive.Disposables;
    using System.ServiceModel;
    using System.ServiceModel.Channels;
    using System.Threading;
    using System.Threading.Tasks;
    using Dangr.Diagnostics;
    using JetBrains.Annotations;

    /// <summary>
    /// <para>A service that listens for connections from 
    /// <see cref="WcfLogClient" /></para>
    /// <para>
    /// <para>s and logs the messages to a designated <see cref="LogService" />
    /// </para>
    /// <para>.</para>
    /// </para>
    /// </summary>
    public class WcfLogService : IWcfLogService
    {
        /// <summary>
        /// Object used to hold a reference to the running <see cref="WcfLogService" /> .
        /// </summary>
        public class ServiceHolder : ICancelable
        {
            private readonly Task serviceTask;

            /// <summary>
            /// Gets a value indicating whether the <see cref="WcfLogService" /> is running
            /// </summary>
            public bool IsRunning => !this.serviceTask.IsCompleted;

            /// <summary>
            /// Gets a value that indicates whether the object is disposed.
            /// </summary>
            public bool IsDisposed { get; private set; }

            internal ServiceHolder(Task serviceTask)
            {
                Assert.Validate.IsNotNull(serviceTask, nameof(serviceTask));
                this.serviceTask = serviceTask;
            }

            /// <summary>
            /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
            /// </summary>
            public void Dispose()
            {
                this.Dispose(true);
            }

            /// <summary>
            /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
            /// </summary>
            /// <param name="isDisposing">
            /// A value indicating whether this object is being disposed.
            /// </param>
            protected virtual void Dispose(bool isDisposing)
            {
                if (isDisposing && !this.IsDisposed)
                {
                    this.Shutdown(TimeSpan.Zero);
                    this.IsDisposed = true;
                }
            }

            /// <summary>
            /// Shuts down the <see cref="WcfLogService" /> using the specified timeout.
            /// </summary>
            /// <param name="timeout">The timeout.</param>
            public void Shutdown(TimeSpan timeout)
            {
                WcfLogService.SignalShutdown();
                this.serviceTask.Wait(timeout);
            }

            /// <summary>
            /// Waits for the service to shut down.
            /// </summary>
            /// <param name="timeout">The timeout.</param>
            public void Wait(TimeSpan timeout)
            {
                this.serviceTask.Wait(timeout);
            }
        }

        private static readonly object RunLock = new object();
        private static bool isRunning;

        private static LogService logService;
        private static CancellationTokenSource cancelTokenSource;

        /// <summary>
        /// Runs the <see cref="WcfLogService" /> .
        /// </summary>
        /// <param name="logService">
        /// The <see cref="LogService" /> that will log the incoming messages.
        /// </param>
        /// <param name="baseAddresses">
        /// The base addresses for the <see cref="WcfLogService" /> .
        /// </param>
        /// <param name="endpointAddress">
        /// The endpoint address for the <see cref="WcfLogService" /> .
        /// </param>
        /// <param name="binding">
        /// The wcf binding for the <see cref="WcfLogService" /> .
        /// </param>
        /// <returns>
        /// <para>A <see cref="WcfLogService.ServiceHolder" /> that can be used to shut down the <see cref="WcfLogService" /> or <c> null </c></para>
        /// <para>if the service was already running.</para>
        /// </returns>
        public static ServiceHolder Run(
            LogService logService,
            Uri[] baseAddresses,
            string endpointAddress,
            Binding binding)
        {
            Assert.Validate.IsNotNull(logService, nameof(logService));
            Assert.Validate.IsNotNull(baseAddresses, nameof(baseAddresses));
            Assert.Validate.IsNotEmpty(baseAddresses, nameof(baseAddresses));
            Assert.Validate.IsNotNull(endpointAddress, nameof(endpointAddress));
            Assert.Validate.IsNotNull(binding, nameof(binding));

            var dict = new Dictionary<string, Binding>
            {
                { endpointAddress, binding }
            };

            return WcfLogService.Run(logService, baseAddresses, dict);
        }

        /// <summary>
        /// Runs the <see cref="WcfLogService" /> .
        /// </summary>
        /// <param name="logService">
        /// The <see cref="LogService" /> that will log the incoming messages.
        /// </param>
        /// <param name="baseAddresses">
        /// The base addresses for the <see cref="WcfLogService" /> .
        /// </param>
        /// <param name="endpoints">
        /// The endpoints for the <see cref="WcfLogService" /> .
        /// </param>
        /// <returns>
        /// <para>A <see cref="WcfLogService.ServiceHolder" /> that can be used to shut down the <see cref="WcfLogService" /> or <c> null </c></para>
        /// <para>if the service was already running.</para>
        /// </returns>
        public static ServiceHolder Run(
            LogService logService,
            Uri[] baseAddresses,
            Dictionary<string, Binding> endpoints)
        {
            Assert.Validate.IsNotNull(logService, nameof(logService));
            Assert.Validate.IsNotNull(baseAddresses, nameof(baseAddresses));
            Assert.Validate.IsNotEmpty(baseAddresses, nameof(baseAddresses));
            Assert.Validate.IsNotNull(endpoints, nameof(endpoints));
            Assert.Validate.IsNotEmpty(endpoints, nameof(endpoints));

            lock (WcfLogService.RunLock)
            {
                if (WcfLogService.isRunning)
                {
                    return null;
                }

                WcfLogService.isRunning = true;
            }

            WcfLogService.logService = logService;
            WcfLogService.cancelTokenSource = new CancellationTokenSource();

            Task serviceTask = Task.Run(
                () =>
                {
                    ServiceHost selfHost = null;
                    try
                    {
                        selfHost = new ServiceHost(typeof(WcfLogService), baseAddresses);
                        foreach (KeyValuePair<string, Binding> kvp in endpoints)
                        {
                            selfHost.AddServiceEndpoint(typeof(IWcfLogService), kvp.Value, kvp.Key);
                        }

                        selfHost.Open();

                        foreach (Uri address in selfHost.BaseAddresses)
                        {
                            WcfLogService.logService.LogInternal(LogLevel.Verbose, $"Listening on endpoint {address}");
                        }

                        WcfLogService.logService.LogInternal(LogLevel.Status, "The WcfLogService is ready.");

                        WcfLogService.cancelTokenSource.Token.WaitHandle.WaitOne();

                        selfHost.Close();
                    }
                    catch (CommunicationException e)
                    {
                        WcfLogService.logService.LogInternal(LogLevel.Fatal, $"An exception occurred: {e.Message}");
                        selfHost?.Abort();
                    }
                    finally
                    {
                        lock (WcfLogService.RunLock)
                        {
                            WcfLogService.isRunning = false;
                        }
                    }
                });

            return new ServiceHolder(serviceTask);
        }

        /// <summary>
        /// Signals the <see cref="WcfLogService" /> to shutdown.
        /// </summary>
        public static void SignalShutdown()
        {
            WcfLogService.cancelTokenSource?.Cancel();
        }

        /// <summary>
        /// Logs the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        public void Log(LogEntry message)
        {
            Assert.Validate.IsNotNull(message, nameof(message));
            WcfLogService.logService?.LogEntry(message);
        }

        /// <summary>
        /// Logs a batch of messages.
        /// </summary>
        /// <param name="messages">The messages.</param>
        public void LogBatch(LogEntry[] messages)
        {
            Assert.Validate.IsNotNull(messages, nameof(messages));

            if (WcfLogService.logService != null)
            {
                foreach (LogEntry message in messages)
                {
                    WcfLogService.logService.LogEntry(message);
                }
            }
        }
    }
}