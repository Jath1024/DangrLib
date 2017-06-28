// -----------------------------------------------------------------------
//  <copyright file="CommandLineTest.cs" company="DangerDan9631">
//      Copyright (c) 2017 Dan Garvey. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/Dangerdan9631/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------
namespace Dangr.Command
{
    using System;
    using System.Collections.Generic;
    using Dangr.Test;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Assert = Dangr.Diagnostics.Assert;

    [TestClass]
    public class CommandLineTest
    {
        [TestMethod]
        public void ParseJustCommandName()
        {
            const string commandName = "hello";

            new CommandLineTester()
                .ExpectCommandName(commandName)
                .ExpectRawArguments(string.Empty)
                .ExpectRawCommandLine(commandName)
                .ExpectNoNamedArguments()
                .ExpectNoPositionalArguments()
                .ExpectNoFlags()
                .TestCommandLine(commandName);
        }

        [TestMethod]
        public void ParseOneNamedArgument()
        {
            const string commandName = "hello";
            const string rawArguments = "-named1 value1";
            string rawCommandLine = $"{commandName} {rawArguments}";

            new CommandLineTester()
                .ExpectCommandName(commandName)
                .ExpectNamedArgument("named1", "value1")
                .ExpectNoPositionalArguments()
                .ExpectNoFlags()
                .TestCommandLine(rawCommandLine);
        }

        [TestMethod]
        public void ParseMultipleNamedArguments()
        {
            const string commandName = "hello";
            const string rawArguments = "-named1 value1 -named2 value2 -named3 value3";
            string rawCommandLine = $"{commandName} {rawArguments}";

            new CommandLineTester()
                .ExpectCommandName(commandName)
                .ExpectNamedArgument("named1", "value1")
                .ExpectNamedArgument("named2", "value2")
                .ExpectNamedArgument("named3", "value3")
                .ExpectNoPositionalArguments()
                .ExpectNoFlags()
                .TestCommandLine(rawCommandLine);
        }
        
        [TestMethod]
        public void ParseDuplicateNamedArguments()
        {
            const string rawCommandLine = "hello -named1 value1 -named1 value2";

            CommandLineParseException exception = TestUtils.TestForError<CommandLineParseException>(
                () => new CommandLineTester().TestCommandLine(rawCommandLine),
                "Did not catch expected error.");

            Assert.Validate.AreEqual(exception.Position, 22, "Error not found at correct index.");
        }

        [TestMethod]
        public void ParseOnePositionalArgument()
        {
            const string commandName = "hello";
            const string rawArguments = "positional1";
            string rawCommandLine = $"{commandName} {rawArguments}";

            new CommandLineTester()
                .ExpectCommandName(commandName)
                .ExpectNoNamedArguments()
                .ExpectPositionalArgument("positional1")
                .ExpectNoFlags()
                .TestCommandLine(rawCommandLine);
        }

        [TestMethod]
        public void ParseMultiplePositionalArguments()
        {
            const string commandName = "hello";
            const string rawArguments = "positional1 positional2 positional3";
            string rawCommandLine = $"{commandName} {rawArguments}";

            new CommandLineTester()
                .ExpectCommandName(commandName)
                .ExpectNoNamedArguments()
                .ExpectPositionalArgument("positional1")
                .ExpectPositionalArgument("positional2")
                .ExpectPositionalArgument("positional3")
                .ExpectNoFlags()
                .TestCommandLine(rawCommandLine);
        }

        [TestMethod]
        public void ParseOneFlagArgument()
        {
            const string commandName = "hello";
            const string rawArguments = "-flag1";
            string rawCommandLine = $"{commandName} {rawArguments}";

            new CommandLineTester()
                .ExpectCommandName(commandName)
                .ExpectNoNamedArguments()
                .ExpectNoPositionalArguments()
                .ExpectFlag("flag1")
                .TestCommandLine(rawCommandLine);
        }

        [TestMethod]
        public void ParseMultipleFlagArguments()
        {
            const string commandName = "hello";
            const string rawArguments = "-flag1 -flag2 -flag3";
            string rawCommandLine = $"{commandName} {rawArguments}";

            new CommandLineTester()
                .ExpectCommandName(commandName)
                .ExpectNoNamedArguments()
                .ExpectNoPositionalArguments()
                .ExpectFlag("flag1")
                .ExpectFlag("flag2")
                .ExpectFlag("flag3")
                .TestCommandLine(rawCommandLine);
        }

        [TestMethod]
        public void ParseDuplicateFlags()
        {
            const string rawCommandLine = "hello -flag1 -flag1";

            CommandLineParseException exception = TestUtils.TestForError<CommandLineParseException>(
                () => new CommandLineTester().TestCommandLine(rawCommandLine),
                "Did not catch expected error.");

            Assert.Validate.AreEqual(exception.Position, 14, "Error not found at correct index.");
        }

        [TestMethod]
        public void ParseSingleMixedArguments()
        {
            const string commandName = "hello";
            const string rawArguments = "positional1 -named1 value1 -flag1";
            string rawCommandLine = $"{commandName} {rawArguments}";

            new CommandLineTester()
                .ExpectCommandName(commandName)
                .ExpectNamedArgument("named1", "value1")
                .ExpectPositionalArgument("positional1")
                .ExpectFlag("flag1")
                .TestCommandLine(rawCommandLine);
        }

        [TestMethod]
        public void ParseMultipleMixedArguments()
        {
            const string commandName = "hello";
            const string rawArguments = "positional1 -named1 value1 -flag1 -flag2 -named2 value2 positional2 -flag3 -named3 value3 positional3";
            string rawCommandLine = $"{commandName} {rawArguments}";

            new CommandLineTester()
                .ExpectCommandName(commandName)
                .ExpectNamedArgument("named1", "value1")
                .ExpectNamedArgument("named2", "value2")
                .ExpectNamedArgument("named3", "value3")
                .ExpectPositionalArgument("positional1")
                .ExpectPositionalArgument("positional2")
                .ExpectPositionalArgument("positional3")
                .ExpectFlag("flag1")
                .ExpectFlag("flag2")
                .ExpectFlag("flag3")
                .TestCommandLine(rawCommandLine);
        }
        
        [TestMethod]
        public void NullArgumentName()
        {
            const string rawCommandLine = "hello - nextArgument";

            CommandLineParseException exception = TestUtils.TestForError<CommandLineParseException>(
                () => new CommandLineTester().TestCommandLine(rawCommandLine),
                "Did not catch expected error.");

            Assert.Validate.AreEqual(exception.Position, 7, "Error not found at correct index.");
        }

        [TestMethod]
        public void ArgumentNameWithInvalidCharacter()
        {
            const string rawCommandLine = "hello -argument$";

            CommandLineParseException exception = TestUtils.TestForError<CommandLineParseException>(
                () => new CommandLineTester().TestCommandLine(rawCommandLine),
                "Did not catch expected error.");

            Assert.Validate.AreEqual(exception.Position, 15, "Error not found at correct index.");
        }

        [TestMethod]
        public void ArgumentNameWithDoubleStartToken()
        {
            const string rawCommandLine = "hello --argument";

            CommandLineParseException exception = TestUtils.TestForError<CommandLineParseException>(
                () => new CommandLineTester().TestCommandLine(rawCommandLine),
                "Did not catch expected error.");

            Assert.Validate.AreEqual(exception.Position, 7, "Error not found at correct index.");
        }

        [TestMethod]
        public void EmptyCommandLine()
        {
            CommandLineParseException exception = TestUtils.TestForError<CommandLineParseException>(
                () => new CommandLineTester().TestCommandLine(string.Empty),
                "Did not catch expected error.");
            Assert.Validate.AreEqual(exception.Position, 0, "Error not found at correct index.");
        }
        
        [TestMethod]
        public void WhitespaceCommandLine()
        {
            const string rawCommandLine = "  \t  ";

            CommandLineParseException exception = TestUtils.TestForError<CommandLineParseException>(
                () => new CommandLineTester().TestCommandLine(rawCommandLine),
                "Did not catch expected error.");
            Assert.Validate.AreEqual(exception.Position, 0, "Error not found at correct index.");
        }

        [TestMethod]
        public void CommandNameWithInvalidCharacter()
        {
            const string rawCommandLine = "hello% -argument";

            CommandLineParseException exception = TestUtils.TestForError<CommandLineParseException>(
                () => new CommandLineTester().TestCommandLine(rawCommandLine),
                "Did not catch expected error.");

            Assert.Validate.AreEqual(exception.Position, 5, "Error not found at correct index.");
        }

        [TestMethod]
        public void CommandNameWithArgumentStartToken()
        {
            const string rawCommandLine = "-hello -argument";

            CommandLineParseException exception = TestUtils.TestForError<CommandLineParseException>(
                () => new CommandLineTester().TestCommandLine(rawCommandLine),
                "Did not catch expected error.");

            Assert.Validate.AreEqual(exception.Position, 0, "Error not found at correct index.");
        }

        [TestMethod]
        public void TrimWhitespaceNoArgs()
        {
            const string commandName = "hello";
            string rawCommandLine = $"\t    {commandName} \t    ";

            new CommandLineTester()
                .ExpectCommandName(commandName)
                .ExpectRawArguments(string.Empty)
                .ExpectRawCommandLine(rawCommandLine)
                .ExpectNoNamedArguments()
                .ExpectNoPositionalArguments()
                .ExpectNoFlags()
                .TestCommandLine(rawCommandLine);
        }

        [TestMethod]
        public void TrimWhitespaceWithArgs()
        {
            const string commandName = "hello";
            const string rawArguments = "there";
            string rawCommandLine = $"\t    {commandName} \t    {rawArguments}  \t  ";

            new CommandLineTester()
                .ExpectCommandName(commandName)
                .ExpectRawArguments(rawArguments)
                .ExpectRawCommandLine(rawCommandLine)
                .ExpectNoNamedArguments()
                .ExpectPositionalArgument("there")
                .ExpectNoFlags()
                .TestCommandLine(rawCommandLine);
        }
        
        [TestMethod]
        public void DoubleQuotedStringWithSpace()
        {
            const string rawCommandLine = "hello \"Quoted string with space\"";

            new CommandLineTester()
                .ExpectPositionalArgument("Quoted string with space")
                .TestCommandLine(rawCommandLine);
        }

        [TestMethod]
        public void SingleQuotedStringWithSpace()
        {
            const string rawCommandLine = "hello 'Quoted string with space'";

            new CommandLineTester()
                .ExpectPositionalArgument("Quoted string with space")
                .TestCommandLine(rawCommandLine);
        }

        [TestMethod]
        public void DoubleQuotedStringWithSingleQuotes()
        {
            const string rawCommandLine = "hello \"Quoted string 'with quotes'\"";

            new CommandLineTester()
                .ExpectPositionalArgument("Quoted string 'with quotes'")
                .TestCommandLine(rawCommandLine);
        }

        [TestMethod]
        public void SingleQuotedStringWithDoubleQuotes()
        {
            const string rawCommandLine = "hello 'Quoted string \"with quotes\"'";

            new CommandLineTester()
                .ExpectPositionalArgument("Quoted string \"with quotes\"")
                .TestCommandLine(rawCommandLine);
        }

        [TestMethod]
        public void DoubleQuotedStringWithEscapedQuotes()
        {
            const string rawCommandLine = "hello \"Quoted string \\\"with escaped quotes\\\"\"";

            new CommandLineTester()
                .ExpectPositionalArgument("Quoted string \"with escaped quotes\"")
                .TestCommandLine(rawCommandLine);
        }

        [TestMethod]
        public void SingleQuotedStringWithEscapedQuotes()
        {
            const string rawCommandLine = "hello 'Quoted string \\'with escaped quotes\\''";

            new CommandLineTester()
                .ExpectPositionalArgument("Quoted string 'with escaped quotes'")
                .TestCommandLine(rawCommandLine);
        }

        [TestMethod]
        public void Example1()
        {
            string rawCommandLine = "TestCommand -Named1 argument1 -Named2 \"argument \\\"2\\\"\"";

            new CommandLineTester()
                .ExpectCommandName("TestCommand")
                .ExpectNamedArgument("Named1", "argument1")
                .ExpectNamedArgument("Named2", "argument \"2\"")
                .ExpectNoPositionalArguments()
                .ExpectNoFlags()
                .TestCommandLine(rawCommandLine);
        }

        [TestMethod]
        public void Example2()
        {
            string rawCommandLine = "TestCommand -Flag1 -Flag2 -Named1 arg";
            
            new CommandLineTester()
                .ExpectCommandName("TestCommand")
                .ExpectNamedArgument("Named1", "arg")
                .ExpectNoPositionalArguments()
                .ExpectFlag("Flag1")
                .ExpectFlag("Flag2")
                .TestCommandLine(rawCommandLine);
        }
        
        [TestMethod]
        public void Example3()
        {
            string rawCommandLine = "TestCommand positional0 \"positional arg 1\" -Named1 named positional2 -Flag1";

            new CommandLineTester()
                .ExpectCommandName("TestCommand")
                .ExpectNamedArgument("Named1", "named")
                .ExpectPositionalArgument("positional0")
                .ExpectPositionalArgument("positional arg 1")
                .ExpectPositionalArgument("positional2")
                .ExpectFlag("Flag1")
                .TestCommandLine(rawCommandLine);
        }
        
        private class CommandLineTester
        {
            public string RawCommandLine { get; private set; }
            public string CommandName { get; private set; }
            public string RawArguments { get; private set; }
            public Dictionary<string, string> NamedArguments { get; private set; }
            public List<string> PositionalArguments { get; private set; }
            public HashSet<string> Flags { get; private set; }

            public CommandLine TestCommandLine(string commandLine)
            {
                CommandLine result = new CommandLine(commandLine);

                if(this.RawCommandLine != null)
                {
                    Assert.Validate.AreEqual(
                        this.RawCommandLine, 
                        result.RawCommandLine, 
                        "Expected raw command line not found.");
                }

                if (this.CommandName != null) {
                    Assert.Validate.AreEqual(
                        this.CommandName,
                        result.CommandName,
                        "Expected command name not found.");
                }

                if (this.RawArguments != null) {
                    Assert.Validate.AreEqual(
                        this.RawArguments,
                        result.RawArguments,
                        "Expected raw arguments not found.");
                }

                if (this.NamedArguments != null) {
                    Assert.Validate.AreEqual(
                        this.NamedArguments.Count,
                        result.NamedArguments.Count,
                        "Found incorrect number of named arguments.");
                    foreach(KeyValuePair<string, string> entry in this.NamedArguments)
                    {
                        Assert.Validate.IsTrue(
                            result.NamedArguments.ContainsKey(entry.Key),
                            $"Expected named argument '{entry.Key}' not found.");
                        Assert.Validate.AreEqual(
                            entry.Value,
                            result.NamedArguments[entry.Key],
                            $"Found incorrect value for named argument '{entry.Key}'.");
                    }
                }

                if (this.PositionalArguments != null) {
                    Assert.Validate.AreEqual(
                        this.PositionalArguments.Count,
                        result.PositionalArguments.Count,
                        "Found incorrect number of positional arguments.");
                    for(int i = 0; i < this.PositionalArguments.Count; i++) {
                        Assert.Validate.AreEqual(
                            this.PositionalArguments[i],
                            result.PositionalArguments[i],
                            $"Found incorrect value for positional argument ({i}).");
                    }
                }

                if (this.Flags != null) {
                    Assert.Validate.AreEqual(
                        this.Flags.Count,
                        result.Flags.Count,
                        "Found incorrect number of flags.");
                    foreach (string flag in this.Flags) {
                        Assert.Validate.IsTrue(
                            result.Flags.Contains(flag),
                            $"Expected flag '{flag}' not found.");
                    }
                }

                return result;
            }

            public CommandLineTester ExpectRawCommandLine(string rawCommandLine)
            {
                this.RawCommandLine = rawCommandLine;
                return this;
            }

            public CommandLineTester ExpectCommandName(string commandName)
            {
                this.CommandName = commandName;
                return this;
            }

            public CommandLineTester ExpectRawArguments(string rawArguments)
            {
                this.RawArguments = rawArguments;
                return this;
            }

            public CommandLineTester ExpectNamedArgument(string name, string value)
            {
                if (this.NamedArguments == null)
                {
                    this.NamedArguments = new Dictionary<string, string>();
                }

                this.NamedArguments.Add(name, value);
                return this;
            }

            public CommandLineTester ExpectNoNamedArguments()
            {
                this.NamedArguments = new Dictionary<string, string>();
                return this;
            }

            public CommandLineTester ExpectPositionalArgument(string value)
            {
                if (this.PositionalArguments == null)
                {
                    this.PositionalArguments = new List<string>();
                }

                this.PositionalArguments.Add(value);
                return this;
            }

            public CommandLineTester ExpectNoPositionalArguments()
            {
                this.PositionalArguments = new List<string>();
                return this;
            }

            public CommandLineTester ExpectFlag(string name)
            {
                if (this.Flags == null)
                {
                    this.Flags = new HashSet<string>();
                }

                this.Flags.Add(name);
                return this;
            }

            public CommandLineTester ExpectNoFlags()
            {
                this.Flags = new HashSet<string>();
                return this;
            }
        }
    }
}