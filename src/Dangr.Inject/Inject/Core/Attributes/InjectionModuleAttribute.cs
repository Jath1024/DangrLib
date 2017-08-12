// -----------------------------------------------------------------------
//  <copyright file="InjectionModuleAttribute.cs" company="Phoenix Game Studios, LLC">
//      Copyright (c) 2017 Phoenix Game Studios, LLC. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/PhoenixGameStudios/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.Inject.Core.Attributes
{
    using System;
    using Dangr.Inject.Internal;

    /// <summary>
    /// Attribute used to mark a module class that contains <see cref="InjectionProvider"/>s.
    /// </summary>
    /// <seealso cref="System.Attribute" />
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class InjectionModuleAttribute : Attribute
    {
    }
}