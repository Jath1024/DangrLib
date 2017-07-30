// -----------------------------------------------------------------------
//  <copyright file="WeakReferenceObjectPool.cs" company="DangerDan9631">
//      Copyright (c) 2017 Dan Garvey. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/Dangerdan9631/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.Core.ObjectPool
{
    using System;
    using System.Collections.Generic;
    using Dangr.Core.Collections;

    /// <summary>
    /// A generic implementation of an 
    /// <see cref="ObjectPool{T}" /> that uses 
    /// <see cref="System.WeakReference" /> s to store it's objects.
    /// </summary>
    /// <typeparam name="T">The type of objects to store.</typeparam>
    public class WeakReferenceObjectPool<T> : ObjectPool<T>
        where T : class, IPooledObject, new()
    {
        private readonly List<WeakReference> pool = new List<WeakReference>();
        private readonly object poolLock = new object();

        /// <summary>
        /// Clears all items from the <see cref="ObjectPool{T}" /> .
        /// </summary>
        public override void Clear()
        {
            lock (this.poolLock)
            {
                this.pool.Clear();
            }
        }

        /// <summary>
        /// Tries to get a reference to an object of type <typeparamref name="T"/>.
        /// </summary>
        /// <param name="obj">
        /// The reference to the object fetched from the <see cref="ObjectPool{T}" /> .
        /// </param>
        /// <returns><c> true </c> if a reference was fetched.</returns>
        protected override bool TryFetch(out T obj)
        {
            lock (this.poolLock)
            {
                while (this.pool.Count > 0)
                {
                    WeakReference objRef = this.pool.Dequeue();
                    obj = objRef.Target as T;
                    if (obj != null)
                    {
                        return true;
                    }
                }
            }

            obj = default(T);
            return false;
        }

        /// <summary>
        /// Tries to get a reference to an object of type <typeparamref name="T"/>.
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="obj">
        /// The reference to the object fetched from the <see cref="ObjectPool{T}" /> .
        /// </param>
        /// <returns><c> true </c> if a reference was fetched.</returns>
        protected override bool TryFetch(Predicate<T> condition, out T obj)
        {
            lock (this.poolLock)
            {
                for (int i = this.pool.Count - 1; i >= 0; i--)
                {
                    WeakReference objRef = this.pool[i];
                    obj = objRef.Target as T;
                    if (obj != null)
                    {
                        if (condition(obj))
                        {
                            this.pool.RemoveAt(i);
                            return true;
                        }
                    }
                    else
                    {
                        this.pool.RemoveAt(i);
                    }
                }
            }

            obj = default(T);
            return false;
        }

        /// <summary>
        /// Stores the given object in the <see cref="ObjectPool{T}" /> .
        /// </summary>
        /// <param name="obj">The object to store.</param>
        protected override void Store(T obj)
        {
            lock (this.poolLock)
            {
                this.pool.Add(new WeakReference(obj));
            }
        }
    }
}