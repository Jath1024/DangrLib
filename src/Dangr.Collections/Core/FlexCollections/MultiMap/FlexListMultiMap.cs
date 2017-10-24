﻿// -----------------------------------------------------------------------
//  <copyright file="FlexListMultiMap.cs" company="Phoenix Game Studios, LLC">
//      Copyright (c) 2017 Phoenix Game Studios, LLC. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/PhoenixGameStudios/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.Core.FlexCollections.MultiMap
{
    public static class FlexListMultiMap
    {
        /// <summary>
        /// Provides read only covariant methods for the collection.
        /// </summary>
        /// <typeparam name="TKey">The type of key used to reference objects contained in the collection.</typeparam>
        /// <typeparam name="TValue">The type of object contained in the collection.</typeparam>
        public interface IReadOnlyCovariant<out TKey, out TValue>
            : FlexMultiMap.IReadOnlyCovariant<TKey, TValue>
        {
        }

        /// <summary>
        /// Provides read only methods for the collection.
        /// </summary>
        /// <typeparam name="TKey">The type of key used to reference objects contained in the collection.</typeparam>
        /// <typeparam name="TValue">The type of object contained in the collection.</typeparam>
        public interface IReadOnly<TKey, TValue>
            : IReadOnlyCovariant<TKey, TValue>, FlexMultiMap.IReadOnly<TKey, TValue>
        {
        }

        /// <summary>
        /// Provides covariant methods for the collection.
        /// </summary>
        /// <typeparam name="TKey">The type of key used to reference objects contained in the collection.</typeparam>
        /// <typeparam name="TValue">The type of object contained in the collection.</typeparam>
        public interface ICovariant<out TKey, out TValue>
            : IReadOnlyCovariant<TKey, TValue>, FlexMultiMap.ICovariant<TKey, TValue>
        {
        }

        /// <summary>
        /// Provides generic methods for the collection.
        /// </summary>
        /// <typeparam name="TKey">The type of key used to reference objects contained in the collection.</typeparam>
        /// <typeparam name="TValue">The type of object contained in the collection.</typeparam>
        public interface IGeneric<TKey, TValue>
            : IReadOnly<TKey, TValue>, ICovariant<TKey, TValue>, FlexMultiMap.IGeneric<TKey, TValue>
        {
        }
    }
}