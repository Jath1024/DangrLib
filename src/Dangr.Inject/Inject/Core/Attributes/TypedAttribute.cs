// -----------------------------------------------------------------------
//  <copyright file="TypedAttribute.cs" company="DangerDan9631">
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
    /// Attribute used to define a type to use when searching for an <see cref="InjectionProvider"/> to use for a parameter.
    /// </summary>
    /// <seealso cref="System.Attribute" />
    [AttributeUsage(AttributeTargets.Parameter)]
    public sealed class TypedAttribute : Attribute
    {
        /// <summary>
        /// Gets the type of the <see cref="InjectionProvider"/> to use.
        /// </summary>
        public Type Type { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TypedAttribute"/> class.
        /// </summary>
        /// <param name="type">The type of the <see cref="InjectionProvider"/> to use.</param>
        public TypedAttribute(Type type)
        {
            this.Type = type;
        }
    }
}