// -----------------------------------------------------------------------
//  <copyright file="MemoryRegistryTest.cs" company="DangerDan9631">
//      Copyright (c) 2017 Dan Garvey. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/Dangerdan9631/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.Registry
{
    using Dangr.Core.Registry;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class MemoryRegistryTest : RegistryTest
    {
        [TestInitialize]
        public void TestInit()
        {
            this.InitializeTest();
        }

        protected override IRegistry CreateRegistry()
        {
            return new MemoryRegistry();
        }

        [TestMethod]
        public void MemoryRegistry_Create()
        {
            this.TestCreate();
        }

        [TestMethod]
        public void MemoryRegistry_Modify()
        {
            this.TestModify();
        }

        [TestMethod]
        public void MemoryRegistry_Remove()
        {
            this.TestRemove();
        }

        [TestMethod]
        public void MemoryRegistry_Clear()
        {
            this.TestClear();
        }

        [TestMethod]
        public void MemoryRegistry_AddRemove()
        {
            this.TestAddRemove();
        }

        [TestMethod]
        public void MemoryRegistry_InvalidType()
        {
            this.TestInvalidType();
        }

        [TestMethod]
        public void MemoryRegistry_Serialize()
        {
            this.TestSerialize();
        }

        [TestMethod]
        public void MemoryRegister_ConcurrentReadLock()
        {
            this.TestConcurrentReadLock();
        }

        [TestMethod]
        public void MemoryRegister_ConcurrentWriteLock()
        {
            this.TestConcurrentWriteLock();
        }

        [TestMethod]
        public void MemoryRegister_TestString()
        {
            this.TestString();
        }

        [TestMethod]
        public void MemoryRegister_TestLong()
        {
            this.TestLong();
        }

        [TestMethod]
        public void MemoryRegister_TestFloat()
        {
            this.TestFloat();
        }

        [TestMethod]
        public void MemoryRegister_TestDouble()
        {
            this.TestDouble();
        }

        [TestMethod]
        public void MemoryRegister_TestInt()
        {
            this.TestInt();
        }

        [TestMethod]
        public void MemoryRegister_TestBool()
        {
            this.TestBool();
        }
    }
}