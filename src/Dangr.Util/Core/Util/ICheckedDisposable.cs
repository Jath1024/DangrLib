// -----------------------------------------------------------------------
//  <copyright file="ICheckedDisposable.cs" company="DangerDan9631">
//      Copyright (c) 2017 Dan Garvey. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/Dangerdan9631/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.Core.Util
{
    using System;

    /// <summary>
    /// Represents an IDisposable that can be checked for it's disposed state.
    /// </summary>
    public interface ICheckedDisposable : IDisposable
    {
        /// <summary>
        /// Gets a value that indicates whether the object is disposed.
        /// </summary>
        bool IsDisposed { get; }
    }
}