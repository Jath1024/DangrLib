// -----------------------------------------------------------------------
//  <copyright file="RegistryTest.cs" company="DangerDan9631">
//      Copyright (c) 2017 Dan Garvey. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/Dangerdan9631/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.Registry
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Runtime.Serialization.Json;
    using System.Threading;
    using System.Threading.Tasks;
    using Dangr.Core.Registry;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    public abstract class RegistryTest
    {
        protected Dictionary<string, string> expectedValues;
        protected IRegistry testRegistry;

        protected void InitializeTest()
        {
            this.testRegistry = this.CreateRegistry();

            this.testRegistry.Edit()
                .SetBool(RegNames.ValBoolTrue, true)
                .SetDouble(RegNames.ValDouble101, 10.1)
                .SetFloat(RegNames.ValFloat1542, 154.2f)
                .SetInt(RegNames.ValInt19, 19)
                .SetLong(RegNames.ValLong184, 184L)
                .SetString(RegNames.ValStringHello, "hello")
                .Apply();

            this.expectedValues = new Dictionary<string, string>(this.testRegistry.GetValues());
        }

        protected abstract IRegistry CreateRegistry();

        protected void CheckValue(IRegistry reg, Dictionary<string, string> expectedValues)
        {
            IDictionary<string, string> actualValues = reg.GetValues();

            foreach (KeyValuePair<string, string> kvp in actualValues)
            {
                Assert.IsTrue(expectedValues.ContainsKey(kvp.Key), "Unexpected key '{0}' found.", kvp.Key);
                Assert.AreEqual(expectedValues[kvp.Key], kvp.Value, "Unexpected value found for key '{0}'", kvp.Key);
            }

            foreach (KeyValuePair<string, string> kvp in expectedValues)
            {
                Assert.IsTrue(actualValues.ContainsKey(kvp.Key), "Could not find expected key '{0}'.", kvp.Key);
            }
        }

        protected void TestCreate()
        {
            this.CheckValue(this.testRegistry, this.expectedValues);
        }

        protected void TestModify()
        {
            bool valueChangedEvent = false;
            this.testRegistry.ValueChanged += (o, str) =>
            {
                Assert.AreEqual(str.Key, RegNames.ValBoolTrue, "Unexpected key changed");
                valueChangedEvent = true;
            };

            this.testRegistry.Edit().SetBool(RegNames.ValBoolTrue, false).Apply();

            this.expectedValues[RegNames.ValBoolTrue] = false.ToString();

            this.CheckValue(this.testRegistry, this.expectedValues);
            Assert.IsTrue(valueChangedEvent, "ValueChangedEvent was not triggered.");
        }

        protected void TestRemove()
        {
            bool valueChangedEvent = false;
            this.testRegistry.ValueChanged += (o, str) =>
            {
                Assert.AreEqual(str.Key, RegNames.ValBoolTrue, "Unexpected key changed");
                valueChangedEvent = true;
            };

            int numEntries = this.testRegistry.Count;
            this.testRegistry.Edit().Remove(RegNames.ValBoolTrue).Apply();
            Assert.IsFalse(this.testRegistry.GetBool(RegNames.ValBoolTrue, false), "Key was not removed");
            Assert.AreEqual(this.testRegistry.Count, numEntries - 1, "Incorrect number of entries");
            Assert.IsTrue(valueChangedEvent, "ValueChangedEvent was not triggered.");
        }

        protected void TestClear()
        {
            int numKeys = this.testRegistry.Count;
            int valueChangedEventCount = 0;
            this.testRegistry.ValueChanged += (o, str) => { valueChangedEventCount++; };

            this.testRegistry.Edit().Clear().Apply();
            Assert.AreEqual(this.testRegistry.Count, 0, "Registry was not cleared.");
            Assert.AreEqual(
                numKeys,
                valueChangedEventCount,
                "ValueChangedEvent was not triggered expected number of times.");
        }

        protected void TestAddRemove()
        {
            int valueChangedEventCount = 0;
            this.testRegistry.ValueChanged += (o, str) =>
            {
                Assert.AreEqual(str.Key, RegNames.ValBoolTrue, "Unexpected key changed");
                valueChangedEventCount++;
            };

            this.testRegistry.Edit().SetBool(RegNames.ValBoolTrue, true).Remove(RegNames.ValBoolTrue).Apply();

            Assert.IsTrue(this.testRegistry.GetBool(RegNames.ValBoolTrue, false), "Value was not added after remove");
            Assert.AreEqual(1, valueChangedEventCount, "ValueChangedEvent was not triggered expected number of times.");
        }

        protected void TestInvalidType()
        {
            try
            {
                this.testRegistry.GetInt(RegNames.ValBoolTrue, 10);
            }
            catch (ArgumentException)
            {
                return;
            }

            Assert.Fail("Expected exception was not thrown");
        }

        protected void TestSerialize()
        {
            using (MemoryStream stream = new MemoryStream())
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(MemoryRegistry));
                serializer.WriteObject(stream, (MemoryRegistry) this.testRegistry);

                stream.Position = 0;
                IRegistry reg2 = (IRegistry) serializer.ReadObject(stream);

                this.CheckValue(reg2, this.expectedValues);
            }
        }

        protected void TestConcurrentReadLock()
        {
            // Get a write lock
            IRegistryEditor editor = this.testRegistry.Edit();
            editor.Lock();

            // Try to read the value
            var t = new Task<bool>(() => this.testRegistry.GetBool(RegNames.ValAsyncTrue, false));
            t.Start();

            // Delay to guarantee race condition
            Thread.Sleep(500);

            // Modify the value
            editor.SetBool(RegNames.ValAsyncTrue, true).Apply();

            // Make sure the modified value was read in parallel thread
            t.Wait();
            Assert.IsTrue(t.Result, "Read was not locked in parallel thread");
        }

        protected void TestConcurrentWriteLock()
        {
            // Get a write lock
            IRegistryEditor editor = this.testRegistry.Edit();
            editor.Lock();

            // Try to modify the value
            Task t = new Task(() => this.testRegistry.Edit().SetBool(RegNames.ValAsyncTrue, true).Apply());
            t.Start();

            // Delay to guarantee race condition
            Thread.Sleep(500);

            // Modify the value
            editor.SetBool(RegNames.ValAsyncTrue, false).Apply();

            // Make sure the parallel thread wrote the value second
            t.Wait();
            Assert.IsTrue(
                this.testRegistry.GetBool(RegNames.ValAsyncTrue, false),
                "Write was not locked in parallel thread");
        }
    }
}