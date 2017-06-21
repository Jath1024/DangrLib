// -----------------------------------------------------------------------
//  <copyright file="TestPartitionTable.cs" company="DangerDan9631">
//      Copyright (c) 2017 Dan Garvey. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/Dangerdan9631/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.Entity
{
    using Dangr.Util;

    public class TestPartitionTable : IdPartitionTable
    {
        protected override void PopulateTable()
        {
            this.AddId(TestIds.TestEntity, (uint) IdCounter.Range.OneMillion);
        }
    }
}