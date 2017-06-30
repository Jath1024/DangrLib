// -----------------------------------------------------------------------
//  <copyright file="PrivateSetterOnParameter.cs" company="DangerDan9631">
//      Copyright (c) 2017 Dan Garvey. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/Dangerdan9631/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.Command.Commands
{
    using Dangr.Command.Annotation;

    [DangrCommand("PrivateSetter", "A dangr command that has a parameter attribute on a property with a private setter."
     )]
    public class PrivateSetterOnParameter : IDangrCommand
    {
        [Parameter("A parameter with a private setter.")]
        public string Value { get; private set; }

        public void Execute(ICommandContext executionContext)
        {
        }
    }
}