// -----------------------------------------------------------------------
//  <copyright file="IdCounterOutOfRangeException.cs" company="Phoenix Game Studios, LLC">
//      Copyright (c) 2017 Phoenix Game Studios, LLC. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/PhoenixGameStudios/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------
namespace Dangr.Core.Util
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// Exception thrown when an <see cref="IdCounter" /> attempts to get an ID
    /// outside of its specified range.
    /// </summary>
    [Serializable]
    public class IdCounterOutOfRangeException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IdCounterOutOfRangeException" /> class.
        /// </summary>
        /// <param name="min">
        /// The minimum value for the <see cref="IdCounter" /> .
        /// </param>
        /// <param name="max">
        /// The maximum value for the <see cref="IdCounter" /> .
        /// </param>
        /// <param name="next">
        /// The next value for the <see cref="IdCounter" /> .
        /// </param>
        public IdCounterOutOfRangeException(ulong min, ulong max, ulong next)
            : base($"ID counter value '{next}' is outside of the range [{min}, {max}]")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IdCounterOutOfRangeException" /> class.
        /// </summary>
        /// <param name="info">
        /// The <see cref="System.Runtime.Serialization.SerializationInfo" /> that holds the serialized object data about the exception being thrown.
        /// </param>
        /// <param name="context">
        /// The <see cref="System.Runtime.Serialization.StreamingContext" /> that contains contextual information about the source or destination.
        /// </param>
        protected IdCounterOutOfRangeException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}