// -----------------------------------------------------------------------
//  <copyright file="InjectionCoreSetTest.cs" company="Phoenix Game Studios, LLC">
//      Copyright (c) 2017 Phoenix Game Studios, LLC. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/PhoenixGameStudios/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.Inject
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.Linq;
    using Dangr.Inject.Core;
    using Dangr.Inject.Core.Attributes;
    using Dangr.Inject.Internal;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Assert = Dangr.Diagnostics.Assert;

    [TestClass]
    public class InjectionCoreSetTest
    {
        [InjectionModule]
        public class TestModule
        {
            [Singleton]
            [BindToType(typeof(TestTypes.ISetClass))]
            [BindAsSet]
            private TestTypes.SetClass1 setClass1Instance;

            [Singleton]
            [BindToType(typeof(TestTypes.ISetClass))]
            [BindAsSet]
            private TestTypes.SetClass2 setClass2Instance;

            [Singleton]
            [BindToType(typeof(TestTypes.ISetClass))]
            [BindAsSet]
            private TestTypes.SetClass3 setClass3Instance1;

            [Singleton]
            [BindToType(typeof(TestTypes.ISetClass))]
            [BindAsSet]
            private TestTypes.SetClass3 setClass3Instance2;
        }




        [InjectionModule]
        public class TestModule
        {
            [Singleton]
            [Provider(typeof(TestTypes.ISetClass))]
            [ProvidesSet]
            public TestTypes.SetClass1 SetClass1Instance { get; set; }

            [Singleton]
            [Provider(typeof(TestTypes.ISetClass))]
            [ProvidesSet]
            public TestTypes.SetClass2 SetClass2Instance { get; set; }

            [Singleton]
            [Provider(typeof(TestTypes.ISetClass))]
            [ProvidesSet]
            public TestTypes.SetClass3 SetClass3Instance1 { get; set; }

            [Singleton]
            [Provider(typeof(TestTypes.ISetClass))]
            [ProvidesSet]
            public TestTypes.SetClass3 SetClass3Instance2 { get; set; }
        }

        private InjectionCore core;

        [TestInitialize]
        public void Setup()
        {
            this.core = new InjectionCore();
            this.core.LoadModule(typeof(TestModule));
        }
        
        [TestMethod]
        public void TestSet()
        {
            var set = this.core.Get<ISet<TestTypes.ISetClass>>();

            Assert.Validate.IsNotNull(set, "Set is null");
            TestTypes.ISetClass[] setArray = set.ToArray();
            Assert.Validate.AreEqual(setArray.Length, 4, "Incorrect number of elements returned");

            Assert.Validate.IsTrue(setArray[0] is TestTypes.SetClass1, "First element not correct type");
            Assert.Validate.IsTrue(setArray[1] is TestTypes.SetClass2, "Second element not correct type");
            Assert.Validate.IsTrue(setArray[2] is TestTypes.SetClass3, "Third element not correct type");
            Assert.Validate.AreEqual(((TestTypes.SetClass3) setArray[2]).InstanceId, 0,
                "Incorrect instance Id returned for third element");
            Assert.Validate.IsTrue(setArray[3] is TestTypes.SetClass3, "Fourth element not correct type");
            Assert.Validate.AreEqual(((TestTypes.SetClass3) setArray[3]).InstanceId, 1,
                "Incorrect instance Id returned for fourth element");
        }
    }
}