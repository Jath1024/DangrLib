// -----------------------------------------------------------------------
//  <copyright file="CommandExecutionException.cs" company="DangerDan9631">
//      Copyright (c) 2017 Dan Garvey. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/Dangerdan9631/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.Command.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// Base Exception type for errors that occur while attempting to execute a command.
    /// </summary>
    /// <seealso cref="System.Exception" />
    [Serializable]
    public abstract class CommandExecutionException : Exception, ISerializable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CommandExecutionException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        protected CommandExecutionException(string message) : base(message)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandExecutionException"/> class.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo" /> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext" /> that contains contextual information about the source or destination.</param>
        protected CommandExecutionException(
            SerializationInfo info,
            StreamingContext context)
            : base(info, context)
        { }
    }
}