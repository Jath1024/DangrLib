// -----------------------------------------------------------------------
//  <copyright file="ICommandContext.cs" company="DangerDan9631">
//      Copyright (c) 2017 Dan Garvey. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/Dangerdan9631/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.Command
{
    using Dangr.Util;

    /// <summary>
    /// Defines the methods that an <see cref="IDangrCommand"/> can invoke within the context that it is running.
    /// </summary>
    public interface ICommandContext : INamedObject
    {
        /// <summary>
        /// Executes the specified command line.
        /// </summary>
        /// <param name="commandString">The command line.</param>
        void Execute(string commandString);

        /// <summary>
        /// Outputs the specified object to the <see cref="ICommandContext"/> output stream.
        /// </summary>
        /// <param name="output">The output.</param>
        void Output(object output);

        /// <summary>
        /// Outputs the specified object to the <see cref="ICommandContext"/> error stream.
        /// </summary>
        /// <param name="error">The error.</param>
        void Error(object error);

        /// <summary>
        /// Gets the help text for all of the <see cref="IDangrCommand"/>s defined in the <see cref="ICommandContext"/>.
        /// </summary>
        /// <returns>The help text for all of the <see cref="IDangrCommand"/>s defined in the <see cref="ICommandContext"/>.</returns>
        string GetHelpText();

        /// <summary>
        /// Gets the help text for the specified <see cref="IDangrCommand"/>s defined in the <see cref="ICommandContext"/>.
        /// </summary>
        /// <param name="commandName">Name of the command.</param>
        /// <returns>The help text for the specified <see cref="IDangrCommand"/>s defined in the <see cref="ICommandContext"/>.</returns>
        string GetHelpText(string commandName);
    }
}