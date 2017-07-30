// -----------------------------------------------------------------------
//  <copyright file="ValidationFailedException.cs" company="DangerDan9631">
//      Copyright (c) 2017 Dan Garvey. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/Dangerdan9631/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.Core.Diagnostics
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// Exception that is thrown when a Validation is failed.
    /// </summary>
    [Serializable]
    public class ValidationFailedException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationFailedException" /> .
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public ValidationFailedException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationFailedException" /> .
        /// </summary>
        /// <param name="info">
        /// The System.Runtime.Serialization.SerializationInfo that holds the serialized object data about the exception being thrown.
        /// </param>
        /// <param name="context">
        /// The System.Runtime.Serialization.StreamingContext that contains contextual information about the source or destination.
        /// </param>
        protected ValidationFailedException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}