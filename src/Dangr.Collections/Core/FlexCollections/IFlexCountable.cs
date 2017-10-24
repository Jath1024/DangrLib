// -----------------------------------------------------------------------
//  <copyright file="IFlexCountable.cs" company="Phoenix Game Studios, LLC">
//      Copyright (c) 2017 Phoenix Game Studios, LLC. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/PhoenixGameStudios/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.Core.FlexCollections
{
    /// <summary>
    /// Provides properties that can be used to Quantify an object.
    /// </summary>
    public interface IFlexCountable
    {
        /// <summary>
        /// Gets the number of items in this instance.
        /// </summary>
        int Count { get; }

        /// <summary>
        /// Gets a value indicating whether this instance is empty.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is empty; otherwise, <c>false</c>.
        /// </value>
        bool IsEmpty { get; }
    }
}