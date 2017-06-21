namespace Dangr.Command
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CommandTest
    {
        [TestMethod]
        public void CommandTest_CommandParsing()
        {
            string commandName = "commandName";
            string param1 = nameof(param1);
            string param2 = nameof(param2);
            string param3 = nameof(param3);

            string flag1 = nameof(flag1);
            string flag2 = nameof(flag2);

            string stringParam1 = "\"param with space\"";
            string stringParam2 = "\"param2 with space\"";
            string stringParamWithFlag = "\" -flaghere\"";
            string stringParamWithQuote = "'single quote string'";
            string stringParamWithEscape = "\"quoted string here \\\" and  \\\\ here.\"";
            string stringParamWithEscapeExpected = "\"quoted string here \" and  \\ here.\"";
            
            string stringParam1Sq = stringParam1.Replace('"', '\'');
            string stringParam2Sq = stringParam2.Replace('"', '\'');
            string stringParamWithFlagSq = stringParamWithFlag.Replace('"', '\'');
            string stringParamWithQuoteSq = stringParamWithQuote.Replace('"', '$').Replace("'", "\"").Replace('$', '\'');
            string stringParamWithEscapeSq = stringParamWithEscape.Replace('"', '\'');
            string stringParamWithEscapeExpectedSq = stringParamWithEscapeExpected.Replace('"', '\'');

            string currentTest = "CommandName";
            CommandLine cmd = new CommandLine($"{commandName}");
            Assert.IsTrue(commandName.Equals(cmd.CommandName, StringComparison.InvariantCultureIgnoreCase), $"{currentTest}: Command name does not match");

            currentTest = "CommandName trimming";
            cmd = new CommandLine($"\t{commandName} ");
            Assert.IsTrue(commandName.Equals(cmd.CommandName, StringComparison.InvariantCultureIgnoreCase), $"{currentTest}: Command name does not match");
            
            currentTest = "Parameters";
            cmd = new CommandLine($"\t{commandName} {param1} {param2} {param3}");
            Assert.IsTrue(commandName.Equals(cmd.CommandName, StringComparison.InvariantCultureIgnoreCase), $"{currentTest}: Command name does not match");
            Assert.IsTrue(param1.Equals(cmd.ArgumentList[0], StringComparison.InvariantCultureIgnoreCase), $"{currentTest}: parameter 1 does not match");
            Assert.IsTrue(param2.Equals(cmd.ArgumentList[1], StringComparison.InvariantCultureIgnoreCase), $"{currentTest}: parameter 2 does not match");
            Assert.IsTrue(param3.Equals(cmd.ArgumentList[2], StringComparison.InvariantCultureIgnoreCase), $"{currentTest}: parameter 3 does not match");
            Assert.AreEqual(cmd.ArgumentList.Count, 3, $"{currentTest}: Incorrect number of parameters");
            Assert.AreEqual(cmd.Flags.Count, 0, $"{currentTest}: Incorrect number of flags");

            currentTest = "Flags";
            cmd = new CommandLine($"\t{commandName} -{flag1} -{flag2}");
            Assert.IsTrue(commandName.Equals(cmd.CommandName, StringComparison.InvariantCultureIgnoreCase), $"{currentTest}: Command name does not match");
            Assert.IsTrue(cmd.Flags.Contains(flag1), $"{currentTest}: flag 1 not found");
            Assert.IsTrue(cmd.Flags.Contains(flag2), $"{currentTest}: flag 2 not found");
            Assert.AreEqual(cmd.ArgumentList.Count, 0, $"{currentTest}: Incorrect number of parameters");
            Assert.AreEqual(cmd.Flags.Count, 2, $"{currentTest}: Incorrect number of flags");
            
            currentTest = "Double Quotes";
            cmd = new CommandLine($"\t{commandName} {stringParam1} named:{stringParam2} {stringParamWithFlag} {stringParamWithQuote} {stringParamWithEscape}");
            Assert.IsTrue(commandName.Equals(cmd.CommandName, StringComparison.InvariantCultureIgnoreCase), $"{currentTest}: Command name does not match");
            Assert.IsTrue(stringParam1.Equals(cmd.ArgumentList[0], StringComparison.InvariantCultureIgnoreCase), $"{currentTest}: parameter 1 does not match");
            Assert.IsTrue(("named:" + stringParam2).Equals(cmd.ArgumentList[1], StringComparison.InvariantCultureIgnoreCase), $"{ currentTest}: parameter 2 does not match");
            Assert.IsTrue(stringParamWithFlag.Equals(cmd.ArgumentList[2], StringComparison.InvariantCultureIgnoreCase), $"{currentTest}: parameter 1 does not match");
            Assert.IsTrue(stringParamWithQuote.Equals(cmd.ArgumentList[3], StringComparison.InvariantCultureIgnoreCase), $"{currentTest}: parameter 1 does not match");
            Assert.IsTrue(stringParamWithEscapeExpected.Equals(cmd.ArgumentList[4], StringComparison.InvariantCultureIgnoreCase), $"{ currentTest}: parameter 2 does not match");
            Assert.AreEqual(cmd.ArgumentList.Count, 5, $"{currentTest}: Incorrect number of parameters");
            Assert.AreEqual(cmd.Flags.Count, 0, $"{currentTest}: Incorrect number of flags");
            
            currentTest = "Single Quotes";
            cmd = new CommandLine($"\t{commandName} {stringParam1Sq} named:{stringParam2Sq} {stringParamWithFlagSq} {stringParamWithQuoteSq} {stringParamWithEscapeSq}");
            Assert.IsTrue(commandName.Equals(cmd.CommandName, StringComparison.InvariantCultureIgnoreCase), $"{currentTest}: Command name does not match");
            Assert.IsTrue(stringParam1Sq.Equals(cmd.ArgumentList[0], StringComparison.InvariantCultureIgnoreCase), $"{currentTest}: parameter 1 does not match");
            Assert.IsTrue(("named:" + stringParam2Sq).Equals(cmd.ArgumentList[1], StringComparison.InvariantCultureIgnoreCase), $"{ currentTest}: parameter 2 does not match");
            Assert.IsTrue(stringParamWithFlagSq.Equals(cmd.ArgumentList[2], StringComparison.InvariantCultureIgnoreCase), $"{currentTest}: parameter 1 does not match");
            Assert.IsTrue(stringParamWithQuoteSq.Equals(cmd.ArgumentList[3], StringComparison.InvariantCultureIgnoreCase), $"{currentTest}: parameter 1 does not match");
            Assert.IsTrue(stringParamWithEscapeExpectedSq.Equals(cmd.ArgumentList[4], StringComparison.InvariantCultureIgnoreCase), $"{ currentTest}: parameter 2 does not match");
            Assert.AreEqual(cmd.ArgumentList.Count, 5, $"{currentTest}: Incorrect number of parameters");
            Assert.AreEqual(cmd.Flags.Count, 0, $"{currentTest}: Incorrect number of flags");
        }

        [TestMethod]
        public void CommandTest_CommandParsingErrors()
        {
            this.ParseCommandWithError("", CommandErrorCode.InvalidCommandName);
            this.ParseCommandWithError("[ello", CommandErrorCode.InvalidCommandName);
            this.ParseCommandWithError("he!!o?", CommandErrorCode.InvalidCommandName);
            this.ParseCommandWithError("command - argument2", CommandErrorCode.InvalidCommandArgument);
            this.ParseCommandWithError("command 'argument2", CommandErrorCode.InvalidCommandArgument);
            this.ParseCommandWithError("command 'argument2\\'", CommandErrorCode.InvalidCommandArgument);
            this.ParseCommandWithError("command \"argument2", CommandErrorCode.InvalidCommandArgument);
            this.ParseCommandWithError("command \"argument2\\\"", CommandErrorCode.InvalidCommandArgument);
            this.ParseCommandWithError("command -", CommandErrorCode.InvalidCommandArgument);
        }

        private void ParseCommandWithError(string commandLine, CommandErrorCode errorCode)
        {
            bool caughtException = false;
//            try
//            {
//                new CommandLine(commandLine);
//            }
//            catch (CommandException e) when (e.ErrorCode.Id.Equals(e.ErrorCode.Id))
//            {
//                caughtException = true;
//                Console.WriteLine($"Caught expected error: {e}");
//            }

            Assert.IsTrue(caughtException, $"Did not catch expected error {errorCode}");
        }
    }
}
