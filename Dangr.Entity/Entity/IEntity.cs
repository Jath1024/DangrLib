// -----------------------------------------------------------------------
//  <copyright file="IEntity.cs" company="DangerDan9631">
//      Copyright (c) 2017 Dan Garvey. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/Dangerdan9631/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.Entity
{
    /// <summary>
    /// Interface that defines an entity that can be stored in an 
    /// <see cref="Dangr.Entity.EntityTable`1" /> .
    /// </summary>
    public interface IEntity
    {
        /// <summary>
        /// Gets the <see cref="Dangr.Entity.IEntity.EntityInfo" /> generated for this <see cref="IEntity" /> .
        /// </summary>
        EntityInfo EntityInfo { get; }
    }
}