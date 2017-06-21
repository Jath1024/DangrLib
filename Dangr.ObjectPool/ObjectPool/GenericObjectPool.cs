// -----------------------------------------------------------------------
//  <copyright file="GenericObjectPool.cs" company="DangerDan9631">
//      Copyright (c) 2017 Dan Garvey. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/Dangerdan9631/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
//  <dateCreated>2017-04-24</dateCreated>
//  <dateModified>2017-06-20</dateModified>
//  <lastModifiedBy>Dan Garvey</lastModifiedBy>
// -----------------------------------------------------------------------

namespace Dangr.ObjectPool
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Dangr.Collections;

    /// <summary>
    /// A generic implementation of an 
    /// <see cref="Dangr.ObjectPool.ObjectPool`1" /> .
    /// </summary>
    /// <typeparam name="T">The type of objects to store.</typeparam>
    public class GenericObjectPool<T> : ObjectPool<T>
        where T : IPooledObject, new()
    {
        private readonly List<T> pool = new List<T>();
        private readonly object poolLock = new object();

        /// <summary>
        /// Clears all items from the <see cref="Dangr.ObjectPool.ObjectPool`1" /> .
        /// </summary>
        public override void Clear()
        {
            lock (this.poolLock)
            {
                this.pool.Clear();
            }
        }

        /// <summary>
        /// Tries to get a reference to an object of type <see cref="T" /> .
        /// </summary>
        /// <param name="obj">
        /// The reference to the object fetched from the <see cref="Dangr.ObjectPool.ObjectPool`1" /> .
        /// </param>
        /// <returns><c> true </c> if a reference was fetched.</returns>
        protected override bool TryFetch(out T obj)
        {
            lock (this.poolLock)
            {
                if (this.pool.Count > 0)
                {
                    obj = this.pool.Dequeue();
                    return true;
                }
            }

            obj = default(T);
            return false;
        }

        /// <summary>
        /// Tries to get a reference to an object of type <see cref="T" /> .
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="obj">
        /// The reference to the object fetched from the <see cref="Dangr.ObjectPool.ObjectPool`1" /> .
        /// </param>
        /// <returns><c> true </c> if a reference was fetched.</returns>
        protected override bool TryFetch(Predicate<T> condition, out T obj)
        {
            lock (this.poolLock)
            {
                foreach (T tempObj in this.pool.Where(tempObj => condition(tempObj)))
                {
                    obj = tempObj;
                    return true;
                }
            }

            obj = default(T);
            return false;
        }

        /// <summary>
        /// Stores the given object in the <see cref="Dangr.ObjectPool.ObjectPool`1" /> .
        /// </summary>
        /// <param name="obj">The object to store.</param>
        protected override void Store(T obj)
        {
            lock (this.poolLock)
            {
                this.pool.Add(obj);
            }
        }
    }
}