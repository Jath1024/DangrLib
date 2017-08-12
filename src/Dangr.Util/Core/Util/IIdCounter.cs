// -----------------------------------------------------------------------
//  <copyright file="IIdCounter.cs" company="Phoenix Game Studios, LLC">
//      Copyright (c) 2017 Phoenix Game Studios, LLC. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/PhoenixGameStudios/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------
namespace Dangr.Core.Util
{
    /// <summary>
    /// Interface for a counter that keeps track of the next ID within a range
    /// of IDs.
    /// </summary>
    public interface IIdCounter
    {
        /// <summary>
        /// Gets the next available ID.
        /// </summary>
        /// <exception cref="IdCounterOutOfRangeException">
        /// If the next value would be larger than the max value of this <see cref="IdCounter" /> .
        /// </exception>
        /// <returns>The next available Id.</returns>
        ulong GetId();
    }
}