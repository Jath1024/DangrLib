// -----------------------------------------------------------------------
//  <copyright file="DebugAssertResolver.cs" company="DangerDan9631">
//      Copyright (c) 2017 Dan Garvey. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/Dangerdan9631/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.Diagnostics
{
    using System;
    using System.Diagnostics;
    using System.Windows.Forms;
    using Dangr.Logging;

    /// <summary>
    /// Shows a dialog if specific conditions are not met.
    /// </summary>
    internal class DebugAssertResolver : AssertResolver
    {
        private static readonly string LogCategory = nameof(DebugAssertResolver);

        /// <summary>
        /// Initializes a new instance of the <see cref="DebugAssertResolver" /> class.
        /// </summary>
        internal DebugAssertResolver()
            : base(true)
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
            DialogResult result = MessageBox.Show(
                message,
                "Assertion Failed",
                MessageBoxButtons.AbortRetryIgnore,
                MessageBoxIcon.Exclamation);

            switch (result)
            {
                case DialogResult.Abort:
                    this.LogFatal(logSource, message);
                    switch (type)
                    {
                        case AssertType.NotDisposed:
                            ex = new ObjectDisposedException(message);
                            break;
                        default:
                            ex = new AssertionFailedException(message);
                            break;
                    }

                    return false;

                case DialogResult.Retry:
                    this.LogWarning(logSource, message);
                    ex = null;
                    Debugger.Break();
                    return false;

                case DialogResult.Ignore:
                default:
                    this.LogWarning(logSource, message);
                    ex = null;
                    return true;
            }
        }

        private void LogFatal(ILogSource logSource, string message)
        {
            if (logSource != null)
            {
                logSource.LogFatal(message);
            }
            else
            {
                Assert.DefaultLogger?.Log(LogLevel.Fatal, DebugAssertResolver.LogCategory, message);
            }
        }

        private void LogWarning(ILogSource logSource, string message)
        {
            if (logSource != null)
            {
                logSource.LogWarning(message);
            }
            else
            {
                Assert.DefaultLogger?.Log(LogLevel.Warning, DebugAssertResolver.LogCategory, message);
            }
        }
    }
}