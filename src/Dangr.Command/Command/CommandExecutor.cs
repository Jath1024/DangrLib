// -----------------------------------------------------------------------
//  <copyright file="CommandExecutor.cs" company="DangerDan9631">
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
    /// The executor that defines what <see cref="IDangrCommand"/>s exist and can be executed.
    /// </summary>
    /// <remarks>
    /// <para>
    /// The <see cref="CommandExecutor"/> is an object that will parse a given command line and execute
    /// it as a command. Different <see cref="IDangrCommand"/>s can be registered.
    /// </para>
    /// <para>
    /// <see cref="CommandExecutor"/>s can also be nested to create a scope for specific commands. Commands
    /// registered with the child executor can only be accessed when executed with the child executor,
    /// but commands registered with the parent executor can be executed from the child. Names are resolved
    /// starting with the child, so any commands registered with the same name will override commands in
    /// the parent executor.
    /// </para>
    /// <para>
    /// Command lines are parsed using a <see cref="CommandLine"/> instance and should follow those
    /// conventions for command and argument names.
    /// </para>
    /// </remarks>
    /// 
    /// 
    /// <example>
    /// <c>Example 1</c><br/>
    /// The following example will create a <see cref="CommandExecutor"/>, register a command called "Output"
    /// and execute it.
    /// <code>
    /// TextWriter outputStream = new StringWriter();
    /// TextWriter errorStream = new StringWriter();
    /// 
    /// CommandExecutor executor = new CommandExecutor("TestContext", outputStream, errorStream);
    /// executor.AddCommand&lt;OutputCommand&gt;();
    /// executor.Execute("Output 'hello world'");
    /// </code>
    /// Will write to the outputStream:
    /// <code>
    /// hello world
    /// </code>
    /// </example>
    /// 
    /// 
    /// <example>
    /// <c>Example 2</c><br/>
    /// The following example will create a <see cref="CommandExecutor"/>, register a command called "Output"
    /// and execute the command from it's child <see cref="CommandExecutor"/>.
    /// <code>
    /// TextWriter outputStream = new StringWriter();
    /// TextWriter errorStream = new StringWriter();
    /// 
    /// CommandExecutor parentExecutor = new CommandExecutor("TestContext", outputStream, errorStream);
    /// CommandExecutor childExecutor = new CommandExecutor("ChildContext", parentExecutor);
    /// parentExecutor.AddCommand&lt;OutputCommand&gt;();
    /// childExecutor.Execute("Output 'hello world'");
    /// </code>
    /// Will write to the outputStream:
    /// <code>
    /// hello world
    /// </code>
    /// </example>
    /// <seealso cref="CommandLine"/>
    public sealed class CommandExecutor : ICommandContext
    {
        private readonly TextWriter outputWriter;
        private readonly TextWriter errorWriter;
        private readonly CommandExecutor parentExecutor;
        private readonly Dictionary<string, IDangrCommandFactory> commandMap;

        /// <summary>
        /// Gets the name of this <see cref="INamedObject" />.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandExecutor"/> class.
        /// </summary>
        /// <param name="contextName">Name of the executor.</param>
        /// <param name="outputStream">The standard output stream.</param>
        /// <param name="errorStream">The standard error stream.</param>
        public CommandExecutor(string contextName, TextWriter outputStream, TextWriter errorStream)
        {
            this.Name = contextName;
            this.commandMap = new Dictionary<string, IDangrCommandFactory>();
            this.AddCommand<DangrCommandHelp>();
            this.parentExecutor = null;
            this.outputWriter = outputStream;
            this.errorWriter = errorStream;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandExecutor"/> class.
        /// </summary>
        /// <param name="contextName">Name of the executor.</param>
        /// <param name="parentExecutor">The parent executor.</param>
        public CommandExecutor(string contextName, CommandExecutor parentExecutor)
            : this(contextName, parentExecutor.outputWriter, parentExecutor.errorWriter)
        {
            this.parentExecutor = parentExecutor;
        }

        /// <summary>
        /// Adds a <see cref="IDangrCommand"/> to this <see cref="CommandExecutor"/>.
        /// </summary>
        /// <typeparam name="T">The type of <see cref="IDangrCommand"/> to add.</typeparam>
        /// <exception cref="ArgumentException"> Thrown if the command already exists in the command executor.</exception>
        public void AddCommand<T>() where T : IDangrCommand, new()
        {
            var commandFactory = new DangrCommandFactory<T>();
            string commandName = commandFactory.CommandName;
            if (this.commandMap.ContainsKey(commandName))
            {
                throw new ArgumentException(
                    $"The command {commandName} already exists in command executor {this.Name}.",
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
        void ICommandContext.Output(object output)
        {
            this.outputWriter.WriteLine(output);
        }

        /// <summary>
        /// Outputs the specified object to the <see cref="ICommandContext" /> error stream.
        /// </summary>
        /// <param name="error">The error.</param>
        void ICommandContext.Error(object error)
        {
            this.errorWriter.WriteLine(error);
        }

        /// <summary>
        /// Gets the help text for all of the <see cref="IDangrCommand" />s defined in the <see cref="ICommandContext" />.
        /// </summary>
        /// <returns>
        /// The help text for all of the <see cref="IDangrCommand" />s defined in the <see cref="ICommandContext" />.
        /// </returns>
        string ICommandContext.GetHelpText()
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
        string ICommandContext.GetHelpText(string commandName)
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

            if (this.parentExecutor != null)
            {
                return this.parentExecutor.GetCommandFactory(commandName);
            }

            throw new UnknownCommandException(
                commandName,
                $"Command '{commandName}' does not exist in this executor.");
        }
    }
}