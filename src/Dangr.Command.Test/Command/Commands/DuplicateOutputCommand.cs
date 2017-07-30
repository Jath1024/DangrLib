// -----------------------------------------------------------------------
//  <copyright file="DuplicateOutputCommand.cs" company="DangerDan9631">
//      Copyright (c) 2017 Dan Garvey. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/Dangerdan9631/DangrLib/blob/master/LICENSE for full license information.
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