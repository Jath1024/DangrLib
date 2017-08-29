// -----------------------------------------------------------------------
//  <copyright file="Validate.cs" company="Phoenix Game Studios, LLC">
//      Copyright (c) 2017 Phoenix Game Studios, LLC. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/PhoenixGameStudios/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.Core.Diagnostics
{
    using Dangr.Internal.Diagnostics;

    /// <summary>
    /// Contains build dependent <see cref="AssertResolver" />s for various scenarios.
    /// </summary>
    public static class Validate
    {
        /// <summary>
        /// Throws an argument exception if specific conditions are not met.
        /// </summary>
        public static IConditionChecker Argument { get; } = new ArgumentResolver();

        /// <summary>
        /// Throws an exception if specific conditions are not met.
        /// </summary>
        public static IConditionChecker Value { get; } = new ValidateResolver();

        /// <summary>
        /// Shows a dialog if specific conditions are not met. Does nothing in release builds.
        /// </summary>
        public static IConditionChecker Debug { get; } =
#if DEBUG
            new DebugAssertResolver();
#else
            new NoopResolver();
#endif
    }
}