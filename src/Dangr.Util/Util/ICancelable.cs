// -----------------------------------------------------------------------
//  <copyright file="ICancelable.cs" company="DangerDan9631">
//      Copyright (c) 2017 Dan Garvey. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/Dangerdan9631/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.Util
{
    using System;

    /// <summary>
    /// Disposable resource with dipsosal state tracking.
    /// </summary>
    public interface ICancelable : IDisposable
    {
        /// <summary>
        /// Gets a value that indicates whether the object is disposed.
        /// </summary>
        bool IsDisposed { get; }
    }
}