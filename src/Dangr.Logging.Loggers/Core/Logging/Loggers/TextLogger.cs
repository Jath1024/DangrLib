// -----------------------------------------------------------------------
//  <copyright file="TextLogger.cs" company="Phoenix Game Studios, LLC">
//      Copyright (c) 2017 Phoenix Game Studios, LLC. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/PhoenixGameStudios/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------
namespace Dangr.Core.Logging.Loggers
{
    using System;
    using System.IO;
    using System.Reflection;
    using Dangr.Core.Diagnostics;
    using Dangr.Core.Logging;
    using Dangr.Core.Util;

    /// <summary>
    ///     A logger pipeline logger that will log entries to a text file.
    /// </summary>
    public class TextLogger : ILogEndpoint, ICheckedDisposable
    {
        /// <summary>
        ///     The default log file date format.
        /// </summary>
        public const string DefaultLogFileDateFormat = @"yyMMdd-HHmm";

        /// <summary>
        ///     The default maximum log file size in bytes.
        /// </summary>
        public const long DefaultMaxLogFileSize = 0x100000; // 1 MB

        /// <summary>
        ///     The default log file flush size in bytes.
        /// </summary>
        public const long DefaultLogFileFlushSize = 0x20000; // 128 KB

        /// <summary>
        ///     The default maximum log file entries.
        /// </summary>
        public const int DefaultMaxLogFileEntries = 1000000;

        /// <summary>
        ///     The default maximum log file interval.
        /// </summary>
        public static readonly TimeSpan DefaultMaxLogFileInterval = TimeSpan.FromDays(7);

        private StreamWriter writer;
        private int logCounter;
        private long lastFlushSize;

        /// <summary>
        ///     Gets the file that this <see cref="TextLogger" /> is logging to.
        /// </summary>
        public FileInfo LogFile { get; private set; }

        /// <summary>
        ///     Gets the log file directory.
        /// </summary>
        public string LogFileDirectory { get; }

        /// <summary>
        ///     Gets the log file prefix.
        /// </summary>
        public string LogFilePrefix { get; }

        /// <summary>
        ///     Gets the log file date format.
        /// </summary>
        public string LogFileDateFormat { get; }

        /// <summary>
        ///     Gets or sets the maximum size of the log file before creating a new file.
        /// </summary>
        public long MaxLogFileSize { get; set; }

        /// <summary>
        ///     Gets or sets the maximum size of the log file before changes are flushed to disk.
        /// </summary>
        public long MaxLogFileFlushSize { get; set; }

        /// <summary>
        ///     Gets or sets the maximum interval that can pass before creating a new log file.
        /// </summary>
        public TimeSpan MaxLogFileInterval { get; set; }

        /// <summary>
        ///     Gets or sets the maximum number of log file entries in a single log file.
        /// </summary>
        public int MaxLogFileEntries { get; set; }

        /// <summary>
        ///     Gets a value indicating whether this object is disposed.
        /// </summary>
        public bool IsDisposed { get; private set; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="TextLogger" /> class.
        /// </summary>
        /// <param name="logFileDirectory"> The log file directory. </param>
        /// <param name="logFilePrefix"> The log file prefix. </param>
        /// <param name="logFileDateFormat"> The log file date format. </param>
        public TextLogger(string logFileDirectory = null, string logFilePrefix = null, string logFileDateFormat = null)
        {
            this.LogFileDirectory = logFileDirectory;
            if (string.IsNullOrWhiteSpace(this.LogFileDirectory))
            {
                this.LogFileDirectory = Path.GetDirectoryName(Directory.GetCurrentDirectory());
            }

            if (this.LogFileDirectory == null)
            {
                throw new ArgumentNullException();
            }

            if (!Directory.Exists(this.LogFileDirectory))
            {
                Directory.CreateDirectory(this.LogFileDirectory);
            }

            this.LogFilePrefix = logFilePrefix ?? string.Empty;
            this.LogFileDateFormat = logFileDateFormat ?? TextLogger.DefaultLogFileDateFormat;

            this.LogFile = this.GetNewLogFile();
            this.logCounter = 0;
            this.MaxLogFileSize = TextLogger.DefaultMaxLogFileSize;
            this.MaxLogFileFlushSize = TextLogger.DefaultLogFileFlushSize;
            this.MaxLogFileInterval = TextLogger.DefaultMaxLogFileInterval;
            this.MaxLogFileEntries = TextLogger.DefaultMaxLogFileEntries;

            this.writer = new StreamWriter(this.LogFile.FullName, append: true);
            this.lastFlushSize = this.writer.BaseStream.Length;
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
                this.writer.Dispose();
                this.IsDisposed = true;
            }
        }

        /// <summary>
        ///     Logs the specified entry.
        /// </summary>
        /// <param name="entry"> The entry. </param>
        public void Log(LogEntry entry)
        {
            Assert.Validate.NotDisposed(this, nameof(TextLogger));

            this.writer.WriteLine(entry.ToString());

            if ((this.writer.BaseStream.Length > this.MaxLogFileSize)
                || (DateTime.UtcNow - this.LogFile.CreationTimeUtc > this.MaxLogFileInterval)
                || (++this.logCounter > this.MaxLogFileEntries))
            {
                this.writer.Close();
                this.LogFile = this.GetNewLogFile();
                this.logCounter = 0;
                this.writer = new StreamWriter(this.LogFile.FullName, append: true);
                this.lastFlushSize = this.writer.BaseStream.Length;
            }
            else
            {
                long baseStreamLength = this.writer.BaseStream.Length;
                if (baseStreamLength - this.lastFlushSize > this.MaxLogFileFlushSize)
                {
                    this.writer.Flush();
                    this.lastFlushSize = baseStreamLength;
                }
            }
        }

        private FileInfo GetNewLogFile()
        {
            string dateString = DateTimeOffset.Now.ToString(this.LogFileDateFormat);
            string logFileName = $"{this.LogFilePrefix}{dateString}.log";

            string fileName = Path.Combine(this.LogFileDirectory, logFileName);

            int counter = 1;
            while (File.Exists(fileName))
            {
                string newLogFileName = $"{this.LogFilePrefix}{dateString}.{counter++}.log";
                fileName = Path.Combine(this.LogFileDirectory, newLogFileName);
            }

            return new FileInfo(fileName);
        }
    }
}