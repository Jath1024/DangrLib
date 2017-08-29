// -----------------------------------------------------------------------
//  <copyright file="CommandContextTest.cs" company="Phoenix Game Studios, LLC">
//      Copyright (c) 2017 Phoenix Game Studios, LLC. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/PhoenixGameStudios/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------
namespace Dangr.Command
{
    using System;
    using System.IO;
    using Dangr.Command.Commands;
    using Dangr.Core.Command;
    using Dangr.Core.Command.Exceptions;
    using Dangr.Core.Diagnostics;
    using Dangr.Core.Test;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CommandContextTest
    {
        [TestMethod]
        public void Execute_Output()
        {
            TextWriter outputStream = new StringWriter();
            TextWriter errorStream = new StringWriter();

            CommandExecutor executor = new CommandExecutor("TestContext", outputStream, errorStream);
            executor.AddCommand<OutputCommand>();
            executor.Execute("Output hello");

            Validate.Value.AreEqual("hello" + Environment.NewLine, outputStream.ToString(),
                "Did not find the expected output.");
        }

        [TestMethod]
        public void Execute_Error()
        {
            TextWriter outputStream = new StringWriter();
            TextWriter errorStream = new StringWriter();

            CommandExecutor executor = new CommandExecutor("TestContext", outputStream, errorStream);
            executor.AddCommand<ErrorCommand>();
            executor.Execute("Error hello");

            Validate.Value.AreEqual("hello" + Environment.NewLine, errorStream.ToString(),
                "Did not find the expected error.");
        }

        [TestMethod]
        public void Execute_UnknownCommand()
        {
            TextWriter outputStream = new StringWriter();
            TextWriter errorStream = new StringWriter();

            CommandExecutor executor = new CommandExecutor("TestContext", outputStream, errorStream);
            executor.AddCommand<OutputCommand>();

            UnknownCommandException exception = TestUtils.TestForError<UnknownCommandException>(
                () => executor.Execute("Error hello"),
                "Did not catch expected exception");

            Validate.Value.AreEqual("Error", exception.CommandName,
                "Error did not occur with the correct command.");
        }

        [TestMethod]
        public void ExecuteWithParentContext_Output()
        {
            TextWriter outputStream = new StringWriter();
            TextWriter errorStream = new StringWriter();

            CommandExecutor parentExecutor = new CommandExecutor("TestContext", outputStream, errorStream);
            CommandExecutor childExecutor = new CommandExecutor("ChildContext", parentExecutor);
            parentExecutor.AddCommand<OutputCommand>();
            childExecutor.Execute("Output hello");

            Validate.Value.AreEqual("hello" + Environment.NewLine, outputStream.ToString(),
                "Did not find the expected output.");
        }

        [TestMethod]
        public void ExecuteWithParentContext_UnknownCommand()
        {
            TextWriter outputStream = new StringWriter();
            TextWriter errorStream = new StringWriter();

            CommandExecutor parentExecutor = new CommandExecutor("TestContext", outputStream, errorStream);
            CommandExecutor childExecutor = new CommandExecutor("ChildContext", parentExecutor);
            parentExecutor.AddCommand<OutputCommand>();

            UnknownCommandException exception = TestUtils.TestForError<UnknownCommandException>(
                () => childExecutor.Execute("Error hello"),
                "Did not catch expected exception");

            Validate.Value.AreEqual("Error", exception.CommandName,
                "Error did not occur with the correct command.");
        }

        [TestMethod]
        public void ExecuteWithParentContext_HideParent()
        {
            TextWriter outputStream = new StringWriter();
            TextWriter errorStream = new StringWriter();

            CommandExecutor parentExecutor = new CommandExecutor("TestContext", outputStream, errorStream);
            CommandExecutor childExecutor = new CommandExecutor("ChildContext", parentExecutor);
            parentExecutor.AddCommand<DuplicateOutputCommand>();
            childExecutor.AddCommand<OutputCommand>();

            childExecutor.Execute("Output hello");

            Validate.Value.AreEqual("hello" + Environment.NewLine, outputStream.ToString(),
                "Did not find the expected output.");
        }

        [TestMethod]
        public void AddCommand_Duplicate()
        {
            TextWriter outputStream = new StringWriter();
            TextWriter errorStream = new StringWriter();

            CommandExecutor executor = new CommandExecutor("TestContext", outputStream, errorStream);
            executor.AddCommand<OutputCommand>();
            ArgumentException exception = TestUtils.TestForError<ArgumentException>(
                () => executor.AddCommand<DuplicateOutputCommand>(),
                "Did not catch expected exception.");
            Validate.Value.AreEqual("DuplicateOutputCommand", exception.ParamName,
                "Exception occurred for wrong argument.");
        }

        [TestMethod]
        public void Example1()
        {
            TextWriter outputStream = new StringWriter();
            TextWriter errorStream = new StringWriter();

            CommandExecutor executor = new CommandExecutor("TestContext", outputStream, errorStream);
            executor.AddCommand<OutputCommand>();
            executor.Execute("Output 'hello world'");

            Validate.Value.AreEqual("hello world" + Environment.NewLine, outputStream.ToString(),
                "Did not find the expected output.");
        }

        [TestMethod]
        public void Example2()
        {
            TextWriter outputStream = new StringWriter();
            TextWriter errorStream = new StringWriter();

            CommandExecutor parentExecutor = new CommandExecutor("TestContext", outputStream, errorStream);
            CommandExecutor childExecutor = new CommandExecutor("ChildContext", parentExecutor);
            parentExecutor.AddCommand<OutputCommand>();
            childExecutor.Execute("Output 'hello world'");

            Validate.Value.AreEqual("hello world" + Environment.NewLine, outputStream.ToString(),
                "Did not find the expected output.");
        }
    }
}