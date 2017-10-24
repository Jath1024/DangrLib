// -----------------------------------------------------------------------
//  <copyright file="FlexContainer.cs" company="Phoenix Game Studios, LLC">
//      Copyright (c) 2017 Phoenix Game Studios, LLC. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/PhoenixGameStudios/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.Core.FlexCollections.Container
{
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// Defines interfaces for an object that contains other objects and can be searched.
    /// </summary>
    public static class FlexContainer
    {
        /// <summary>
        /// Provides read only covariant methods for the collection.
        /// </summary>
        /// <typeparam name="T">The type of objects contained inside the instance.</typeparam>
        public interface IReadOnlyCovariant<out T>
            : IEnumerable<T>, IFlexCountable
        {
            /// <summary>
            /// Determines whether the instance contains the specified item.
            /// </summary>
            /// <param name="item">The item.</param>
            /// <returns>
            ///   <c>true</c> if the instance contains the specified item; otherwise, <c>false</c>.
            /// </returns>
            bool Contains(object item);

            /// <summary>
            /// Determines whether the instance contains any of the specified items.
            /// </summary>
            /// <param name="items">The items.</param>
            /// <returns>
            ///   <c>true</c> if the instance contains any of the specified items; otherwise, <c>false</c>.
            /// </returns>
            bool ContainsAny(IEnumerable items);

            /// <summary>
            /// Determines whether the instance contains all of the specified items.
            /// </summary>
            /// <param name="items">The items.</param>
            /// <returns>
            ///   <c>true</c> if the instance contains all of the specified items; otherwise, <c>false</c>.
            /// </returns>
            bool ContainsAll(IEnumerable items);
        }

        /// <summary>
        /// Provides read only methods for the collection.
        /// </summary>
        /// <typeparam name="T">The type of object contained in the collection.</typeparam>
        public interface IReadOnly<T> : IReadOnlyCovariant<T>
        {
            /// <summary>
            /// Determines whether the instance contains the specified item.
            /// </summary>
            /// <param name="item">The item.</param>
            /// <returns>
            ///   <c>true</c> if the instance contains the specified item; otherwise, <c>false</c>.
            /// </returns>
            bool Contains(T item);

            /// <summary>
            /// Determines whether the instance contains any of the specified items.
            /// </summary>
            /// <param name="items">The items.</param>
            /// <returns>
            ///   <c>true</c> if the instance contains any of the specified items; otherwise, <c>false</c>.
            /// </returns>
            bool ContainsAny(IEnumerable<T> items);

            /// <summary>
            /// Determines whether the instance contains all of the specified items.
            /// </summary>
            /// <param name="items">The items.</param>
            /// <returns>
            ///   <c>true</c> if the instance contains all of the specified items; otherwise, <c>false</c>.
            /// </returns>
            bool ContainsAll(IEnumerable<T> items);
        }

        /// <summary>
        /// Provides covariant methods for the collection.
        /// </summary>
        /// <typeparam name="T">The type of object contained in the collection.</typeparam>
        public interface ICovariant<out T> : IReadOnlyCovariant<T>
        {
            /// <summary>
            /// Removes all instances from the collection.
            /// </summary>
            void Clear();
        }

        /// <summary>
        /// Provides generic methods for the collection.
        /// </summary>
        /// <typeparam name="T">The type of object contained in the collection.</typeparam>
        public interface IGeneric<T> : IReadOnly<T>, ICovariant<T>
        {
        }
    }
}