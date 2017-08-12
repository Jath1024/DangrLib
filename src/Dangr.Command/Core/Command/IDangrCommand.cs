// -----------------------------------------------------------------------
//  <copyright file="IDangrCommand.cs" company="Phoenix Game Studios, LLC">
//      Copyright (c) 2017 Phoenix Game Studios, LLC. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/PhoenixGameStudios/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------
namespace Dangr.Core.Command
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