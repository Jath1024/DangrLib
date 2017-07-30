// -----------------------------------------------------------------------
//  <copyright file="Assert.cs" company="DangerDan9631">
//      Copyright (c) 2017 Dan Garvey. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/Dangerdan9631/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.Core.Diagnostics
{
    using Dangr.Core.Logging;
    using Dangr.Internal.Diagnostics;

    /// <summary>
    /// Contains build dependent <see cref="AssertResolver" /> s for various
    /// scenarios.
    /// </summary>
    public static class Assert
    {
        /// <summary>
        /// <see cref="ILogger" /> to use when no log source is passed in to an <see cref="AssertResolver" /> .
        /// </summary>
        public static ILogger DefaultLogger { get; set; }

        /// <summary>
        /// Throws an exception if specific conditions are not met.
        /// </summary>
        public static AssertResolver Validate { get; } = new ValidateResolver();

        /// <summary>
        /// Shows a dialog if specific conditions are not met. Same as <see cref="Assert.Warn" /> in release builds.
        /// </summary>
        public static AssertResolver Debug { get; } =
#if DEBUG
            new DebugAssertResolver();
#else
            new WarnResolver();
#endif

        /// <summary>
        /// Logs a warning if specific conditions are not met.
        /// </summary>
        public static AssertResolver Warn { get; } = new WarnResolver();
    }
}