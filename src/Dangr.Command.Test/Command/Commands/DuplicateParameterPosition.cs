// -----------------------------------------------------------------------
//  <copyright file="DuplicateParameterPosition.cs" company="Phoenix Game Studios, LLC">
//      Copyright (c) 2017 Phoenix Game Studios, LLC. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/PhoenixGameStudios/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------
namespace Dangr.Command.Commands
{
    using Dangr.Core.Command;
    using Dangr.Core.Command.Annotation;

    [DangrCommand("DuplicateParameterPosition", "A dangr command that has two parameters with the same position.")]
    public class DuplicateParameterPosition : IDangrCommand
    {
        [Parameter("A parameter.", Position = 0)]
        public string Value { get; set; }

        [Parameter("A duplicate parameter.", Position = 0)]
        public string Value2 { get; set; }

        public void Execute(ICommandContext executionContext)
        {
        }
    }
}