// -----------------------------------------------------------------------
//  <copyright file="FlexListTestBase.cs" company="Phoenix Game Studios, LLC">
//      Copyright (c) 2017 Phoenix Game Studios, LLC. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/PhoenixGameStudios/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.FlexCollections.List
{
    using System;
    using Dangr.Core.Diagnostics;
    using Dangr.Core.FlexCollections.List;
    using Dangr.Core.Test;
    using Dangr.FlexCollections.Collection;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    public abstract class FlexListTestBase : FlexCollectionTestBase
    {
        [DataTestMethod]
        [DataRow(new[] { "1", "2", "3" }, "1", new[] { "1", "2", "3", "1" })]
        public void Add_T_Duplicates(string[] items, string addItem, string[] result)
        {
            var collection = this.CreateContainer<FlexList.IGeneric<string>>(items);
            collection.Add(addItem);

            this.ValidateCollection(collection, result);
        }

        [DataTestMethod]
        [DataRow(new[] { "1", "2", "3" }, new[] { "1" }, new[] { "1", "2", "3", "1" })]
        [DataRow(new[] { "1", "2", "3" }, new[] { "2", "3" }, new[] { "1", "2", "3", "2", "3" })]
        public void AddAll_T_Duplicates(string[] items, string[] addItems, string[] result)
        {
            var collection = this.CreateContainer<FlexList.IGeneric<string>>(items);
            collection.AddAll(addItems);

            this.ValidateCollection(collection, result);
        }

        [DataTestMethod]
        [DataRow(new[] { "1", "2", "1" }, "1", true, new[] { "2", "1" })]
        [DataRow(new[] { "2", "2", "2" }, "2", true, new[] { "2", "2" })]
        public void Remove_Duplicates(string[] items, string removeItem, bool expected, string[] result)
        {
            this.Remove_object_Duplicates(items, removeItem, expected, result);
            this.Remove_T_Duplicates(items, removeItem, expected, result);
        }

        private void Remove_object_Duplicates(string[] items, string removeItem, bool expected, string[] result)
        {
            var collection = this.CreateContainer<FlexList.ICovariant<string>>(items);
            Validate.Value.AreEqual(collection.Remove(removeItem), expected);

            this.ValidateCollection(collection, result);
        }

        private void Remove_T_Duplicates(string[] items, string removeItem, bool expected, string[] result)
        {
            var collection = this.CreateContainer<FlexList.IGeneric<string>>(items);
            Validate.Value.AreEqual(collection.Remove(removeItem), expected);

            this.ValidateCollection(collection, result);
        }

        [DataTestMethod]
        [DataRow(new[] { "1", "2", "1" }, new[] { "1" }, 1, new[] { "2", "1" })]
        [DataRow(new[] { "2", "2", "2" }, new[] { "2" }, 1, new[] { "2", "2" })]
        [DataRow(new[] { "2", "2", "2" }, new[] { "2", "2" }, 2, new[] { "2" })]
        [DataRow(new[] { "1", "1", "3" }, new[] { "1", "4" }, 1, new[] { "1", "3" })]
        public void RemoveAll_Duplicates(string[] items, string[] removeItems, int expected, string[] result)
        {
            this.RemoveAll_object_Duplicates(items, removeItems, expected, result);
            this.RemoveAll_T_Duplicates(items, removeItems, expected, result);
        }

        private void RemoveAll_object_Duplicates(string[] items, string[] removeItems, int expected, string[] result)
        {
            var collection = this.CreateContainer<FlexList.ICovariant<string>>(items);
            Validate.Value.AreEqual(collection.RemoveAll(removeItems), expected);

            this.ValidateCollection(collection, result);
        }

        private void RemoveAll_T_Duplicates(string[] items, string[] removeItems, int expected, string[] result)
        {
            var collection = this.CreateContainer<FlexList.IGeneric<string>>(items);
            Validate.Value.AreEqual(collection.RemoveAll(removeItems), expected);

            this.ValidateCollection(collection, result);
        }

        [DataTestMethod]
        [DataRow(new[] { "1", "3", "3" }, 2, new[] { "1" })]
        [DataRow(new[] { "4", "3", "4" }, 3, new string[0])]
        public void RemoveWhere_Duplicates(string[] items, int expected, string[] result)
        {
            this.RemoveWhere_object_Duplicates(items, expected, result);
            this.RemoveWhere_T_Duplicates(items, expected, result);
        }

        private void RemoveWhere_object_Duplicates(string[] items, int expected, string[] result)
        {
            var collection = this.CreateContainer<FlexList.ICovariant<string>>(items);
            Validate.Value.AreEqual(collection.RemoveWhere(o => (o as string).CompareTo("2") > 0), expected);

            this.ValidateCollection(collection, result);
        }

        private void RemoveWhere_T_Duplicates(string[] items, int expected, string[] result)
        {
            var collection = this.CreateContainer<FlexList.IGeneric<string>>(items);
            Validate.Value.AreEqual(collection.RemoveWhere(o => o.CompareTo("2") > 0), expected);

            this.ValidateCollection(collection, result);
        }

        [DataTestMethod]
        [DataRow(new[] { "1", "2", "3" }, 0, "1")]
        [DataRow(new[] { "1", "2", "3" }, 1, "2")]
        [DataRow(new[] { "1", "2", "3" }, 2, "3")]
        public void Get_inBounds(string[] items, int index, string expected)
        {
            this.GetIndex_inBounds(items, index, expected);
            this.GetMethod_inBounds(items, index, expected);
        }

        private void GetIndex_inBounds(string[] items, int index, string expected)
        {
            var collection = this.CreateContainer<FlexList.IReadOnlyCovariant<string>>(items);
            Validate.Value.AreEqual(collection[index], expected);
        }

        private void GetMethod_inBounds(string[] items, int index, string expected)
        {
            var collection = this.CreateContainer<FlexList.IReadOnlyCovariant<string>>(items);
            Validate.Value.AreEqual(collection.Get(index), expected);
        }

        [DataTestMethod]
        [DataRow(new string[0], 1)]
        [DataRow(new[] { "1", "2", "3" }, -1)]
        [DataRow(new[] { "1", "2", "3" }, 3)]
        public void Get_outOfBounds(string[] items, int index)
        {
            this.GetIndex_outOfBounds(items, index);
            this.GetMethod_outOfBounds(items, index);
        }

        private void GetIndex_outOfBounds(string[] items, int index)
        {
            var collection = this.CreateContainer<FlexList.IReadOnlyCovariant<string>>(items);
            TestUtils.TestForError<ArgumentOutOfRangeException>(
                () =>
                {
                    string x = collection[index];
                });
        }

        private void GetMethod_outOfBounds(string[] items, int index)
        {
            var collection = this.CreateContainer<FlexList.IReadOnlyCovariant<string>>(items);
            TestUtils.TestForError<ArgumentOutOfRangeException>(() => collection.Get(index));
        }

        [DataTestMethod]
        [DataRow(new[] { "1", "2", "3" }, 0, "4")]
        [DataRow(new[] { "1", "2", "3" }, 1, "5")]
        [DataRow(new[] { "1", "2", "3" }, 2, "6")]
        public void Set_inBounds(string[] items, int index, string expected)
        {
            this.SetIndex_inBounds(items, index, expected);
            this.SetMethod_inBounds(items, index, expected);
        }

        private void SetIndex_inBounds(string[] items, int index, string expected)
        {
            var collection = this.CreateContainer<FlexList.IGeneric<string>>(items);
            collection[index] = expected;
            Validate.Value.AreEqual(collection[index], expected);
        }

        private void SetMethod_inBounds(string[] items, int index, string expected)
        {
            var collection = this.CreateContainer<FlexList.IGeneric<string>>(items);
            collection.Set(index, expected);
            Validate.Value.AreEqual(collection[index], expected);
        }

        [DataTestMethod]
        [DataRow(new string[0], 1)]
        [DataRow(new[] { "1", "2", "3" }, -1)]
        [DataRow(new[] { "1", "2", "3" }, 3)]
        public void Set_outOfBounds(string[] items, int index)
        {
            this.SetIndex_outOfBounds(items, index);
            this.SetMethod_outOfBounds(items, index);
        }

        private void SetIndex_outOfBounds(string[] items, int index)
        {
            var collection = this.CreateContainer<FlexList.IGeneric<string>>(items);
            TestUtils.TestForError<ArgumentOutOfRangeException>(() => collection[index] = "abc");
        }

        private void SetMethod_outOfBounds(string[] items, int index)
        {
            var collection = this.CreateContainer<FlexList.IGeneric<string>>(items);
            TestUtils.TestForError<ArgumentOutOfRangeException>(() => collection.Set(index, "abc"));
        }
        
        [DataTestMethod]
        [DataRow(new[] { "1"}, 0)]
        public void Set_null(string[] items, int index)
        {
            this.SetIndex_null(items, index);
            this.SetMethod_null(items, index);
        }

        private void SetIndex_null(string[] items, int index)
        {
            var collection = this.CreateContainer<FlexList.IGeneric<string>>(items);
            TestUtils.TestForError<ArgumentNullException>(() => collection[index] = null);
            this.ValidateCollection(collection, items);
        }

        private void SetMethod_null(string[] items, int index)
        {
            var collection = this.CreateContainer<FlexList.IGeneric<string>>(items);
            TestUtils.TestForError<ArgumentNullException>(() => collection.Set(index, null));
            this.ValidateCollection(collection, items);
        }

        [DataTestMethod]
        [DataRow(new[] { "1", "2", "3" }, "1", 0)]
        [DataRow(new[] { "1", "2", "3" }, "2", 1)]
        [DataRow(new[] { "1", "2", "3" }, "3", 2)]
        [DataRow(new[] { "1", "2", "3" }, "4", FlexList.INDEX_NOT_FOUND)]
        [DataRow(new[] { "1", "2", "2" }, "2", 1)]
        [DataRow(new string[0], "3", FlexList.INDEX_NOT_FOUND)]
        public void IndexOf(string[] items, string item, int expected)
        {
            this.IndexOf_object(items, item, expected);
            this.IndexOf_T(items, item, expected);
        }

        private void IndexOf_object(string[] items, string item, int expected)
        {
            var collection = this.CreateContainer<FlexList.IReadOnlyCovariant<string>>(items);
            Validate.Value.AreEqual(collection.IndexOf(item), expected);
        }

        private void IndexOf_T(string[] items, string item, int expected)
        {
            var collection = this.CreateContainer<FlexList.IReadOnly<string>>(items);
            Validate.Value.AreEqual(collection.IndexOf(item), expected);
        }

        [DataTestMethod]
        [DataRow(new[] { "1", "2", "3" }, null, FlexList.INDEX_NOT_FOUND)]
        [DataRow(new[] { "1", "2", "3" }, typeof(object), FlexList.INDEX_NOT_FOUND)]
        public void IndexOf_WrongType(string[] items, object item, int expected)
        {
            var collection = this.CreateContainer<FlexList.IReadOnlyCovariant<string>>(items);
            Validate.Value.AreEqual(collection.IndexOf(item), expected);
        }

        [DataTestMethod]
        [DataRow(new[] { "1", "2", "3" }, "1", 0, 0)]
        [DataRow(new[] { "1", "2", "3" }, "1", 1, FlexList.INDEX_NOT_FOUND)]
        [DataRow(new[] { "1", "2", "3" }, "4", 0, FlexList.INDEX_NOT_FOUND)]
        [DataRow(new[] { "1", "2", "2" }, "2", 1, 1)]
        [DataRow(new[] { "1", "2", "2" }, "2", 2, 2)]
        [DataRow(new[] { "1", "2", "2" }, "2", 15, FlexList.INDEX_NOT_FOUND)]
        [DataRow(new string[0], "3", 0, FlexList.INDEX_NOT_FOUND)]
        public void IndexOf_Start(string[] items, string item, int start, int expected)
        {
            this.IndexOf_object_Start(items, item, start, expected);
            this.IndexOf_T_Start(items, item, start, expected);
        }

        private void IndexOf_object_Start(string[] items, string item, int start, int expected)
        {
            var collection = this.CreateContainer<FlexList.IReadOnlyCovariant<string>>(items);
            Validate.Value.AreEqual(collection.IndexOf(item, start), expected);
        }

        private void IndexOf_T_Start(string[] items, string item, int start, int expected)
        {
            var collection = this.CreateContainer<FlexList.IReadOnly<string>>(items);
            Validate.Value.AreEqual(collection.IndexOf(item, start), expected);
        }

        [DataTestMethod]
        [DataRow(new[] { "1", "2", "3" }, null, 0, FlexList.INDEX_NOT_FOUND)]
        [DataRow(new[] { "1", "2", "3" }, typeof(object), 0, FlexList.INDEX_NOT_FOUND)]
        public void IndexOf_Start_WrongType(string[] items, object item, int start, int expected)
        {
            var collection = this.CreateContainer<FlexList.IReadOnlyCovariant<string>>(items);
            Validate.Value.AreEqual(collection.IndexOf(item, start), expected);
        }

        [DataTestMethod]
        [DataRow(new[] { "1", "2", "3" }, "1", 0, 1, 0)]
        [DataRow(new[] { "1", "2", "3" }, "1", 1, 1, FlexList.INDEX_NOT_FOUND)]
        [DataRow(new[] { "1", "2", "3" }, "4", 0, 1, FlexList.INDEX_NOT_FOUND)]
        [DataRow(new[] { "1", "2", "2" }, "2", 1, 1, 1)]
        [DataRow(new[] { "1", "2", "2" }, "2", 2, 1, 2)]
        [DataRow(new[] { "1", "2", "3" }, "3", 0, 2, FlexList.INDEX_NOT_FOUND)]
        [DataRow(new[] { "1", "2", "2" }, "2", 15, 0, FlexList.INDEX_NOT_FOUND)]
        [DataRow(new[] { "1", "2", "3" }, "1", 0, -10, FlexList.INDEX_NOT_FOUND)]
        [DataRow(new[] { "1", "2", "3" }, "1", 0, 0, FlexList.INDEX_NOT_FOUND)]
        [DataRow(new[] { "1", "2", "3" }, "1", 0, 10, 0)]
        [DataRow(new string[0], "3", 0, 1, FlexList.INDEX_NOT_FOUND)]
        public void IndexOf_StartCount(string[] items, string item, int start, int count, int expected)
        {
            this.IndexOf_object_StartCount(items, item, start, count, expected);
            this.IndexOf_T_StartCount(items, item, start, count, expected);
        }

        public void IndexOf_object_StartCount(string[] items, string item, int start, int count, int expected)
        {
            var collection = this.CreateContainer<FlexList.IReadOnlyCovariant<string>>(items);
            Validate.Value.AreEqual(collection.IndexOf(item, start, count), expected);
        }

        public void IndexOf_T_StartCount(string[] items, string item, int start, int count, int expected)
        {
            var collection = this.CreateContainer<FlexList.IReadOnly<string>>(items);
            Validate.Value.AreEqual(collection.IndexOf(item, start, count), expected);
        }

        [DataTestMethod]
        [DataRow(new[] { "1", "2", "3" }, null, 0, 10, FlexList.INDEX_NOT_FOUND)]
        [DataRow(new[] { "1", "2", "3" }, typeof(object), 0, 10, FlexList.INDEX_NOT_FOUND)]
        public void IndexOf_StartCount_WrongType(string[] items, object item, int start, int count, int expected)
        {
            var collection = this.CreateContainer<FlexList.IReadOnlyCovariant<string>>(items);
            Validate.Value.AreEqual(collection.IndexOf(item, start, count), expected);
        }

        [DataTestMethod]
        [DataRow(new[] { "1", "2", "3" }, 0, new[] { "2", "3" })]
        [DataRow(new[] { "1", "2", "3" }, 1, new[] { "1", "3" })]
        [DataRow(new[] { "1", "2", "3" }, 2, new[] { "1", "2" })]
        public void RemoveAt_Successful(string[] items, int index, string[] result)
        {
            var collection = this.CreateContainer<FlexList.ICovariant<string>>(items);
            collection.RemoveAt(index);

            this.ValidateCollection(collection, result);
        }

        [DataTestMethod]
        [DataRow(new[] { "1", "2", "3" }, 4)]
        [DataRow(new[] { "1" }, 1)]
        [DataRow(new string[0], 1)]
        public void RemoveAt_Failure(string[] items, int index)
        {
            var collection = this.CreateContainer<FlexList.ICovariant<string>>(items);
            TestUtils.TestForError<ArgumentOutOfRangeException>(() => collection.RemoveAt(index));
        }

        [DataTestMethod]
        [DataRow(new[] { "1", "2", "3" }, "4", 0, new[] { "4", "1", "2", "3" })]
        [DataRow(new[] { "1", "2", "3" }, "4", 1, new[] { "1", "4", "2", "3" })]
        [DataRow(new[] { "1", "2", "3" }, "4", 2, new[] { "1", "2", "4", "3" })]
        [DataRow(new[] { "1", "2", "3" }, "4", 3, new[] { "1", "2", "3", "4" })]
        [DataRow(new string[0], "1", 0, new[] { "1" })]
        public void Insert_InBounds(string[] items, string addItem, int index, string[] result)
        {
            var collection = this.CreateContainer<FlexList.IGeneric<string>>(items);
            collection.Insert(index, addItem);

            this.ValidateCollection(collection, result);
        }

        [DataTestMethod]
        [DataRow(new[] { "1", "2", "3" }, "4", -1)]
        [DataRow(new[] { "1", "2", "3" }, "4", 10)]
        [DataRow(new string[0], "1", 1)]
        public void Insert_OutOfBounds(string[] items, string addItem, int index)
        {
            var collection = this.CreateContainer<FlexList.IGeneric<string>>(items);
            TestUtils.TestForError<ArgumentOutOfRangeException>(() => collection.Insert(index, addItem));
            this.ValidateCollection(collection, items);
        }

        [DataTestMethod]
        [DataRow(new[] { "1" }, null, 0)]
        public void Insert_null(string[] items, string addItem, int index)
        {
            var collection = this.CreateContainer<FlexList.IGeneric<string>>(items);
            TestUtils.TestForError<ArgumentNullException>(() => collection.Insert(index, addItem));
            this.ValidateCollection(collection, items);
        }

        [DataTestMethod]
        [DataRow(new[] { "1", "2", "3" }, new[] { "4" }, 0, new[] { "4", "1", "2", "3" })]
        [DataRow(new[] { "1", "2", "3" }, new[] { "4" }, 1, new[] { "1", "4", "2", "3" })]
        [DataRow(new[] { "1", "2", "3" }, new[] { "4" }, 2, new[] { "1", "2", "4", "3" })]
        [DataRow(new[] { "1", "2", "3" }, new[] { "4" }, 3, new[] { "1", "2", "3", "4" })]
        [DataRow(new[] { "1", "2", "3" }, new[] { "4", "5" }, 1, new[] { "1", "4", "5", "2", "3" })]
        [DataRow(new[] { "1" }, new[] { "2", "3" }, 0, new[] { "2", "3", "1" })]
        [DataRow(new string[0], new[] { "1", "2", "3" }, 0, new[] { "1", "2", "3" })]
        public void InsertAll_InBounds(string[] items, string[] addItems, int index, string[] result)
        {
            var collection = this.CreateContainer<FlexList.IGeneric<string>>(items);
            collection.InsertAll(index, addItems);

            this.ValidateCollection(collection, result);
        }

        [DataTestMethod]
        [DataRow(new[] { "1", "2", "3" }, new[] { "4" }, -1)]
        [DataRow(new[] { "1", "2", "3" }, new[] { "4" }, 10)]
        [DataRow(new string[0], new[] { "1", "2", "3" }, 1)]
        public void InsertAll_OutOfBounds(string[] items, string[] addItems, int index)
        {
            var collection = this.CreateContainer<FlexList.IGeneric<string>>(items);
            TestUtils.TestForError<ArgumentOutOfRangeException>(() => collection.InsertAll(index, addItems));
            this.ValidateCollection(collection, items);
        }
    }
}