namespace Dangr.Command
{
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using Commands;
    using Dangr.Util;

    /// <summary>
    /// The context that defines what <see cref="DangrCommand"/>s exist and can be executed.
    /// </summary>
    public class CommandContext : ICommandContext, INamedObject
    {
        private readonly TextWriter outputWriter;
        private readonly TextWriter errorWriter;
        private readonly CommandContext parentContext;
        readonly Dictionary<string, IDangrCommandFactory> commandMap;

        /// <summary>
        /// Gets the name of this <see cref="INamedObject" />.
        /// </summary>
        public string Name { get { return this.ContextName; } }

        /// <summary>
        /// Gets the name of the context.
        /// </summary>
        /// <value>The name of the context.</value>
        public string ContextName { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandContext"/> class.
        /// </summary>
        /// <param name="contextName">Name of the context.</param>
        /// <param name="outputStream">The standard output stream.</param>
        /// <param name="errorStream">The standard error stream.</param>
        public CommandContext(string contextName, TextWriter outputStream, TextWriter errorStream)
        {
            this.ContextName = contextName;
            this.commandMap = new Dictionary<string, IDangrCommandFactory>();
            this.AddCommand<DangrCommandHelp>();
            this.parentContext = null;
            this.outputWriter = outputStream;
            this.errorWriter = errorStream;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandContext"/> class.
        /// </summary>
        /// <param name="contextName">Name of the context.</param>
        /// <param name="parentContext">The parent context.</param>
        public CommandContext(string contextName, CommandContext parentContext)
        {
            this.ContextName = contextName;
            this.commandMap = new Dictionary<string, IDangrCommandFactory>();
            this.AddCommand<DangrCommandHelp>();
            this.parentContext = parentContext;
            this.outputWriter = parentContext.outputWriter;
            this.errorWriter = parentContext.errorWriter;
        }

        /// <summary>
        /// Adds a <see cref="DangrCommand"/> to this <see cref="CommandContext"/>.
        /// </summary>
        /// <typeparam name="T">The type of <see cref="DangrCommand"/> to add.</typeparam>
        /// <exception cref="CommandException"> Thrown if the command already exists in the command context.</exception>
        public void AddCommand<T>() where T : DangrCommand, new()
        {
            var commandFactory = new DangrCommandFactory<T>();
            string commandName = commandFactory.CommandName;
            if (this.commandMap.ContainsKey(commandName))
            {
                throw new CommandException(CommandErrorCode.CommandAlreadyExists,
                    $"The command {commandName} already exists in command context {this.ContextName}.");
            }

            this.commandMap.Add(commandName, commandFactory);
        }

        /// <summary>
        /// Executes the specified command line.
        /// </summary>
        /// <param name="commandLine">The command line.</param>
        public void Execute(string commandLine)
        {
            var cmd = new CommandLine(commandLine);
            this.ExecuteInternal(cmd, this);
        }

        private void ExecuteInternal(CommandLine commandLine, ICommandContext executionContext)
        {
            IDangrCommandFactory commandFactory;
            if (!this.commandMap.TryGetValue(commandLine.CommandName, out commandFactory))
            {
                if (this.parentContext == null)
                {
                    throw new CommandException(
                        CommandErrorCode.CommandDoesNotExist, 
                        $"Command '{commandLine.CommandName}' does not exist in this context.");
                }

                this.parentContext.ExecuteInternal(commandLine, executionContext);
            }

            DangrCommand command = commandFactory.Create(commandLine);
            command.Execute(executionContext);
        }

        /// <summary>
        /// Outputs the specified object to the <see cref="ICommandContext" /> output stream.
        /// </summary>
        /// <typeparam name="T">The type of output.</typeparam>
        /// <param name="output">The output.</param>
        public void Output<T>(T output)
        {
            this.outputWriter.WriteLine(output);
        }

        /// <summary>
        /// Outputs the specified object to the <see cref="ICommandContext" /> error stream.
        /// </summary>
        /// <typeparam name="T">The type of error.</typeparam>
        /// <param name="error">The error.</param>
        public void Error<T>(T error)
        {
            this.errorWriter.WriteLine(error);
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            foreach(var command in this.commandMap.Values) 
            {
                builder.Append(command.CommandHelp);
            }

            return builder.ToString();
        }
    }
}
