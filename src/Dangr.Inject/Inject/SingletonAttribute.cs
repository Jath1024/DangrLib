// -----------------------------------------------------------------------
//  <copyright file="SingletonAttribute.cs" company="DangerDan9631">
//      Copyright (c) 2017 Dan Garvey. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/Dangerdan9631/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.Inject
{
    using System;

    /// <summary>
    /// Attribute that marks an <see cref="InjectionProvider"/> property as being Singleton Scoped. 
    /// Each time this <see cref="InjectionProvider"/> is called, it will return the same instance.
    /// </summary>
    /// <seealso cref="System.Attribute" />
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Method)]
    public class SingletonAttribute : Attribute
    { }
}