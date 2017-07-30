// -----------------------------------------------------------------------
//  <copyright file="LogEntry.cs" company="DangerDan9631">
//      Copyright (c) 2017 Dan Garvey. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/Dangerdan9631/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.Core.Logging
{
    using System;
    using System.Runtime.Serialization;
    using Dangr.Core.Util;

    /// <summary>
    ///     An entry in a log.
    /// </summary>
    [DataContract(Namespace = "http://Dangr/Logging/2015/10")]
    public sealed class LogEntry
    {
        /// <summary>
        ///     The default timestamp format to use when logging.
        /// </summary>
        public const string DefaultTimeStampFormat = "yy.MM.dd HH:mm:ss.fffff";

        /// <summary>
        ///     The default log format to use when logging.
        /// </summary>
        public const string DefaultLogFormat = "[{0}]:{1}:{2}:{3}";

        private static readonly IdCounter IdCounter = new IdCounter(0, IdCounter.Range.Max);

        /// <summary>
        ///     Gets the unique Id for this <see cref="LogEntry" />.
        /// </summary>
        [DataMember(Order = 1, IsRequired = true)]
        public ulong Id { get; private set; }

        /// <summary>
        ///     Gets the timestamp when this <see cref="LogEntry" /> was created.
        /// </summary>
        [DataMember(Order = 2, IsRequired = true)]
        public DateTimeOffset TimeStamp { get; private set; }

        /// <summary>
        ///     Gets the <see cref="LogLevel" /> used to log this <see cref="LogEntry" />.
        /// </summary>
        [DataMember(Order = 3, IsRequired = true)]
        public LogLevel LogLevel { get; private set; }

        /// <summary>
        ///     Gets the log category for this <see cref="LogEntry" />.
        /// </summary>
        [DataMember(Order = 4, IsRequired = true)]
        public string Category { get; private set; }

        /// <summary>
        ///     Gets the Message that was logged.
        /// </summary>
        [DataMember(Order = 5, IsRequired = true)]
        public object Message { get; private set; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="LogEntry" /> class.
        /// </summary>
        /// <param name="logLevel"> The <see cref="LogLevel" />. </param>
        /// <param name="category"> The category. </param>
        /// <param name="message"> The message. </param>
        public LogEntry(LogLevel logLevel, string category, object message)
        {
            this.Initialize(LogEntry.IdCounter.GetId(), DateTime.Now, logLevel, category, message);
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="LogEntry" /> class.
        /// </summary>
        /// <param name="other"> The other <see cref="LogEntry" /> to copy. </param>
        /// <exception cref="System.ArgumentNullException"> </exception>
        public LogEntry(LogEntry other)
        {
            if (other == null)
            {
                throw new ArgumentNullException(nameof(other));
            }

            this.Initialize(LogEntry.IdCounter.GetId(), other.TimeStamp, other.LogLevel, other.Category, other.Message);
        }

        private void Initialize(ulong id, DateTimeOffset timeStamp, LogLevel logLevel, string category, object message)
        {
            this.Id = id;
            this.TimeStamp = timeStamp;
            this.LogLevel = logLevel;
            this.Category = category;
            this.Message = message;
        }

        /// <summary>
        ///     Returns a string that represents the current object.
        /// </summary>
        /// <returns> A string that represents the current object. </returns>
        public override string ToString()
        {
            return this.ToString(LogEntry.DefaultLogFormat);
        }

        /// <summary>
        ///     Returns a string that represents the current <see cref="LogEntry" /> in the specified format.
        /// </summary>
        /// <param name="logFormat"> The format to use to log the <see cref="LogEntry" />. </param>
        /// <param name="timeStampFormat"> The format to use for the <see cref="LogEntry" /> timestamp. </param>
        /// <returns> </returns>
        public string ToString(string logFormat, string timeStampFormat = LogEntry.DefaultTimeStampFormat)
        {
            return string.Format(
                logFormat,
                this.TimeStamp.ToString(timeStampFormat),
                this.LogLevel,
                this.Category,
                this.Message);
        }
    }
}