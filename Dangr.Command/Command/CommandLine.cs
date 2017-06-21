namespace Dangr.Command
{
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Parses a command string and provides access to the command name and individual arguments.
    /// </summary>
    public class CommandLine
    {
        private readonly char[] InvalidCommandNameChars = "`~!@#$%^&*()=+[]{}|\\;:\"',<>/?".ToCharArray();
        
        private List<string> argumentList;

        /// <summary>
        /// Gets the name of the command.
        /// </summary>
        public string CommandName { get; private set; }

        /// <summary>
        /// Gets the list of parsed argument.
        /// </summary>
        public IReadOnlyList<string> ArgumentList { get { return this.argumentList; } }

        /// <summary>
        /// Gets the flags specified in this command line.
        /// </summary>
        public HashSet<string> Flags { get; private set; }

        /// <summary>
        /// Gets the raw command line string.
        /// </summary>
        public string RawCommandLine { get; private set; }

        /// <summary>
        /// Gets the argument portion of the command line as a string.
        /// </summary>
        public string RawArguments { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandLine"/> class.
        /// </summary>
        /// <param name="commandLine">The command line to parse.</param>
        public CommandLine(string commandLine)
        {
            this.ParseCommandLine(commandLine);
        }

        private void ParseCommandLine(string commandLine)
        {
            this.RawCommandLine = commandLine.Trim();
            this.CommandName = string.Empty;
            this.RawArguments = string.Empty;
            this.argumentList = new List<string>();
            this.Flags = new HashSet<string>();

            this.ParseCommandName();
            this.ParseArguments();
        }

        private void ParseCommandName()
        {
            int endIndex = -1;
            for(int i = 0; i < this.RawCommandLine.Length; i++)
            {
                if (char.IsWhiteSpace(this.RawCommandLine[i]))
                {
                    endIndex = i;
                    break;
                }
            }

            if (endIndex == -1)
            {
                this.CommandName = this.RawCommandLine.ToLower();
            }
            else
            {
                this.CommandName = this.RawCommandLine.Substring(0, endIndex).ToLower();

                if (endIndex < this.RawCommandLine.Length + 1)
                {
                    this.RawArguments = this.RawCommandLine.Substring(endIndex + 1).TrimStart();
                }
            }

            int invalidChar = this.CommandName.IndexOfAny(this.InvalidCommandNameChars);
            if (invalidChar >= 0)
            {
                throw new CommandException(CommandErrorCode.InvalidCommandName, $"The command name cannot containt the character {this.CommandName[invalidChar]}")
                    .AddCommandParseInfo(this.RawCommandLine, 0);
            }

            if (string.IsNullOrWhiteSpace(this.CommandName))
            {
                throw new CommandException(CommandErrorCode.InvalidCommandName, "The command name cannot be empty.")
                    .AddCommandParseInfo(this.RawCommandLine, 0);
            }
        }

        private void ParseArguments()
        {
            StringBuilder argumentBuilder = new StringBuilder();
            bool inSingleQuotes = false;
            bool inDoubleQuotes = false;
            bool isEscapedCharacter = false;
            for (int i = 0; i < this.RawArguments.Length; i++)
            {
                char ch = this.RawArguments[i];
                if (isEscapedCharacter)
                {
                    isEscapedCharacter = false;
                    argumentBuilder.Append(ch);
                    continue;
                }

                if (char.IsWhiteSpace(ch))
                {
                    if (!inSingleQuotes && !inDoubleQuotes)
                    {
                        string arg = argumentBuilder.ToString();
                        if (arg.Length > 0)
                        {
                            if (arg[0] == '-')
                            {
                                if (arg.Length == 1)
                                {
                                    throw new CommandException(CommandErrorCode.InvalidCommandArgument, "Missing flag after - in argument.")
                                        .AddCommandParseInfo(this.RawArguments, this.RawArguments.Length);
                                }

                                this.Flags.Add(arg.Substring(1));
                            }
                            else
                            {
                                this.argumentList.Add(arg);
                            }
                        }
                        
                        argumentBuilder.Clear();
                        continue;
                    }
                }
                else if (ch.Equals('"'))
                {
                    if (!inSingleQuotes)
                    {
                        inDoubleQuotes = !inDoubleQuotes;
                    }
                }
                else if (ch.Equals('\''))
                {
                    if (!inDoubleQuotes)
                    {
                        inSingleQuotes = !inSingleQuotes;
                    }
                }

                if (ch.Equals('\\'))
                {
                    isEscapedCharacter = true;
                }
                else
                {
                    argumentBuilder.Append(ch);
                }
            }
            
            if (inSingleQuotes)
            {
                throw new CommandException(CommandErrorCode.InvalidCommandArgument, "Missing closing ' in argument.")
                    .AddCommandParseInfo(this.RawArguments, this.RawArguments.Length);
            }

            if (inDoubleQuotes)
            {
                throw new CommandException(CommandErrorCode.InvalidCommandArgument, "Missing closing \" in argument.")
                    .AddCommandParseInfo(this.RawArguments, this.RawArguments.Length);
            }

            // Add the rest of the string as the final argument.
            string finalArg = argumentBuilder.ToString();
            if (finalArg.Length > 0)
            {
                if (finalArg[0] == '-')
                {
                    if (finalArg.Length == 1)
                    {
                        throw new CommandException(CommandErrorCode.InvalidCommandArgument, "Missing flag after - in argument.")
                            .AddCommandParseInfo(this.RawArguments, this.RawArguments.Length);
                    }

                    this.Flags.Add(finalArg.Substring(1));
                }
                else
                {
                    this.argumentList.Add(finalArg);
                }
            }

            this.argumentList.RemoveAll(str => string.IsNullOrWhiteSpace(str));
        }
    }
}
