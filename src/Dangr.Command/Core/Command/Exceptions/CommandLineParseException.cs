// -----------------------------------------------------------------------
//  <copyright file="CommandLineParseException.cs" company="DangerDan9631">
//      Copyright (c) 2017 Dan Garvey. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/Dangerdan9631/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.Core.Command.Exceptions
{
    using System;
    using System.Runtime.Serialization;
    using System.Security.Permissions;

    /// <summary>
    /// Exception that occurrs when there is an error parsing a <see cref="Core.CommandLine"/>.
    /// </summary>
    /// <seealso cref="System.Exception" />
    [Serializable]
    public class CommandLineParseException : CommandExecutionException
    {
        /// <summary>
        /// Gets the position in the command line that the exception occurred.
        /// </summary>
        public int Position { get; }

        /// <summary>
        /// Gets the command line that was parsed when this exception was thrown.
        /// </summary>
        public string CommandLine { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandLineParseException"/> class.
        /// </summary>
        /// <param name="position">The position in the command line that the exception occurred.</param>
        /// <param name="commandLine">The command line that was parsed when this exception was thrown.</param>
        /// <param name="message">A message that describes the current exception.</param>
        public CommandLineParseException(int position, string commandLine, string message)
            : base(message)
        {
            this.Position = position;
            this.CommandLine = commandLine;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandLineParseException"/> class.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo" /> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext" /> that contains contextual information about the source or destination.</param>
        protected CommandLineParseException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            this.Position = (int) info.GetValue(nameof(this.Position), typeof(int));
            this.CommandLine = (string) info.GetValue(nameof(this.CommandLine), typeof(string));
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
            info.AddValue(nameof(this.Position), this.Position);
            info.AddValue(nameof(this.CommandLine), this.CommandLine);

            base.GetObjectData(info, context);
        }
    }
}