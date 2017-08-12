// -----------------------------------------------------------------------
//  <copyright file="PrivateSetterOnParameter.cs" company="Phoenix Game Studios, LLC">
//      Copyright (c) 2017 Phoenix Game Studios, LLC. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/PhoenixGameStudios/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------
namespace Dangr.Command.Commands
{
    using Dangr.Core.Command;
    using Dangr.Core.Command.Annotation;

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