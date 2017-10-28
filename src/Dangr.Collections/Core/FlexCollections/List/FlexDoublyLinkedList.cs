// -----------------------------------------------------------------------
//  <copyright file="FlexDoublyLinkedList.cs" company="Phoenix Game Studios, LLC">
//      Copyright (c) 2017 Phoenix Game Studios, LLC. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/PhoenixGameStudios/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.Core.FlexCollections.List
{
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// Defines interfaces for a <see cref="FlexList"/> that uses a doubly linked list of nodes as its internal data store.
    /// </summary>
    public static class FlexDoublyLinkedList
    {
        /// <summary>
        /// Provides read only covariant methods for the collection.
        /// </summary>
        /// <typeparam name="T">The type of object contained in the collection.</typeparam>
        public interface IReadOnlyCovariant<out T> : FlexLinkedList.IReadOnlyCovariant<T>
        {
            /// <summary>
            /// Returns an enumerator that iterates through the collection in reverse.
            /// </summary>
            /// <returns>An enumerator that can be used to iterate through the collection in reverse.</returns>
            IEnumerator<T> GetReverseEnumerator();
        }

        /// <summary>
        /// Provides read only methods for the collection.
        /// </summary>
        /// <typeparam name="T">The type of object contained in the collection.</typeparam>
        public interface IReadOnly<T> : IReadOnlyCovariant<T>, FlexLinkedList.IReadOnly<T>
        {
        }

        /// <summary>
        /// Provides covariant methods for the collection.
        /// </summary>
        /// <typeparam name="T">The type of object contained in the collection.</typeparam>
        public interface ICovariant<out T> : IReadOnlyCovariant<T>, FlexLinkedList.ICovariant<T>
        {
        }

        /// <summary>
        /// Provides generic methods for the collection.
        /// </summary>
        /// <typeparam name="T">The type of object contained in the collection.</typeparam>
        public interface IGeneric<T> : IReadOnly<T>, ICovariant<T>, FlexLinkedList.IGeneric<T>
        {
        }
    }
}