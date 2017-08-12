// -----------------------------------------------------------------------
//  <copyright file="DangrCommandHelp.cs" company="Phoenix Game Studios, LLC">
//      Copyright (c) 2017 Phoenix Game Studios, LLC. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/PhoenixGameStudios/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------
namespace Dangr.Internal.Command.Commands
{
    using Dangr.Core.Command;
    using Dangr.Core.Command.Annotation;
    using Dangr.Core.Command.Exceptions;

    /// <summary>
    /// <see cref="IDangrCommand"/> that provides help for DangrCommands defined within the current command context.
    /// </summary>
    [DangrCommand("help", "Provides help for DangrCommands defined within the current command context.")]
    internal class DangrCommandHelp : IDangrCommand
    {
        /// <summary>
        /// Gets or sets the name of the command to display the help summary for.
        /// </summary>
        [Parameter("The name of the command to display the help summary for.", Mandatory = false, Position = 0)]
        public string CommandName { get; set; } = null;

        /// <summary>
        /// Executes this <see cref="IDangrCommand" />.
        /// </summary>
        /// <param name="executionContext"></param>
        public void Execute(ICommandContext executionContext)
        {
            if (this.CommandName == null)
            {
                executionContext.Output(executionContext.GetHelpText());
            }
            else
            {
                try
                {
                    executionContext.Output(executionContext.GetHelpText(this.CommandName));
                }
                catch (UnknownCommandException)
                {
                    executionContext.Error($"Could not find command with name '{this.CommandName}'");
                }
            }
        }
    }
}