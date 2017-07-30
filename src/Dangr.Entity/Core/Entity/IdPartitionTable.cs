// -----------------------------------------------------------------------
//  <copyright file="IdPartitionTable.cs" company="DangerDan9631">
//      Copyright (c) 2017 Dan Garvey. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/Dangerdan9631/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.Core.Entity
{
    using System;
    using System.Collections.Generic;
    using Dangr.Core.Util;

    /// <summary>
    /// A partition table used to generate IDs for <see cref="IEntity" /> s.
    /// </summary>
    public abstract class IdPartitionTable
    {
        private ulong nextId;
        private readonly Dictionary<string, IIdCounter> table = new Dictionary<string, IIdCounter>();
        
        /// <summary>
        /// Gets the next ID in the partition defined for the given entity name.
        /// </summary>
        /// <param name="entityName">The entity name.</param>
        /// <exception cref="System.InvalidOperationException">
        /// If an ID cannot be generated for the given entity name.
        /// </exception>
        /// <returns>
        /// The next ID in the partition defined for the given entity name.
        /// </returns>
        public ulong GetId(string entityName)
        {
            IIdCounter idCounter;
            if (!this.table.TryGetValue(entityName, out idCounter))
            {
                return this.GetDefaultId(entityName);
            }

            return idCounter.GetId();
        }

        /// <summary>
        /// Gets a default ID to use when there is no partition for a given entity id.
        /// </summary>
        /// <param name="entityName">
        /// The entity name that does not have a partition.
        /// </param>
        /// <exception cref="System.InvalidOperationException">
        /// If an ID cannot be generated for the given entity name.
        /// </exception>
        /// <returns>The generated ID.</returns>
        protected virtual ulong GetDefaultId(string entityName)
        {
            throw new InvalidOperationException(
                $"Cannot get entity ID. Entity name '{entityName}' does not have an ID partition.");
        }

        /// <summary>
        /// Adds a partition with a single ID for the specified entity name.
        /// </summary>
        /// <param name="entityName">
        /// The entity name to add the partition for.
        /// </param>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// If the Id overflows uint.MaxValue.
        /// </exception>
        protected void AddStaticId(string entityName)
        {
            this.AddStaticId(entityName, this.nextId);
        }

        /// <summary>
        /// Adds a partition with a single ID for the specified entity name.
        /// </summary>
        /// <param name="entityName">
        /// The entity name to add the partition for.
        /// </param>
        /// <param name="id">The id to give to the partition</param>
        /// <exception cref="System.InvalidOperationException">
        /// If the <paramref name="id" /> specified is not larger than the last specified partition.
        /// </exception>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// If the Id overflows uint.MaxValue.
        /// </exception>
        protected void AddStaticId(string entityName, ulong id)
        {
            if (id < this.nextId)
            {
                throw new InvalidOperationException("IDs must be added in ascending order.");
            }

            this.table.Add(entityName, new StaticIdCounter(id));
            this.nextId = id + 1;
        }

        /// <summary>
        /// Adds a partition with a range of IDs for the specified entity name.
        /// </summary>
        /// <param name="entityName">
        /// The entity name to add the partition for.
        /// </param>
        /// <param name="size">The size of the new partition.</param>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// If the Id overflows uint.MaxValue.
        /// </exception>
        protected void AddId(string entityName, ulong size)
        {
            this.AddId(entityName, this.nextId, size);
        }

        /// <summary>
        /// Adds a partition with a range of IDs for the specified entity name.
        /// </summary>
        /// <param name="entityName">
        /// The entity name to add the partition for.
        /// </param>
        /// <param name="min">The minimum id to give to the partition</param>
        /// <param name="size">The size of the new partition.</param>
        /// <exception cref="System.InvalidOperationException">
        /// If the id specified is not larger than the last specified partition.
        /// </exception>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// If the Id overflows uint.MaxValue.
        /// </exception>
        protected void AddId(string entityName, ulong min, ulong size)
        {
            if (min < this.nextId)
            {
                throw new InvalidOperationException("IDs must be added in ascending order.");
            }

            this.table.Add(entityName, new IdCounter(min, size));
            this.nextId = min + size;
        }
    }
}