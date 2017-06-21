// -----------------------------------------------------------------------
//  <copyright file="MemoryLogger.cs" company="DangerDan9631">
//      Copyright (c) 2017 Dan Garvey. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/Dangerdan9631/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.Logging.Loggers
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    /// <summary>
    ///     Logger pipeline logger that will log entries to memory.
    /// </summary>
    public class MemoryLogger : ILogEndpoint, INotifyPropertyChanged
    {
        /// <summary>
        ///     The default maximum number of entries
        /// </summary>
        public const int DefaultMaxNumEntries = 5000;

        private readonly object entriesLock = new object();
        private readonly List<LogEntry> entries;
        private int maxNumEntries;

        /// <summary>
        ///     Gets the entries stored in memory.
        /// </summary>
        public IReadOnlyCollection<LogEntry> Entries
        {
            get
            {
                lock (this.entriesLock)
                {
                    return this.entries.ToArray();
                }
            }
        }

        /// <summary>
        ///     Gets or sets the maximum number entries.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"> MaxNumEntries;Value must be greater than 0 </exception>
        public int MaxNumEntries
        {
            get { return this.maxNumEntries; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(
                        nameof(MemoryLogger.MaxNumEntries),
                        value,
                        "Value must be greater than 0");
                }

                this.maxNumEntries = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        ///     Occurs when a property of this object is changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        ///     Initializes a new instance of the <see cref="MemoryLogger" /> class.
        /// </summary>
        public MemoryLogger()
        {
            lock (this.entriesLock)
            {
                this.entries = new List<LogEntry>();
            }

            this.MaxNumEntries = MemoryLogger.DefaultMaxNumEntries;
        }

        /// <summary>
        ///     Logs the specified entry.
        /// </summary>
        /// <param name="entry"> The entry. </param>
        public void Log(LogEntry entry)
        {
            lock (this.entriesLock)
            {
                this.entries.Add(entry);

                while (this.entries.Count > this.MaxNumEntries)
                {
                    this.entries.RemoveAt(0);
                }
            }

            // ReSharper disable once ExplicitCallerInfoArgument
            this.OnPropertyChanged(nameof(MemoryLogger.Entries));
        }

        /// <summary>
        ///     Called when [property changed].
        /// </summary>
        /// <param name="name"> The name. </param>
        protected void OnPropertyChanged([CallerMemberName] string name = "")
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}