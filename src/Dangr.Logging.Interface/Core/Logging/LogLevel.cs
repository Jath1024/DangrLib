// -----------------------------------------------------------------------
//  <copyright file="LogLevel.cs" company="Phoenix Game Studios, LLC">
//      Copyright (c) 2017 Phoenix Game Studios, LLC. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/PhoenixGameStudios/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------
namespace Dangr.Core.Logging
{
    /// <summary>
    /// Defines the possible log levels.
    /// </summary>
    public enum LogLevel
    {
        /// <summary>
        /// A message used to display debug level information.
        /// </summary>
        Debug,

        /// <summary>
        /// A message used to display a change in status.
        /// </summary>
        Status,

        /// <summary>
        /// A message with detailed information.
        /// </summary>
        Verbose,

        /// <summary>
        /// A message with standard information.
        /// </summary>
        Info,

        /// <summary>
        /// A warning message.
        /// </summary>
        Warning,

        /// <summary>
        /// A message for a non-fatal error.
        /// </summary>
        Critical,

        /// <summary>
        /// A message for a fatal error.
        /// </summary>
        Fatal
    }
}