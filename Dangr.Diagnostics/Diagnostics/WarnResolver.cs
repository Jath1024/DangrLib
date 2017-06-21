// -----------------------------------------------------------------------
//  <copyright file="WarnResolver.cs" company="DangerDan9631">
//      Copyright (c) 2017 Dan Garvey. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/Dangerdan9631/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.Diagnostics
{
    using System;
    using Dangr.Logging;

    /// <summary>
    /// Logs a warning if specific conditions are not met.
    /// </summary>
    internal class WarnResolver : AssertResolver
    {
        private static readonly string LogCategory = nameof(WarnResolver);

        /// <summary>
        /// Initializes a new instance of the <see cref="WarnResolver" /> class.
        /// </summary>
        internal WarnResolver()
            : base(false)
        { }

        /// <summary>
        /// Shows a <paramref name="message" /> and gets an exception that should be thrown.
        /// </summary>
        /// <param name="type">
        /// The type of assert condition that was evaluated.
        /// </param>
        /// <param name="message">The message that should be shown.</param>
        /// <param name="logSource">
        /// The <see cref="Dangr.Logging.ILogSource" /> used to log messages on failure.
        /// </param>
        /// <param name="ex">
        /// Out param for an exception that should be thrown or null.
        /// </param>
        /// <returns>True if the assert should be remembered.</returns>
        protected override bool Failed(AssertType type, string message, ILogSource logSource, out Exception ex)
        {
            if (logSource != null)
            {
                logSource.LogWarning(message);
            }
            else
            {
                Assert.DefaultLogger?.Log(LogLevel.Warning, WarnResolver.LogCategory, message);
            }

            ex = null;
            return false;
        }
    }
}