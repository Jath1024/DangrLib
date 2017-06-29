// -----------------------------------------------------------------------
//  <copyright file="IDangrCommand.cs" company="DangerDan9631">
//      Copyright (c) 2017 Dan Garvey. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/Dangerdan9631/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.Command
{
    /// <summary>
    /// Defines a command that can be executed.
    /// </summary>
    public interface IDangrCommand
    {
        /// <summary>
        /// Executes this <see cref="IDangrCommand"/> using the specified <see cref="ICommandContext"/>.
        /// </summary>
        void Execute(ICommandContext executionContext);
    }
}