// -----------------------------------------------------------------------
//  <copyright file="DuplicateParameterName.cs" company="DangerDan9631">
//      Copyright (c) 2017 Dan Garvey. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/Dangerdan9631/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.Command.Commands
{
    using Dangr.Command.Annotation;

    [DangrCommand("DuplicateParameter", "A dangr command that has two parameters with the same name.")]
    public class DuplicateParameterName : IDangrCommand
    {
        [Parameter("A parameter.")]
        public string Value { get; set; }

        [Alias("Value")]
        [Parameter("A duplicate parameter.")]
        public string Value2 { get; set; }

        public void Execute(ICommandContext executionContext)
        { }
    }
}