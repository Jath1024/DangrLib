// -----------------------------------------------------------------------
//  <copyright file="TypeCommand.cs" company="Phoenix Game Studios, LLC">
//      Copyright (c) 2017 Phoenix Game Studios, LLC. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/PhoenixGameStudios/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------
namespace Dangr.Command.Commands
{
    using Dangr.Core.Command;
    using Dangr.Core.Command.Annotation;

    [DangrCommand("Types", "A dangr command with many typed arguments.")]
    public class TypeCommand : IDangrCommand
    {
        [Parameter("A decimal parameter", Mandatory = false)]
        public decimal Decimal { get; set; }

        [Parameter("A double parameter", Mandatory = false)]
        public double Double { get; set; }

        [Parameter("A float parameter", Mandatory = false)]
        public float Float { get; set; }

        [Parameter("A long parameter", Mandatory = false)]
        public long Long { get; set; }

        [Parameter("An int parameter", Mandatory = false)]
        public int Int { get; set; }

        [Parameter("A String parameter", Mandatory = false)]
        public string String { get; set; }

        [Parameter("A boolean flag parameter", Mandatory = false)]
        public bool Bool { get; set; }

        public void Execute(ICommandContext executionContext)
        {
        }
    }
}