// -----------------------------------------------------------------------
//  <copyright file="AssertType.cs" company="DangerDan9631">
//      Copyright (c) 2017 Dan Garvey. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/Dangerdan9631/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.Diagnostics
{
    /// <summary>
    /// Defines the different assert conditions usable in 
    /// <see cref="AssertResolver" /> implementations.
    /// </summary>
    public enum AssertType
    {
        /// <summary>
        /// The <see cref="Dangr.Diagnostics.AssertType.IsTrue" /> assert type.
        /// </summary>
        IsTrue,

        /// <summary>
        /// The <see cref="Dangr.Diagnostics.AssertType.IsFalse" /> assert type.
        /// </summary>
        IsFalse,

        /// <summary>
        /// The <see cref="Dangr.Diagnostics.AssertType.AreEqual" /> assert type.
        /// </summary>
        AreEqual,

        /// <summary>
        /// The <see cref="Dangr.Diagnostics.AssertType.AreNotEqual" /> assert type.
        /// </summary>
        AreNotEqual,

        /// <summary>
        /// The <see cref="Dangr.Diagnostics.AssertType.IsNotNull" /> assert type.
        /// </summary>
        IsNotNull,

        /// <summary>
        /// The <see cref="Dangr.Diagnostics.AssertType.IsNull" /> assert type.
        /// </summary>
        IsNull,

        /// <summary>
        /// The is <c>null</c> or empty assert type.
        /// </summary>
        IsNullOrEmpty,

        /// <summary>
        /// The is not <c>null</c> or empty assert type.
        /// </summary>
        IsNotNullOrEmpty,

        /// <summary>
        /// The is <c>null</c> or whitespace assert type.
        /// </summary>
        IsNullOrWhiteSpace,

        /// <summary>
        /// The is not <c>null</c> or whitespace assert type.
        /// </summary>
        IsNotNullOrWhiteSpace,

        /// <summary>
        /// The <see cref="Dangr.Diagnostics.AssertType.IsNotEmpty" /> assert type.
        /// </summary>
        IsNotEmpty,

        /// <summary>
        /// The <see cref="Dangr.Diagnostics.AssertType.IsEmpty" /> assert type.
        /// </summary>
        IsEmpty,

        /// <summary>
        /// The <see cref="Dangr.Diagnostics.AssertType.IsNotZero" /> assert type.
        /// </summary>
        IsNotZero,

        /// <summary>
        /// The <see cref="Dangr.Diagnostics.AssertType.IsInRange" /> assert type.
        /// </summary>
        IsInRange,

        /// <summary>
        /// The <see cref="Dangr.Diagnostics.AssertType.Compare" /> assert type.
        /// </summary>
        Compare,

        /// <summary>
        /// The <see cref="Dangr.Diagnostics.AssertType.NotDisposed" /> assert type.
        /// </summary>
        NotDisposed,

        /// <summary>
        /// The <see cref="Dangr.Diagnostics.AssertType.IsType" /> assert type.
        /// </summary>
        IsType,

        /// <summary>
        /// The <see cref="Dangr.Diagnostics.AssertType.IsTypeOrNull" /> assert type.
        /// </summary>
        IsTypeOrNull,

        /// <summary>
        /// The <see cref="Dangr.Diagnostics.AssertType.Fail" /> assert type.
        /// </summary>
        Fail
    }
}