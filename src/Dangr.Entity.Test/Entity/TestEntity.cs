// -----------------------------------------------------------------------
//  <copyright file="TestEntity.cs" company="DangerDan9631">
//      Copyright (c) 2017 Dan Garvey. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/Dangerdan9631/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.Entity
{
    using Dangr.Core.Entity;

    [Entity(TestIds.TestEntity)]
    public class TestEntity : IEntity
    {
        public EntityInfo EntityInfo { get; }
        private readonly EntityTable<TestEntity> entityTable;

        public TestEntity(EntityTable<TestEntity> entityTable)
        {
            this.entityTable = entityTable;
            this.EntityInfo = this.entityTable.Add(this);
        }

        public void Destroy()
        {
            this.entityTable.Remove(this);
        }
    }
}