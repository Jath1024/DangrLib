// -----------------------------------------------------------------------
//  <copyright file="LogService.cs" company="DangerDan9631">
//      Copyright (c) 2017 Dan Garvey. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/Dangerdan9631/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.Logging
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using JetBrains.Annotations;

    /// <summary>
    ///     Service that logs messages at various levels using different logging
    ///     endpoints.
    /// </summary>
    public class LogService : ILogService
    {
        private readonly Task processTask;
        private readonly CancellationTokenSource processTaskCancellationTokenSource;

        private readonly ConcurrentQueue<LogEntry> entriesQueue;
        private readonly ISet<string> features;

        /// <summary>
        ///     Gets the logger used when logging from this source.
        /// </summary>
        public ILogger Logger => this;

        /// <summary>
        ///     Gets the log category of this <see cref="ILogSource" /> used when logging.
        /// </summary>
        public string LogCategory { get; } = nameof(LogService);

        /// <summary>
        ///     Gets a value indicating whether this object is disposed.
        /// </summary>
        public bool IsDisposed { get; private set; }

        /// <summary>
        ///     Occurs when the <see cref="LogService" /> is started.
        /// </summary>
        public event EventHandler Started;

        /// <summary>
        ///     Occurs when the <see cref="LogService" /> receives a shut down signal.
        /// </summary>
        public event EventHandler ShuttingDown;

        /// <summary>
        ///     Occurs when the <see cref="LogService" /> has finished shutting down.
        /// </summary>
        public event EventHandler ShutDown;

        private event Action<LogEntry> LogMessage;
        private event Action<LogEntry> LogInternalMessage;

        /// <summary>
        ///     Initializes a new instance of the <see cref="LogService" /> class.
        /// </summary>
        public LogService()
        {
            this.processTaskCancellationTokenSource = new CancellationTokenSource();
            this.processTask = Task.Factory.StartNew(
                this.ProcessLogs,
                this.processTaskCancellationTokenSource.Token,
                TaskCreationOptions.LongRunning,
                TaskScheduler.Current);

            this.entriesQueue = new ConcurrentQueue<LogEntry>();
            this.features = new HashSet<string>();
        }

        /// <summary>
        ///     Finalizes an instance of the <see cref="LogService" /> class.
        /// </summary>
        ~LogService()
        {
            this.Dispose(false);
        }

        /// <summary>
        ///     Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
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
                if (!this.processTaskCancellationTokenSource.IsCancellationRequested)
                {
                    this.processTaskCancellationTokenSource.Cancel();
                    this.processTaskCancellationTokenSource.Dispose();
                }

                this.IsDisposed = true;
            }
        }

        /// <summary>
        ///     Signals the <see cref="LogService" /> a signal to start shutting down, and waits for completion.
        /// </summary>
        public void SignalShutDown()
        {
            this.SignalShutDown(TimeSpan.FromMilliseconds(-1));
        }

        /// <summary>
        ///     Signals the <see cref="LogService" /> a signal to start shutting down, and waits the specified time for completion.
        /// </summary>
        /// <param name="timeout"> The time to wait for completion. (Use -1 milliseconds to wait indefinitely.) </param>
        public void SignalShutDown(TimeSpan timeout)
        {
            if (!this.processTask.IsCompleted)
            {
                if (!this.processTaskCancellationTokenSource.IsCancellationRequested)
                {
                    this.OnShuttingDown();
                    this.processTaskCancellationTokenSource.Cancel();
                }

                this.processTask.Wait(timeout);
            }
        }

        /// <summary>
        ///     Add a feature to be logged.
        /// </summary>
        /// <param name="feature"> The feature. </param>
        /// <returns> A reference to this <see cref="LogService" />. </returns>
        public LogService AddFeature([NotNull] string feature)
        {
            this.features.Add(feature);
            return this;
        }

        /// <summary>
        ///     Removes a feature from being logged.
        /// </summary>
        /// <param name="feature"> The feature. </param>
        /// <returns> A reference to this <see cref="LogService" />. </returns>
        public LogService RemoveFeature([NotNull] string feature)
        {
            this.features.Remove(feature);
            return this;
        }

        /// <summary>
        ///     Registers an <see cref="ILogEndpoint" /> to receive log events from this <see cref="LogService" />.
        /// </summary>
        /// <param name="endpoint"> The <see cref="ILogEndpoint" />. </param>
        public void RegisterEndpoint([NotNull] ILogEndpoint endpoint)
        {
            this.LogMessage += endpoint.Log;
        }

        /// <summary>
        ///     Stops a registered <see cref="ILogEndpoint" /> from receiving log events from this <see cref="LogService" />.
        /// </summary>
        /// <param name="endpoint"> The <see cref="ILogEndpoint" />. </param>
        public void UnregisterEndpoint([NotNull] ILogEndpoint endpoint)
        {
            this.LogMessage -= endpoint.Log;
        }

        /// <summary>
        ///     Registers an <see cref="ILogEndpoint" /> to receive internal log events from this <see cref="LogService" />.
        /// </summary>
        /// <param name="endpoint"> The <see cref="ILogEndpoint" />. </param>
        public void RegisterInternalEndpoint([NotNull] ILogEndpoint endpoint)
        {
            this.LogInternalMessage += endpoint.Log;
        }

        /// <summary>
        ///     Stops a registered <see cref="ILogEndpoint" /> from receiving internal log events from this
        ///     <see cref="LogService" />.
        /// </summary>
        /// <param name="endpoint"> The <see cref="ILogEndpoint" />. </param>
        public void UnregisterInternalEndpoint([NotNull] ILogEndpoint endpoint)
        {
            this.LogInternalMessage -= endpoint.Log;
        }

        /// <summary>
        ///     Logs a message at the specified level.
        /// </summary>
        /// <param name="level"> The <see cref="Dangr.Logging.LogLevel" />. </param>
        /// <param name="message"> The message. </param>
        public void Log(LogLevel level, [NotNull] object message)
        {
            LogEntry entry = new LogEntry(level, string.Empty, message);
            this.LogEntry(entry);
        }

        /// <summary>
        ///     Logs a message at the specified level.
        /// </summary>
        /// <param name="level"> The <see cref="Dangr.Logging.LogLevel" />. </param>
        /// <param name="category"> The category. </param>
        /// <param name="message"> The message. </param>
        public void Log(LogLevel level, [NotNull] string category, [NotNull] object message)
        {
            LogEntry entry = new LogEntry(level, category, message);
            this.LogEntry(entry);
        }

        /// <summary>
        ///     Logs a message at the specified level.
        /// </summary>
        /// <param name="level"> The <see cref="Dangr.Logging.LogLevel" />. </param>
        /// <param name="feature"> The feature gating this message logging. </param>
        /// <param name="category"> The category. </param>
        /// <param name="message"> The message. </param>
        public void Log(LogLevel level, [NotNull] string feature, [NotNull] string category, [NotNull] object message)
        {
            if (this.features.Contains(feature))
            {
                LogEntry entry = new LogEntry(level, category, message);
                this.LogEntry(entry);
            }
        }

        /// <summary>
        ///     Logs a message internal to the <see cref="LogService" />.
        /// </summary>
        /// <param name="level"> The <see cref="Dangr.Logging.LogLevel" />. </param>
        /// <param name="message"> The message. </param>
        public void LogInternal(LogLevel level, [NotNull] object message)
        {
            this.OnLogInternalMessage(new LogEntry(level, this.LogCategory, message));
        }

        /// <summary>
        ///     Logs an entry to the <see cref="LogService" />.
        /// </summary>
        /// <param name="entry"> The message. </param>
        public void LogEntry([NotNull] LogEntry entry)
        {
            this.entriesQueue.Enqueue(entry);
        }

        private void ProcessLogs()
        {
            this.OnStarted();
            CancellationToken cancellationToken = this.processTaskCancellationTokenSource.Token;

            while (!cancellationToken.IsCancellationRequested || (this.entriesQueue.Count > 0))
            {
                LogEntry logEntry;
                if (this.entriesQueue.TryDequeue(out logEntry))
                {
                    try
                    {
                        this.OnLogMessage(logEntry);
                    }
                    catch (Exception e)
                    {
                        this.LogInternal(LogLevel.Critical, e.ToString());
                    }
                }
                else
                {
                    Thread.Sleep(TimeSpan.FromMilliseconds(100));
                }
            }

            this.OnShutDown();
        }

        private void OnStarted()
        {
            this.Started?.Invoke(this, EventArgs.Empty);
        }

        private void OnShuttingDown()
        {
            this.ShuttingDown?.Invoke(this, EventArgs.Empty);
        }

        private void OnShutDown()
        {
            this.ShutDown?.Invoke(this, EventArgs.Empty);
        }

        private void OnLogMessage(LogEntry message)
        {
            this.LogMessage?.Invoke(message);
        }

        private void OnLogInternalMessage(LogEntry message)
        {
            this.LogInternalMessage?.Invoke(message);
        }
    }
}