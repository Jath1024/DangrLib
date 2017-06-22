namespace Dangr.Command
{
    using Dangr.Error;

    /// <summary>
    /// Error codes that are used by <see cref="CommandException"/>s.
    /// </summary>
    public class CommandErrorCode : ErrorCode
    {
        /// <summary>
        /// <see cref="CommandErrorCode"/> that is used when parsing an invalid command name.
        /// </summary>
        public static readonly CommandErrorCode InvalidCommandName = new CommandErrorCode(
            nameof(Command) + ".001", 
            nameof(CommandErrorCode.InvalidCommandName),
            "The command name is invalid.");

        /// <summary>
        /// <see cref="CommandErrorCode"/> that is used when parsing an invalid command argument.
        /// </summary>
        public static readonly CommandErrorCode InvalidCommandArgument = new CommandErrorCode(
            nameof(Command) + ".002",
            nameof(CommandErrorCode.InvalidCommandArgument),
            "The command argument is invalid.");

        /// <summary>
        /// <see cref="CommandErrorCode"/> that is used when a specified command argument could not be bound.
        /// </summary>
        public static readonly CommandErrorCode UnknownCommandArgument = new CommandErrorCode(
            nameof(Command) + ".003",
            nameof(CommandErrorCode.UnknownCommandArgument),
            "Could not bind command argument.");

        /// <summary>
        /// <see cref="CommandErrorCode"/> that is used when a mandatory command argument was not specified.
        /// </summary>
        public static readonly CommandErrorCode MissingMandatoryArgument = new CommandErrorCode(
            nameof(Command) + ".004",
            nameof(CommandErrorCode.MissingMandatoryArgument),
            "Missing a mandatory argument.");
        
        /// <summary>
        /// <see cref="CommandErrorCode"/> that is used when a <see cref="ParameterAttribute"/> is applied to an invalid parameter.
        /// </summary>
        public static readonly CommandErrorCode InvalidCommandParameter = new CommandErrorCode(
            nameof(Command) + ".005",
            nameof(CommandErrorCode.InvalidCommandParameter),
            "Invalid command parameter.");

        /// <summary>
        /// <see cref="CommandErrorCode"/> that is used when a <see cref="DangrCommand"/> is defined in an invalid way.
        /// </summary>
        public static readonly CommandErrorCode InvalidCommandDefinition = new CommandErrorCode(
            nameof(Command) + ".006",
            nameof(CommandErrorCode.InvalidCommandDefinition),
            "Invalid command definition.");

        /// <summary>
        /// <see cref="CommandErrorCode"/> that is used when trying to execute a <see cref="DangrCommand"/>
        /// that does not exist in a given <see cref="CommandContext"/>.
        /// </summary>
        public static readonly CommandErrorCode CommandDoesNotExist = new CommandErrorCode(
            nameof(Command) + ".101",
            nameof(CommandErrorCode.CommandDoesNotExist),
            "The command does not exist.");

        /// <summary>
        /// <see cref="CommandErrorCode"/> that is used when trying to add a <see cref="DangrCommand"/> that
        /// already exists in a given <see cref="CommandContext"/>.
        /// </summary>
        public static readonly CommandErrorCode CommandAlreadyExists = new CommandErrorCode(
            nameof(Command) + ".102",
            nameof(CommandErrorCode.CommandAlreadyExists),
            "The command already exists in the current command context.");

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandErrorCode"/> class.
        /// </summary>
        /// <param name="id">The unique identifier for this <see cref="ErrorCode" />.</param>
        /// <param name="name">The descriptive name for this <see cref="ErrorCode" />.</param>
        /// <param name="message">The generic message for this <see cref="ErrorCode" />.</param>
        public CommandErrorCode(string id, string name, string message)
            : base(id, name, message)
        { }
    }
}
