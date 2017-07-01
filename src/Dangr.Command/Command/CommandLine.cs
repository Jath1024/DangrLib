// -----------------------------------------------------------------------
//  <copyright file="CommandLine.cs" company="DangerDan9631">
//      Copyright (c) 2017 Dan Garvey. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/Dangerdan9631/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.Command
{
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.Text.RegularExpressions;
    using Dangr.Command.Exceptions;

    /// <summary>
    /// Represents a command that can be executed, and the arguments to use
    /// when executing.
    /// </summary>
    /// <remarks>
    /// <para>
    /// <see cref="CommandLine"/> is an object that will parse a given command
    /// line string, and break it down into its components which can be
    /// accessed as needed.
    /// </para>
    /// <para>
    /// The Command Name is the first element of the command line string, and 
    /// represents the command that should be run.
    /// </para>
    /// <para>
    /// The arguments are parsed from the portion of the command line after 
    /// the name. Arguments are seperated by whitespace and can be specified 
    /// in one of three different ways.
    /// <list type="bullet">
    ///   <item>
    ///     <term>Flags</term>
    ///     <description>
    ///       Arguments that begin with '-' and that are not followed by a 
    ///       value, are stored as flags. Flags are used to represent the 
    ///       boolean value <c>true</c> when present, and <c>false</c>
    ///       otherwise.</description>
    ///   </item>
    ///   <item>
    ///     <term>Named arguments</term>
    ///     <description>
    ///       Arguments that begin with '-' and that are followed by a value,
    ///       are stored as named arguments. Named arguments can be accessed as
    ///       name/value pairs.
    ///     </description>
    ///   </item>
    ///   <item>
    ///     <term>Positional arguments</term>
    ///     <description>
    ///       Values that do not begin with '-' and that are not preceded by an 
    ///       argument that does, are positional arguments. Positional
    ///       arguments are stored as a list in the order they are specified.
    ///     </description>
    ///   </item>
    /// </list>
    /// </para>
    /// <para>
    /// Command and argument names can be any string of characters that do not
    /// contain one of the following values: 
    /// <c>`~!@#$%^&amp;*()=+[]{}|\;:"',&lt;&gt;/?</c>.
    /// They also cannot start with the '-' character. When reading flag or 
    /// argument names, the '-' prefix will be removed from the name.
    /// Command names will always be converted to lowercase. Argument names
    /// are case sensitive.
    /// </para>
    /// <para>
    /// Value arguments may be contained in single (') or double (") quotes, 
    /// which can be escaped using a backslash (\) character. They cannot start
    /// with the '-' character, and any whitespace must be contained in quotes.
    /// Otherwise there are no restrictions on the characters in a value 
    /// argument. When reading values, surrounding quote characters will be
    /// removed, and escaped quote characters will be replaced with their
    /// unescaped values.
    /// </para>
    /// </remarks>
    /// 
    /// 
    /// <example>
    /// <c>Example 1</c><br/>
    /// The following example will create a <see cref="CommandLine"/> that 
    /// executes 'TestCommand' using named arguments:
    /// <code>
    /// CommandLine commandLine = new CommandLine(
    ///     "TestCommand -Named1 argument1 -Named2 \"argument \\\"2\\\"\"");
    /// Console.WriteLine($"CommandName: {commandLine.CommandName}");
    /// Console.WriteLine($"Named1: {commandLine.NamedArguments["Named1"]}");
    /// Console.WriteLine($"Named2: {commandLine.NamedArguments["Named2"]}");
    /// </code>
    /// Will output:
    /// <code>
    /// CommandName: TestCommand
    /// Named1: argument1
    /// Named2: argument "2"
    /// </code>
    /// </example>
    /// 
    /// 
    /// <example>
    /// <c>Example 2</c><br/>
    /// The following example will create a <see cref="CommandLine"/> that 
    /// executes 'TestCommand' using flags:
    /// <code>
    /// CommandLine commandLine = new CommandLine(
    ///     "TestCommand -Flag1 -Flag2 -Named1 arg");
    /// Console.WriteLine($"CommandName: {commandLine.CommandName}");
    /// Console.WriteLine($"Flag1: {commandLine.Flags.Contains("Flag1")}");
    /// Console.WriteLine($"Flag2: {commandLine.Flags.Contains("Flag2")}");
    /// Console.WriteLine($"Flag3: {commandLine.Flags.Contains("Flag3")}");
    /// Console.WriteLine($"Named1: {commandLine.NamedArguments["Named1"]}");
    /// </code>
    /// Will output:
    /// <code>
    /// CommandName: TestCommand
    /// Flag1: true
    /// Flag2: true
    /// Flag3: false
    /// Named1: arg
    /// </code>
    /// </example>
    /// 
    /// 
    /// <example>
    /// <c>Example 3</c><br/>
    /// The following example will create a <see cref="CommandLine"/> that 
    /// executes 'TestCommand' using positional arguments:
    /// <code>
    /// CommandLine commandLine = new CommandLine(
    ///     "TestCommand positional0 \"positional arg 1\" -Named1 named positional2 -Flag1");
    /// Console.WriteLine($"CommandName: {commandLine.CommandName}");
    /// Console.WriteLine($"Named1: {commandLine.NamedArguments["Named1"]}");
    /// Console.WriteLine($"Flag1: {commandLine.Flags.Contains("Flag1")}");
    /// for(int i = 0; i &lt; this.PositionalArguments.Count; i++)
    /// {
    ///     Console.WriteLine($"Positional {i}: {this.PositionalArguments[i]}");
    /// }
    /// </code>
    /// Will output:
    /// <code>
    /// CommandName: TestCommand
    /// Named1: named
    /// Flag1: true
    /// Positional 0: positional0
    /// Positional 1: positional arg 1
    /// Positional 2: positional2
    /// </code>
    /// </example>
    public class CommandLine
    {
        private static readonly char[] IllegalNameChars = "`~!@#$%^&*()=+[]{}|\\;:\"',<>/?".ToCharArray();
        private const string ArgumentToken = "-";

        // Task: [5] Create a Regex Builder Library.
        // https://github.com/Dangerdan9631/DangrLib/issues/5
        private const string DoubleQuotedRegexString = "\" ((?: \\\\\" | [^\"] )*) \"";

        private const string SingleQuotedRegexString = "' ((?: \\\\' | [^'] )*) '";
        private const string WordRegexString = "([\\S-[\"']]+)";

        private static readonly string ArgumentMatchRegexString =
            $"(?> {CommandLine.WordRegexString} | {CommandLine.DoubleQuotedRegexString} | {CommandLine.SingleQuotedRegexString} )";

        private static readonly RegexOptions RegexOptions = RegexOptions.Compiled | RegexOptions.IgnorePatternWhitespace;

        private static readonly Regex ArgumentMatchRegex = new Regex(
            CommandLine.ArgumentMatchRegexString,
            CommandLine.RegexOptions);

        /// <summary>
        /// Gets the raw command line string that was parsed.
        /// </summary>
        public string RawCommandLine { get; }

        /// <summary>
        /// Gets the name of the command.
        /// </summary>
        public string CommandName { get; }

        /// <summary>
        /// Gets the raw portion of the string used to parse the command arguments.
        /// </summary>
        public string RawArguments { get; }

        /// <summary>
        /// Gets a dictionary of named arguments and the values parsed from the command line.
        /// </summary>
        public ImmutableDictionary<string, string> NamedArguments { get; }

        /// <summary>
        /// Gets an ordered list of positional arguments parsed from the command line.
        /// </summary>
        public ImmutableList<string> PositionalArguments { get; }

        /// <summary>
        /// Gets the set of flags parsed from the command line.
        /// </summary>
        public ImmutableHashSet<string> Flags { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandLine"/> class.
        /// </summary>
        /// <param name="commandLine">The command line to parse.</param>
        public CommandLine(string commandLine)
        {
            this.RawCommandLine = commandLine;

            string commandName;
            int currentIndex;
            CommandLine.ParseCommandName(this.RawCommandLine, out commandName, out currentIndex);
            this.CommandName = commandName;
            this.RawArguments = currentIndex < this.RawCommandLine.Length
                ? this.RawCommandLine.Substring(currentIndex).TrimEnd()
                : string.Empty;

            Dictionary<string, string> namedArguments;
            List<string> positionalArguments;
            HashSet<string> flags;
            CommandLine.ParseArguments(currentIndex, this.RawCommandLine, out namedArguments, out positionalArguments,
                out flags);
            this.NamedArguments = namedArguments.ToImmutableDictionary();
            this.PositionalArguments = positionalArguments.ToImmutableList();
            this.Flags = flags.ToImmutableHashSet();
        }

        private static void ParseCommandName(string rawCommandLine, out string commandName, out int endIndex)
        {
            if (string.IsNullOrWhiteSpace(rawCommandLine))
            {
                throw new CommandLineParseException(0, rawCommandLine, $"Cannot parse empty command line.");
            }

            int startIndex = 0;
            while ((startIndex < rawCommandLine.Length) && char.IsWhiteSpace(rawCommandLine[startIndex]))
            {
                startIndex++;
            }

            endIndex = startIndex + 1;
            while ((endIndex < rawCommandLine.Length) && !char.IsWhiteSpace(rawCommandLine[endIndex]))
            {
                endIndex++;
            }

            commandName = rawCommandLine.Substring(startIndex, endIndex - startIndex);
            CommandLine.ValidateName(commandName, startIndex, rawCommandLine);

            while ((endIndex < rawCommandLine.Length) && char.IsWhiteSpace(rawCommandLine[endIndex]))
            {
                endIndex++;
            }
        }

        private static void ParseArguments(
            int startIndex,
            string rawCommandLine,
            out Dictionary<string, string> namedArguments,
            out List<string> positionalArguments,
            out HashSet<string> flags)
        {
            namedArguments = new Dictionary<string, string>();
            positionalArguments = new List<string>();
            flags = new HashSet<string>();

            string argumentName = null;
            int argumentNameIndex = -1;
            MatchCollection matches = CommandLine.ArgumentMatchRegex.Matches(rawCommandLine, startIndex);
            foreach (Match match in matches)
            {
                if (match.Value.StartsWith(CommandLine.ArgumentToken))
                {
                    string value = match.Value.Substring(1);
                    CommandLine.ValidateName(value, match.Index + 1, rawCommandLine);

                    if (argumentName != null)
                    {
                        CommandLine.AddFlag(argumentName, flags, argumentNameIndex, rawCommandLine);
                    }

                    argumentName = value;
                    argumentNameIndex = match.Index + 1;
                }
                else
                {
                    for (int i = 1; i < match.Groups.Count; i++)
                    {
                        Group group = match.Groups[i];
                        if (!group.Success)
                        {
                            continue;
                        }

                        string value = CommandLine.UnescapeCharacters(group.Value);
                        if (argumentName == null)
                        {
                            CommandLine.AddPositionalArgument(value, positionalArguments, group.Index, rawCommandLine);
                        }
                        else
                        {
                            CommandLine.AddNamedArgument(
                                argumentName,
                                value,
                                namedArguments,
                                argumentNameIndex,
                                rawCommandLine);
                            argumentName = null;
                            argumentNameIndex = -1;
                        }
                    }
                }
            }

            if (argumentName != null)
            {
                CommandLine.AddFlag(argumentName, flags, argumentNameIndex, rawCommandLine);
            }
        }

        private static void ValidateName(string name, int index, string rawCommandLine)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new CommandLineParseException(
                    index,
                    rawCommandLine,
                    $"Name cannot be empty.");
            }

            int invalidCharIndex = name.IndexOfAny(CommandLine.IllegalNameChars);
            if (invalidCharIndex >= 0)
            {
                throw new CommandLineParseException(
                    index + invalidCharIndex,
                    rawCommandLine,
                    $"Name '{name}' contains illegal character '{name[invalidCharIndex]}'.");
            }

            if (name.StartsWith(CommandLine.ArgumentToken))
            {
                throw new CommandLineParseException(
                    index,
                    rawCommandLine,
                    $"Name '{name}' cannot start with character '{CommandLine.ArgumentToken}'.");
            }
        }

        private static void AddFlag(string flagName, HashSet<string> flags, int index, string rawCommandLine)
        {
            if (flags.Contains(flagName))
            {
                throw new CommandLineParseException(
                    index,
                    rawCommandLine,
                    $"Command Line already contains flag '{flagName}'.");
            }

            flags.Add(flagName);
        }

        private static void AddNamedArgument(string argumentName, string argumentValue,
            Dictionary<string, string> namedArguments, int index, string rawCommandLine)
        {
            if (namedArguments.ContainsKey(argumentName))
            {
                throw new CommandLineParseException(
                    index,
                    rawCommandLine,
                    $"Command Line already contains named argument '{argumentName}'.");
            }

            namedArguments.Add(argumentName, argumentValue);
        }

        private static void AddPositionalArgument(string value, List<string> positionalArguments, int index,
            string rawCommandLine)
        {
            positionalArguments.Add(value);
        }

        private static string UnescapeCharacters(string escaped)
        {
            return escaped
                .Replace("\\\"", "\"")
                .Replace("\\'", "'");
        }
    }
}