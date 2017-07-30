// -----------------------------------------------------------------------
//  <copyright file="TestEndpoint.cs" company="DangerDan9631">
//      Copyright (c) 2017 Dan Garvey. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/Dangerdan9631/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.Framework.Logging
{
    using Dangr.Core.Logging;
    using Dangr.Logging;

    public class TestEndpoint : ILogEndpoint
    {
        public int NumMessagesLogged { get; private set; }

        /// <summary>
        /// Logs the specified entry.
        /// </summary>
        /// <param name="entry">The entry.</param>
        public void Log(LogEntry entry)
        {
            this.NumMessagesLogged++;
        }
    }
}