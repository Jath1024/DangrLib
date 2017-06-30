// -----------------------------------------------------------------------
//  <copyright file="InjectionCoreTest.cs" company="DangerDan9631">
//      Copyright (c) 2017 Dan Garvey. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/Dangerdan9631/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.Inject
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Assert = Dangr.Diagnostics.Assert;

    [TestClass]
    public class InjectionCoreTest
    {
        [InjectionModule]
        public class TestModule
        {
            [Singleton]
            [Provides(typeof(TestTypes.IClass1))]
            public TestTypes.Class1 Class1Instance { get; set; }

            [Prototype]
            [Provides(typeof(TestTypes.IClass2))]
            public TestTypes.Class2 Class2Instance { get; set; }

            [Singleton]
            [Provides("NamedClass1")]
            public TestTypes.Class1 NamedClass1Instance { get; set; }

            [Singleton]
            [Provides(typeof(TestTypes.Class3), "NamedClass3")]
            public TestTypes.Class3 NamedClass3Instance { get; set; }

            [Singleton]
            [Provides(typeof(TestTypes.Class1Container))]
            public TestTypes.Class1Container
                Class1ContainerInstance { get; set; }

            [Singleton]
            [Provides("ConstructedClass1Container")]
            public static TestTypes.Class1Container ProvideClass1Container(TestTypes.IClass1 class1)
            {
                return new TestTypes.Class1Container(class1);
            }

            [Singleton]
            [Provides("ConstructedClass1ContainerWithNamedDependency")]
            public static TestTypes.Class1Container ProvideClass1ContainerWithNamedClass(
                [Named("NamedClass1")] TestTypes.IClass1 class1)
            {
                return new TestTypes.Class1Container(class1);
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
        public void TestSingleton()
        {
            TestTypes.IClass1 first = this.core.Get<TestTypes.IClass1>();
            TestTypes.IClass1 second = this.core.Get<TestTypes.IClass1>();

            Assert.Validate.IsNotNull(first, "First instance is null.");
            Assert.Validate.IsNotNull(second, "First instance is null.");
            Assert.Validate.IsTrue(object.ReferenceEquals(first, second),
                "Did not return the same singleton between calls.");
        }

        [TestMethod]
        public void TestPrototype()
        {
            TestTypes.IClass2 first = this.core.Get<TestTypes.IClass2>();
            TestTypes.IClass2 second = this.core.Get<TestTypes.IClass2>();

            Assert.Validate.IsNotNull(first, "First instance is null.");
            Assert.Validate.IsNotNull(second, "First instance is null.");
            Assert.Validate.IsFalse(object.ReferenceEquals(first, second), "Returned the same prototype between calls.");
        }

        [TestMethod]
        public void TestNamed()
        {
            TestTypes.IClass1 first = (TestTypes.IClass1) this.core.Get("NamedClass1");
            TestTypes.IClass1 second = (TestTypes.IClass1) this.core.Get("NamedClass1");

            Assert.Validate.IsNotNull(first, "First instance is null.");
            Assert.Validate.IsNotNull(second, "First instance is null.");
            Assert.Validate.IsTrue(object.ReferenceEquals(first, second),
                "Did not return the same singleton between calls.");
        }

        [TestMethod]
        public void TestTypeAndNamed()
        {
            TestTypes.Class3 first = this.core.Get<TestTypes.Class3>();
            TestTypes.Class3 second = (TestTypes.Class3) this.core.Get("NamedClass3");

            Assert.Validate.IsNotNull(first, "First instance is null.");
            Assert.Validate.IsNotNull(second, "First instance is null.");
            Assert.Validate.IsTrue(object.ReferenceEquals(first, second),
                "Did not return the same singleton between calls.");
        }

        [TestMethod]
        public void TestNestedDependency()
        {
            TestTypes.Class1Container container = this.core.Get<TestTypes.Class1Container>();
            TestTypes.IClass1 contained = this.core.Get<TestTypes.IClass1>();

            Assert.Validate.IsNotNull(container, "Container instance is null.");
            Assert.Validate.IsNotNull(contained, "Contained instance is null.");
            Assert.Validate.IsTrue(object.ReferenceEquals(container.Class1Instance, contained),
                "Did not get the correct contained class.");
        }

        [TestMethod]
        public void TestProviderMethod()
        {
            TestTypes.Class1Container container =
                (TestTypes.Class1Container) this.core.Get("ConstructedClass1Container");
            TestTypes.IClass1 contained = this.core.Get<TestTypes.IClass1>();

            Assert.Validate.IsNotNull(container, "Container instance is null.");
            Assert.Validate.IsNotNull(contained, "Contained instance is null.");
            Assert.Validate.IsTrue(object.ReferenceEquals(container.Class1Instance, contained),
                "Did not get the correct contained class.");
        }

        [TestMethod]
        public void TestProviderMethodWithNamedDependency()
        {
            TestTypes.Class1Container container =
                (TestTypes.Class1Container) this.core.Get("ConstructedClass1ContainerWithNamedDependency");
            TestTypes.Class1 contained = (TestTypes.Class1) this.core.Get("NamedClass1");

            Assert.Validate.IsNotNull(container, "Container instance is null.");
            Assert.Validate.IsNotNull(contained, "Contained instance is null.");
            Assert.Validate.IsTrue(object.ReferenceEquals(container.Class1Instance, contained),
                "Did not get the correct contained class.");
        }
    }
}