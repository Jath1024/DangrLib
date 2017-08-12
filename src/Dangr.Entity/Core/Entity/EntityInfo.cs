// -----------------------------------------------------------------------
//  <copyright file="EntityInfo.cs" company="Phoenix Game Studios, LLC">
//      Copyright (c) 2017 Phoenix Game Studios, LLC. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/PhoenixGameStudios/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------
namespace Dangr.Core.Entity
{
    /// <summary>
    /// Stores information about an entity. Created by adding an entity to an 
    /// <see cref="EntityTable{T}" /> .
    /// </summary>
    public sealed class EntityInfo
    {
        /// <summary>
        /// The name used to identify this class of <see cref="IEntity" /> .
        /// </summary>
        public string EntityName { get; }

        /// <summary>
        /// The ID unique to this <see cref="IEntity" /> instance.
        /// </summary>
        public ulong EntityId { get; }

        internal EntityInfo(string entityName, ulong entityId)
        {
            this.EntityName = entityName;
            this.EntityId = entityId;
        }
    }
}