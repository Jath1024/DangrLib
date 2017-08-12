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
    using Dangr.Core.Logging;

    /// <summary>
    /// Throws an exception if specific conditions are not met.
    /// </summary>
    internal class ValidateResolver : AssertResolver
    {
        private static readonly string LogCategory = nameof(ValidateResolver);

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidateResolver" /> class.
        /// </summary>
        public ValidateResolver()
            : base(false)
        {
        }

        /// <summary>
        /// Shows a <paramref name="message" /> and gets an exception that should be thrown.
        /// </summary>
        /// <param name="type">
        /// The type of assert condition that was evaluated.
        /// </param>
        /// <param name="message">The message that should be shown.</param>
        /// <param name="logSource">
        /// The <see cref="ILogSource" /> used to log messages on failure.
        /// </param>
        /// <param name="ex">
        /// Out param for an exception that should be thrown or null.
        /// </param>
        /// <returns>True if the assert should be remembered.</returns>
        protected override bool Failed(AssertType type, string message, ILogSource logSource, out Exception ex)
        {
            if (logSource != null)
            {
                logSource.LogFatal(message);
            }
            else
            {
                Assert.DefaultLogger?.Log(LogLevel.Fatal, ValidateResolver.LogCategory, message);
            }

            switch (type)
            {
                case AssertType.NotDisposed:
                    ex = new ObjectDisposedException(message);
                    break;
                default:
                    ex = new ValidationFailedException(message);
                    break;
            }

            return false;
        }
    }
}