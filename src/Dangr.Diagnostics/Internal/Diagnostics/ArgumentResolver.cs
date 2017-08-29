// -----------------------------------------------------------------------
//  <copyright file="ArgumentResolver.cs" company="Phoenix Game Studios, LLC">
//      Copyright (c) 2017 Phoenix Game Studios, LLC. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/PhoenixGameStudios/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.Internal.Diagnostics
{
    using System;
    using Dangr.Core.Diagnostics;

    /// <inheritdoc />
    /// <summary>
    /// Throws an argument exception if specific conditions are not met.
    /// </summary>
    internal class ArgumentResolver : AssertResolver
    {
        protected override Exception Failed(AssertType type, string message)
        {
            switch (type)
            {
                case AssertType.NotDisposed:
                    return new ObjectDisposedException(message);
                case AssertType.IsDisposed:
                case AssertType.IsTrue:
                case AssertType.IsFalse:
                case AssertType.AreEqual:
                case AssertType.AreNotEqual:
                case AssertType.IsNull:
                case AssertType.IsNullOrEmpty:
                case AssertType.IsNotNullOrEmpty:
                case AssertType.IsNullOrWhiteSpace:
                case AssertType.IsNotNullOrWhiteSpace:
                case AssertType.IsNotEmpty:
                case AssertType.IsEmpty:
                case AssertType.IsNotZero:
                case AssertType.Compare:
                case AssertType.IsType:
                case AssertType.IsTypeOrNull:
                case AssertType.Fail:
                    return new ArgumentException(message);
                case AssertType.IsNotNull:
                    return new ArgumentNullException(message);
                case AssertType.IsInRange:
                    return new ArgumentOutOfRangeException(message);
                default:
                    return new NotImplementedException(
                        $"Argument resolver for AssertType {type} has not been implemented.");
            }
        }
    }
}