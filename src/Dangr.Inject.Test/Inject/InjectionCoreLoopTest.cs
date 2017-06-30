// -----------------------------------------------------------------------
//  <copyright file="InjectionCoreLoopTest.cs" company="DangerDan9631">
//      Copyright (c) 2017 Dan Garvey. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/Dangerdan9631/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.Inject
{
    using System;
    using Dangr.Test;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class InjectionCoreLoopTest
    {
        [InjectionModule]
        public class TestModule
        {
            [Singleton]
            [Provides(typeof(TestTypes.LoopedClass1))]
            public TestTypes.LoopedClass1 LoopedClass1Instance { get; set; }

            [Singleton]
            [Provides(typeof(TestTypes.LoopedClass2))]
            public TestTypes.LoopedClass2 LoopedClass2Instance { get; set; }

            [Singleton]
            [Provides("LoopedMethod1")]
            public static object ProvideLoopedMethod1([Named("LoopedMethod2")] object obj)
            {
                return new object();
            }

            [Singleton]
            [Provides("LoopedMethod2")]
            public static object ProvideLoopedMethod2([Named("LoopedMethod1")] object obj)
            {
                return new object();
            }

            [Singleton]
            [Provides("SelfLoopedMethod1")]
            public static object ProvideSelfLoopedMethod1([Named("SelfLoopedMethod1")] object obj)
            {
                return new object();
            }

            [Singleton]
            [Provides("NotLoopedMethod1")]
            public static object ProvideNotLoopedMethod1(
                [Named("NotLoopedMethod2")] object obj1,
                [Named("NotLoopedMethod3")] object obj2,
                [Named("NotLoopedMethod4")] object obj3,
                [Named("NotLoopedMethod4")] object obj4)
            {
                return new object();
            }

            [Singleton]
            [Provides("NotLoopedMethod2")]
            public static object ProvideNotLoopedMethod2([Named("NotLoopedMethod3")] object obj)
            {
                return new object();
            }

            [Singleton]
            [Provides("NotLoopedMethod3")]
            public static object ProvideNotLoopedMethod3()
            {
                return new object();
            }

            [Singleton]
            [Provides("NotLoopedMethod4")]
            public static object ProvideNotLoopedMethod4([Named("NotLoopedMethod3")] object obj)
            {
                return new object();
            }
        }

        private InjectionCore core;

        [TestInitialize]
        public void Setup()
        {
            this.core = new InjectionCore();
            this.core.LoadModule(typeof(TestModule));
        }

        [TestMethod]
        public void TestLoopedConstructor()
        {
            TestUtils.TestForError<InvalidOperationException>(
                () => this.core.Get<TestTypes.LoopedClass1>(),
                "Did not catch expected Exception");
        }

        [TestMethod]
        public void TestLoopedMethod()
        {
            TestUtils.TestForError<InvalidOperationException>(
                () => this.core.Get("LoopedMethod1"),
                "Did not catch expected Exception");
        }

        [TestMethod]
        public void TestSelfLoopedMethod()
        {
            TestUtils.TestForError<InvalidOperationException>(
                () => this.core.Get("SelfLoopedMethod1"),
                "Did not catch expected Exception");
        }

        [TestMethod]
        public void TestNotLoopedMethod()
        {
            this.core.Get("NotLoopedMethod1");
        }
    }
}