// -----------------------------------------------------------------------
//  <copyright file="AliasAttribute.cs" company="Phoenix Game Studios, LLC">
//      Copyright (c) 2017 Phoenix Game Studios, LLC. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/PhoenixGameStudios/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------
namespace Dangr.Core.Command.Annotation
{
    using System;

    /// <summary>
    /// Defines an alias that can be used to access a named parameter or a <see cref="IDangrCommand"/>.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Class, AllowMultiple = true)]
    public sealed class AliasAttribute : Attribute
    {
        /// <summary>
        /// Gets the alias that can be used to reference this parameter.
        /// </summary>
        public string Alias { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AliasAttribute"/> class.
        /// </summary>
        /// <param name="alias">The alias that can be used to reference this parameter.</param>
        public AliasAttribute(string alias)
        {
            this.Alias = alias;
        }
    }
}