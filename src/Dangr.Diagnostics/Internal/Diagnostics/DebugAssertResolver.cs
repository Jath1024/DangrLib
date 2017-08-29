// -----------------------------------------------------------------------
//  <copyright file="DebugAssertResolver.cs" company="Phoenix Game Studios, LLC">
//      Copyright (c) 2017 Phoenix Game Studios, LLC. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/PhoenixGameStudios/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.Internal.Diagnostics
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Windows.Forms;
    using Dangr.Core.Diagnostics;

    /// <summary>
    /// Shows a dialog if specific conditions are not met.
    /// </summary>
    internal class DebugAssertResolver : AssertResolver
    {
        private readonly HashSet<string> ignoredAssertions = new HashSet<string>();

        // Visible for testing.
        internal bool ShouldForceDialogResult { get; set; }

        // Visible for testing.
        internal DialogResult ForcedDialogResult { get; set; } = DialogResult.Ignore;

        /// <summary>
        /// Shows a message and gets an exception that should be thrown.
        /// </summary>
        /// <param name="type">The type of assert condition that was evaluated.</param>
        /// <param name="message">The message that should be shown.</param>
        /// <returns>
        /// The exception that should be thrown, or null.
        /// </returns>
        protected override Exception Failed(AssertType type, string message)
        {
            StackFrame frame = new StackFrame(3, true);
            string frameKey = frame.ToString();

            DialogResult result = DialogResult.Ignore;
            if (!this.ignoredAssertions.Contains(frameKey))
            {
                result = this.ShouldForceDialogResult
                    ? this.ForcedDialogResult
                    : MessageBox.Show(
                        message,
                        "Assertion Failed",
                        MessageBoxButtons.AbortRetryIgnore,
                        MessageBoxIcon.Exclamation);
            }

            switch (result)
            {
                case DialogResult.Abort:
                    switch (type)
                    {
                        case AssertType.NotDisposed:
                            return new ObjectDisposedException(message);
                        default:
                            return new AssertionFailedException(message);
                    }

                case DialogResult.Retry:
                    Debugger.Break();
                    return null;

                case DialogResult.Ignore:
                    this.ignoredAssertions.Add(frameKey);
                    return null;

                default:
                    return null;
            }
        }
    }
}