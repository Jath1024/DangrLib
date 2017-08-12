// -----------------------------------------------------------------------
//  <copyright file="ProvidesSetAttribute.cs" company="Phoenix Game Studios, LLC">
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
    /// Attribute that marks a property as an <see cref="InjectionProvider"/> that is part of a set of providers.
    /// </summary>
    /// <seealso cref="System.Attribute" />
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Method)]
    public sealed class ProvidesSetAttribute : Attribute
    {
        /// <summary>
        /// Gets the type of dependency that is provided.
        /// </summary>
        public Type ProvidesType { get; }

        /// <summary>
        /// Gets the name that can be used to reference this provider set.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProvidesSetAttribute"/> class.
        /// </summary>
        /// <param name="type">The type of dependency that is provided.</param>
        public ProvidesSetAttribute(Type type)
        {
            this.ProvidesType = type;
            this.Name = null;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProvidesSetAttribute"/> class.
        /// </summary>
        /// <param name="name">The name that can be used to reference this provider set.</param>
        public ProvidesSetAttribute(string name)
        {
            this.ProvidesType = null;
            this.Name = name;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProvidesSetAttribute"/> class.
        /// </summary>
        /// <param name="type">The type of dependency that is provided.</param>
        /// <param name="name">The name that can be used to reference this provider set.</param>
        public ProvidesSetAttribute(Type type, string name)
        {
            this.ProvidesType = type;
            this.Name = name;
        }
    }
}