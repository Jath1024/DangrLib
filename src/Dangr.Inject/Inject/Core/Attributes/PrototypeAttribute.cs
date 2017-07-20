// -----------------------------------------------------------------------
//  <copyright file="PrototypeAttribute.cs" company="DangerDan9631">
//      Copyright (c) 2017 Dan Garvey. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/Dangerdan9631/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.Inject.Core.Attributes
{
    using System;
    using Dangr.Inject.Internal;

    /// <summary>
    /// Attribute that marks an <see cref="InjectionProvider"/> property as being Prototype Scoped. 
    /// Each time this <see cref="InjectionProvider"/> is called, it will return a new instance.
    /// </summary>
    /// <seealso cref="System.Attribute" />
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Method)]
    public sealed class PrototypeAttribute : Attribute
    {
    }
}