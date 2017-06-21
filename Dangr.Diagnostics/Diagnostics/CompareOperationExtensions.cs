// -----------------------------------------------------------------------
//  <copyright file="CompareOperationExtensions.cs" company="DangerDan9631">
//      Copyright (c) 2017 Dan Garvey. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/Dangerdan9631/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.Diagnostics
{
    /// <summary>
    /// <para>Provides extended functionality to the 
    /// <see cref="CompareOperation" /></para>
    /// <para>enumeration.</para>
    /// </summary>
    public static class CompareOperationExtensions
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
                    return "??";
            }
        }
    }
}