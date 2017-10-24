// -----------------------------------------------------------------------
//  <copyright file="FlexArrayListTest.cs" company="Phoenix Game Studios, LLC">
//      Copyright (c) 2017 Phoenix Game Studios, LLC. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/PhoenixGameStudios/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.FlexCollections.List
{
    using Dangr.Core.FlexCollections.List;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class FlexArrayListTest : FlexArrayListTestBase
    {
        protected override T CreateContainer<T>(string[] items)
        {
            return new FlexArrayList<string>(items) as T;
        }

        protected override FlexArrayList.IGeneric<string> CreateArrayList()
        {
            return new FlexArrayList<string>();
        }

        protected override FlexArrayList.IGeneric<string> CreateArrayList(int capacity)
        {
            return new FlexArrayList<string>(capacity);
        }

        protected override FlexArrayList.IGeneric<string> CreateArrayList(string[] items)
        {
            return new FlexArrayList<string>(items);
        }
    }
}