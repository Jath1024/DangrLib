// -----------------------------------------------------------------------
//  <copyright file="FlexDoublyLinkedListTest.cs" company="Phoenix Game Studios, LLC">
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
    public class FlexDoublyLinkedListTest : FlexDoublyLinkedListTestBase
    {
        protected override T CreateContainer<T>(string[] items)
        {
            return new FlexDoublyLinkedList<string>(items) as T;
        }
    }
}