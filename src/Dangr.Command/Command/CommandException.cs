namespace Dangr.Command
{
    using System;
    using System.Runtime.Serialization;
    using Dangr.Error;

    /// <summary>
    /// Exception that is thrown when parsing or executing commands.
    /// </summary>
    [Serializable]
    public class CommandException : Exception, IDangrException
    {
        /// <summary>
        /// Gets the <see cref="ErrorCode" /> for the error that caused this <see cref="IDangrException" />.
        /// </summary>
        public ErrorCode ErrorCode { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandException"/> class.
        /// </summary>
        /// <param name="errorCode">The <see cref="CommandErrorCode"/>.</param>
        public CommandException(CommandErrorCode errorCode)
        {
            this.ErrorCode = errorCode;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandException"/> class.
        /// </summary>
        /// <param name="errorCode">The <see cref="CommandErrorCode"/>.</param>
        /// <param name="message">The message that describes the error.</param>
        public CommandException(CommandErrorCode errorCode, string message)
            : base(message)
        {
            this.ErrorCode = errorCode;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandException"/> class.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo" /> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext" /> that contains contextual information about the source or destination.</param>
        protected CommandException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            // TODO: Parse error code out of serialization info.
        }

        /// <summary>
        /// Adds the information about an error that occurred while parsing a command.
        /// </summary>
        /// <param name="commandLine">The command line.</param>
        /// <param name="index">The index the error occurred at.</param>
        /// <returns>A reference to this <see cref="CommandException"/>.</returns>
        public CommandException AddCommandParseInfo(string commandLine, int index)
        {
            this.Data["commandLine"] = commandLine;
            this.Data["index"] = index;

            return this;
        }

        /// <summary>
        /// When overridden in a derived class, sets the <see cref="T:System.Runtime.Serialization.SerializationInfo" /> with information about the exception.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo" /> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext" /> that contains contextual information about the source or destination.</param>
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("ErrorCodeId", this.ErrorCode.Id);
            base.GetObjectData(info, context);
        }
    }
}
