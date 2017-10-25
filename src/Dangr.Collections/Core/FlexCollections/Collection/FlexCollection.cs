// -----------------------------------------------------------------------
//  <copyright file="FlexCollection.cs" company="Phoenix Game Studios, LLC">
//      Copyright (c) 2017 Phoenix Game Studios, LLC. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/PhoenixGameStudios/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.Core.FlexCollections.Collection
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Dangr.Core.FlexCollections.Container;

    /// <summary>
    /// Defines interfaces for a <see cref="FlexContainer"/> that objects can be added to or removed from.
    /// </summary>
    public static class FlexCollection
    {
        /// <summary>
        /// Provides read only covariant methods for the collection.
        /// </summary>
        /// <typeparam name="T">The type of object contained in the collection.</typeparam>
        public interface IReadOnlyCovariant<out T>
            : FlexContainer.IReadOnlyCovariant<T>
        {
        }

        /// <summary>
        /// Provides read only methods for the collection.
        /// </summary>
        /// <typeparam name="T">The type of object contained in the collection.</typeparam>
        public interface IReadOnly<T> : IReadOnlyCovariant<T>, FlexContainer.IReadOnly<T>
        {
        }

        /// <summary>
        /// Provides covariant methods for the collection.
        /// </summary>
        /// <typeparam name="T">The type of object contained in the collection.</typeparam>
        public interface ICovariant<out T> : IReadOnlyCovariant<T>, FlexContainer.ICovariant<T>
        {
            /// <summary>
            /// Removes the specified item from the collection.
            /// </summary>
            /// <param name="item">The item to remove.</param>
            /// <returns><c>true</c> if the item was found and removed. <c>false</c> if the item was not found.</returns>
            bool Remove(object item);

            /// <summary>
            /// Removes all of the specified items from the collection.
            /// </summary>
            /// <param name="items">The items to remove.</param>
            /// <returns>The number of items that were found and removed from the collection.</returns>
            int RemoveAll(IEnumerable items);

            /// <summary>
            /// Removes the all items the match the specified condition.
            /// </summary>
            /// <param name="predicate">The predicate to match the items.</param>
            /// <returns>The number of items that were found and removed from the collection.</returns>
            int RemoveWhere(Predicate<object> predicate);
        }

        /// <summary>
        /// Provides generic methods for the collection.
        /// </summary>
        /// <typeparam name="T">The type of object contained in the collection.</typeparam>
        public interface IGeneric<T> : IReadOnly<T>, ICovariant<T>, FlexContainer.IGeneric<T>
        {
            /// <summary>
            /// Adds the specified item to the collection.
            /// </summary>
            /// <param name="item">The item to add to the collection.</param>
            void Add(T item);

            /// <summary>
            /// Adds all of the specified items to the collection.
            /// </summary>
            /// <param name="items">The items to add to the collection.</param>
            void AddAll(IEnumerable<T> items);

            /// <summary>
            /// Removes the specified item from the collection.
            /// </summary>
            /// <param name="item">The item to remove.</param>
            /// <returns><c>true</c> if the item was found and removed. <c>false</c> if the item was not found.</returns>
            bool Remove(T item);

            /// <summary>
            /// Removes all of the specified items from the collection.
            /// </summary>
            /// <param name="items">The items to remove.</param>
            /// <returns>The number of items that were found and removed from the collection.</returns>
            int RemoveAll(IEnumerable<T> items);

            /// <summary>
            /// Removes the all items the match the specified condition.
            /// </summary>
            /// <param name="predicate">The predicate to match the items.</param>
            /// <returns>The number of items that were found and removed from the collection.</returns>
            int RemoveWhere(Predicate<T> predicate);
        }
    }
}