// -----------------------------------------------------------------------
//  <copyright file="InjectAttribute.cs" company="Phoenix Game Studios, LLC">
//      Copyright (c) 2017 Phoenix Game Studios, LLC. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/PhoenixGameStudios/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.Inject.Core.Attributes
{
    using System;

    /// <summary>
    /// Attribute used to mark a non-default constructor as the injection constructor for a class.
    /// </summary>
    /// <seealso cref="System.Attribute" />
    [AttributeUsage(AttributeTargets.Constructor)]
    public sealed class InjectAttribute : Attribute
    {
    }
}