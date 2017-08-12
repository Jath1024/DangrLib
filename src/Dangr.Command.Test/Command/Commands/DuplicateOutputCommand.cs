// -----------------------------------------------------------------------
//  <copyright file="DuplicateOutputCommand.cs" company="Phoenix Game Studios, LLC">
//      Copyright (c) 2017 Phoenix Game Studios, LLC. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/PhoenixGameStudios/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------
namespace Dangr.Command.Commands
{
    using System;
    using Dangr.Core.Command;
    using Dangr.Core.Command.Annotation;

    [DangrCommand("Output", "A dangr command with a duplicate name.")]
    public class DuplicateOutputCommand : IDangrCommand
    {
        public void Execute(ICommandContext executionContext)
        {
            throw new InvalidOperationException("DuplicateOutputCommand should not have been executed.");
        }
    }
}