// -----------------------------------------------------------------------
//  <copyright file="LogSourceExtensions.cs" company="DangerDan9631">
//      Copyright (c) 2017 Dan Garvey. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/Dangerdan9631/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.Logging
{
    /// <summary>
    /// Provides extended functionality for <see cref="ILogSource" /> objects.
    /// </summary>
    public static class LogSourceExtensions
    {
        /// <summary>
        /// Logs a <paramref name="message" /> used to display diagnostic information.
        /// </summary>
        /// <param name="logSource">
        /// The <see cref="ILogSource" /> used to log the message.
        /// </param>
        /// <param name="message">The message to log.</param>
        public static void LogDebug(this ILogSource logSource, object message)
        {
            logSource?.Logger?.Log(LogLevel.Debug, logSource.LogCategory, message);
        }

        /// <summary>
        /// Logs a <paramref name="message" /> used to display diagnostic information.
        /// </summary>
        /// <param name="logSource">
        /// The <see cref="ILogSource" /> used to log the message.
        /// </param>
        /// <param name="feature">
        /// The feature gating this <paramref name="message" /> logging.
        /// </param>
        /// <param name="message">The message to log.</param>
        public static void LogDebug(this ILogSource logSource, string feature, object message)
        {
            logSource?.Logger?.Log(LogLevel.Debug, feature, logSource.LogCategory, message);
        }

        /// <summary>
        /// Logs a <paramref name="message" /> used to display verbose information.
        /// </summary>
        /// <param name="logSource">
        /// The <see cref="ILogSource" /> used to log the message.
        /// </param>
        /// <param name="message">The message to log.</param>
        public static void LogVerbose(this ILogSource logSource, object message)
        {
            logSource?.Logger?.Log(LogLevel.Verbose, logSource.LogCategory, message);
        }

        /// <summary>
        /// Logs a <paramref name="message" /> used to display verbose information.
        /// </summary>
        /// <param name="logSource">
        /// The <see cref="ILogSource" /> used to log the message.
        /// </param>
        /// <param name="feature">
        /// The feature gating this <paramref name="message" /> logging.
        /// </param>
        /// <param name="message">The message to log.</param>
        public static void LogVerbose(this ILogSource logSource, string feature, object message)
        {
            logSource?.Logger?.Log(LogLevel.Verbose, feature, logSource.LogCategory, message);
        }

        /// <summary>
        /// Logs an informational message.
        /// </summary>
        /// <param name="logSource">
        /// The <see cref="ILogSource" /> used to log the message.
        /// </param>
        /// <param name="message">The message to log.</param>
        public static void LogInfo(this ILogSource logSource, object message)
        {
            logSource?.Logger?.Log(LogLevel.Info, logSource.LogCategory, message);
        }

        /// <summary>
        /// Logs an informational message.
        /// </summary>
        /// <param name="logSource">
        /// The <see cref="ILogSource" /> used to log the message.
        /// </param>
        /// <param name="feature">
        /// The feature gating this <paramref name="message" /> logging.
        /// </param>
        /// <param name="message">The message to log.</param>
        public static void LogInfo(this ILogSource logSource, string feature, object message)
        {
            logSource?.Logger?.Log(LogLevel.Info, feature, logSource.LogCategory, message);
        }

        /// <summary>
        /// Logs a <paramref name="message" /> used to display a status change of an object.
        /// </summary>
        /// <param name="logSource">
        /// The <see cref="ILogSource" /> used to log the message.
        /// </param>
        /// <param name="message">The message to log.</param>
        public static void LogStatus(this ILogSource logSource, object message)
        {
            logSource?.Logger?.Log(LogLevel.Status, logSource.LogCategory, message);
        }

        /// <summary>
        /// Logs a <paramref name="message" /> used to display a status change of an object.
        /// </summary>
        /// <param name="logSource">
        /// The <see cref="ILogSource" /> used to log the message.
        /// </param>
        /// <param name="feature">
        /// The feature gating this <paramref name="message" /> logging.
        /// </param>
        /// <param name="message">The message to log.</param>
        public static void LogStatus(this ILogSource logSource, string feature, object message)
        {
            logSource?.Logger?.Log(LogLevel.Status, feature, logSource.LogCategory, message);
        }

        /// <summary>
        /// Logs a warning.
        /// </summary>
        /// <param name="logSource">
        /// The <see cref="ILogSource" /> used to log the message.
        /// </param>
        /// <param name="message">The message to log.</param>
        public static void LogWarning(this ILogSource logSource, object message)
        {
            logSource?.Logger?.Log(LogLevel.Warning, logSource.LogCategory, message);
        }

        /// <summary>
        /// Logs a warning.
        /// </summary>
        /// <param name="logSource">
        /// The <see cref="ILogSource" /> used to log the message.
        /// </param>
        /// <param name="feature">
        /// The feature gating this <paramref name="message" /> logging.
        /// </param>
        /// <param name="message">The message to log.</param>
        public static void LogWarning(this ILogSource logSource, string feature, object message)
        {
            logSource?.Logger?.Log(LogLevel.Warning, feature, logSource.LogCategory, message);
        }

        /// <summary>
        /// Logs a <paramref name="message" /> that a critical, but recoverable, error has occurred.
        /// </summary>
        /// <param name="logSource">
        /// The <see cref="ILogSource" /> used to log the message.
        /// </param>
        /// <param name="message">The message to log.</param>
        public static void LogCritical(this ILogSource logSource, object message)
        {
            logSource?.Logger?.Log(LogLevel.Critical, logSource.LogCategory, message);
        }

        /// <summary>
        /// Logs a <paramref name="message" /> that a critical, but recoverable, error has occurred.
        /// </summary>
        /// <param name="logSource">
        /// The <see cref="ILogSource" /> used to log the message.
        /// </param>
        /// <param name="feature">
        /// The feature gating this <paramref name="message" /> logging.
        /// </param>
        /// <param name="message">The message to log.</param>
        public static void LogCritical(this ILogSource logSource, string feature, object message)
        {
            logSource?.Logger?.Log(LogLevel.Critical, feature, logSource.LogCategory, message);
        }

        /// <summary>
        /// Logs a <paramref name="message" /> that a fatal, non-recoverable, error has occurred.
        /// </summary>
        /// <param name="logSource">
        /// The <see cref="ILogSource" /> used to log the message.
        /// </param>
        /// <param name="message">The message to log.</param>
        public static void LogFatal(this ILogSource logSource, object message)
        {
            logSource?.Logger?.Log(LogLevel.Fatal, logSource.LogCategory, message);
        }

        /// <summary>
        /// Logs a <paramref name="message" /> that a fatal, non-recoverable, error has occurred.
        /// </summary>
        /// <param name="logSource">
        /// The <see cref="ILogSource" /> used to log the message.
        /// </param>
        /// <param name="feature">
        /// The feature gating this <paramref name="message" /> logging.
        /// </param>
        /// <param name="message">The message to log.</param>
        public static void LogFatal(this ILogSource logSource, string feature, object message)
        {
            logSource?.Logger?.Log(LogLevel.Fatal, feature, logSource.LogCategory, message);
        }
    }
}