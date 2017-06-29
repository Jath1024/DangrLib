// -----------------------------------------------------------------------
//  <copyright file="MissingCommandArgumentException.cs" company="DangerDan9631">
//      Copyright (c) 2017 Dan Garvey. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/Dangerdan9631/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.Command.Exceptions
{
    using System;
    using System.Runtime.Serialization;
    using System.Security.Permissions;

    /// <summary>
    /// The Exception that is thrown when a mandatory argument is not specified when attempting to execute a command.
    /// </summary>
    /// <seealso cref="System.Exception" />
    [Serializable]
    public class MissingCommandArgumentException : Exception
    {
        /// <summary>
        /// Gets the name of the missing mandatory argument.
        /// </summary>
        public string ArgumentName { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MissingCommandArgumentException"/> class.
        /// </summary>
        /// <param name="argumentName">Name of the missing mandatory argument.</param>
        /// <param name="message">The message.</param>
        public MissingCommandArgumentException(string argumentName, string message) : base(message)
        {
            this.ArgumentName = argumentName;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MissingCommandArgumentException"/> class.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo" /> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext" /> that contains contextual information about the source or destination.</param>
        protected MissingCommandArgumentException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
            this.ArgumentName = (string) info.GetValue(nameof(this.ArgumentName), typeof(string));
        }

        /// <summary>
        /// When overridden in a derived class, sets the <see cref="T:System.Runtime.Serialization.SerializationInfo" /> with information about the exception.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo" /> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext" /> that contains contextual information about the source or destination.</param>
        /// <PermissionSet>
        ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Read="*AllFiles*" PathDiscovery="*AllFiles*" />
        ///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="SerializationFormatter" />
        /// </PermissionSet>
        [SecurityPermission(
             SecurityAction.LinkDemand,
             Flags = SecurityPermissionFlag.SerializationFormatter)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(nameof(this.ArgumentName), this.ArgumentName);

            base.GetObjectData(info, context);
        }
    }
}