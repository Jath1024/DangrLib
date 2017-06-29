// -----------------------------------------------------------------------
//  <copyright file="DangrCommandHelp.cs" company="DangerDan9631">
//      Copyright (c) 2017 Dan Garvey. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/Dangerdan9631/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.Command.Commands
{
    using Dangr.Command.Annotation;
    using Dangr.Command.Exceptions;

    /// <summary>
    /// <see cref="IDangrCommand"/> that provides help for DangrCommands defined within the current command context.
    /// </summary>
    [DangrCommand("help", "Provides help for DangrCommands defined within the current command context.")]
    public class DangrCommandHelp : IDangrCommand
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