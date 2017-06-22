// -----------------------------------------------------------------------
//  <copyright file="ILogEndpoint.cs" company="DangerDan9631">
//      Copyright (c) 2017 Dan Garvey. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/Dangerdan9631/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.Logging
{
    /// <summary>
    /// Interface for an object that will perform an action with a log entry.
    /// </summary>
    public interface ILogEndpoint
    {
        /// <summary>
        /// Logs the specified entry.
        /// </summary>
        /// <param name="entry">The entry.</param>
        void Log(LogEntry entry);
    }
}