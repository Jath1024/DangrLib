// -----------------------------------------------------------------------
//  <copyright file="WcfLogger.cs" company="Phoenix Game Studios, LLC">
//      Copyright (c) 2017 Phoenix Game Studios, LLC. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/PhoenixGameStudios/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------
namespace Dangr.Core.Logging.Loggers
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.ServiceModel;
    using System.ServiceModel.Channels;
    using System.Text;
    using System.Threading;
    using Dangr.Core.Diagnostics;
    using Dangr.Core.Logging;
    using Dangr.Core.Logging.Wcf;
    using Dangr.Core.Util;
    using Dangr.Internal.Logging.Wcf;

    /// <summary>
    ///     Logger pipeline logger that will use WCF to send logs to a 
    ///     <see cref="WcfLogService" /> that is listening for logs.
    /// </summary>
    public class WcfLogger : ILogEndpoint, ICheckedDisposable
    {
        /// <summary>
        ///     The default maximum batch size.
        /// </summary>
        public const int DefaultMaxBatchSize = 200;

        /// <summary>
        ///     The default interval to wait before sending a batch of logs.
        /// </summary>
        public static readonly TimeSpan DefaultMessageInterval = TimeSpan.FromMilliseconds(100);

        private readonly LogService logService;
        private bool loggedEndpointNotFound;
        private WcfLogClient client;
        private readonly Timer timer;
        private readonly ConcurrentQueue<LogEntry> entriesQueue;

        /// <summary>
        ///     Gets or sets the maximum size of the batch.
        /// </summary>
        public int MaxBatchSize { get; }

        /// <summary>
        ///     Gets or sets the interval to wait before sending a batch of logs.
        /// </summary>
        public TimeSpan MessageInterval { get; }

        /// <summary>
        ///     Gets a value indicating whether this object is disposed.
        /// </summary>
        public bool IsDisposed { get; private set; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="WcfLogger" /> class.
        /// </summary>
        /// <param name="logService"> The log service this pipeline is registered with. </param>
        /// <param name="binding"> The binding. </param>
        /// <param name="endpointAddress"> The endpoint address. </param>
        public WcfLogger(LogService logService, Binding binding, EndpointAddress endpointAddress)
            : this(logService, binding, endpointAddress, WcfLogger.DefaultMaxBatchSize, WcfLogger.DefaultMessageInterval
            )
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="WcfLogger" /> class.
        /// </summary>
        /// <param name="logService"> The log service this pipeline is registered with. </param>
        /// <param name="binding"> The binding. </param>
        /// <param name="endpointAddress"> The endpoint address. </param>
        /// <param name="maxBatchSize"> The maximum size of the batch. </param>
        /// <param name="maxTimeSpan"> The interval to wait before sending a batch of logs. </param>
        public WcfLogger(
            LogService logService,
            Binding binding,
            EndpointAddress endpointAddress,
            int maxBatchSize,
            TimeSpan maxTimeSpan)
        {
            this.logService = logService;
            this.ConnectClient(binding, endpointAddress);

            this.MaxBatchSize = maxBatchSize;
            this.MessageInterval = maxTimeSpan;
            this.entriesQueue = new ConcurrentQueue<LogEntry>();
            this.timer = new Timer(this.ProcessMessages, null, this.MessageInterval.Milliseconds,
                this.MessageInterval.Milliseconds);
        }

        private void ConnectClient(Binding binding, EndpointAddress endpointAddress)
        {
            try
            {
                this.client = WcfLogClient.CreateClient(binding, endpointAddress);
            }
            catch (EndpointNotFoundException e)
            {
                // Swallow the exception.
                // We only want to log EndpointNotFound exception once, so we don't spam 
                // messages everytime something is logged.
                if (!this.loggedEndpointNotFound)
                {
                    this.logService.LogInternal(
                        LogLevel.Critical,
                        new Exception(
                            $"Exception occurred while WCF Channel on endpoint {endpointAddress} was opening.",
                            e));
                    this.loggedEndpointNotFound = true;
                }
            }
            catch (Exception e) when (e is CommunicationException || e is InvalidOperationException)
            {
                this.logService.LogInternal(
                    LogLevel.Critical,
                    new Exception(
                        $"Exception occurred while WCF Channel on endpoint {endpointAddress} was opening.",
                        e));
            }
        }

        /// <summary>
        ///     Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
        }

        /// <summary>
        ///     Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="isDisposing">
        ///     <c> true </c> to release both managed and unmanaged resources; <c> false </c> to release only
        ///     unmanaged resources.
        /// </param>
        protected virtual void Dispose(bool isDisposing)
        {
            if (isDisposing && !this.IsDisposed)
            {
                this.timer.Dispose();
                this.client.Dispose();
                this.IsDisposed = true;
            }
        }

        /// <summary>
        ///     Logs the specified entry.
        /// </summary>
        /// <param name="entry"> The entry. </param>
        public void Log(LogEntry entry)
        {
            Validate.Value.IsNotDisposed(this, nameof(WcfLogger));
            Validate.Value.IsNotNull(entry, nameof(entry));
            this.entriesQueue.Enqueue(entry);
        }

        private void ProcessMessages(object state)
        {
            Validate.Value.IsNotDisposed(this, nameof(WcfLogger));

            var batch = new List<LogEntry>();

            while ((batch.Count < this.MaxBatchSize) && (this.entriesQueue.Count > 0))
            {
                LogEntry entry;
                if (this.entriesQueue.TryDequeue(out entry))
                {
                    batch.Add(entry);
                }
            }

            try
            {
                if (batch.Count == 1)
                {
                    this.client.Log(batch[0]);
                }
                else
                {
                    this.client.LogBatch(batch.ToArray());
                }
            }
            catch (EndpointNotFoundException e)
            {
                // Swallow the exception.
                // We only want to log EndpointNotFound exception once, so we don't spam 
                // messages everytime something is logged.
                if (!this.loggedEndpointNotFound)
                {
                    StringBuilder sb = new StringBuilder("An exception occurred while logging a message.");
                    for (int i = 0; i < batch.Count; i++)
                    {
                        if (i > 0)
                        {
                            sb.AppendLine();
                        }

                        sb.AppendFormat("\tSkipping logging of message {0}.", batch[i]);
                    }

                    this.logService.LogInternal(LogLevel.Critical, new Exception(sb.ToString(), e).ToString());
                    this.loggedEndpointNotFound = true;
                }
            }
            catch (Exception e) when (e is CommunicationException || e is InvalidOperationException)
            {
                // Swallow the exception.
                StringBuilder sb = new StringBuilder("An exception occurred while logging a message.");
                for (int i = 0; i < batch.Count; i++)
                {
                    if (i > 0)
                    {
                        sb.AppendLine();
                    }

                    sb.AppendFormat("\tSkipping logging of message {0}.", batch[i]);
                }

                this.logService.LogInternal(LogLevel.Critical, new Exception(sb.ToString(), e).ToString());
            }
        }
    }
}