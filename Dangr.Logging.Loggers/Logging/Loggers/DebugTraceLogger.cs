// -----------------------------------------------------------------------
//  <copyright file="DebugTraceLogger.cs" company="DangerDan9631">
//      Copyright (c) 2017 Dan Garvey. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/Dangerdan9631/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.Logging.Loggers
{
    using System.Diagnostics;

    /// <summary>
    /// Logger pipeline logger that will log a message to the debug trace
    /// </summary>
    public class DebugTraceLogger : ILogEndpoint
    {
        /// <summary>
        /// Logs the specified entry.
        /// </summary>
        /// <param name="entry">The entry.</param>
        public void Log(LogEntry entry)
        {
            Debug.WriteLine(entry.ToString());
        }
    }
}