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
        /// Gets the operation string for the specified <see cref="CompareOperation" /> .
        /// </summary>
        /// <param name="operation">
        /// The <see cref="CompareOperation" /> .
        /// </param>
        /// <returns>The operation string</returns>
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

        public static bool Compare<T>(this CompareOperation operation, T a, T b) where T : IComparable
        {
            bool bothNull = a == null && b == null;

            switch (operation)
            {
                case CompareOperation.Equal:
                    return bothNull || (a != null && a.CompareTo(b) == 0);

                case CompareOperation.Greater:
                    return !bothNull && a != null && a.CompareTo(b) > 0;

                case CompareOperation.GreaterEqual:
                    return bothNull || (a != null && a.CompareTo(b) >= 0);

                case CompareOperation.Less:
                    return !bothNull && (a == null || a.CompareTo(b) < 0);

                case CompareOperation.LessEqual:
                    return bothNull || a == null || a.CompareTo(b) <= 0;
                default:
                    throw new ArgumentOutOfRangeException(nameof(operation), operation, null);
            }
        }

        public static bool Compare(this CompareOperation operation, float a, float b, float precision)
        {
            switch (operation)
            {
                case CompareOperation.Equal:
                    return Math.Abs(a - b) <= precision;

                case CompareOperation.Greater:
                    return a.CompareTo(b) > 0 && Math.Abs(a - b) > precision;

                case CompareOperation.GreaterEqual:
                    return a.CompareTo(b) >= 0 || Math.Abs(a - b) <= precision;

                case CompareOperation.Less:
                    return a.CompareTo(b) < 0 && Math.Abs(a - b) > precision;

                case CompareOperation.LessEqual:
                    return a.CompareTo(b) <= 0 || Math.Abs(a - b) <= precision;
                default:
                    throw new ArgumentOutOfRangeException(nameof(operation), operation, null);
            }
        }

        public static bool Compare(this CompareOperation operation, double a, double b, double precision)
        {
            switch (operation)
            {
                case CompareOperation.Equal:
                    return Math.Abs(a - b) <= precision;

                case CompareOperation.Greater:
                    return a.CompareTo(b) > 0 && Math.Abs(a - b) > precision;

                case CompareOperation.GreaterEqual:
                    return a.CompareTo(b) >= 0 || Math.Abs(a - b) <= precision;

                case CompareOperation.Less:
                    return a.CompareTo(b) < 0 && Math.Abs(a - b) > precision;

                case CompareOperation.LessEqual:
                    return a.CompareTo(b) <= 0 || Math.Abs(a - b) <= precision;
                default:
                    throw new ArgumentOutOfRangeException(nameof(operation), operation, null);
            }
        }
    }
}