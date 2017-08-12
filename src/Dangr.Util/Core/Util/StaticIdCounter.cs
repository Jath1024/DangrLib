// -----------------------------------------------------------------------
//  <copyright file="StaticIdCounter.cs" company="Phoenix Game Studios, LLC">
//      Copyright (c) 2017 Phoenix Game Studios, LLC. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/PhoenixGameStudios/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------
namespace Dangr.Core.Util
{
    /// <summary>
    /// An <see cref="IIdCounter" /> that contains a single ID.
    /// </summary>
    public class StaticIdCounter : IIdCounter
    {
        private readonly ulong value;

        /// <summary>
        /// Initializes a new instance of the <see cref="StaticIdCounter" /> .
        /// </summary>
        /// <param name="value">
        /// The value tracked by this <see cref="StaticIdCounter" /> .
        /// </param>
        public StaticIdCounter(ulong value)
        {
            this.value = value;
        }

        /// <summary>
        /// Gets the next available ID.
        /// </summary>
        /// <returns>The next available Id.</returns>
        public ulong GetId()
        {
            return this.value;
        }
    }
}