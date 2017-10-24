// -----------------------------------------------------------------------
//  <copyright file="FlexArrayList.cs" company="Phoenix Game Studios, LLC">
//      Copyright (c) 2017 Phoenix Game Studios, LLC. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/PhoenixGameStudios/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.Core.FlexCollections.List
{
    public static class FlexArrayList
    {
        /// <summary>
        /// The default capacity of a FlexArrayList.
        /// </summary>
        public const int DEFAULT_CAPACITY = 10;

        /// <summary>
        /// Provides read only covariant methods for the collection.
        /// </summary>
        /// <typeparam name="T">The type of object contained in the collection.</typeparam>
        public interface IReadOnlyCovariant<out T> : FlexList.IReadOnlyCovariant<T>
        {
            /// <summary>
            /// Gets the current capacity of the array list.
            /// </summary>
            int Capacity { get; }
        }

        /// <summary>
        /// Provides read only methods for the collection.
        /// </summary>
        /// <typeparam name="T">The type of object contained in the collection.</typeparam>
        public interface IReadOnly<T> : IReadOnlyCovariant<T>, FlexList.IReadOnly<T>
        {
        }

        /// <summary>
        /// Provides covariant methods for the collection.
        /// </summary>
        /// <typeparam name="T">The type of object contained in the collection.</typeparam>
        public interface ICovariant<out T> : IReadOnlyCovariant<T>, FlexList.ICovariant<T>
        {
        }

        /// <summary>
        /// Provides generic methods for the collection.
        /// </summary>
        /// <typeparam name="T">The type of object contained in the collection.</typeparam>
        public interface IGeneric<T> : IReadOnly<T>, ICovariant<T>, FlexList.IGeneric<T>
        {
        }
    }
}