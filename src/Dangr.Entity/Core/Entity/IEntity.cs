// -----------------------------------------------------------------------
//  <copyright file="IEntity.cs" company="Phoenix Game Studios, LLC">
//      Copyright (c) 2017 Phoenix Game Studios, LLC. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/PhoenixGameStudios/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------
namespace Dangr.Core.Entity
{
    /// <summary>
    /// Interface that defines an entity that can be stored in an 
    /// <see cref="EntityTable{TEntity}" /> .
    /// </summary>
    public interface IEntity
    {
        /// <summary>
        /// Gets the <see cref="IEntity.EntityInfo" /> generated for this <see cref="IEntity" /> .
        /// </summary>
        EntityInfo EntityInfo { get; }
    }
}