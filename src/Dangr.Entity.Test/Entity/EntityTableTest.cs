// -----------------------------------------------------------------------
//  <copyright file="EntityTableTest.cs" company="DangerDan9631">
//      Copyright (c) 2017 Dan Garvey. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/Dangerdan9631/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.Entity
{
    using Dangr.Core.Entity;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class EntityTableTest
    {
        [TestMethod]
        public void EntityTable_Test()
        {
            var table = new EntityTable<TestEntity>(new TestPartitionTable());
            TestEntity e = new TestEntity(table);

            Assert.AreEqual(table.Get(e.EntityInfo.EntityId), e, "Entity not added to table");

            e.Destroy();
            Assert.AreEqual(table.Get(e.EntityInfo.EntityId), null, "Entity not removed from table");
        }
    }
}