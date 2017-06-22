// -----------------------------------------------------------------------
//  <copyright file="IUidObject.cs" company="DangerDan9631">
//      Copyright (c) 2017 Dan Garvey. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/Dangerdan9631/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.Util
{
    /// <summary>
    /// Defines a property to retrieve an identifier unique to this object
    /// within a specific group.
    /// </summary>
    public interface IUidObject
    {
        /// <summary>
        /// Gets the UID of this <see cref="IUidObject" /> .
        /// </summary>
        ulong Uid { get; }
    }
}