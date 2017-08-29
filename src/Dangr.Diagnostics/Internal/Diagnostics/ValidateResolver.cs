// -----------------------------------------------------------------------
//  <copyright file="ValidateResolver.cs" company="Phoenix Game Studios, LLC">
//      Copyright (c) 2017 Phoenix Game Studios, LLC. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/PhoenixGameStudios/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.Internal.Diagnostics
{
    using System;
    using Dangr.Core.Diagnostics;

    /// <summary>
    /// Throws an exception if specific conditions are not met.
    /// </summary>
    internal class ValidateResolver : AssertResolver
    {
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
            switch (type)
            {
                case AssertType.NotDisposed:
                    return new ObjectDisposedException(message);
                default:
                    return new ValidationFailedException(message);
            }
        }
    }
}