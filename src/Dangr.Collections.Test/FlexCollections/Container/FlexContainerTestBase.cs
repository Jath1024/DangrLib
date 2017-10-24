// -----------------------------------------------------------------------
//  <copyright file="FlexContainerTestBase.cs" company="Phoenix Game Studios, LLC">
//      Copyright (c) 2017 Phoenix Game Studios, LLC. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/PhoenixGameStudios/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.FlexCollections.Container
{
    using System.Collections;
    using System.Collections.Generic;
    using Dangr.Core.Diagnostics;
    using Dangr.Core.FlexCollections.Container;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    public abstract class FlexContainerTestBase
    {
        protected abstract T CreateContainer<T>(string[] items) where T : class;

        [DataTestMethod]
        [DataRow(new[] { "1", "2", "3" }, "1", true)]
        [DataRow(new[] { "1", "2", "3" }, "2", true)]
        [DataRow(new[] { "1", "2", "3" }, "3", true)]
        [DataRow(new[] { "1", "2", "3" }, "4", false)]
        [DataRow(new[] { "1" }, "1", true)]
        [DataRow(new string[0], "1", false)]
        [DataRow(new[] { "1" }, null, false)]
        public void Contains(string[] items, string searchItem, bool expected)
        {
            this.Contains_object(items, searchItem, expected);
            this.Contains_T(items, searchItem, expected);
        }

        private void Contains_object(string[] items, string searchItem, bool expected)
        {
            var container = this.CreateContainer<FlexContainer.IReadOnlyCovariant<string>>(items);
            Validate.Value.AreEqual(container.Contains(searchItem), expected);
        }

        private void Contains_T(string[] items, string searchItem, bool expected)
        {
            var container = this.CreateContainer<FlexContainer.IReadOnly<string>>(items);
            Validate.Value.AreEqual(container.Contains(searchItem), expected);
        }

        [DataTestMethod]
        [DataRow(new[] { "1", "2", "3" }, new[] { "1" }, true)]
        [DataRow(new[] { "1", "2", "3" }, new[] { "2" }, true)]
        [DataRow(new[] { "1", "2", "3" }, new[] { "3" }, true)]
        [DataRow(new[] { "1", "2", "3" }, new[] { "1", "4" }, true)]
        [DataRow(new[] { "1", "2", "3" }, new[] { "4", "2" }, true)]
        [DataRow(new[] { "1", "2", "3" }, new[] { "4", "5" }, false)]
        [DataRow(new[] { "1" }, new[] { "1" }, true)]
        [DataRow(new string[0], new[] { "1" }, false)]
        public void ContainsAny(string[] items, string[] searchItems, bool expected)
        {
            this.ContainsAny_object(items, searchItems, expected);
            this.ContainsAny_T(items, searchItems, expected);
        }

        private void ContainsAny_object(string[] items, string[] searchItems, bool expected)
        {
            var container = this.CreateContainer<FlexContainer.IReadOnlyCovariant<string>>(items);
            Validate.Value.AreEqual(container.ContainsAny(searchItems), expected);
        }

        private void ContainsAny_T(string[] items, string[] searchItems, bool expected)
        {
            var container = this.CreateContainer<FlexContainer.IReadOnly<string>>(items);
            Validate.Value.AreEqual(container.ContainsAny(searchItems), expected);
        }

        [DataTestMethod]
        [DataRow(new[] { "1", "2", "3" }, new[] { "1" }, true)]
        [DataRow(new[] { "1", "2", "3" }, new[] { "2" }, true)]
        [DataRow(new[] { "1", "2", "3" }, new[] { "3" }, true)]
        [DataRow(new[] { "1", "2", "3" }, new[] { "1", "2", "3" }, true)]
        [DataRow(new[] { "1", "2", "3" }, new[] { "1", "4" }, false)]
        [DataRow(new[] { "1", "2", "3" }, new[] { "4", "2" }, false)]
        [DataRow(new[] { "1", "2", "3" }, new[] { "4", "5" }, false)]
        [DataRow(new[] { "1" }, new[] { "1" }, true)]
        [DataRow(new string[0], new[] { "1" }, false)]
        public void ContainsAll(string[] items, string[] searchItems, bool expected)
        {
            this.ContainsAll_object(items, searchItems, expected);
            this.ContainsAll_T(items, searchItems, expected);
        }

        private void ContainsAll_object(string[] items, string[] searchItems, bool expected)
        {
            var container = this.CreateContainer<FlexContainer.IReadOnlyCovariant<string>>(items);
            Validate.Value.AreEqual(container.ContainsAll(searchItems), expected);
        }

        private void ContainsAll_T(string[] items, string[] searchItems, bool expected)
        {
            var container = this.CreateContainer<FlexContainer.IReadOnly<string>>(items);
            Validate.Value.AreEqual(container.ContainsAll(searchItems), expected);
        }

        [DataTestMethod]
        [DataRow(new[] { "1", "2", "3" })]
        [DataRow(new[] { "1" })]
        [DataRow(new string[0])]
        public void Clear(string[] items)
        {
            var container = this.CreateContainer<FlexContainer.ICovariant<string>>(items);
            container.Clear();
            Validate.Value.AreEqual(container.Count, 0);
            Validate.Value.IsTrue(container.IsEmpty);
        }

        [DataTestMethod]
        [DataRow(new[] { "1", "2", "3" })]
        [DataRow(new[] { "1" })]
        [DataRow(new string[0])]
        public void GetEnumerator(string[] items)
        {
            this.GetEnumerator_object(items);
            this.GetEnumerator_T(items);
        }

        private void GetEnumerator_object(string[] items)
        {
            int count = 0;
            IEnumerable container = this.CreateContainer<IEnumerable>(items);
            foreach (object item in container)
            {
                count++;
            }

            Validate.Value.AreEqual(count, items.Length);
        }

        private void GetEnumerator_T(string[] items)
        {
            int count = 0;
            var container = this.CreateContainer<IEnumerable<string>>(items);
            foreach (string item in container)
            {
                count++;
            }

            Validate.Value.AreEqual(count, items.Length);
        }
    }
}