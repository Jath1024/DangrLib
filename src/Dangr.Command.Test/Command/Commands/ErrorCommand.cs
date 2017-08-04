﻿// -----------------------------------------------------------------------
//  <copyright file="ErrorCommand.cs" company="DangerDan9631">
//      Copyright (c) 2017 Dan Garvey. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/Dangerdan9631/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.Command.Commands
{
    using Dangr.Core.Command;
    using Dangr.Core.Command.Annotation;

    [DangrCommand("Error", "A dangr command that writes a value to error.")]
    public class ErrorCommand : IDangrCommand
    {
        [Parameter("The value to output.", Mandatory = true, Position = 0)]
        public string Value { get; set; }

        public void Execute(ICommandContext executionContext)
        {
            executionContext.Error(this.Value);
        }
    }
}