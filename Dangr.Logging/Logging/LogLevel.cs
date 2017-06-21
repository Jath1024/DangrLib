// -----------------------------------------------------------------------
//  <copyright file="LogLevel.cs" company="DangerDan9631">
//      Copyright (c) 2017 Dan Garvey. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/Dangerdan9631/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.Logging
{
    /// <summary>
    /// Defines the possible log levels.
    /// </summary>
    public enum LogLevel
    {
        /// <summary>
        /// Logs a debug message.
        /// </summary>
        Debug,

        /// <summary>
        /// Logs a status change.
        /// </summary>
        Status,

        /// <summary>
        /// Logs a message with detailed information.
        /// </summary>
        Verbose,

        /// <summary>
        /// Logs a message with standard information.
        /// </summary>
        Info,

        /// <summary>
        /// Logs a warning message.
        /// </summary>
        Warning,

        /// <summary>
        /// Logs a non-fatal error.
        /// </summary>
        Critical,

        /// <summary>
        /// Logs a fatal error.
        /// </summary>
        Fatal
    }
}