// -----------------------------------------------------------------------
//  <copyright file="AssertTests.cs" company="DangerDan9631">
//      Copyright (c) 2017 Dan Garvey. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/Dangerdan9631/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.Diagnostics
{
    using System;
    using System.Collections.Generic;
    using Dangr.Core.Diagnostics;
    using Dangr.Core.Test;
    using Dangr.Core.Util;
    using Dangr.Internal.Diagnostics;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class AssertTests
    {
        private class TestDisposable : ICheckedDisposable
        {
            /// <summary>
            /// Gets a value indicating whether this 
            /// <see cref="ICheckedDisposable" /> has been disposed.
            /// </summary>
            public bool IsDisposed { get; private set; }

            /// <summary>
            /// Finalizes an instance of the <see cref="AssertTests.TestDisposable" /> class.
            /// </summary>
            ~TestDisposable()
            {
                this.Dispose(false);
            }

            /// <summary>
            /// Disposes the resources managed by this <see cref="ICheckedDisposable" /> .
            /// </summary>
            public void Dispose()
            {
                if (this.IsDisposed)
                {
                    return;
                }

                this.Dispose(true);
                GC.SuppressFinalize(this);
            }

            /// <summary>
            /// Disposes the resources managed by this <see cref="ICheckedDisposable" /> .
            /// </summary>
            /// <param name="isDisposing">
            /// <c> true </c> if the method call comes from a <see cref="Dispose"/> method, or <c> false </c> if it comes from the finalizer.
            /// </param>
            protected virtual void Dispose(bool isDisposing)
            {
                if (isDisposing)
                {
                    this.IsDisposed = true;
                }
            }
        }

        [TestMethod]
        public void AssertTest()
        {
            AssertResolver assert = new ValidateResolver();

            TestDisposable obj1 = new TestDisposable();
            TestDisposable obj2 = new TestDisposable();
            var emptyCollection = new List<object>();
            var filledCollection = new List<object>
            {
                obj1,
                obj2
            };

            assert.IsTrue(true, "IsTrue Failed.");
            TestUtils.TestForError<ValidationFailedException>(
                () => assert.IsTrue(false, "IsTrue Failed."),
                "IsTrue did not fail.");

            assert.IsFalse(false, "IsFalse Failed.");
            TestUtils.TestForError<ValidationFailedException>(
                () => assert.IsFalse(true, "IsFalse Failed."),
                "IsFalse did not fail.");

            assert.AreEqual(1, 1, "AreEqual Failed.");
            assert.AreEqual(null, null, "AreEqual Failed.");
            TestUtils.TestForError<ValidationFailedException>(
                () => assert.AreEqual(1, 2, "AreEqual Failed."),
                "AreEqual did not fail.");
            TestUtils.TestForError<ValidationFailedException>(
                () => assert.AreEqual(null, 2, "AreEqual Failed."),
                "AreEqual did not fail.");
            TestUtils.TestForError<ValidationFailedException>(
                () => assert.AreEqual(1, null, "AreEqual Failed."),
                "AreEqual did not fail.");

            assert.AreNotEqual(1, 2, "AreNotEqual Failed.");
            TestUtils.TestForError<ValidationFailedException>(
                () => assert.AreNotEqual(1, 1, "AreNotEqual Failed."),
                "AreNotEqual did not fail.");

            assert.IsNotNull(obj1, "IsNotNull Failed.");
            TestUtils.TestForError<ValidationFailedException>(
                () => assert.IsNotNull(null, "IsNotNull Failed."),
                "IsNotNull did not fail.");

            assert.IsNull(null, "IsNull Failed.");
            TestUtils.TestForError<ValidationFailedException>(
                () => assert.IsNull(obj1, "IsNull Failed."),
                "IsNull did not fail.");

            assert.IsNullOrEmpty(null, "IsNullOrEmpty Failed.");
            assert.IsNullOrEmpty(string.Empty, "IsNullOrEmpty Failed.");
            TestUtils.TestForError<ValidationFailedException>(
                () => assert.IsNullOrEmpty("string", "IsNullOrEmpty Failed."),
                "IsNullOrEmpty did not fail.");

            assert.IsNotNullOrEmpty("string", "IsNotNullOrEmpty Failed.");
            TestUtils.TestForError<ValidationFailedException>(
                () => assert.IsNotNullOrEmpty(null, "IsNotNullOrEmpty Failed."),
                "IsNotNullOrEmpty did not fail.");
            TestUtils.TestForError<ValidationFailedException>(
                () => assert.IsNotNullOrEmpty(string.Empty, "IsNotNullOrEmpty Failed."),
                "IsNotNullOrEmpty did not fail.");

            assert.IsNullOrWhiteSpace(null, "IsNullOrWhiteSpace Failed.");
            assert.IsNullOrWhiteSpace(string.Empty, "IsNullOrWhiteSpace Failed.");
            assert.IsNullOrWhiteSpace(" ", "IsNullOrWhiteSpace Failed.");
            TestUtils.TestForError<ValidationFailedException>(
                () => assert.IsNullOrWhiteSpace("string", "IsNullOrWhiteSpace Failed."),
                "IsNullOrWhiteSpace did not fail.");

            assert.IsNotNullOrWhiteSpace("string", "IsNotNullOrWhiteSpace Failed.");
            TestUtils.TestForError<ValidationFailedException>(
                () => assert.IsNotNullOrWhiteSpace(null, "IsNotNullOrWhiteSpace Failed."),
                "IsNotNullOrWhiteSpace did not fail.");
            TestUtils.TestForError<ValidationFailedException>(
                () => assert.IsNotNullOrWhiteSpace(string.Empty, "IsNotNullOrWhiteSpace Failed."),
                "IsNotNullOrWhiteSpace did not fail.");
            TestUtils.TestForError<ValidationFailedException>(
                () => assert.IsNotNullOrWhiteSpace(" ", "IsNotNullOrWhiteSpace Failed."),
                "IsNotNullOrWhiteSpace did not fail.");

            assert.IsNotEmpty(filledCollection, "IsNotEmpty Failed.");
            TestUtils.TestForError<ValidationFailedException>(
                () => assert.IsNotEmpty(emptyCollection, "IsNotEmpty Failed."),
                "IsNotEmpty did not fail.");

            assert.IsEmpty(emptyCollection, "IsEmpty Failed.");
            TestUtils.TestForError<ValidationFailedException>(
                () => assert.IsEmpty(filledCollection, "IsEmpty Failed."),
                "IsEmpty did not fail.");

            assert.IsNotZero(1, "IsNotZero Failed.");
            assert.IsNotZero(float.Epsilon, "IsNotZero Failed.");
            assert.IsNotZero(double.Epsilon, "IsNotZero Failed.");
            TestUtils.TestForError<ValidationFailedException>(
                () => assert.IsNotZero(0, "IsNotZero Failed."),
                "IsNotZero did not fail.");
            TestUtils.TestForError<ValidationFailedException>(
                () => assert.IsNotZero(0.0f, "IsNotZero Failed."),
                "IsNotZero did not fail.");
            TestUtils.TestForError<ValidationFailedException>(
                () => assert.IsNotZero(0.0, "IsNotZero Failed."),
                "IsNotZero did not fail.");

            assert.IsInRange(1, 1, 3, "IsInRange Failed.");
            assert.IsInRange(2, 1, 3, "IsInRange Failed.");
            assert.IsInRange(3, 1, 3, "IsInRange Failed.");
            TestUtils.TestForError<ValidationFailedException>(
                () => assert.IsInRange(0, 1, 2, "IsInRange Failed."),
                "IsInRange did not fail.");
            TestUtils.TestForError<ValidationFailedException>(
                () => assert.IsInRange(3, 1, 2, "IsInRange Failed."),
                "IsInRange did not fail.");

            assert.IsInRange(1f, 1, 3, "IsInRange Failed.");
            assert.IsInRange(2f, 1, 3, "IsInRange Failed.");
            assert.IsInRange(3f, 1, 3, "IsInRange Failed.");
            TestUtils.TestForError<ValidationFailedException>(
                () => assert.IsInRange(0.0f, 1, 2, "IsInRange Failed."),
                "IsInRange did not fail.");
            TestUtils.TestForError<ValidationFailedException>(
                () => assert.IsInRange(3.0f, 1, 2, "IsInRange Failed."),
                "IsInRange did not fail.");

            assert.IsInRange(1.0, 1, 3, "IsInRange Failed.");
            assert.IsInRange(2.0, 1, 3, "IsInRange Failed.");
            assert.IsInRange(3.0, 1, 3, "IsInRange Failed.");
            TestUtils.TestForError<ValidationFailedException>(
                () => assert.IsInRange(0.0, 1, 2, "IsInRange Failed."),
                "IsInRange did not fail.");
            TestUtils.TestForError<ValidationFailedException>(
                () => assert.IsInRange(3.0, 1, 2, "IsInRange Failed."),
                "IsInRange did not fail.");

            assert.Compare(0, CompareOperation.Equal, 0, "Compare Failed.");
            assert.Compare(2, CompareOperation.Greater, 1, "Compare Failed.");
            assert.Compare(1, CompareOperation.GreaterEqual, 1, "Compare Failed.");
            assert.Compare(2, CompareOperation.GreaterEqual, 1, "Compare Failed.");
            assert.Compare(0, CompareOperation.Less, 1, "Compare Failed.");
            assert.Compare(0, CompareOperation.LessEqual, 1, "Compare Failed.");
            assert.Compare(1, CompareOperation.LessEqual, 1, "Compare Failed.");
            TestUtils.TestForError<ValidationFailedException>(
                () => assert.Compare(0, CompareOperation.Equal, 1, "Compare Failed."),
                "Compare did not fail.");
            TestUtils.TestForError<ValidationFailedException>(
                () => assert.Compare(0, CompareOperation.Greater, 1, "Compare Failed."),
                "Compare did not fail.");
            TestUtils.TestForError<ValidationFailedException>(
                () => assert.Compare(1, CompareOperation.Greater, 1, "Compare Failed."),
                "Compare did not fail.");
            TestUtils.TestForError<ValidationFailedException>(
                () => assert.Compare(0, CompareOperation.GreaterEqual, 1, "Compare Failed."),
                "Compare did not fail.");
            TestUtils.TestForError<ValidationFailedException>(
                () => assert.Compare(1, CompareOperation.Less, 1, "Compare Failed."),
                "Compare did not fail.");
            TestUtils.TestForError<ValidationFailedException>(
                () => assert.Compare(2, CompareOperation.Less, 1, "Compare Failed."),
                "Compare did not fail.");
            TestUtils.TestForError<ValidationFailedException>(
                () => assert.Compare(2, CompareOperation.LessEqual, 1, "Compare Failed."),
                "Compare did not fail.");

            assert.Compare(0.0f, CompareOperation.Equal, 0, "Compare Failed.");
            assert.Compare(2.0f, CompareOperation.Greater, 1, "Compare Failed.");
            assert.Compare(1.0f, CompareOperation.GreaterEqual, 1, "Compare Failed.");
            assert.Compare(2.0f, CompareOperation.GreaterEqual, 1, "Compare Failed.");
            assert.Compare(0.0f, CompareOperation.Less, 1, "Compare Failed.");
            assert.Compare(0.0f, CompareOperation.LessEqual, 1, "Compare Failed.");
            assert.Compare(1.0f, CompareOperation.LessEqual, 1, "Compare Failed.");
            TestUtils.TestForError<ValidationFailedException>(
                () => assert.Compare(0.0f, CompareOperation.Equal, 1, "Compare Failed."),
                "Compare did not fail.");
            TestUtils.TestForError<ValidationFailedException>(
                () => assert.Compare(0.0f, CompareOperation.Greater, 1, "Compare Failed."),
                "Compare did not fail.");
            TestUtils.TestForError<ValidationFailedException>(
                () => assert.Compare(1.0f, CompareOperation.Greater, 1, "Compare Failed."),
                "Compare did not fail.");
            TestUtils.TestForError<ValidationFailedException>(
                () => assert.Compare(0.0f, CompareOperation.GreaterEqual, 1, "Compare Failed."),
                "Compare did not fail.");
            TestUtils.TestForError<ValidationFailedException>(
                () => assert.Compare(1.0f, CompareOperation.Less, 1, "Compare Failed."),
                "Compare did not fail.");
            TestUtils.TestForError<ValidationFailedException>(
                () => assert.Compare(2.0f, CompareOperation.Less, 1, "Compare Failed."),
                "Compare did not fail.");
            TestUtils.TestForError<ValidationFailedException>(
                () => assert.Compare(2.0f, CompareOperation.LessEqual, 1, "Compare Failed."),
                "Compare did not fail.");

            assert.Compare(0.0, CompareOperation.Equal, 0, "Compare Failed.");
            assert.Compare(2.0, CompareOperation.Greater, 1, "Compare Failed.");
            assert.Compare(1.0, CompareOperation.GreaterEqual, 1, "Compare Failed.");
            assert.Compare(2.0, CompareOperation.GreaterEqual, 1, "Compare Failed.");
            assert.Compare(0.0, CompareOperation.Less, 1, "Compare Failed.");
            assert.Compare(0.0, CompareOperation.LessEqual, 1, "Compare Failed.");
            assert.Compare(1.0, CompareOperation.LessEqual, 1, "Compare Failed.");
            TestUtils.TestForError<ValidationFailedException>(
                () => assert.Compare(0.0, CompareOperation.Equal, 1, "Compare Failed."),
                "Validation did not fail.");
            TestUtils.TestForError<ValidationFailedException>(
                () => assert.Compare(0.0, CompareOperation.Greater, 1, "Compare Failed."),
                "Validation did not fail.");
            TestUtils.TestForError<ValidationFailedException>(
                () => assert.Compare(1.0, CompareOperation.Greater, 1, "Compare Failed."),
                "Validation did not fail.");
            TestUtils.TestForError<ValidationFailedException>(
                () => assert.Compare(0.0, CompareOperation.GreaterEqual, 1, "Compare Failed."),
                "Validation did not fail.");
            TestUtils.TestForError<ValidationFailedException>(
                () => assert.Compare(1.0, CompareOperation.Less, 1, "Compare Failed."),
                "Validation did not fail.");
            TestUtils.TestForError<ValidationFailedException>(
                () => assert.Compare(2.0, CompareOperation.Less, 1, "Compare Failed."),
                "Validation did not fail.");
            TestUtils.TestForError<ValidationFailedException>(
                () => assert.Compare(2.0, CompareOperation.LessEqual, 1, "Compare Failed."),
                "Validation did not fail.");

            assert.NotDisposed(obj1, "NotDisposed Failed.");
            obj2.Dispose();
            TestUtils.TestForError<ObjectDisposedException>(
                () => assert.NotDisposed(obj2, "NotDisposed Failed."),
                "Validation did not fail.");

            assert.IsType<TestDisposable>(obj1, "IsType Failed.");
            TestUtils.TestForError<ValidationFailedException>(
                () => assert.IsType<TestDisposable>(new object(), "IsType Failed."),
                "Validation did not fail.");

            assert.IsTypeOrNull<TestDisposable>(obj1, "IsTypeOrNull Failed.");
            assert.IsTypeOrNull<TestDisposable>(null, "IsTypeOrNull Failed.");
            TestUtils.TestForError<ValidationFailedException>(
                () => assert.IsTypeOrNull<TestDisposable>(new object(), "IsTypeOrNull Failed."),
                "Validation did not fail.");

            TestUtils.TestForError<ValidationFailedException>(
                () => assert.Fail("Fail Failed."),
                "Validation did not fail.");
        }
    }
}