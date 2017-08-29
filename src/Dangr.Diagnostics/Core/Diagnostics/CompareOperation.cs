// -----------------------------------------------------------------------
//  <copyright file="CompareOperation.cs" company="Phoenix Game Studios, LLC">
//      Copyright (c) 2017 Phoenix Game Studios, LLC. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/PhoenixGameStudios/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.Core.Diagnostics
{
    /// <summary>
    /// The types of compare operations that can be used in 
    /// <see cref="IConditionChecker" /> compare operations.
    /// </summary>
    public enum CompareOperation
    {
        /// <summary>
        /// Compare equals.
        /// </summary>
        Equal,

        /// <summary>
        /// Compare greater than.
        /// </summary>
        Greater,

        /// <summary>
        /// Compare greater than or equals.
        /// </summary>
        GreaterEqual,

        /// <summary>
        /// Compare less than.
        /// </summary>
        Less,

        /// <summary>
        /// Compare less than or equals.
        /// </summary>
        LessEqual
    }
}