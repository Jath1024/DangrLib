// -----------------------------------------------------------------------
//  <copyright file="CompareOperationExtensions.cs" company="Phoenix Game Studios, LLC">
//      Copyright (c) 2017 Phoenix Game Studios, LLC. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/PhoenixGameStudios/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------
namespace Dangr.Internal.Diagnostics
{
    using System;
    using Dangr.Core.Diagnostics;

    /// <summary>
    /// <para>Provides extended functionality to the 
    /// <see cref="CompareOperation" /></para>
    /// <para>enumeration.</para>
    /// </summary>
    internal static class CompareOperationExtensions
    {
        /// <summary>
        /// Gets the <paramref name="operation" /> string for the specified <see cref="CompareOperation" /> .
        /// </summary>
        /// <param name="operation">
        /// The <see cref="CompareOperation" /> .
        /// </param>
        /// <returns>The <paramref name="operation" /> string</returns>
        public static string GetOperation(this CompareOperation operation)
        {
            switch (operation)
            {
                case CompareOperation.Equal:
                    return "==";

                case CompareOperation.Greater:
                    return ">";

                case CompareOperation.GreaterEqual:
                    return ">=";

                case CompareOperation.Less:
                    return "<";

                case CompareOperation.LessEqual:
                    return "<=";

                default:
                    throw new InvalidOperationException($"Unknown CompareOperation {operation}.");
            }
        }
    }
}