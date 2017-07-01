// -----------------------------------------------------------------------
//  <copyright file="ILogSource.cs" company="DangerDan9631">
//      Copyright (c) 2017 Dan Garvey. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/Dangerdan9631/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.Logging
{
    /// <summary>
    /// Provides methods for logging messages that come from the object.
    /// </summary>
    public interface ILogSource
    {
        /// <summary>
        /// Gets the <see cref="ILogger"/> used when logging from this <see cref="ILogSource"/>.
        /// </summary>
        ILogger Logger { get; }

        /// <summary>
        /// Gets the log category of this <see cref="ILogSource" /> used when logging.
        /// </summary>
        string LogCategory { get; }
    }
}