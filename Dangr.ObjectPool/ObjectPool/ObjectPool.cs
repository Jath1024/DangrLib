// -----------------------------------------------------------------------
//  <copyright file="ObjectPool.cs" company="DangerDan9631">
//      Copyright (c) 2017 Dan Garvey. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/Dangerdan9631/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.ObjectPool
{
    using System;

    /// <summary>
    /// Abstract class used to store a pool of objects that can be reused.
    /// </summary>
    /// <typeparam name="T">The type of objects to store.</typeparam>
    public abstract class ObjectPool<T>
        where T : IPooledObject, new()
    {
        /// <summary>
        /// Gets the first available object from the <see cref="Dangr.ObjectPool.ObjectPool`1" /> .
        /// </summary>
        /// <returns>
        /// The first available object from the <see cref="Dangr.ObjectPool.ObjectPool`1" /> .
        /// </returns>
        public T Get()
        {
            T pooledObject;
            if (!this.TryFetch(out pooledObject))
            {
                pooledObject = this.Create();
            }

            pooledObject.Acquire();
            return pooledObject;
        }

        /// <summary>
        /// Gets the first available object from the <see cref="Dangr.ObjectPool.ObjectPool`1" /> that matches the given <see cref="System.Predicate`1" /> .
        /// </summary>
        /// <param name="condition">
        /// The <see cref="System.Predicate`1" /> to match.
        /// </param>
        /// <returns>
        /// The first available object from the <see cref="Dangr.ObjectPool.ObjectPool`1" /> .
        /// </returns>
        public T Get(Predicate<T> condition)
        {
            T pooledObject;
            if (!this.TryFetch(condition, out pooledObject))
            {
                pooledObject = this.Create();
            }

            pooledObject.Acquire();
            return pooledObject;
        }

        /// <summary>
        /// Returns the specified object to the <see cref="Dangr.ObjectPool.ObjectPool`1" /> .
        /// </summary>
        /// <param name="obj">The object to return.</param>
        public void Return(T obj)
        {
            obj.Reset();
            this.Store(obj);
        }

        /// <summary>
        /// Creates a new instance of the pooled object.
        /// </summary>
        /// <returns>A new instance of the pooled object.</returns>
        protected virtual T Create()
        {
            return new T();
        }

        /// <summary>
        /// Clears all items from the <see cref="Dangr.ObjectPool.ObjectPool`1" /> .
        /// </summary>
        public abstract void Clear();

        /// <summary>
        /// Tries to get a reference to an object of type <see cref="T" /> .
        /// </summary>
        /// <param name="obj">
        /// The reference to the object fetched from the <see cref="Dangr.ObjectPool.ObjectPool`1" /> .
        /// </param>
        /// <returns><c> true </c> if a reference was fetched.</returns>
        protected abstract bool TryFetch(out T obj);

        /// <summary>
        /// <para>Tries to get a reference to an object of type <see cref="T" /> that matches the given <see cref="System.Predicate`1" /></para>
        /// <para>.</para>
        /// </summary>
        /// <param name="condition">
        /// The condition that the fetched object should match.
        /// </param>
        /// <param name="obj">
        /// The reference to the object fetched from the <see cref="Dangr.ObjectPool.ObjectPool`1" /> .
        /// </param>
        /// <returns><c> true </c> if a reference was fetched.</returns>
        protected abstract bool TryFetch(Predicate<T> condition, out T obj);

        /// <summary>
        /// Stores the given object in the <see cref="Dangr.ObjectPool.ObjectPool`1" /> .
        /// </summary>
        /// <param name="obj">The object to store.</param>
        protected abstract void Store(T obj);
    }
}