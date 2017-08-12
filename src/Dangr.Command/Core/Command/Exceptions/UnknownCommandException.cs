// -----------------------------------------------------------------------
//  <copyright file="UnknownCommandException.cs" company="Phoenix Game Studios, LLC">
//      Copyright (c) 2017 Phoenix Game Studios, LLC. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/PhoenixGameStudios/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------
namespace Dangr.Core.Command.Exceptions
{
    using System;
    using System.Runtime.Serialization;
    using System.Security.Permissions;

    /// <summary>
    /// The Exception that is thrown when attempting to execute an unknown command.
    /// </summary>
    /// <seealso cref="System.Exception" />
    [Serializable]
    public class UnknownCommandException : CommandExecutionException
    {
        /// <summary>
        /// Gets the name of the unknown command.
        /// </summary>
        public string CommandName { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnknownCommandException"/> class.
        /// </summary>
        /// <param name="commandName">The name of the unknown command. </param>
        /// <param name="message">The message that describes the error.</param>
        public UnknownCommandException(string commandName, string message)
            : base(message)
        {
            this.CommandName = commandName;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnknownCommandException"/> class.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo" /> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext" /> that contains contextual information about the source or destination.</param>
        protected UnknownCommandException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
            this.CommandName = (string) info.GetValue(nameof(this.CommandName), typeof(string));
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
            info.AddValue(nameof(this.CommandName), this.CommandName);

            base.GetObjectData(info, context);
        }
    }
}