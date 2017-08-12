// -----------------------------------------------------------------------
//  <copyright file="DuplicateParameterName.cs" company="Phoenix Game Studios, LLC">
//      Copyright (c) 2017 Phoenix Game Studios, LLC. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/PhoenixGameStudios/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------
namespace Dangr.Command.Commands
{
    using Dangr.Core.Command;
    using Dangr.Core.Command.Annotation;

    [DangrCommand("DuplicateParameter", "A dangr command that has two parameters with the same name.")]
    public class DuplicateParameterName : IDangrCommand
    {
        [Parameter("A parameter.")]
        public string Value { get; set; }

        [Alias("Value")]
        [Parameter("A duplicate parameter.")]
        public string Value2 { get; set; }

        public void Execute(ICommandContext executionContext)
        {
        }
    }
}