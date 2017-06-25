namespace Dangr.Command
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Text;
    using Dangr.Command.Commands;

    /// <summary>
    /// Object used to create new <see cref="IDangrCommand"/>s of type <see cref="T:T"/>.
    /// </summary>
    /// <typeparam name="T">The type of <see cref="IDangrCommand"/> to create.</typeparam>
    public class DangrCommandFactory<T> : IDangrCommandFactory
        where T : IDangrCommand, new()
    {
        private string commandSummary;
        private readonly List<CommandParameter> parameterList;
        private readonly Dictionary<string, CommandParameter> parameterNameMap;
        private readonly Dictionary<int, CommandParameter> parameterPositionMap;

        /// <summary>
        /// Gets the name of the command.
        /// </summary>
        public string CommandName { get; private set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="DangrCommandFactory{T}"/> class.
        /// </summary>
        public DangrCommandFactory()
        {
            this.parameterList = new List<CommandParameter>();
            this.parameterNameMap = new Dictionary<string, CommandParameter>();
            this.parameterPositionMap = new Dictionary<int, CommandParameter>();

            this.InitializeType();
        }

        /// <summary>
        /// Creates a new instance of the specified <see cref="IDangrCommand" /> using the given command line.
        /// </summary>
        /// <param name="commandLine">The command line.</param>
        /// <returns>
        /// A new <see cref="IDangrCommand" /> instance with parameters set from the given command line.
        /// </returns>
        public IDangrCommand Create(CommandLine commandLine)
        {
            T command = new T();

            Dictionary<PropertyInfo, string> boundParameters = new Dictionary<PropertyInfo, string>();

            // Map all named and positional arguments.
            var arguments = commandLine.ArgumentList;
            for (int i = 0; i < arguments.Count; i++)
            {
                string argument = arguments[i];
                CommandParameter commandParameter;
                string value;
                var parts = argument.Split(':');
                if (parts.Length > 1)
                {
                    string name = parts[0];
                    if (!this.parameterNameMap.TryGetValue(name, out commandParameter))
                    {
                        throw new CommandException(CommandErrorCode.UnknownCommandArgument, $"Unknown parameter '{name}'")
                            .AddCommandParseInfo(commandLine.RawCommandLine, -1);
                    }

                    value = argument.Substring(name.Length+1).Trim('"');
                }
                else
                {
                    if (!this.parameterPositionMap.TryGetValue(i, out commandParameter))
                    {
                        throw new CommandException(CommandErrorCode.UnknownCommandArgument, $"No known positional parameter for position '{i}'")
                            .AddCommandParseInfo(commandLine.RawCommandLine, -1);
                    }

                    value = argument;
                }

                boundParameters.Add(commandParameter.PropertyInfo, value);
            }

            // Map all flags.
            foreach (string flag in commandLine.Flags)
            {
                CommandParameter commandParameter;
                if (!this.parameterNameMap.TryGetValue(flag, out commandParameter))
                {
                    throw new CommandException(CommandErrorCode.UnknownCommandArgument, $"Unknown flag '{flag}'")
                        .AddCommandParseInfo(commandLine.RawCommandLine, -1);
                }

                if (!commandParameter.PropertyInfo.PropertyType.Equals(typeof(bool)))
                {
                    throw new CommandException(CommandErrorCode.InvalidCommandArgument, $"Parameter '{flag}' was not defined as a flag ")
                        .AddCommandParseInfo(commandLine.RawCommandLine, -1);
                }

                boundParameters.Add(commandParameter.PropertyInfo, Boolean.TrueString);
            }

            // Check for missing mandatory parameters.
            foreach (CommandParameter p in this.parameterList)
            {
                if (p.IsMandatory && !boundParameters.ContainsKey(p.PropertyInfo))
                {
                    throw new CommandException(CommandErrorCode.MissingMandatoryArgument, $"Mandatory parameter {p.PropertyInfo.Name} was not specified.")
                        .AddCommandParseInfo(commandLine.RawCommandLine, -1);
                }
            }

            // Bind the arguments.
            foreach (var kvp in boundParameters)
            {
                if (kvp.Key.PropertyType.Equals(typeof(Boolean)))
                {
                    kvp.Key.SetValue(command, true);
                }
                else
                {
                    kvp.Key.SetValue(command, kvp.Value);
                }
            }

            return command;
        }

        /// <summary>
        /// Gets the command help.
        /// </summary>
        /// <returns>The command help.</returns>
        public string CommandHelp
        {
            get
            {
                StringBuilder sb = new StringBuilder("Command: ");
                sb.AppendLine(this.CommandName);
                sb.AppendLine("Summary:");
                sb.AppendLine(this.commandSummary);
                sb.AppendLine();

                if (this.parameterList.Count > 0)
                {
                    sb.AppendLine("Parameters:");
                    foreach (var parameter in this.parameterList)
                    {
                        sb.AppendFormat("\t{0} : {1}{2}",
                            parameter.PropertyInfo.Name,
                            parameter.IsMandatory ? "[Mandatory] " : string.Empty,
                            parameter.Position >= 0 ? parameter.Position.ToString() : string.Empty);
                        sb.AppendLine();

                        if (parameter.Aliases.Count > 1)
                        {
                            sb.Append("\tAliases : ");
                            bool isFirstAlias = true;
                            foreach (var alias in parameter.Aliases)
                            {
                                if (alias != parameter.PropertyInfo.Name)
                                {
                                    if (!isFirstAlias)
                                    {
                                        sb.Append(", ");
                                    }
                                    isFirstAlias = false;
                                    sb.Append(alias);
                                }
                            }
                            sb.AppendLine();
                        }

                        sb.AppendLine(parameter.Summary);
                        sb.AppendLine();
                    }
                }

                return sb.ToString();
            }
        }

        private void InitializeType()
        {
            this.CommandName = typeof(T).Name.Replace("DangrCommand", string.Empty).ToLower();

            var dangrCommandAttribute = typeof(T).GetCustomAttribute<DangrCommandAttribute>();
            if (dangrCommandAttribute == null)
            {
                throw new CommandException(CommandErrorCode.InvalidCommandDefinition, $"Missing {nameof(DangrCommandAttribute)} on command {this.CommandName}.");
            }
            this.commandSummary = dangrCommandAttribute.Summary;

            var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var property in properties)
            {
                var parameterAttribute = property.GetCustomAttribute<ParameterAttribute>();
                if (parameterAttribute == null)
                {
                    continue;
                }

                if (!property.SetMethod.IsPublic)
                {
                    throw new CommandException(CommandErrorCode.InvalidCommandParameter, $"Parameter '{property.Name}' must have a public setter.");
                }

                var commandParameter = new CommandParameter(property, parameterAttribute);
                foreach (var alias in commandParameter.Aliases)
                {
                    if (this.parameterNameMap.ContainsKey(alias))
                    {
                        throw new CommandException(CommandErrorCode.InvalidCommandParameter, $"Parameter '{alias}' has already been defined.");
                    }

                    this.parameterNameMap.Add(alias, commandParameter);
                }

                if (commandParameter.Position > -1)
                {
                    if (this.parameterPositionMap.ContainsKey(commandParameter.Position))
                    {
                        throw new CommandException(CommandErrorCode.InvalidCommandParameter, $"Parameter position '{commandParameter.Position}' has already been defined.");
                    }

                    this.parameterPositionMap.Add(commandParameter.Position, commandParameter);
                }

                this.parameterList.Add(commandParameter);
            }
        }

        private class CommandParameter
        {
            public PropertyInfo PropertyInfo { get; private set; }
            public bool IsMandatory { get; private set; }
            public int Position { get; private set; }
            public string Summary { get; private set; }
            public HashSet<string> Aliases { get; private set; }

            public CommandParameter(PropertyInfo propertyInfo, ParameterAttribute attribute)
            {
                this.PropertyInfo = propertyInfo;
                this.IsMandatory = attribute.Mandatory;
                this.Position = attribute.Position;
                this.Summary = attribute.Summary;
                this.Aliases = new HashSet<string>();
                this.Aliases.Add(propertyInfo.Name);

                var aliasAttributes = propertyInfo.GetCustomAttributes<AliasAttribute>();
                foreach (var aliasAttribute in aliasAttributes)
                {
                    this.Aliases.Add(aliasAttribute.Alias);
                }
            }
        }
    }
}
