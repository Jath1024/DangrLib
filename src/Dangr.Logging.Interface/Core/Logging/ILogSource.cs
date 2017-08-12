// -----------------------------------------------------------------------
//  <copyright file="ILogSource.cs" company="Phoenix Game Studios, LLC">
//      Copyright (c) 2017 Phoenix Game Studios, LLC. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/PhoenixGameStudios/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------
namespace Dangr.Core.Logging
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