// -----------------------------------------------------------------------
//  <copyright file="SingletonAttribute.cs" company="Phoenix Game Studios, LLC">
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
    /// Attribute that marks an <see cref="InjectionProvider"/> property as being Singleton Scoped. 
    /// Each time this <see cref="InjectionProvider"/> is called, it will return the same instance.
    /// </summary>
    /// <seealso cref="System.Attribute" />
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Method)]
    public sealed class SingletonAttribute : Attribute
    {
    }
}