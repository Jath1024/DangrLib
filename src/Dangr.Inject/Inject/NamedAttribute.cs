// -----------------------------------------------------------------------
//  <copyright file="NamedAttribute.cs" company="DangerDan9631">
//      Copyright (c) 2017 Dan Garvey. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/Dangerdan9631/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.Inject
{
    using System;

    /// <summary>
    /// Attribute used to define a name to use when searching for an <see cref="InjectionProvider"/> to use for a parameter.
    /// </summary>
    /// <seealso cref="System.Attribute" />
    [AttributeUsage(AttributeTargets.Parameter)]
    public class NamedAttribute : Attribute
    {
        /// <summary>
        /// Gets the name of the <see cref="InjectionProvider"/> to use.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="NamedAttribute"/> class.
        /// </summary>
        /// <param name="name">The name of the <see cref="InjectionProvider"/> to use.</param>
        public NamedAttribute(string name)
        {
            this.Name = name;
        }
    }
}