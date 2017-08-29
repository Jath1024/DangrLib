// -----------------------------------------------------------------------
//  <copyright file="RegistryTest.cs" company="Phoenix Game Studios, LLC">
//      Copyright (c) 2017 Phoenix Game Studios, LLC. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/PhoenixGameStudios/DangrLib/blob/master/LICENSE for full license information.
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
    using Dangr.Core.Diagnostics;
    using Dangr.Core.Registry;
    using Dangr.Core.Test;

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
                Validate.Value.IsTrue(expectedValues.ContainsKey(kvp.Key), $"Unexpected key '{kvp.Key}' found.");
                Validate.Value.AreEqual(expectedValues[kvp.Key], kvp.Value, $"Unexpected value found for key '{kvp.Key}'");
            }

            foreach (KeyValuePair<string, string> kvp in expectedValues)
            {
                Validate.Value.IsTrue(actualValues.ContainsKey(kvp.Key), "Could not find expected key '{kvp.Key}'.");
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
                Validate.Value.AreEqual(str.Key, RegNames.ValBoolTrue, "Unexpected key changed");
                valueChangedEvent = true;
            };

            this.testRegistry.Edit().SetBool(RegNames.ValBoolTrue, false).Apply();

            this.expectedValues[RegNames.ValBoolTrue] = false.ToString();

            this.CheckValue(this.testRegistry, this.expectedValues);
            Validate.Value.IsTrue(valueChangedEvent, "ValueChangedEvent was not triggered.");
            Console.WriteLine(this.testRegistry.ToString());
        }

        protected void TestRemove()
        {
            bool valueChangedEvent = false;
            this.testRegistry.ValueChanged += (o, str) =>
            {
                Validate.Value.AreEqual(str.Key, RegNames.ValBoolTrue, "Unexpected key changed");
                valueChangedEvent = true;
            };

            int numEntries = this.testRegistry.Count;
            this.testRegistry.Edit().Remove(RegNames.ValBoolTrue).Apply();
            Validate.Value.IsFalse(this.testRegistry.GetBool(RegNames.ValBoolTrue, false), "Key was not removed");
            Validate.Value.AreEqual(this.testRegistry.Count, numEntries - 1, "Incorrect number of entries");
            Validate.Value.IsTrue(valueChangedEvent, "ValueChangedEvent was not triggered.");

            // Remove invalid key
            TestUtils.TestForError<ArgumentException>(
                () => this.testRegistry.Edit().Remove(" "),
                "Exception was not thrown when removing invalid key.");
        }

        protected void TestClear()
        {
            int numKeys = this.testRegistry.Count;
            int valueChangedEventCount = 0;
            this.testRegistry.ValueChanged += (o, str) => { valueChangedEventCount++; };

            this.testRegistry.Edit().Clear().Apply();
            Validate.Value.AreEqual(this.testRegistry.Count, 0, "Registry was not cleared.");
            Validate.Value.AreEqual(
                numKeys,
                valueChangedEventCount,
                "ValueChangedEvent was not triggered expected number of times.");
        }

        protected void TestAddRemove()
        {
            int valueChangedEventCount = 0;
            this.testRegistry.ValueChanged += (o, str) =>
            {
                Validate.Value.AreEqual(str.Key, RegNames.ValBoolTrue, "Unexpected key changed");
                valueChangedEventCount++;
            };

            this.testRegistry.Edit().SetBool(RegNames.ValBoolTrue, true).Remove(RegNames.ValBoolTrue).Apply();

            Validate.Value.IsTrue(this.testRegistry.GetBool(RegNames.ValBoolTrue, false), "Value was not added after remove");
            Validate.Value.AreEqual(1, valueChangedEventCount, "ValueChangedEvent was not triggered expected number of times.");
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

            Validate.Value.Fail("Expected exception was not thrown");
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
            Validate.Value.IsTrue(t.Result, "Read was not locked in parallel thread");
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
            Validate.Value.IsTrue(
                this.testRegistry.GetBool(RegNames.ValAsyncTrue, false),
                "Write was not locked in parallel thread");
        }

        protected void TestString()
        {
            // Null value
            TestUtils.TestForError<ArgumentException>(
                () => this.testRegistry.GetString(null, "Bye"),
                "Exception was not thrown for null key.");

            // Non existant value
            Validate.Value.AreEqual(
                this.testRegistry.GetString("FakeEntry", "Bye"),
                "Bye",
                "Default value not returned for nonexistant key.");
            
            // Valid Value
            Validate.Value.AreEqual(
                this.testRegistry.GetString(RegNames.ValStringHello, "Bye"),
                "hello",
                "Wrong value returned.");
            
            // Add with invalid key
            TestUtils.TestForError<ArgumentException>(
                () => this.testRegistry.Edit().SetString(" ", "Bye"),
                "Exception was not thrown when adding with invalid key.");
        }

        protected void TestLong()
        {
            // Null value
            TestUtils.TestForError<ArgumentException>(
                () => this.testRegistry.GetLong(null, 10L),
                "Exception was not thrown for null key.");

            // Non existant value
            Validate.Value.AreEqual(
                this.testRegistry.GetLong("FakeEntry", 10L),
                10L,
                "Default value not returned for nonexistant key.");

            // Incorrect Type
            TestUtils.TestForError<ArgumentException>(
                () => this.testRegistry.GetLong(RegNames.ValStringHello, 10L),
                "Exception was not thrown for key of wrong type.");

            // Valid Value
            Validate.Value.AreEqual(
                this.testRegistry.GetLong(RegNames.ValLong184, 10L),
                184L,
                "Wrong value returned.");

            // Add with invalid key
            TestUtils.TestForError<ArgumentException>(
                () => this.testRegistry.Edit().SetLong(" ", 123L),
                "Exception was not thrown when adding with invalid key.");
        }

        protected void TestFloat()
        {
            // Null value
            TestUtils.TestForError<ArgumentException>(
                () => this.testRegistry.GetFloat(null, 10f),
                "Exception was not thrown for null key.");

            // Non existant value
            Validate.Value.Comparison(
                this.testRegistry.GetFloat("FakeEntry", 10f),
                CompareOperation.Equal,
                10f,
                "Default value not returned for nonexistant key.");

            // Incorrect Type
            TestUtils.TestForError<ArgumentException>(
                () => this.testRegistry.GetFloat(RegNames.ValStringHello, 10f),
                "Exception was not thrown for key of wrong type.");

            // Valid Value
            Validate.Value.Comparison(
                this.testRegistry.GetFloat(RegNames.ValFloat1542, 10f),
                CompareOperation.Equal,
                154.2f,
                "Wrong value returned.");

            // Add with invalid key
            TestUtils.TestForError<ArgumentException>(
                () => this.testRegistry.Edit().SetFloat(" ", 12.3f),
                "Exception was not thrown when adding with invalid key.");
        }

        protected void TestDouble()
        {
            // Null value
            TestUtils.TestForError<ArgumentException>(
                () => this.testRegistry.GetDouble(null, 10.0),
                "Exception was not thrown for null key.");

            // Non existant value
            Validate.Value.Comparison(
                this.testRegistry.GetDouble("FakeEntry", 10.0),
                CompareOperation.Equal,
                10.0,
                "Default value not returned for nonexistant key.");

            // Incorrect Type
            TestUtils.TestForError<ArgumentException>(
                () => this.testRegistry.GetDouble(RegNames.ValStringHello, 10.0),
                "Exception was not thrown for key of wrong type.");

            // Valid Value
            Validate.Value.Comparison(
                this.testRegistry.GetDouble(RegNames.ValDouble101, 10.0),
                CompareOperation.Equal,
                10.1,
                "Wrong value returned.");

            // Add with invalid key
            TestUtils.TestForError<ArgumentException>(
                () => this.testRegistry.Edit().SetDouble(" ", 123.4),
                "Exception was not thrown when adding with invalid key.");
        }

        protected void TestInt()
        {
            // Null value
            TestUtils.TestForError<ArgumentException>(
                () => this.testRegistry.GetInt(null, 10),
                "Exception was not thrown for null key.");

            // Non existant value
            Validate.Value.AreEqual(
                this.testRegistry.GetInt("FakeEntry", 10),
                10,
                "Default value not returned for nonexistant key.");

            // Incorrect Type
            TestUtils.TestForError<ArgumentException>(
                () => this.testRegistry.GetInt(RegNames.ValStringHello, 10),
                "Exception was not thrown for key of wrong type.");

            // Valid Value
            Validate.Value.AreEqual(
                this.testRegistry.GetInt(RegNames.ValInt19, 10),
                19,
                "Wrong value returned.");

            // Add with invalid key
            TestUtils.TestForError<ArgumentException>(
                () => this.testRegistry.Edit().SetInt(" ", 345),
                "Exception was not thrown when adding with invalid key.");
        }

        protected void TestBool()
        {
            // Null value
            TestUtils.TestForError<ArgumentException>(
                () => this.testRegistry.GetBool(null, false),
                "Exception was not thrown for null key.");

            // Non existant value
            Validate.Value.AreEqual(
                this.testRegistry.GetBool("FakeEntry", false),
                false,
                "Default value not returned for nonexistant key.");

            // Incorrect Type
            TestUtils.TestForError<ArgumentException>(
                () => this.testRegistry.GetBool(RegNames.ValStringHello, false),
                "Exception was not thrown for key of wrong type.");

            // Valid Value
            Validate.Value.AreEqual(
                this.testRegistry.GetBool(RegNames.ValBoolTrue, false),
                true,
                "Wrong value returned.");

            // Add with invalid key
            TestUtils.TestForError<ArgumentException>(
                () => this.testRegistry.Edit().SetBool(" ", false),
                "Exception was not thrown when adding with invalid key.");
        }
    }
}