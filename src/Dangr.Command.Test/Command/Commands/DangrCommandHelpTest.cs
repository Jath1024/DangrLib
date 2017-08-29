// -----------------------------------------------------------------------
//  <copyright file="DangrCommandHelpTest.cs" company="Phoenix Game Studios, LLC">
//      Copyright (c) 2017 Phoenix Game Studios, LLC. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/PhoenixGameStudios/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------
namespace Dangr.Command.Commands
{
    using System;
    using System.IO;
    using Dangr.Core.Command;
    using Dangr.Core.Diagnostics;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class DangrCommandHelpTest
    {
        [TestMethod]
        public void ShowHelp()
        {
            TextWriter outputStream = new StringWriter();
            TextWriter errorStream = new StringWriter();

            CommandExecutor executor = new CommandExecutor("TestContext", outputStream, errorStream);
            executor.AddCommand<OutputCommand>();
            executor.Execute("help help");

            Validate.Value.IsNotNullOrWhiteSpace(outputStream.ToString(),
                "Did not find the expected output.");
            Validate.Value.IsNullOrWhiteSpace(errorStream.ToString(),
                "Should not have written value to error.");
            Console.WriteLine(outputStream.ToString());
        }

        [TestMethod]
        public void ShowHelp_All()
        {
            TextWriter outputStream = new StringWriter();
            TextWriter errorStream = new StringWriter();

            CommandExecutor executor = new CommandExecutor("TestContext", outputStream, errorStream);
            executor.AddCommand<OutputCommand>();
            executor.Execute("help");

            Validate.Value.IsNotNullOrWhiteSpace(outputStream.ToString(),
                "Did not find the expected output.");
            Validate.Value.IsNullOrWhiteSpace(errorStream.ToString(),
                "Should not have written value to error.");
            Console.WriteLine(outputStream.ToString());
        }

        [TestMethod]
        public void ShowHelp_InvalidCommand()
        {
            TextWriter outputStream = new StringWriter();
            TextWriter errorStream = new StringWriter();

            CommandExecutor executor = new CommandExecutor("TestContext", outputStream, errorStream);
            executor.AddCommand<OutputCommand>();
            executor.Execute("help invalid");

            Validate.Value.IsNullOrWhiteSpace(outputStream.ToString(),
                "Should not have written value to output.");
            Validate.Value.IsNotNullOrWhiteSpace(errorStream.ToString(),
                "Did not find the expected error output.");
            Console.WriteLine(errorStream.ToString());
        }
    }
}