// -----------------------------------------------------------------------
//  <copyright file="InjectionCoreSetTest.cs" company="DangerDan9631">
//      Copyright (c) 2017 Dan Garvey. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/Dangerdan9631/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.Inject
{
    using System.Collections.Generic;
    using System.Linq;
    using Dangr.Annotation;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Assert = Dangr.Diagnostics.Assert;

    [TestClass]
    public class InjectionCoreSetTest
    {
        [InjectionModule]
        public class TestModule
        {
            [Singleton] [ProvidesSet(typeof(TestTypes.ISetClass))] public TestTypes.SetClass1 SetClass1Instance;

            [Singleton] [ProvidesSet(typeof(TestTypes.ISetClass))] public TestTypes.SetClass2 SetClass2Instance;

            [Singleton] [ProvidesSet(typeof(TestTypes.ISetClass))] public TestTypes.SetClass3 SetClass3Instance1;

            [Singleton] [ProvidesSet(typeof(TestTypes.ISetClass))] public TestTypes.SetClass3 SetClass3Instance2;
        }

        private InjectionCore core;

        [TestInitialize]
        public void Setup()
        {
            this.core = new InjectionCore();
            this.core.LoadModule(typeof(TestModule));
        }
        
        [Task("https://github.com/Dangerdan9631/DangrLib/issues/7", Description = "Dangr.Inject Tests are failing")]
        [Ignore]
        [TestMethod]
        public void TestSet()
        {
            var set = this.core.Get<IEnumerable<TestTypes.ISetClass>>();

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