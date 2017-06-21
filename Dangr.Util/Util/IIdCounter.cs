// -----------------------------------------------------------------------
//  <copyright file="IIdCounter.cs" company="DangerDan9631">
//      Copyright (c) 2017 Dan Garvey. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/Dangerdan9631/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
//  <dateCreated>2017-04-24</dateCreated>
//  <dateModified>2017-06-20</dateModified>
//  <lastModifiedBy>Dan Garvey</lastModifiedBy>
// -----------------------------------------------------------------------

namespace Dangr.Util
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