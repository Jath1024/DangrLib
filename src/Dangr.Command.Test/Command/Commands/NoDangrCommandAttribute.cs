// -----------------------------------------------------------------------
//  <copyright file="NoDangrCommandAttribute.cs" company="DangerDan9631">
//      Copyright (c) 2017 Dan Garvey. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/Dangerdan9631/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.Command.Commands
{
    using Dangr.Core.Command;

    public class NoDangrCommandAttribute : IDangrCommand
    {
        public void Execute(ICommandContext executionContext)
        {
        }
    }
}