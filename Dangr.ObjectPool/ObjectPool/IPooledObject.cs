// -----------------------------------------------------------------------
//  <copyright file="IPooledObject.cs" company="DangerDan9631">
//      Copyright (c) 2017 Dan Garvey. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/Dangerdan9631/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.ObjectPool
{
    /// <summary>
    /// Provides methods for acquiring and resetting items that can be used in
    /// an object pool.
    /// </summary>
    public interface IPooledObject
    {
        /// <summary>
        /// Acquires this <see cref="IPooledObject" /> instance as it is pulled from an <see cref="Dangr.ObjectPool.ObjectPool`1" /> . Should only be called by the <see cref="Dangr.ObjectPool.ObjectPool`1" /> .
        /// </summary>
        void Acquire();

        /// <summary>
        /// Resets this <see cref="IPooledObject" /> instance as it is returned to an <see cref="Dangr.ObjectPool.ObjectPool`1" /> . Should only be called by the <see cref="Dangr.ObjectPool.ObjectPool`1" /> .
        /// </summary>
        void Reset();
    }
}