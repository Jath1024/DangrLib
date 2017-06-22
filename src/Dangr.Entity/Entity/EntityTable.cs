// -----------------------------------------------------------------------
//  <copyright file="EntityTable.cs" company="DangerDan9631">
//      Copyright (c) 2017 Dan Garvey. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/Dangerdan9631/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.Entity
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Dangr.Collections;
    using Dangr.Diagnostics;

    /// <summary>
    /// Table that contains references to all of the <see cref="IEntity" /> s
    /// currently instantiated.
    /// </summary>
    public sealed class EntityTable<TEntity>
        where TEntity : class, IEntity
    {
        private readonly IdPartitionTable idPartitionTable;

        private readonly Dictionary<ulong, TEntity> idTable = new Dictionary<ulong, TEntity>();
        private readonly Dictionary<string, List<TEntity>> nameTable = new Dictionary<string, List<TEntity>>();

        /// <summary>
        /// Initializes a new instance of the <see cref="Dangr.Entity.EntityTable`1" /> class.
        /// </summary>
        /// <param name="idPartitionTable">
        /// The identifier partition table.
        /// </param>
        public EntityTable(IdPartitionTable idPartitionTable)
        {
            Assert.Validate.IsNotNull(idPartitionTable, nameof(idPartitionTable));
            this.idPartitionTable = idPartitionTable;
        }

        /// <summary>
        /// Gets a <see cref="TEntity" /> from the <see cref="Dangr.Entity.EntityTable`1" /> .
        /// </summary>
        /// <param name="id">
        /// The id of the <see cref="TEntity" /> to get.
        /// </param>
        /// <returns>
        /// The <see cref="TEntity" /> with the specified Id, or null.
        /// </returns>
        public TEntity Get(ulong id)
        {
            TEntity entity;
            return this.idTable.TryGetValue(id, out entity) ? entity : null;
        }

        /// <summary>
        /// Gets an <see cref="TEntity" /> from the <see cref="Dangr.Entity.EntityTable`1" /> .
        /// </summary>
        /// <typeparam name="T">
        /// The type of the <see cref="TEntity" /> to get.
        /// </typeparam>
        /// <param name="id">
        /// The id of the <see cref="TEntity" /> to get.
        /// </param>
        /// <returns>
        /// The <see cref="TEntity" /> with the specified Id, or null.
        /// </returns>
        public T Get<T>(ulong id) where T : class, TEntity
        {
            return this.Get(id) as T;
        }

        /// <summary>
        /// Gets an <see cref="TEntity" /> from the <see cref="Dangr.Entity.EntityTable`1" /> .
        /// </summary>
        /// <param name="name">
        /// The name of the <see cref="TEntity" /> to get.
        /// </param>
        /// <returns>
        /// A <see cref="TEntity" /> with the specified name, or null.
        /// </returns>
        public TEntity Get(string name)
        {
            List<TEntity> entityList;
            return this.nameTable.TryGetValue(name, out entityList) ? entityList.FirstOrDefault() : null;
        }

        /// <summary>
        /// Gets an <see cref="TEntity" /> from the <see cref="Dangr.Entity.EntityTable`1" /> .
        /// </summary>
        /// <typeparam name="T">
        /// The type of the <see cref="TEntity" /> to get.
        /// </typeparam>
        /// <param name="name">
        /// The name of the <see cref="TEntity" /> to get.
        /// </param>
        /// <returns>
        /// A <see cref="TEntity" /> with the specified name, or null.
        /// </returns>
        public T Get<T>(string name) where T : class, TEntity
        {
            return this.Get(name) as T;
        }

        /// <summary>
        /// Gets all of the <see cref="TEntity" /> s with the specified <paramref name="name" /> from the <see cref="Dangr.Entity.EntityTable`1" /> .
        /// </summary>
        /// <param name="name">
        /// The name of the <see cref="TEntity" /> s to get.
        /// </param>
        /// <returns>
        /// A list of the <see cref="TEntity" /> s with the specified name.
        /// </returns>
        public IEnumerable<TEntity> GetAll(string name)
        {
            List<TEntity> entityList;
            return this.nameTable.TryGetValue(name, out entityList)
                ? new List<TEntity>(entityList)
                : new List<TEntity>();
        }

        /// <summary>
        /// Gets all of the <see cref="TEntity" /> s with the specified <paramref name="name" /> from the <see cref="Dangr.Entity.EntityTable`1" /> .
        /// </summary>
        /// <typeparam name="T">
        /// The type of the <see cref="TEntity" /> s to get.
        /// </typeparam>
        /// <param name="name">
        /// The name of the <see cref="TEntity" /> s to get.
        /// </param>
        /// <returns>
        /// A list of the <see cref="TEntity" /> s with the specified name.
        /// </returns>
        public IEnumerable<T> GetAll<T>(string name) where T : class, TEntity
        {
            List<TEntity> entityList;
            if (!this.nameTable.TryGetValue(name, out entityList))
            {
                return new List<T>();
            }

            return from entity in entityList
                let tEntity = entity as T
                where tEntity != null
                select tEntity;
        }

        /// <summary>
        /// Adds an <see cref="TEntity" /> to the <see cref="Dangr.Entity.EntityTable`1" /> .
        /// </summary>
        /// <param name="entity">The <see cref="TEntity" /> to add.</param>
        /// <exception cref="System.ArgumentException">
        /// If the <see cref="TEntity" /> was already added to this <see cref="Dangr.Entity.EntityTable`1" /> .
        /// </exception>
        /// <exception cref="System.InvalidOperationException">
        /// If the specified <see cref="IEntity" /> does not have an <see cref="EntityAttribute" /> or its <paramref name="entity" /> name does not have an ID partition.
        /// </exception>
        /// <exception cref="Dangr.Util.IdCounterOutOfRangeException">
        /// If the <paramref name="entity" /> partition for the <see cref="TEntity" /> 's <paramref name="entity" /> name runs out of bounds.
        /// </exception>
        /// <returns>
        /// The <see cref="EntityInfo" /> describing the added <see cref="TEntity" /> .
        /// </returns>
        public EntityInfo Add(TEntity entity)
        {
            string entityName = this.GetEntityName(entity);
            ulong entityId = this.GetEntityId(entityName);

            if (this.idTable.ContainsKey(entityId))
            {
                throw new ArgumentException(
                    $"Entity '{entityName}' with id '{entityId}' was already added to the entity table.");
            }

            this.idTable.Add(entityId, entity);

            List<TEntity> entityList;
            if (!this.nameTable.TryGetValue(entityName, out entityList))
            {
                entityList = new List<TEntity>();
                this.nameTable.Add(entityName, entityList);
            }

            entityList.Add(entity);

            return new EntityInfo(entityName, entityId);
        }

        /// <summary>
        /// Removes an <see cref="TEntity" /> from the <see cref="Dangr.Entity.EntityTable`1" /> .
        /// </summary>
        /// <param name="entity">The <see cref="TEntity" /> to remove.</param>
        /// <exception cref="System.ArgumentNullException">
        /// If the specified <see cref="TEntity" /> is null.
        /// </exception>
        public void Remove(TEntity entity)
        {
            EntityInfo entityInfo = entity.EntityInfo;
            if (entityInfo == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            this.idTable.Remove(entityInfo.EntityId);

            List<TEntity> entityList;
            if (this.nameTable.TryGetValue(entityInfo.EntityName, out entityList))
            {
                entityList.Remove(entity);

                if (entityList.IsEmpty())
                {
                    this.nameTable.Remove(entityInfo.EntityName);
                }
            }
        }

        private string GetEntityName(TEntity entity)
        {
            var attribute =
                entity.GetType().GetTypeInfo().GetCustomAttributes(typeof(EntityAttribute), false).FirstOrDefault() as
                    EntityAttribute;

            if (attribute == null)
            {
                throw new InvalidOperationException(
                    $"Cannot get entity name. Object type '{entity.GetType().Name}' does not have EntityAttribute.");
            }

            return attribute.EntityName;
        }

        private ulong GetEntityId(string entityName)
        {
            return this.idPartitionTable.GetId(entityName);
        }
    }
}