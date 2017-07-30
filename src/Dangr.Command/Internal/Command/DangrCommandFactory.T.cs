// -----------------------------------------------------------------------
//  <copyright file="DangrCommandFactory.T.cs" company="DangerDan9631">
//      Copyright (c) 2017 Dan Garvey. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/Dangerdan9631/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.Internal.Command
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.Reflection;
    using System.Text;
    using Dangr.Core;
    using Dangr.Core.Command;
    using Dangr.Core.Command.Annotation;
    using Dangr.Core.Command.Exceptions;

    /// <summary>
    /// Object used to create new <see cref="IDangrCommand"/>s of type <see cref="T:T"/>.
    /// </summary>
    /// <typeparam name="T">The type of <see cref="IDangrCommand"/> to create.</typeparam>
    internal class DangrCommandFactory<T> : IDangrCommandFactory
        where T : IDangrCommand, new()
    {
        private readonly Lazy<string> commandHelp;

        /// <summary>
        /// Gets the name of the command.
        /// </summary>
        public string CommandName { get; }

        /// <summary>
        /// Gets the summary of the command created by this <see cref="IDangrCommandFactory"/>.
        /// </summary>
        public string CommandSummary { get; }

        /// <summary>
        /// /// Gets the help documentation for the command created by this <see cref="IDangrCommandFactory"/>.
        /// </summary>
        public string CommandHelp => this.commandHelp.Value;

        private ImmutableDictionary<string, CommandParameter> ParameterNameMap { get; }

        private ImmutableDictionary<int, CommandParameter> ParameterPositionMap { get; }

        private ImmutableList<CommandParameter> ParameterList { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DangrCommandFactory{T}"/> class.
        /// </summary>
        public DangrCommandFactory()
        {
            this.commandHelp = new Lazy<string>(this.GenerateCommandHelp);

            string commandName;
            string commandSummary;
            Dictionary<string, CommandParameter> parameterNameMap;
            Dictionary<int, CommandParameter> parameterPositionMap;
            List<CommandParameter> parameterList;
            this.InitializeType(out commandName, out commandSummary, out parameterNameMap, out parameterPositionMap,
                out parameterList);

            this.CommandName = commandName;
            this.CommandSummary = commandSummary;
            this.ParameterNameMap = parameterNameMap.ToImmutableDictionary();
            this.ParameterPositionMap = parameterPositionMap.ToImmutableDictionary();
            this.ParameterList = parameterList.ToImmutableList();
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

            var boundParameters = new Dictionary<PropertyInfo, string>();

            foreach (KeyValuePair<string, string> entry in commandLine.NamedArguments)
            {
                string argumentName = entry.Key;
                string argumentValue = entry.Value;
                CommandParameter parameter;
                if (!this.ParameterNameMap.TryGetValue(argumentName, out parameter))
                {
                    throw new UnknownCommandArgumentException(argumentName, $"Unknown parameter '{argumentName}'");
                }

                boundParameters.Add(parameter.PropertyInfo, argumentValue);
            }

            for (int i = 0; i < commandLine.PositionalArguments.Count; i++)
            {
                string argumentValue = commandLine.PositionalArguments[i];
                CommandParameter parameter;
                if (!this.ParameterPositionMap.TryGetValue(i, out parameter))
                {
                    throw new UnknownCommandArgumentException($"Positional parameter {i}",
                        $"Unknown positional parameter at position '{i}'.");
                }

                boundParameters.Add(parameter.PropertyInfo, argumentValue);
            }

            foreach (string flag in commandLine.Flags)
            {
                CommandParameter parameter;
                if (!this.ParameterNameMap.TryGetValue(flag, out parameter))
                {
                    throw new UnknownCommandArgumentException(flag, $"Unknown flag parameter '{flag}'");
                }

                if (parameter.PropertyInfo.PropertyType != typeof(bool))
                {
                    throw new InvalidCommandArgumentException(flag, $"Flag parameter '{flag}' is not a boolean type.");
                }

                boundParameters.Add(parameter.PropertyInfo, bool.TrueString);
            }

            foreach (CommandParameter parameter in this.ParameterList)
            {
                if (parameter.IsMandatory && !boundParameters.ContainsKey(parameter.PropertyInfo))
                {
                    throw new MissingCommandArgumentException(
                        parameter.PropertyInfo.Name,
                        $"Mandatory parameter {parameter.PropertyInfo.Name} was not specified.");
                }
            }

            foreach (KeyValuePair<PropertyInfo, string> entry in boundParameters)
            {
                DangrCommandFactory<T>.SetValue(command, entry.Key, entry.Value);
            }

            return command;
        }

        private string GenerateCommandHelp()
        {
            StringBuilder sb = new StringBuilder("Command: ");
            sb.AppendLine(this.CommandName);
            sb.AppendLine("Summary:");
            sb.AppendLine(this.CommandSummary);
            sb.AppendLine();

            if (this.ParameterList.Count > 0)
            {
                sb.AppendLine("Parameters:");
                foreach (CommandParameter parameter in this.ParameterList)
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
                        foreach (string alias in parameter.Aliases)
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

        private void InitializeType(
            out string commandName,
            out string commandSummary,
            out Dictionary<string, CommandParameter> parameterMap,
            out Dictionary<int, CommandParameter> parameterPositionmap,
            out List<CommandParameter> parameterList)
        {
            Type commandType = typeof(T);

            DangrCommandAttribute attribute = commandType.GetCustomAttribute<DangrCommandAttribute>();
            if (attribute == null)
            {
                throw new InvalidOperationException(
                    $"Cannot create a {nameof(DangrCommandFactory<T>)} of type {commandType.Name}."
                    + $" No {nameof(DangrCommandAttribute)} was specified.");
            }

            commandName = attribute.CommandName;
            commandSummary = attribute.Summary;

            parameterMap = new Dictionary<string, CommandParameter>();
            parameterPositionmap = new Dictionary<int, CommandParameter>();
            parameterList = new List<CommandParameter>();
            PropertyInfo[] properties =
                commandType.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo property in properties)
            {
                ParameterAttribute parameterAttribute = property.GetCustomAttribute<ParameterAttribute>();
                if (parameterAttribute == null)
                {
                    continue;
                }

                if (!property.SetMethod.IsPublic)
                {
                    throw new InvalidOperationException(
                        $"Cannot create a {nameof(DangrCommandFactory<T>)} of type {commandType.Name}."
                        + $"Parameter '{property.Name}' must have a public setter.");
                }

                CommandParameter commandParameter = new CommandParameter(property, parameterAttribute);
                foreach (string alias in commandParameter.Aliases)
                {
                    if (parameterMap.ContainsKey(alias))
                    {
                        throw new InvalidOperationException(
                            $"Cannot create a {nameof(DangrCommandFactory<T>)} of type {commandType.Name}."
                            + $"Parameter '{alias}' has already been defined.");
                    }

                    parameterMap.Add(alias, commandParameter);

                    if (commandParameter.Position > -1)
                    {
                        if (parameterPositionmap.ContainsKey(commandParameter.Position))
                        {
                            throw new InvalidOperationException(
                                $"Cannot create a {nameof(DangrCommandFactory<T>)} of type {commandType.Name}."
                                + $"Parameter at position '{commandParameter.Position}' has already been defined.");
                        }

                        parameterPositionmap.Add(commandParameter.Position, commandParameter);
                    }

                    parameterList.Add(commandParameter);
                }
            }
        }
        
        private static void SetValue(object instance, PropertyInfo property, string value)
        {
            Type propertyType = property.PropertyType;
            if (propertyType == typeof(bool))
            {
                property.SetValue(instance, true);
            }
            else if (propertyType == typeof(decimal))
            {
                property.SetValue(instance, Convert.ToDecimal(value));
            }
            else if (propertyType == typeof(double))
            {
                property.SetValue(instance, Convert.ToDouble(value));
            }
            else if (propertyType == typeof(float))
            {
                property.SetValue(instance, Convert.ToSingle(value));
            }
            else if (propertyType == typeof(long))
            {
                property.SetValue(instance, Convert.ToInt64(value));
            }
            else if (propertyType == typeof(int))
            {
                property.SetValue(instance, Convert.ToInt32(value));
            }
            else if (propertyType == typeof(string))
            {
                property.SetValue(instance, value);
            }
        }

        private class CommandParameter
        {
            public PropertyInfo PropertyInfo { get; }
            public bool IsMandatory { get; }
            public int Position { get; }
            public string Summary { get; }
            public HashSet<string> Aliases { get; }

            public CommandParameter(PropertyInfo propertyInfo, ParameterAttribute attribute)
            {
                this.PropertyInfo = propertyInfo;
                this.IsMandatory = attribute.Mandatory;
                this.Position = attribute.Position;
                this.Summary = attribute.Summary;
                this.Aliases = new HashSet<string>();
                this.Aliases.Add(propertyInfo.Name);

                IEnumerable<AliasAttribute> aliasAttributes = propertyInfo.GetCustomAttributes<AliasAttribute>();
                foreach (AliasAttribute aliasAttribute in aliasAttributes)
                {
                    this.Aliases.Add(aliasAttribute.Alias);
                }
            }
        }
    }
}