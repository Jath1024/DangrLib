// -----------------------------------------------------------------------
//  <copyright file="FlexMap.cs" company="Phoenix Game Studios, LLC">
//      Copyright (c) 2017 Phoenix Game Studios, LLC. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/PhoenixGameStudios/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.Core.FlexCollections.Map
{
    using Dangr.Core.FlexCollections.Collection;

    public static class FlexMap
    {
        /// <summary>
        /// Provides read only covariant methods for the collection.
        /// </summary>
        /// <typeparam name="TKey">The type of key used to reference objects contained in the collection.</typeparam>
        /// <typeparam name="TValue">The type of object contained in the collection.</typeparam>
        public interface IReadOnlyCovariant
            <out TKey, out TValue> : FlexCollection.IReadOnlyCovariant<ICovarianttKeyValuePair<TKey, TValue>>
        {
        }

        /// <summary>
        /// Provides read only methods for the collection.
        /// </summary>
        /// <typeparam name="TKey">The type of key used to reference objects contained in the collection.</typeparam>
        /// <typeparam name="TValue">The type of object contained in the collection.</typeparam>
        public interface IReadOnly<TKey, TValue> : IReadOnlyCovariant<TKey, TValue>,
            FlexCollection.IReadOnly<ICovarianttKeyValuePair<TKey, TValue>>
        {
        }

        /// <summary>
        /// Provides covariant methods for the collection.
        /// </summary>
        /// <typeparam name="TKey">The type of key used to reference objects contained in the collection.</typeparam>
        /// <typeparam name="TValue">The type of object contained in the collection.</typeparam>
        public interface ICovariant<out TKey, out TValue> : IReadOnlyCovariant<TKey, TValue>,
            FlexCollection.ICovariant<ICovarianttKeyValuePair<TKey, TValue>>
        {
        }

        /// <summary>
        /// Provides generic methods for the collection.
        /// </summary>
        /// <typeparam name="TKey">The type of key used to reference objects contained in the collection.</typeparam>
        /// <typeparam name="TValue">The type of object contained in the collection.</typeparam>
        public interface IGeneric<TKey, TValue> : IReadOnly<TKey, TValue>,
            ICovariant<TKey, TValue>,
            FlexCollection.IGeneric<ICovarianttKeyValuePair<TKey, TValue>>
        {
        }
    }
}