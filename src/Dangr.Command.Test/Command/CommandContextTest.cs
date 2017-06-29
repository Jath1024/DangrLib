// -----------------------------------------------------------------------
//  <copyright file="CommandContextTest.cs" company="DangerDan9631">
//      Copyright (c) 2017 Dan Garvey. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/Dangerdan9631/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.Command
{
    using System;
    using System.IO;
    using Dangr.Command.Commands;
    using Dangr.Command.Exceptions;
    using Dangr.Test;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Assert = Dangr.Diagnostics.Assert;

    [TestClass]
    public class CommandContextTest
    {
        [TestMethod]
        public void Execute_Output()
        {
            TextWriter outputStream = new StringWriter();
            TextWriter errorStream = new StringWriter();

            CommandContext context = new CommandContext("TestContext", outputStream, errorStream);
            context.AddCommand<OutputCommand>();
            context.Execute("Output hello");

            Assert.Validate.AreEqual("hello" + Environment.NewLine, outputStream.ToString(),
                "Did not find the expected output.");
        }

        [TestMethod]
        public void Execute_Error()
        {
            TextWriter outputStream = new StringWriter();
            TextWriter errorStream = new StringWriter();

            CommandContext context = new CommandContext("TestContext", outputStream, errorStream);
            context.AddCommand<ErrorCommand>();
            context.Execute("Error hello");

            Assert.Validate.AreEqual("hello" + Environment.NewLine, errorStream.ToString(),
                "Did not find the expected error.");
        }

        [TestMethod]
        public void Execute_UnknownCommand()
        {
            TextWriter outputStream = new StringWriter();
            TextWriter errorStream = new StringWriter();

            CommandContext context = new CommandContext("TestContext", outputStream, errorStream);
            context.AddCommand<OutputCommand>();

            UnknownCommandException exception = TestUtils.TestForError<UnknownCommandException>(
                () => context.Execute("Error hello"),
                "Did not catch expected exception");

            Assert.Validate.AreEqual("Error", exception.CommandName,
                "Error did not occur with the correct command.");
        }

        [TestMethod]
        public void ExecuteWithParentContext_Output()
        {
            TextWriter outputStream = new StringWriter();
            TextWriter errorStream = new StringWriter();

            CommandContext parentContext = new CommandContext("TestContext", outputStream, errorStream);
            CommandContext childContext = new CommandContext("ChildContext", parentContext);
            parentContext.AddCommand<OutputCommand>();
            childContext.Execute("Output hello");

            Assert.Validate.AreEqual("hello" + Environment.NewLine, outputStream.ToString(),
                "Did not find the expected output.");
        }

        [TestMethod]
        public void ExecuteWithParentContext_UnknownCommand()
        {
            TextWriter outputStream = new StringWriter();
            TextWriter errorStream = new StringWriter();

            CommandContext parentContext = new CommandContext("TestContext", outputStream, errorStream);
            CommandContext childContext = new CommandContext("ChildContext", parentContext);
            parentContext.AddCommand<OutputCommand>();

            UnknownCommandException exception = TestUtils.TestForError<UnknownCommandException>(
                () => childContext.Execute("Error hello"),
                "Did not catch expected exception");

            Assert.Validate.AreEqual("Error", exception.CommandName,
                "Error did not occur with the correct command.");
        }

        [TestMethod]
        public void ExecuteWithParentContext_HideParent()
        {
            TextWriter outputStream = new StringWriter();
            TextWriter errorStream = new StringWriter();

            CommandContext parentContext = new CommandContext("TestContext", outputStream, errorStream);
            CommandContext childContext = new CommandContext("ChildContext", parentContext);
            parentContext.AddCommand<DuplicateOutputCommand>();
            childContext.AddCommand<OutputCommand>();

            childContext.Execute("Output hello");

            Assert.Validate.AreEqual("hello" + Environment.NewLine, outputStream.ToString(),
                "Did not find the expected output.");
        }

        [TestMethod]
        public void AddCommand_Duplicate()
        {
            TextWriter outputStream = new StringWriter();
            TextWriter errorStream = new StringWriter();

            CommandContext context = new CommandContext("TestContext", outputStream, errorStream);
            context.AddCommand<OutputCommand>();
            ArgumentException exception = TestUtils.TestForError<ArgumentException>(
                () => context.AddCommand<DuplicateOutputCommand>(),
                "Did not catch expected exception.");
            Assert.Validate.AreEqual("DuplicateOutputCommand", exception.ParamName,
                "Exception occurred for wrong argument.");
        }
    }
}