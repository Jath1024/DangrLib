// -----------------------------------------------------------------------
//  <copyright file="IUidObject.cs" company="Phoenix Game Studios, LLC">
//      Copyright (c) 2017 Phoenix Game Studios, LLC. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/PhoenixGameStudios/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------
namespace Dangr.Core.Util
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