// -----------------------------------------------------------------------
//  <copyright file="IDangrCommandFactory.cs" company="Phoenix Game Studios, LLC">
//      Copyright (c) 2017 Phoenix Game Studios, LLC. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/PhoenixGameStudios/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------
namespace Dangr.Core.Command
{
    /// <summary>
    /// Provides an interface for creating new <see cref="IDangrCommand"/> instances.
    /// </summary>
    public interface IDangrCommandFactory
    {
        /// <summary>
        /// Gets the name of the command.
        /// </summary>
        string CommandName { get; }

        /// <summary>
        /// Gets the summary of the command created by this <see cref="IDangrCommandFactory"/>.
        /// </summary>
        string CommandSummary { get; }

        /// <summary>
        /// Gets the help documentation for the command created by this <see cref="IDangrCommandFactory"/>.
        /// </summary>
        string CommandHelp { get; }

        /// <summary>
        /// Creates a new instance of the specified <see cref="IDangrCommand"/> using the given command line.
        /// </summary>
        /// <param name="commandLine">The command line.</param>
        /// <returns>A new <see cref="IDangrCommand"/> instance with parameters set from the given command line.</returns>
        IDangrCommand Create(CommandLine commandLine);
    }
}