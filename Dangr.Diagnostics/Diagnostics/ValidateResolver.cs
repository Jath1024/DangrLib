// -----------------------------------------------------------------------
//  <copyright file="ValidateResolver.cs" company="DangerDan9631">
//      Copyright (c) 2017 Dan Garvey. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/Dangerdan9631/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
//  <dateCreated>2017-04-24</dateCreated>
//  <dateModified>2017-06-20</dateModified>
//  <lastModifiedBy>Dan Garvey</lastModifiedBy>
// -----------------------------------------------------------------------

namespace Dangr.Diagnostics
{
    using System;
    using Dangr.Logging;

    /// <summary>
    /// Throws an exception if specific conditions are not met.
    /// </summary>
    public class ValidateResolver : AssertResolver
    {
        private static readonly string LogCategory = nameof(ValidateResolver);

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidateResolver" /> class.
        /// </summary>
        public ValidateResolver()
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