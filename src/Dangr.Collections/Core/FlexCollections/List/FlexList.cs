// -----------------------------------------------------------------------
//  <copyright file="FlexList.cs" company="Phoenix Game Studios, LLC">
//      Copyright (c) 2017 Phoenix Game Studios, LLC. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/PhoenixGameStudios/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.Core.FlexCollections.List
{
    using System;
    using System.Collections.Generic;
    using Dangr.Core.FlexCollections.Collection;

    /// <summary>
    /// Defines interfaces for an ordered <see cref="FlexCollection"/> where objects can be retrieved, inserted, or removed by index.
    /// </summary>
    public static class FlexList
    {
        /// <summary>
        /// The magic number returned to indicate that the index of a value could not be found. 
        /// Usually because the value does not exist in the FlexList.
        /// </summary>
        public const int INDEX_NOT_FOUND = -1;

        /// <summary>
        /// Provides read only covariant methods for the collection.
        /// </summary>
        /// <typeparam name="T">The type of object contained in the collection.</typeparam>
        public interface IReadOnlyCovariant<out T>
            : FlexCollection.IReadOnlyCovariant<T>
        {
            /// <summary>
            /// Gets or sets the object at the specified index.
            /// </summary>
            /// <param name="index">The index of the item.</param>
            /// <returns>The object at the specified index.</returns>
            /// <exception cref="ArgumentOutOfRangeException">Thrown if the index is &lt; 0 or &gt;= Count.</exception>
            T this[int index] { get; }

            /// <summary>
            /// Gets the object at the specified index.
            /// </summary>
            /// <param name="index">The index of the item.</param>
            /// <returns>The object at the specified index.</returns>
            /// <exception cref="ArgumentOutOfRangeException">Thrown if the index is &lt; 0 or &gt;= Count.</exception>
            T Get(int index);

            /// <summary>
            /// Gets the first object in the collection.
            /// </summary>
            /// <returns>The first item in the collection.</returns>
            /// <exception cref="InvalidOperationException">Thrown if the collection is empty.</exception>
            T GetFirst();

            /// <summary>
            /// Gets the last object in the collection.
            /// </summary>
            /// <returns>The last item in the collection or null if the collection is empty.</returns>
            /// <exception cref="InvalidOperationException">Thrown if the collection is empty.</exception>
            T GetLast();

            /// <summary>
            /// Gets the index of the specified item.
            /// </summary>
            /// <param name="item">The item.</param>
            /// <returns>
            /// The index of the specified item, or <see cref="FlexList.INDEX_NOT_FOUND"/> if the item is
            /// not a part of the collection.
            /// </returns>
            int IndexOf(object item);

            /// <summary>
            /// Gets the index of the specified item.
            /// </summary>
            /// <param name="item">The item.</param>
            /// <param name="start">The index to start searching for the object.</param>
            /// <returns>
            /// The index of the specified item, or <see cref="FlexList.INDEX_NOT_FOUND"/> if the item is
            /// not a part of the collection in the specified range.
            /// </returns>
            /// <exception cref="ArgumentOutOfRangeException">Thrown if the start is &lt; 0 or &gt;= Count.</exception>
            int IndexOf(object item, int start);

            /// <summary>
            /// Gets the index of the specified item.
            /// </summary>
            /// <param name="item">The item.</param>
            /// <param name="start">The index to start searching for the object.</param>
            /// <param name="count">The number of items after and including the start index to search for the object.</param>
            /// <returns>
            /// The index of the specified item, or <see cref="FlexList.INDEX_NOT_FOUND"/> if the item is
            /// not a part of the collection in the specified range.
            /// </returns>
            /// <exception cref="ArgumentOutOfRangeException">Thrown if the start is &lt; 0 or &gt;= Count.</exception>
            int IndexOf(object item, int start, int count);

            /// <summary>
            /// Gets the index of the last occurrence of the specified item.
            /// </summary>
            /// <param name="item">The item.</param>
            /// <returns>
            /// The index of the specified item, or <see cref="FlexList.INDEX_NOT_FOUND"/> if the item is
            /// not a part of the collection in the specified range.
            /// </returns>
            int LastIndexOf(object item);

            /// <summary>
            /// Gets the index of the last occurrence of the specified item.
            /// </summary>
            /// <param name="item">The item.</param>
            /// <param name="end">The index to end searching for the object.</param>
            /// <returns>
            /// The index of the specified item, or <see cref="FlexList.INDEX_NOT_FOUND"/> if the item is
            /// not a part of the collection in the specified range.
            /// </returns>
            /// <exception cref="ArgumentOutOfRangeException">Thrown if the end is &lt; 0 or &gt;= Count.</exception>
            int LastIndexOf(object item, int end);

            /// <summary>
            /// Gets the index of the last occurrence of the specified item.
            /// </summary>
            /// <param name="item">The item.</param>
            /// <param name="end">The index to end searching for the object.</param>
            /// <param name="count">The number of items before and including the end index to search for the object.</param>
            /// <returns>
            /// The index of the specified item, or <see cref="FlexList.INDEX_NOT_FOUND"/> if the item is
            /// not a part of the collection in the specified range.
            /// </returns>
            /// <exception cref="ArgumentOutOfRangeException">Thrown if the end is &lt; 0 or &gt;= Count.</exception>
            int LastIndexOf(object item, int end, int count);
        }

        /// <summary>
        /// Provides read only methods for the collection.
        /// </summary>
        /// <typeparam name="T">The type of object contained in the collection.</typeparam>
        public interface IReadOnly<T> : IReadOnlyCovariant<T>, FlexCollection.IReadOnly<T>
        {
            /// <summary>
            /// Gets the index of the specified item.
            /// </summary>
            /// <param name="item">The item.</param>
            /// <returns>
            /// The index of the specified item, or <see cref="FlexList.INDEX_NOT_FOUND"/> if the item is
            /// not a part of the collection.
            /// </returns>
            int IndexOf(T item);

            /// <summary>
            /// Gets the index of the specified item.
            /// </summary>
            /// <param name="item">The item.</param>
            /// <param name="start">The index to start searching for the object.</param>
            /// <returns>
            /// The index of the specified item, or <see cref="FlexList.INDEX_NOT_FOUND"/> if the item is
            /// not a part of the collection in the specified range.
            /// </returns>
            /// <exception cref="ArgumentOutOfRangeException">Thrown if the start is &lt; 0 or &gt;= Count.</exception>
            int IndexOf(T item, int start);

            /// <summary>
            /// Gets the index of the specified item.
            /// </summary>
            /// <param name="item">The item.</param>
            /// <param name="start">The index to start searching for the object.</param>
            /// <param name="count">The number of items after and including the start index to search for the object.</param>
            /// <returns>
            /// The index of the specified item, or <see cref="FlexList.INDEX_NOT_FOUND"/> if the item is
            /// not a part of the collection in the specified range.
            /// </returns>
            /// <exception cref="ArgumentOutOfRangeException">Thrown if the start is &lt; 0 or &gt;= Count.</exception>
            int IndexOf(T item, int start, int count);
            
            /// <summary>
            /// Gets the index of the last occurrence of the specified item.
            /// </summary>
            /// <param name="item">The item.</param>
            /// <returns>
            /// The index of the specified item, or <see cref="FlexList.INDEX_NOT_FOUND"/> if the item is
            /// not a part of the collection in the specified range.
            /// </returns>
            int LastIndexOf(T item);

            /// <summary>
            /// Gets the index of the last occurrence of the specified item.
            /// </summary>
            /// <param name="item">The item.</param>
            /// <param name="end">The index to end searching for the object.</param>
            /// <returns>
            /// The index of the specified item, or <see cref="FlexList.INDEX_NOT_FOUND"/> if the item is
            /// not a part of the collection in the specified range.
            /// </returns>
            /// <exception cref="ArgumentOutOfRangeException">Thrown if the end is &lt; 0 or &gt;= Count.</exception>
            int LastIndexOf(T item, int end);

            /// <summary>
            /// Gets the index of the last occurrence of the specified item.
            /// </summary>
            /// <param name="item">The item.</param>
            /// <param name="end">The index to end searching for the object.</param>
            /// <param name="count">The number of items before and including the end index to search for the object.</param>
            /// <returns>
            /// The index of the specified item, or <see cref="FlexList.INDEX_NOT_FOUND"/> if the item is
            /// not a part of the collection in the specified range.
            /// </returns>
            /// <exception cref="ArgumentOutOfRangeException">Thrown if the end is &lt; 0 or &gt;= Count.</exception>
            int LastIndexOf(T item, int end, int count);
        }

        /// <summary>
        /// Provides covariant methods for the collection.
        /// </summary>
        /// <typeparam name="T">The type of object contained in the collection.</typeparam>
        public interface ICovariant<out T> : IReadOnlyCovariant<T>, FlexCollection.ICovariant<T>
        {
            /// <summary>
            /// Removes the last occurrence of the specified element from the collection.
            /// </summary>
            /// <returns><c>true</c> if an item was removed, otherwise false.</returns>
            bool RemoveLast(object item);

            /// <summary>
            /// Removes the object at the specified index.
            /// </summary>
            /// <param name="index">The index to remove the item at.</param>
            /// <exception cref="ArgumentOutOfRangeException">Thrown if the index is &lt; 0 or &gt;= Count.</exception>
            void RemoveAt(int index);

            /// <summary>
            /// Removes the first element from the collection.
            /// </summary>
            /// <returns><c>true</c> if an item was removed, otherwise false.</returns>
            bool RemoveFirstElement();

            /// <summary>
            /// Removes the last element from the collection.
            /// </summary>
            /// <returns><c>true</c> if an item was removed, otherwise false.</returns>
            bool RemoveLastElement();
        }

        /// <summary>
        /// Provides generic methods for the collection.
        /// </summary>
        /// <typeparam name="T">The type of object contained in the collection.</typeparam>
        public interface IGeneric<T> : IReadOnly<T>, ICovariant<T>, FlexCollection.IGeneric<T>
        {
            /// <summary>
            /// Gets or sets the object at the specified index.
            /// </summary>
            /// <param name="index">The index of the item.</param>
            /// <returns>The object at the specified index.</returns>
            /// <exception cref="ArgumentOutOfRangeException">Thrown if the index is &lt; 0 or &gt;= Count.</exception>
            new T this[int index] { get; set; }

            /// <summary>
            /// Sets the value at the specified index.
            /// </summary>
            /// <param name="index">The index.</param>
            /// <param name="value">The value.</param>
            /// <exception cref="ArgumentOutOfRangeException">Thrown if the index is &lt; 0 or &gt;= Count.</exception>
            void Set(int index, T value);

            /// <summary>
            /// Inserts the given value at the specified index.
            /// </summary>
            /// <param name="index">The index.</param>
            /// <param name="value">The value.</param>
            /// <exception cref="ArgumentOutOfRangeException">Thrown if the index is &lt; 0 or &gt;= Count.</exception>
            void Insert(int index, T value);

            /// <summary>
            /// Inserts all the given values at the specified index.
            /// </summary>
            /// <param name="index">The index.</param>
            /// <param name="values">The values.</param>
            /// <exception cref="ArgumentOutOfRangeException">Thrown if the index is &lt; 0 or &gt;= Count.</exception>
            void InsertAll(int index, IEnumerable<T> values);

            /// <summary>
            /// Removes the last occurrence of the specified element from the collection.
            /// </summary>
            /// <returns><c>true</c> if an item was removed, otherwise false.</returns>
            bool RemoveLast(T item);
        }
    }
}