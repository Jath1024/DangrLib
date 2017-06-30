// -----------------------------------------------------------------------
//  <copyright file="ILogService.cs" company="DangerDan9631">
//      Copyright (c) 2017 Dan Garvey. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/Dangerdan9631/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.Logging
{
    using Dangr.Util;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="T:Dangr.Logging.ILogger" />
    /// <seealso cref="T:Dangr.Logging.ILogSource" />
    /// <seealso cref="T:Dangr.Util.ICancelable" />
    public interface ILogService : ILogger, ILogSource, ICancelable
    {
    }
}