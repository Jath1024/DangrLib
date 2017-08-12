// -----------------------------------------------------------------------
//  <copyright file="EntityAttribute.cs" company="Phoenix Game Studios, LLC">
//      Copyright (c) 2017 Phoenix Game Studios, LLC. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/PhoenixGameStudios/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------
namespace Dangr.Core.Entity
{
    using System;

    /// <summary>
    /// Attribute that can be used on an <see cref="IEntity" /> to specify the
    /// EntityName.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public sealed class EntityAttribute : Attribute
    {
        /// <summary>
        /// Gets or sets the entity name to use on an <see cref="IEntity" /> .
        /// </summary>
        public string EntityName { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityAttribute" /> class.
        /// </summary>
        /// <param name="entityName">
        /// The entity name to use on an <see cref="Dangr.Core.Entity" /> .
        /// </param>
        public EntityAttribute(string entityName)
        {
            this.EntityName = entityName;
        }
    }
}