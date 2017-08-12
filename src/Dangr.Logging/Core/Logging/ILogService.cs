// -----------------------------------------------------------------------
//  <copyright file="ILogService.cs" company="Phoenix Game Studios, LLC">
//      Copyright (c) 2017 Phoenix Game Studios, LLC. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/PhoenixGameStudios/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------
namespace Dangr.Core.Logging
{
    using Dangr.Core.Util;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="T:Dangr.Logging.ILogger" />
    /// <seealso cref="T:Dangr.Logging.ILogSource" />
    /// <seealso cref="T:Dangr.Util.ICheckedDisposable" />
    public interface ILogService : ILogger, ILogSource, ICheckedDisposable
    {
    }
}