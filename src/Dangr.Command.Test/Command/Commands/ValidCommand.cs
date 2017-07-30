// -----------------------------------------------------------------------
//  <copyright file="ValidCommand.cs" company="DangerDan9631">
//      Copyright (c) 2017 Dan Garvey. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/Dangerdan9631/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.Command.Commands
{
    using Dangr.Core.Command;
    using Dangr.Core.Command.Annotation;

    [DangrCommand("ValidCommand", "A valid dangr command.")]
    public class ValidCommand : IDangrCommand
    {
        [Parameter("A parameter at position 0", Mandatory = false, Position = 0)]
        public string Parameter0 { get; set; }

        [Parameter("A parameter at position 1", Mandatory = false, Position = 1)]
        public string Parameter1 { get; set; }

        [Parameter("A named parameter", Mandatory = false)]
        [Alias("name")]
        public string Named0 { get; set; }

        [Parameter("A Mandatory parameter", Mandatory = true)]
        public string MandatoryArg { get; set; }

        [Parameter("A flag parameter", Mandatory = false)]
        public bool Flag0 { get; set; }

        public string SkipThisProperty { get; set; }

        public void Execute(ICommandContext executionContext)
        {
            executionContext.Output(
                $"P0: {this.Parameter0} P1: {this.Parameter1} Named0: {this.Named0} MandatoryArg: {this.MandatoryArg} Flag0: {this.Flag0}");
        }
    }
}