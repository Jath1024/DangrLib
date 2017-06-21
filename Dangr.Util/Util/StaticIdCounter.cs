﻿// -----------------------------------------------------------------------
//  <copyright file="StaticIdCounter.cs" company="DangerDan9631">
//      Copyright (c) 2017 Dan Garvey. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/Dangerdan9631/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.Util
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