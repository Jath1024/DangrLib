// -----------------------------------------------------------------------
//  <copyright file="FlexCollectionTestBase.cs" company="Phoenix Game Studios, LLC">
//      Copyright (c) 2017 Phoenix Game Studios, LLC. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/PhoenixGameStudios/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.FlexCollections.Collection
{
    using System;
    using Dangr.Core.Diagnostics;
    using Dangr.Core.FlexCollections.Collection;
    using Dangr.Core.Test;
    using Dangr.FlexCollections.Container;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    public abstract class FlexCollectionTestBase : FlexContainerTestBase
    {
        [DataTestMethod]
        [DataRow(new[] { "1", "2", "3" }, "4", new[] { "1", "2", "3", "4" })]
        [DataRow(new string[0], "1", new[] { "1" })]
        public void Add_T(string[] items, string addItem, string[] result)
        {
            var collection = this.CreateContainer<FlexCollection.IGeneric<string>>(items);
            collection.Add(addItem);

            this.ValidateCollection(collection, result);
        }

        [DataTestMethod]
        [DataRow(new[] { "1" }, null, new[] { "1" })]
        public void Add_T_null(string[] items, string addItem, string[] result)
        {
            var collection = this.CreateContainer<FlexCollection.IGeneric<string>>(items);
            TestUtils.TestForError<ArgumentNullException>(() => collection.Add(addItem));
            this.ValidateCollection(collection, result);
        }

        [DataTestMethod]
        [DataRow(new[] { "1", "2", "3" }, new[] { "4" }, new[] { "1", "2", "3", "4" })]
        [DataRow(new[] { "1", "2", "3" }, new[] { "4", "5" }, new[] { "1", "2", "3", "4", "5" })]
        [DataRow(new[] { "1" }, new[] { "2", "3" }, new[] { "1", "2", "3" })]
        [DataRow(new string[0], new[] { "1", "2", "3" }, new[] { "1", "2", "3" })]
        public void AddAll_T(string[] items, string[] addItems, string[] result)
        {
            var collection = this.CreateContainer<FlexCollection.IGeneric<string>>(items);
            collection.AddAll(addItems);

            this.ValidateCollection(collection, result);
        }

        [DataTestMethod]
        [DataRow(new[] { "1", "2", "3" }, "1", true, new[] { "2", "3" })]
        [DataRow(new[] { "1", "2", "3" }, "2", true, new[] { "1", "3" })]
        [DataRow(new[] { "1", "2", "3" }, "3", true, new[] { "1", "2" })]
        [DataRow(new[] { "1", "2", "3" }, "4", false, new[] { "1", "2", "3" })]
        [DataRow(new[] { "1" }, "1", true, new string[0])]
        [DataRow(new string[0], "1", false, new string[0])]
        [DataRow(new[] { "1" }, null, false, new[] { "1" })]
        public void Remove_object(string[] items, string removeItem, bool expected, string[] result)
        {
            var collection = this.CreateContainer<FlexCollection.ICovariant<string>>(items);
            Validate.Value.AreEqual(collection.Remove(removeItem), expected);

            this.ValidateCollection(collection, result);
        }

        [DataTestMethod]
        [DataRow(new[] { "1", "2", "3" }, "1", true, new[] { "2", "3" })]
        [DataRow(new[] { "1", "2", "3" }, "2", true, new[] { "1", "3" })]
        [DataRow(new[] { "1", "2", "3" }, "3", true, new[] { "1", "2" })]
        [DataRow(new[] { "1", "2", "3" }, "4", false, new[] { "1", "2", "3" })]
        [DataRow(new[] { "1" }, "1", true, new string[0])]
        [DataRow(new string[0], "1", false, new string[0])]
        [DataRow(new[] { "1" }, null, false, new[] { "1" })]
        public void Remove_T(string[] items, string removeItem, bool expected, string[] result)
        {
            var collection = this.CreateContainer<FlexCollection.IGeneric<string>>(items);
            Validate.Value.AreEqual(collection.Remove(removeItem), expected);

            this.ValidateCollection(collection, result);
        }

        [DataTestMethod]
        [DataRow(new[] { "1", "2", "3" }, new[] { "1" }, 1, new[] { "2", "3" })]
        [DataRow(new[] { "1", "2", "3" }, new[] { "2" }, 1, new[] { "1", "3" })]
        [DataRow(new[] { "1", "2", "3" }, new[] { "3" }, 1, new[] { "1", "2" })]
        [DataRow(new[] { "1", "2", "3" }, new[] { "4" }, 0, new[] { "1", "2", "3" })]
        [DataRow(new[] { "1", "2", "3" }, new[] { "1", "3" }, 2, new[] { "2" })]
        [DataRow(new[] { "1", "2", "3" }, new[] { "1", "4" }, 1, new[] { "2", "3" })]
        [DataRow(new[] { "1" }, new[] { "1" }, 1, new string[0])]
        [DataRow(new string[0], new[] { "1" }, 0, new string[0])]
        public void RemoveAll_object(string[] items, string[] removeItems, int expected, string[] result)
        {
            var collection = this.CreateContainer<FlexCollection.ICovariant<string>>(items);
            Validate.Value.AreEqual(collection.RemoveAll(removeItems), expected);

            this.ValidateCollection(collection, result);
        }

        [DataTestMethod]
        [DataRow(new[] { "1", "2", "3" }, new[] { "1" }, 1, new[] { "2", "3" })]
        [DataRow(new[] { "1", "2", "3" }, new[] { "2" }, 1, new[] { "1", "3" })]
        [DataRow(new[] { "1", "2", "3" }, new[] { "3" }, 1, new[] { "1", "2" })]
        [DataRow(new[] { "1", "2", "3" }, new[] { "4" }, 0, new[] { "1", "2", "3" })]
        [DataRow(new[] { "1", "2", "3" }, new[] { "1", "3" }, 2, new[] { "2" })]
        [DataRow(new[] { "1", "2", "3" }, new[] { "1", "4" }, 1, new[] { "2", "3" })]
        [DataRow(new[] { "1" }, new[] { "1" }, 1, new string[0])]
        [DataRow(new string[0], new[] { "1" }, 0, new string[0])]
        public void RemoveAll_T(string[] items, string[] removeItems, int expected, string[] result)
        {
            var collection = this.CreateContainer<FlexCollection.IGeneric<string>>(items);
            Validate.Value.AreEqual(collection.RemoveAll(removeItems), expected);

            this.ValidateCollection(collection, result);
        }

        [DataTestMethod]
        [DataRow(new[] { "1", "2", "3" }, 1, new[] { "1", "2" })]
        [DataRow(new[] { "1", "3", "4" }, 2, new[] { "1" })]
        [DataRow(new[] { "3", "4" }, 2, new string[0])]
        [DataRow(new[] { "3" }, 1, new string[0])]
        [DataRow(new string[0], 0, new string[0])]
        public void RemoveWhere_object(string[] items, int expected, string[] result)
        {
            var collection = this.CreateContainer<FlexCollection.ICovariant<string>>(items);
            Validate.Value.AreEqual(collection.RemoveWhere(o => (o as string).CompareTo("2") > 0), expected);

            this.ValidateCollection(collection, result);
        }

        [DataTestMethod]
        [DataRow(new[] { "1", "2", "3" }, 1, new[] { "1", "2" })]
        [DataRow(new[] { "1", "3", "4" }, 2, new[] { "1" })]
        [DataRow(new[] { "3", "4" }, 2, new string[0])]
        [DataRow(new[] { "3" }, 1, new string[0])]
        [DataRow(new string[0], 0, new string[0])]
        public void RemoveWhere_T(string[] items, int expected, string[] result)
        {
            var collection = this.CreateContainer<FlexCollection.IGeneric<string>>(items);
            Validate.Value.AreEqual(collection.RemoveWhere(o => o.CompareTo("2") > 0), expected);

            this.ValidateCollection(collection, result);
        }

        protected void ValidateCollection(FlexCollection.IReadOnlyCovariant<string> collection, string[] result)
        {
            Validate.Value.AreEqual(collection.Count, result.Length);
            int currentIndex = 0;
            foreach (string item in collection)
            {
                Validate.Value.AreEqual(item, result[currentIndex]);
                currentIndex++;
            }
        }
    }
}