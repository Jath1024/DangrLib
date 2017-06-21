// -----------------------------------------------------------------------
//  <copyright file="ILogger.cs" company="DangerDan9631">
//      Copyright (c) 2017 Dan Garvey. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/Dangerdan9631/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.Logging
{
    /// <summary>
    /// Provides methods for logging categorized messages at varying 
    /// <see cref="LogLevel" /> s.
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Logs a <paramref name="message" /> at the specified level.
        /// </summary>
        /// <param name="level">The <see cref="LogLevel" /> .</param>
        /// <param name="message">The message.</param>
        void Log(LogLevel level, object message);

        /// <summary>
        /// Logs a <paramref name="message" /> at the specified level.
        /// </summary>
        /// <param name="level">The <see cref="LogLevel" /> .</param>
        /// <param name="category">The category.</param>
        /// <param name="message">The message.</param>
        void Log(LogLevel level, string category, object message);

        /// <summary>
        /// Logs a <paramref name="message" /> at the specified level.
        /// </summary>
        /// <param name="level">The <see cref="LogLevel" /> .</param>
        /// <param name="feature">
        /// The feature gating this <paramref name="message" /> logging.
        /// </param>
        /// <param name="category">The category.</param>
        /// <param name="message">The message.</param>
        void Log(LogLevel level, string feature, string category, object message);
    }
}