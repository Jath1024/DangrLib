// -----------------------------------------------------------------------
//  <copyright file="FlexList.cs" company="Phoenix Game Studios, LLC">
//      Copyright (c) 2017 Phoenix Game Studios, LLC. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/PhoenixGameStudios/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.Core.FlexCollections.List
{
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

            T Get(int index);
            int IndexOf(object item);
            int IndexOf(object item, int start);
            int IndexOf(object item, int start, int count);
        }

        /// <summary>
        /// Provides read only methods for the collection.
        /// </summary>
        /// <typeparam name="T">The type of object contained in the collection.</typeparam>
        public interface IReadOnly<T> : IReadOnlyCovariant<T>, FlexCollection.IReadOnly<T>
        {
            int IndexOf(T item);
            int IndexOf(T item, int start);
            int IndexOf(T item, int start, int count);
        }

        /// <summary>
        /// Provides covariant methods for the collection.
        /// </summary>
        /// <typeparam name="T">The type of object contained in the collection.</typeparam>
        public interface ICovariant<out T> : IReadOnlyCovariant<T>, FlexCollection.ICovariant<T>
        {
            void RemoveAt(int index);
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

            void Set(int index, T value);
            void Insert(int index, T value);
            void InsertAll(int index, IEnumerable<T> values);
        }
    }
}