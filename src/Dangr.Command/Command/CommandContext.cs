// -----------------------------------------------------------------------
//  <copyright file="CommandContext.cs" company="DangerDan9631">
//      Copyright (c) 2017 Dan Garvey. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/Dangerdan9631/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.Command
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using Dangr.Command.Commands;
    using Dangr.Command.Exceptions;
    using Dangr.Util;

    /// <summary>
    /// The context that defines what <see cref="IDangrCommand"/>s exist and can be executed.
    /// </summary>
    /// TASK: [11] Add example and remarks doc comments. 
    /// https://github.com/Dangerdan9631/DangrLib/issues/11
    public class CommandContext : ICommandContext
    {
        private readonly TextWriter outputWriter;
        private readonly TextWriter errorWriter;
        private readonly CommandContext parentContext;
        private readonly Dictionary<string, IDangrCommandFactory> commandMap;

        /// <summary>
        /// Gets the name of this <see cref="INamedObject" />.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandContext"/> class.
        /// </summary>
        /// <param name="contextName">Name of the context.</param>
        /// <param name="outputStream">The standard output stream.</param>
        /// <param name="errorStream">The standard error stream.</param>
        public CommandContext(string contextName, TextWriter outputStream, TextWriter errorStream)
        {
            this.Name = contextName;
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
            : this(contextName, parentContext.outputWriter, parentContext.errorWriter)
        {
            this.parentContext = parentContext;
        }

        /// <summary>
        /// Adds a <see cref="IDangrCommand"/> to this <see cref="CommandContext"/>.
        /// </summary>
        /// <typeparam name="T">The type of <see cref="IDangrCommand"/> to add.</typeparam>
        /// <exception cref="ArgumentException"> Thrown if the command already exists in the command context.</exception>
        public void AddCommand<T>() where T : IDangrCommand, new()
        {
            var commandFactory = new DangrCommandFactory<T>();
            string commandName = commandFactory.CommandName;
            if (this.commandMap.ContainsKey(commandName))
            {
                throw new ArgumentException(
                    $"The command {commandName} already exists in command context {this.Name}.",
                    typeof(T).Name);
            }

            this.commandMap.Add(commandName, commandFactory);
        }

        /// <summary>
        /// Executes the specified command line.
        /// </summary>
        /// <param name="commandString">The command line.</param>
        public void Execute(string commandString)
        {
            CommandLine commandLine = new CommandLine(commandString);
            IDangrCommandFactory commandFactory = this.GetCommandFactory(commandLine.CommandName);
            IDangrCommand command = commandFactory.Create(commandLine);
            command.Execute(this);
        }

        /// <summary>
        /// Outputs the specified object to the <see cref="ICommandContext" /> output stream.
        /// </summary>
        /// <param name="output">The output.</param>
        public void Output(object output)
        {
            this.outputWriter.WriteLine(output);
        }

        /// <summary>
        /// Outputs the specified object to the <see cref="ICommandContext" /> error stream.
        /// </summary>
        /// <param name="error">The error.</param>
        public void Error(object error)
        {
            this.errorWriter.WriteLine(error);
        }

        /// <summary>
        /// Gets the help text for all of the <see cref="IDangrCommand" />s defined in the <see cref="ICommandContext" />.
        /// </summary>
        /// <returns>
        /// The help text for all of the <see cref="IDangrCommand" />s defined in the <see cref="ICommandContext" />.
        /// </returns>
        public string GetHelpText()
        {
            StringBuilder builder = new StringBuilder();
            foreach (IDangrCommandFactory commandFactory in this.commandMap.Values)
            {
                builder.Append(commandFactory.CommandHelp);
            }

            return builder.ToString();
        }

        /// <summary>
        /// Gets the help text for the specified <see cref="IDangrCommand" />s defined in the <see cref="ICommandContext" />.
        /// </summary>
        /// <param name="commandName">Name of the command.</param>
        /// <returns>
        /// The help text for the specified <see cref="IDangrCommand" />s defined in the <see cref="ICommandContext" />.
        /// </returns>
        public string GetHelpText(string commandName)
        {
            IDangrCommandFactory commandFactory = this.GetCommandFactory(commandName);
            return commandFactory.CommandHelp;
        }

        private IDangrCommandFactory GetCommandFactory(string commandName)
        {
            IDangrCommandFactory commandFactory;
            if (this.commandMap.TryGetValue(commandName, out commandFactory))
            {
                return commandFactory;
            }

            if (this.parentContext != null)
            {
                return this.parentContext.GetCommandFactory(commandName);
            }

            throw new UnknownCommandException(
                commandName,
                $"Command '{commandName}' does not exist in this context.");
        }
    }
}