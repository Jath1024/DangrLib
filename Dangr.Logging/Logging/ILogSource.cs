// -----------------------------------------------------------------------
//  <copyright file="ILogSource.cs" company="DangerDan9631">
//      Copyright (c) 2017 Dan Garvey. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/Dangerdan9631/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
//  <dateCreated>2017-04-24</dateCreated>
//  <dateModified>2017-06-20</dateModified>
//  <lastModifiedBy>Dan Garvey</lastModifiedBy>
// -----------------------------------------------------------------------

namespace Dangr.Logging
{
    /// <summary>
    /// Interface for an object that can log messages.
    /// </summary>
    public interface ILogSource
    {
        /// <summary>
        /// Gets the logger used when logging from this source.
        /// </summary>
        ILogger Logger { get; }

        /// <summary>
        /// Gets the log category of this <see cref="ILogSource" /> used when logging.
        /// </summary>
        string LogCategory { get; }
    }
}