// -----------------------------------------------------------------------
//  <copyright file="FlexArrayDeque.cs" company="Phoenix Game Studios, LLC">
//      Copyright (c) 2017 Phoenix Game Studios, LLC. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/PhoenixGameStudios/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.Core.FlexCollections.Deque
{
    using Dangr.Core.FlexCollections.Queue;

    public static class FlexArrayDeque
    {
        /// <summary>
        /// Provides read only covariant methods for the collection.
        /// </summary>
        /// <typeparam name="T">The type of object contained in the collection.</typeparam>
        public interface IReadOnlyCovariant
            <out T> : FlexDeque.IReadOnlyCovariant<T>, FlexArrayQueue.IReadOnlyCovariant<T>
        {
        }

        /// <summary>
        /// Provides read only methods for the collection.
        /// </summary>
        /// <typeparam name="T">The type of object contained in the collection.</typeparam>
        public interface IReadOnly<T> : IReadOnlyCovariant<T>, FlexDeque.IReadOnly<T>, FlexArrayQueue.IReadOnly<T>
        {
        }

        /// <summary>
        /// Provides covariant methods for the collection.
        /// </summary>
        /// <typeparam name="T">The type of object contained in the collection.</typeparam>
        public interface ICovariant
            <out T> : IReadOnlyCovariant<T>, FlexDeque.ICovariant<T>, FlexArrayQueue.ICovariant<T>
        {
        }

        /// <summary>
        /// Provides generic methods for the collection.
        /// </summary>
        /// <typeparam name="T">The type of object contained in the collection.</typeparam>
        public interface IGeneric<T> : IReadOnly<T>, ICovariant<T>, FlexDeque.IGeneric<T>, FlexArrayQueue.IGeneric<T>
        {
        }
    }
}