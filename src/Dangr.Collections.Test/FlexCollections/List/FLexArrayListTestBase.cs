// -----------------------------------------------------------------------
//  <copyright file="FLexArrayListTestBase.cs" company="Phoenix Game Studios, LLC">
//      Copyright (c) 2017 Phoenix Game Studios, LLC. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/PhoenixGameStudios/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.FlexCollections.List
{
    using Dangr.Core.Diagnostics;
    using Dangr.Core.FlexCollections.List;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    public abstract class FlexArrayListTestBase : FlexListTestBase
    {
        protected abstract FlexArrayList.IGeneric<string> CreateArrayList();
        protected abstract FlexArrayList.IGeneric<string> CreateArrayList(int capacity);
        protected abstract FlexArrayList.IGeneric<string> CreateArrayList(string[] items);

        [DataTestMethod]
        [DataRow(new[] { "1", "2", "3" })]
        public void Capacity(string[] items)
        {
            FlexArrayList.IGeneric<string> collection = this.CreateArrayList(items);
            Validate.Value.AreEqual(collection.Capacity, items.Length);
            collection.Add("abc");
            Validate.Value.AreEqual(collection.Capacity, items.Length * 2);
            collection.Clear();
            Validate.Value.AreEqual(collection.Capacity, FlexArrayList.DEFAULT_CAPACITY);
        }

        [TestMethod]
        public void InitialCapacity()
        {
            const int capacity = 3;
            FlexArrayList.IGeneric<string> collection = this.CreateArrayList(capacity);
            Validate.Value.AreEqual(collection.Capacity, capacity);
            for (int i = 0; i <= capacity; i++)
            {
                collection.Add(i.ToString());
            }

            Validate.Value.AreEqual(collection.Capacity, capacity * 2);
        }

        [TestMethod]
        public void DefaultInitialCapacity()
        {
            FlexArrayList.IGeneric<string> collection = this.CreateArrayList();
            Validate.Value.AreEqual(collection.Capacity, FlexArrayList.DEFAULT_CAPACITY);
            for (int i = 0; i <= FlexArrayList.DEFAULT_CAPACITY; i++)
            {
                collection.Add(i.ToString());
            }

            Validate.Value.AreEqual(collection.Capacity, FlexArrayList.DEFAULT_CAPACITY * 2);
        }
    }
}