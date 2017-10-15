// -----------------------------------------------------------------------
//  <copyright file="ConditionCheckerTestBase.cs" company="Phoenix Game Studios, LLC">
//      Copyright (c) 2017 Phoenix Game Studios, LLC. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/PhoenixGameStudios/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.Diagnostics
{
    using System;
    using System.Collections.Generic;
    using Dangr.Core.Diagnostics;
    using Dangr.Core.Test;
    using Dangr.Core.Util;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    public abstract class ConditionCheckerTestBase
    {
        protected IConditionChecker Checker { get; }

        protected ConditionCheckerTestBase(IConditionChecker checker)
        {
            this.Checker = checker;
        }

        protected abstract Type GetExceptionType(TestExceptionType exceptionType);

        protected abstract bool CheckShouldPass(TestExceptionType exceptionType);

        private void RunTest(Func<bool> test, TestExceptionType eType)
        {
            if (this.CheckShouldPass(eType))
            {
                Validate.Value.IsTrue(test());
            }
            else
            {
                Type exceptionType = this.GetExceptionType(eType);
                if (exceptionType == null)
                {
                    Validate.Value.IsFalse(test());
                }
                else
                {
                    TestUtils.TestForError(exceptionType, () => test());
                }
            }
        }

        [DataTestMethod]
        [DataRow(TestObject.ObjectA, TestObject.ObjectB, TestExceptionType.ValidationFailed)]
        [DataRow(TestObject.Null, TestObject.ObjectB, TestExceptionType.ValidationFailed)]
        [DataRow(TestObject.ObjectA, TestObject.Null, TestExceptionType.ValidationFailed)]
        [DataRow(null, null, TestExceptionType.ValidationPassed)]
        [DataRow(TestObject.ObjectA, TestObject.ObjectA, TestExceptionType.ValidationPassed)]
        public void AreEqual_Objects(TestObject a, TestObject b, TestExceptionType eType)
        {
            object objA = a.GetObject();
            object objB = b.GetObject();
            this.RunTest(() => this.Checker.AreEqual(objA, objB), eType);
        }

        [DataTestMethod]
        [DataRow(
            TestValues.FLOAT_10,
            TestValues.FLOAT_15,
            TestValues.FLOAT_PRECISION,
            TestExceptionType.ValidationFailed)]
        [DataRow(
            TestValues.FLOAT_10,
            TestValues.FLOAT_10,
            TestValues.FLOAT_PRECISION,
            TestExceptionType.ValidationPassed)]
        [DataRow(
            TestValues.FLOAT_PRECISION_CHECK,
            TestValues.FLOAT_PRECISION_CHECK_ERROR,
            TestValues.FLOAT_PRECISION,
            TestExceptionType.ValidationPassed)]
        public void AreEqual_Floats(float a, float b, float precision, TestExceptionType eType)
        {
            this.RunTest(() => this.Checker.AreEqual(a, b, precision), eType);
        }

        [DataTestMethod]
        [DataRow(
            TestValues.DOUBLE_10,
            TestValues.DOUBLE_15,
            TestValues.DOUBLE_PRECISION,
            TestExceptionType.ValidationFailed)]
        [DataRow(
            TestValues.DOUBLE_10,
            TestValues.DOUBLE_10,
            TestValues.DOUBLE_PRECISION,
            TestExceptionType.ValidationPassed)]
        [DataRow(
            TestValues.DOUBLE_PRECISION_CHECK,
            TestValues.DOUBLE_PRECISION_CHECK_ERROR,
            TestValues.DOUBLE_PRECISION,
            TestExceptionType.ValidationPassed)]
        public void AreEqual_Doubles(double a, double b, double precision, TestExceptionType eType)
        {
            this.RunTest(() => this.Checker.AreEqual(a, b, precision), eType);
        }

        [DataTestMethod]
        [DataRow(TestObject.ObjectA, TestObject.ObjectB, TestExceptionType.ValidationPassed)]
        [DataRow(TestObject.Null, TestObject.ObjectB, TestExceptionType.ValidationPassed)]
        [DataRow(TestObject.ObjectA, TestObject.Null, TestExceptionType.ValidationPassed)]
        [DataRow(null, null, TestExceptionType.ValidationFailed)]
        [DataRow(TestObject.ObjectA, TestObject.ObjectA, TestExceptionType.ValidationFailed)]
        public void AreNotEqual_Objects(TestObject a, TestObject b, TestExceptionType eType)
        {
            object objA = a.GetObject();
            object objB = b.GetObject();
            this.RunTest(() => this.Checker.AreNotEqual(objA, objB), eType);
        }

        [DataTestMethod]
        [DataRow(
            TestValues.FLOAT_10,
            TestValues.FLOAT_15,
            TestValues.FLOAT_PRECISION,
            TestExceptionType.ValidationPassed)]
        [DataRow(
            TestValues.FLOAT_10,
            TestValues.FLOAT_10,
            TestValues.FLOAT_PRECISION,
            TestExceptionType.ValidationFailed)]
        [DataRow(
            TestValues.FLOAT_PRECISION_CHECK,
            TestValues.FLOAT_PRECISION_CHECK_ERROR,
            TestValues.FLOAT_PRECISION,
            TestExceptionType.ValidationFailed)]
        public void AreNotEqual_Floats(float a, float b, float precision, TestExceptionType eType)
        {
            this.RunTest(() => this.Checker.AreNotEqual(a, b, precision), eType);
        }

        [DataTestMethod]
        [DataRow(
            TestValues.DOUBLE_10,
            TestValues.DOUBLE_15,
            TestValues.DOUBLE_PRECISION,
            TestExceptionType.ValidationPassed)]
        [DataRow(
            TestValues.DOUBLE_10,
            TestValues.DOUBLE_10,
            TestValues.DOUBLE_PRECISION,
            TestExceptionType.ValidationFailed)]
        [DataRow(
            TestValues.DOUBLE_PRECISION_CHECK,
            TestValues.DOUBLE_PRECISION_CHECK_ERROR,
            TestValues.DOUBLE_PRECISION,
            TestExceptionType.ValidationFailed)]
        public void AreNotEqual_Doubles(double a, double b, double precision, TestExceptionType eType)
        {
            this.RunTest(() => this.Checker.AreNotEqual(a, b, precision), eType);
        }

        [DataTestMethod]
        // Less
        [DataRow(
            TestObject.ComparableLess,
            CompareOperation.Less,
            TestObject.ComparableMore,
            TestExceptionType.ValidationPassed)]
        [DataRow(
            TestObject.ComparableLess,
            CompareOperation.Less,
            TestObject.ComparableLess,
            TestExceptionType.ValidationFailed)]
        [DataRow(
            TestObject.ComparableMore,
            CompareOperation.Less,
            TestObject.ComparableLess,
            TestExceptionType.ValidationFailed)]
        [DataRow(TestObject.Null, CompareOperation.Less, TestObject.ComparableLess, TestExceptionType.ValidationPassed)]
        [DataRow(TestObject.Null, CompareOperation.Less, TestObject.Null, TestExceptionType.ValidationFailed)]
        [DataRow(TestObject.ComparableLess, CompareOperation.Less, TestObject.Null, TestExceptionType.ValidationFailed)]
        // Less Equal
        [DataRow(
            TestObject.ComparableLess,
            CompareOperation.LessEqual,
            TestObject.ComparableMore,
            TestExceptionType.ValidationPassed)]
        [DataRow(
            TestObject.ComparableLess,
            CompareOperation.LessEqual,
            TestObject.ComparableLess,
            TestExceptionType.ValidationPassed)]
        [DataRow(
            TestObject.ComparableMore,
            CompareOperation.LessEqual,
            TestObject.ComparableLess,
            TestExceptionType.ValidationFailed)]
        [DataRow(
            TestObject.Null,
            CompareOperation.LessEqual,
            TestObject.ComparableLess,
            TestExceptionType.ValidationPassed)]
        [DataRow(TestObject.Null, CompareOperation.LessEqual, TestObject.Null, TestExceptionType.ValidationPassed)]
        [DataRow(
            TestObject.ComparableLess,
            CompareOperation.LessEqual,
            TestObject.Null,
            TestExceptionType.ValidationFailed)]
        // Equal
        [DataRow(
            TestObject.ComparableLess,
            CompareOperation.Equal,
            TestObject.ComparableMore,
            TestExceptionType.ValidationFailed)]
        [DataRow(
            TestObject.ComparableLess,
            CompareOperation.Equal,
            TestObject.ComparableLess,
            TestExceptionType.ValidationPassed)]
        [DataRow(
            TestObject.ComparableMore,
            CompareOperation.Equal,
            TestObject.ComparableLess,
            TestExceptionType.ValidationFailed)]
        [DataRow(
            TestObject.Null,
            CompareOperation.Equal,
            TestObject.ComparableLess,
            TestExceptionType.ValidationFailed)]
        [DataRow(TestObject.Null, CompareOperation.Equal, TestObject.Null, TestExceptionType.ValidationPassed)]
        [DataRow(
            TestObject.ComparableLess,
            CompareOperation.Equal,
            TestObject.Null,
            TestExceptionType.ValidationFailed)]
        // Greater Equal
        [DataRow(
            TestObject.ComparableLess,
            CompareOperation.GreaterEqual,
            TestObject.ComparableMore,
            TestExceptionType.ValidationFailed)]
        [DataRow(
            TestObject.ComparableLess,
            CompareOperation.GreaterEqual,
            TestObject.ComparableLess,
            TestExceptionType.ValidationPassed)]
        [DataRow(
            TestObject.ComparableMore,
            CompareOperation.GreaterEqual,
            TestObject.ComparableLess,
            TestExceptionType.ValidationPassed)]
        [DataRow(
            TestObject.Null,
            CompareOperation.GreaterEqual,
            TestObject.ComparableLess,
            TestExceptionType.ValidationFailed)]
        [DataRow(TestObject.Null, CompareOperation.GreaterEqual, TestObject.Null, TestExceptionType.ValidationPassed)]
        [DataRow(
            TestObject.ComparableLess,
            CompareOperation.GreaterEqual,
            TestObject.Null,
            TestExceptionType.ValidationPassed)]
        // Greater
        [DataRow(
            TestObject.ComparableLess,
            CompareOperation.Greater,
            TestObject.ComparableMore,
            TestExceptionType.ValidationFailed)]
        [DataRow(
            TestObject.ComparableLess,
            CompareOperation.Greater,
            TestObject.ComparableLess,
            TestExceptionType.ValidationFailed)]
        [DataRow(
            TestObject.ComparableMore,
            CompareOperation.Greater,
            TestObject.ComparableLess,
            TestExceptionType.ValidationPassed)]
        [DataRow(
            TestObject.Null,
            CompareOperation.Greater,
            TestObject.ComparableLess,
            TestExceptionType.ValidationFailed)]
        [DataRow(TestObject.Null, CompareOperation.Greater, TestObject.Null, TestExceptionType.ValidationFailed)]
        [DataRow(
            TestObject.ComparableLess,
            CompareOperation.Greater,
            TestObject.Null,
            TestExceptionType.ValidationPassed)]
        public void Comparison_Objects(TestObject a, CompareOperation operation, TestObject b, TestExceptionType eType)
        {
            IComparable objA = (IComparable) a.GetObject();
            IComparable objB = (IComparable) b.GetObject();
            this.RunTest(() => this.Checker.Comparison(objA, operation, objB), eType);
        }

        [DataTestMethod]
        // Less
        [DataRow(
            TestValues.FLOAT_10,
            CompareOperation.Less,
            TestValues.FLOAT_15,
            TestValues.FLOAT_PRECISION,
            TestExceptionType.ValidationPassed)]
        [DataRow(
            TestValues.FLOAT_10,
            CompareOperation.Less,
            TestValues.FLOAT_10,
            TestValues.FLOAT_PRECISION,
            TestExceptionType.ValidationFailed)]
        [DataRow(
            TestValues.FLOAT_15,
            CompareOperation.Less,
            TestValues.FLOAT_10,
            TestValues.FLOAT_PRECISION,
            TestExceptionType.ValidationFailed)]
        [DataRow(
            TestValues.FLOAT_PRECISION_CHECK,
            CompareOperation.Less,
            TestValues.FLOAT_PRECISION_CHECK_ERROR,
            TestValues.FLOAT_PRECISION,
            TestExceptionType.ValidationFailed)]
        // Less Equal
        [DataRow(
            TestValues.FLOAT_10,
            CompareOperation.LessEqual,
            TestValues.FLOAT_15,
            TestValues.FLOAT_PRECISION,
            TestExceptionType.ValidationPassed)]
        [DataRow(
            TestValues.FLOAT_10,
            CompareOperation.LessEqual,
            TestValues.FLOAT_10,
            TestValues.FLOAT_PRECISION,
            TestExceptionType.ValidationPassed)]
        [DataRow(
            TestValues.FLOAT_15,
            CompareOperation.LessEqual,
            TestValues.FLOAT_10,
            TestValues.FLOAT_PRECISION,
            TestExceptionType.ValidationFailed)]
        [DataRow(
            TestValues.FLOAT_PRECISION_CHECK,
            CompareOperation.LessEqual,
            TestValues.FLOAT_PRECISION_CHECK_ERROR,
            TestValues.FLOAT_PRECISION,
            TestExceptionType.ValidationPassed)]
        // Equal
        [DataRow(
            TestValues.FLOAT_10,
            CompareOperation.Equal,
            TestValues.FLOAT_15,
            TestValues.FLOAT_PRECISION,
            TestExceptionType.ValidationFailed)]
        [DataRow(
            TestValues.FLOAT_10,
            CompareOperation.Equal,
            TestValues.FLOAT_10,
            TestValues.FLOAT_PRECISION,
            TestExceptionType.ValidationPassed)]
        [DataRow(
            TestValues.FLOAT_15,
            CompareOperation.Equal,
            TestValues.FLOAT_10,
            TestValues.FLOAT_PRECISION,
            TestExceptionType.ValidationFailed)]
        [DataRow(
            TestValues.FLOAT_PRECISION_CHECK,
            CompareOperation.Equal,
            TestValues.FLOAT_PRECISION_CHECK_ERROR,
            TestValues.FLOAT_PRECISION,
            TestExceptionType.ValidationPassed)]
        // Greater Equal
        [DataRow(
            TestValues.FLOAT_10,
            CompareOperation.GreaterEqual,
            TestValues.FLOAT_15,
            TestValues.FLOAT_PRECISION,
            TestExceptionType.ValidationFailed)]
        [DataRow(
            TestValues.FLOAT_10,
            CompareOperation.GreaterEqual,
            TestValues.FLOAT_10,
            TestValues.FLOAT_PRECISION,
            TestExceptionType.ValidationPassed)]
        [DataRow(
            TestValues.FLOAT_15,
            CompareOperation.GreaterEqual,
            TestValues.FLOAT_10,
            TestValues.FLOAT_PRECISION,
            TestExceptionType.ValidationPassed)]
        [DataRow(
            TestValues.FLOAT_PRECISION_CHECK,
            CompareOperation.GreaterEqual,
            TestValues.FLOAT_PRECISION_CHECK_ERROR,
            TestValues.FLOAT_PRECISION,
            TestExceptionType.ValidationPassed)]
        // Greater
        [DataRow(
            TestValues.FLOAT_10,
            CompareOperation.Greater,
            TestValues.FLOAT_15,
            TestValues.FLOAT_PRECISION,
            TestExceptionType.ValidationFailed)]
        [DataRow(
            TestValues.FLOAT_10,
            CompareOperation.Greater,
            TestValues.FLOAT_10,
            TestValues.FLOAT_PRECISION,
            TestExceptionType.ValidationFailed)]
        [DataRow(
            TestValues.FLOAT_15,
            CompareOperation.Greater,
            TestValues.FLOAT_10,
            TestValues.FLOAT_PRECISION,
            TestExceptionType.ValidationPassed)]
        [DataRow(
            TestValues.FLOAT_PRECISION_CHECK,
            CompareOperation.Greater,
            TestValues.FLOAT_PRECISION_CHECK_ERROR,
            TestValues.FLOAT_PRECISION,
            TestExceptionType.ValidationFailed)]
        public void Comparison_Floats(
            float a,
            CompareOperation operation,
            float b,
            float precision,
            TestExceptionType eType)
        {
            this.RunTest(() => this.Checker.Comparison(a, operation, b, precision), eType);
        }

        [DataTestMethod]
        // Less
        [DataRow(
            TestValues.DOUBLE_10,
            CompareOperation.Less,
            TestValues.DOUBLE_15,
            TestValues.DOUBLE_PRECISION,
            TestExceptionType.ValidationPassed)]
        [DataRow(
            TestValues.DOUBLE_10,
            CompareOperation.Less,
            TestValues.DOUBLE_10,
            TestValues.DOUBLE_PRECISION,
            TestExceptionType.ValidationFailed)]
        [DataRow(
            TestValues.DOUBLE_15,
            CompareOperation.Less,
            TestValues.DOUBLE_10,
            TestValues.DOUBLE_PRECISION,
            TestExceptionType.ValidationFailed)]
        [DataRow(
            TestValues.DOUBLE_PRECISION_CHECK,
            CompareOperation.Less,
            TestValues.DOUBLE_PRECISION_CHECK_ERROR,
            TestValues.DOUBLE_PRECISION,
            TestExceptionType.ValidationFailed)]
        // Less Equal
        [DataRow(
            TestValues.DOUBLE_10,
            CompareOperation.LessEqual,
            TestValues.DOUBLE_15,
            TestValues.DOUBLE_PRECISION,
            TestExceptionType.ValidationPassed)]
        [DataRow(
            TestValues.DOUBLE_10,
            CompareOperation.LessEqual,
            TestValues.DOUBLE_10,
            TestValues.DOUBLE_PRECISION,
            TestExceptionType.ValidationPassed)]
        [DataRow(
            TestValues.DOUBLE_15,
            CompareOperation.LessEqual,
            TestValues.DOUBLE_10,
            TestValues.DOUBLE_PRECISION,
            TestExceptionType.ValidationFailed)]
        [DataRow(
            TestValues.DOUBLE_PRECISION_CHECK,
            CompareOperation.LessEqual,
            TestValues.DOUBLE_PRECISION_CHECK_ERROR,
            TestValues.DOUBLE_PRECISION,
            TestExceptionType.ValidationPassed)]
        // Equal
        [DataRow(
            TestValues.DOUBLE_10,
            CompareOperation.Equal,
            TestValues.DOUBLE_15,
            TestValues.DOUBLE_PRECISION,
            TestExceptionType.ValidationFailed)]
        [DataRow(
            TestValues.DOUBLE_10,
            CompareOperation.Equal,
            TestValues.DOUBLE_10,
            TestValues.DOUBLE_PRECISION,
            TestExceptionType.ValidationPassed)]
        [DataRow(
            TestValues.DOUBLE_15,
            CompareOperation.Equal,
            TestValues.DOUBLE_10,
            TestValues.DOUBLE_PRECISION,
            TestExceptionType.ValidationFailed)]
        [DataRow(
            TestValues.DOUBLE_PRECISION_CHECK,
            CompareOperation.Equal,
            TestValues.DOUBLE_PRECISION_CHECK_ERROR,
            TestValues.DOUBLE_PRECISION,
            TestExceptionType.ValidationPassed)]
        // Greater Equal
        [DataRow(
            TestValues.DOUBLE_10,
            CompareOperation.GreaterEqual,
            TestValues.DOUBLE_15,
            TestValues.DOUBLE_PRECISION,
            TestExceptionType.ValidationFailed)]
        [DataRow(
            TestValues.DOUBLE_10,
            CompareOperation.GreaterEqual,
            TestValues.DOUBLE_10,
            TestValues.DOUBLE_PRECISION,
            TestExceptionType.ValidationPassed)]
        [DataRow(
            TestValues.DOUBLE_15,
            CompareOperation.GreaterEqual,
            TestValues.DOUBLE_10,
            TestValues.DOUBLE_PRECISION,
            TestExceptionType.ValidationPassed)]
        [DataRow(
            TestValues.DOUBLE_PRECISION_CHECK,
            CompareOperation.GreaterEqual,
            TestValues.DOUBLE_PRECISION_CHECK_ERROR,
            TestValues.DOUBLE_PRECISION,
            TestExceptionType.ValidationPassed)]
        // Greater
        [DataRow(
            TestValues.DOUBLE_10,
            CompareOperation.Greater,
            TestValues.DOUBLE_15,
            TestValues.DOUBLE_PRECISION,
            TestExceptionType.ValidationFailed)]
        [DataRow(
            TestValues.DOUBLE_10,
            CompareOperation.Greater,
            TestValues.DOUBLE_10,
            TestValues.DOUBLE_PRECISION,
            TestExceptionType.ValidationFailed)]
        [DataRow(
            TestValues.DOUBLE_15,
            CompareOperation.Greater,
            TestValues.DOUBLE_10,
            TestValues.DOUBLE_PRECISION,
            TestExceptionType.ValidationPassed)]
        [DataRow(
            TestValues.DOUBLE_PRECISION_CHECK,
            CompareOperation.Greater,
            TestValues.DOUBLE_PRECISION_CHECK_ERROR,
            TestValues.DOUBLE_PRECISION,
            TestExceptionType.ValidationFailed)]
        public void Comparison_Doubles(
            double a,
            CompareOperation operation,
            double b,
            double precision,
            TestExceptionType eType)
        {
            this.RunTest(() => this.Checker.Comparison(a, operation, b, precision), eType);
        }

        [TestMethod]
        public void Fail()
        {
            this.RunTest(() => this.Checker.Fail("This should Fail"), TestExceptionType.ValidationFailed);
        }

        [DataTestMethod]
        [DataRow(false, TestExceptionType.ValidationFailed)]
        [DataRow(true, TestExceptionType.ValidationPassed)]
        public void IsDisposed(bool isDisposed, TestExceptionType eType)
        {
            this.RunTest(() => this.Checker.IsDisposed(new TestDisposable(isDisposed), "TestDisposable"), eType);
        }

        [TestMethod]
        public void IsDisposed_WithNull()
        {
            this.RunTest(
                () => this.Checker.IsDisposed(null, "TestDisposable"),
                TestExceptionType.NullReferenceException);
        }

        [DataTestMethod]
        [DataRow(0, TestExceptionType.ValidationPassed)]
        [DataRow(1, TestExceptionType.ValidationFailed)]
        [DataRow(10, TestExceptionType.ValidationFailed)]
        public void IsEmpty(int numItems, TestExceptionType eType)
        {
            var collection = new List<object>();
            for (int i = 0; i < numItems; i++)
            {
                collection.Add(new object());
            }

            this.RunTest(() => this.Checker.IsEmpty(collection), eType);
        }

        [TestMethod]
        public void IsEmpty_WithNull()
        {
            this.RunTest(() => this.Checker.IsEmpty(null), TestExceptionType.NullReferenceException);
        }

        [DataTestMethod]
        [DataRow(false, TestExceptionType.ValidationPassed)]
        [DataRow(true, TestExceptionType.ValidationFailed)]
        public void IsFalse(bool value, TestExceptionType eType)
        {
            this.RunTest(() => this.Checker.IsFalse(value), eType);
        }

        [DataTestMethod]
        // Value under
        [DataRow(
            TestObject.ComparableLess,
            TestObject.ComparableMiddle,
            TestObject.ComparableMiddle,
            TestExceptionType.BoundsCheckFailed)]
        // Value inside zero range
        [DataRow(
            TestObject.ComparableMiddle,
            TestObject.ComparableMiddle,
            TestObject.ComparableMiddle,
            TestExceptionType.ValidationPassed)]
        // Value above
        [DataRow(
            TestObject.ComparableMore,
            TestObject.ComparableMiddle,
            TestObject.ComparableMiddle,
            TestExceptionType.BoundsCheckFailed)]
        // Null compared to zero range
        [DataRow(
            TestObject.Null,
            TestObject.ComparableMiddle,
            TestObject.ComparableMiddle,
            TestExceptionType.BoundsCheckFailed)]
        // Value at lower boundary
        [DataRow(
            TestObject.ComparableLess,
            TestObject.ComparableLess,
            TestObject.ComparableMore,
            TestExceptionType.ValidationPassed)]
        // Value inside range
        [DataRow(
            TestObject.ComparableMiddle,
            TestObject.ComparableLess,
            TestObject.ComparableMore,
            TestExceptionType.ValidationPassed)]
        // Value at upper boundary
        [DataRow(
            TestObject.ComparableMore,
            TestObject.ComparableLess,
            TestObject.ComparableMore,
            TestExceptionType.ValidationPassed)]
        // Null compared to non-zero range
        [DataRow(
            TestObject.Null,
            TestObject.ComparableLess,
            TestObject.ComparableMore,
            TestExceptionType.BoundsCheckFailed)]
        // Null compared to null lower range
        [DataRow(TestObject.Null, TestObject.Null, TestObject.ComparableMiddle, TestExceptionType.ValidationPassed)]
        // Value inside null lower range
        [DataRow(
            TestObject.ComparableLess,
            TestObject.Null,
            TestObject.ComparableMiddle,
            TestExceptionType.ValidationPassed)]
        // Value at upper boundary of null lower range
        [DataRow(
            TestObject.ComparableMiddle,
            TestObject.Null,
            TestObject.ComparableMiddle,
            TestExceptionType.ValidationPassed)]
        // Value above null lower range
        [DataRow(
            TestObject.ComparableMore,
            TestObject.Null,
            TestObject.ComparableMiddle,
            TestExceptionType.BoundsCheckFailed)]
        // Null upper range
        [DataRow(
            TestObject.Null,
            TestObject.ComparableMiddle,
            TestObject.Null,
            TestExceptionType.IndexOutOfBoundsException)]
        // Null inside null range
        [DataRow(TestObject.Null, TestObject.Null, TestObject.Null, TestExceptionType.ValidationPassed)]
        // Value compared to null range
        [DataRow(TestObject.ComparableLess, TestObject.Null, TestObject.Null, TestExceptionType.BoundsCheckFailed)]
        // Min greater than max 
        [DataRow(
            TestObject.ComparableMiddle,
            TestObject.ComparableMore,
            TestObject.ComparableLess,
            TestExceptionType.IndexOutOfBoundsException)]
        public void IsInRange_Objects(TestObject val, TestObject min, TestObject max, TestExceptionType eType)
        {
            IComparable value = (IComparable) val.GetObject();
            IComparable lower = (IComparable) min.GetObject();
            IComparable upper = (IComparable) max.GetObject();
            this.RunTest(() => this.Checker.IsInRange(value, lower, upper), eType);
        }

        [DataTestMethod]
        // Value under
        [DataRow(
            TestValues.FLOAT_0,
            TestValues.FLOAT_10,
            TestValues.FLOAT_10,
            TestValues.FLOAT_PRECISION,
            TestExceptionType.BoundsCheckFailed)]
        // Value inside zero range
        [DataRow(
            TestValues.FLOAT_10,
            TestValues.FLOAT_10,
            TestValues.FLOAT_10,
            TestValues.FLOAT_PRECISION,
            TestExceptionType.ValidationPassed)]
        // Value above
        [DataRow(
            TestValues.FLOAT_15,
            TestValues.FLOAT_10,
            TestValues.FLOAT_10,
            TestValues.FLOAT_PRECISION,
            TestExceptionType.BoundsCheckFailed)]
        // Value at lower boundary
        [DataRow(
            TestValues.FLOAT_0,
            TestValues.FLOAT_0,
            TestValues.FLOAT_15,
            TestValues.FLOAT_PRECISION,
            TestExceptionType.ValidationPassed)]
        // Value inside range
        [DataRow(
            TestValues.FLOAT_10,
            TestValues.FLOAT_0,
            TestValues.FLOAT_15,
            TestValues.FLOAT_PRECISION,
            TestExceptionType.ValidationPassed)]
        // Value at upper boundary
        [DataRow(
            TestValues.FLOAT_15,
            TestValues.FLOAT_0,
            TestValues.FLOAT_15,
            TestValues.FLOAT_PRECISION,
            TestExceptionType.ValidationPassed)]
        // Min greater than max 
        [DataRow(
            TestValues.FLOAT_10,
            TestValues.FLOAT_15,
            TestValues.FLOAT_0,
            TestValues.FLOAT_PRECISION,
            TestExceptionType.IndexOutOfBoundsException)]
        // Precision check
        [DataRow(
            TestValues.FLOAT_PRECISION_CHECK,
            TestValues.FLOAT_15,
            TestValues.FLOAT_PRECISION_CHECK_ERROR,
            TestValues.FLOAT_PRECISION,
            TestExceptionType.ValidationPassed)]
        public void IsInRange_Floats(float val, float min, float max, float precision, TestExceptionType eType)
        {
            this.RunTest(() => this.Checker.IsInRange(val, min, max, precision), eType);
        }

        [DataTestMethod]
        // Value under
        [DataRow(
            TestValues.DOUBLE_0,
            TestValues.DOUBLE_10,
            TestValues.DOUBLE_10,
            TestValues.DOUBLE_PRECISION,
            TestExceptionType.BoundsCheckFailed)]
        // Value inside zero range
        [DataRow(
            TestValues.DOUBLE_10,
            TestValues.DOUBLE_10,
            TestValues.DOUBLE_10,
            TestValues.DOUBLE_PRECISION,
            TestExceptionType.ValidationPassed)]
        // Value above
        [DataRow(
            TestValues.DOUBLE_15,
            TestValues.DOUBLE_10,
            TestValues.DOUBLE_10,
            TestValues.DOUBLE_PRECISION,
            TestExceptionType.BoundsCheckFailed)]
        // Value at lower boundary
        [DataRow(
            TestValues.DOUBLE_0,
            TestValues.DOUBLE_0,
            TestValues.DOUBLE_15,
            TestValues.DOUBLE_PRECISION,
            TestExceptionType.ValidationPassed)]
        // Value inside range
        [DataRow(
            TestValues.DOUBLE_10,
            TestValues.DOUBLE_0,
            TestValues.DOUBLE_15,
            TestValues.DOUBLE_PRECISION,
            TestExceptionType.ValidationPassed)]
        // Value at upper boundary
        [DataRow(
            TestValues.DOUBLE_15,
            TestValues.DOUBLE_0,
            TestValues.DOUBLE_15,
            TestValues.DOUBLE_PRECISION,
            TestExceptionType.ValidationPassed)]
        // Min greater than max 
        [DataRow(
            TestValues.DOUBLE_10,
            TestValues.DOUBLE_15,
            TestValues.DOUBLE_0,
            TestValues.DOUBLE_PRECISION,
            TestExceptionType.IndexOutOfBoundsException)]
        // Precision check
        [DataRow(
            TestValues.DOUBLE_PRECISION_CHECK,
            TestValues.DOUBLE_15,
            TestValues.DOUBLE_PRECISION_CHECK_ERROR,
            TestValues.DOUBLE_PRECISION,
            TestExceptionType.ValidationPassed)]
        public void IsInRange_Doubles(double val, double min, double max, double precision, TestExceptionType eType)
        {
            this.RunTest(() => this.Checker.IsInRange(val, min, max, precision), eType);
        }

        [DataTestMethod]
        [DataRow(false, TestExceptionType.ValidationPassed)]
        [DataRow(true, TestExceptionType.NotDisposedCheckFailed)]
        public void IsNotDisposed(bool isDisposed, TestExceptionType eType)
        {
            this.RunTest(() => this.Checker.IsNotDisposed(new TestDisposable(isDisposed), "TestDisposable"), eType);
        }

        [TestMethod]
        public void IsNotDisposed_withNull()
        {
            this.RunTest(
                () => this.Checker.IsNotDisposed(null, "TestDisposable"),
                TestExceptionType.NullReferenceException);
        }

        [DataTestMethod]
        [DataRow(0, TestExceptionType.ValidationFailed)]
        [DataRow(1, TestExceptionType.ValidationPassed)]
        [DataRow(10, TestExceptionType.ValidationPassed)]
        public void IsNotEmpty(int numItems, TestExceptionType eType)
        {
            var collection = new List<object>();
            for (int i = 0; i < numItems; i++)
            {
                collection.Add(new object());
            }

            this.RunTest(() => this.Checker.IsNotEmpty(collection), eType);
        }

        [TestMethod]
        public void IsNotEmpty_WithNull()
        {
            this.RunTest(() => this.Checker.IsNotEmpty(null), TestExceptionType.NullReferenceException);
        }

        [DataTestMethod]
        [DataRow(TestObject.ObjectA, TestExceptionType.ValidationPassed)]
        [DataRow(TestObject.Null, TestExceptionType.NullCheckFailed)]
        public void IsNotNull(TestObject a, TestExceptionType eType)
        {
            this.RunTest(() => this.Checker.IsNotNull(a.GetObject()), eType);
        }

        [DataTestMethod]
        [DataRow(TestValues.TEST_STRING, TestExceptionType.ValidationPassed)]
        [DataRow(StringUtils.EmptyString, TestExceptionType.ValidationFailed)]
        [DataRow(null, TestExceptionType.ValidationFailed)]
        public void IsNotNullOrEmpty(string str, TestExceptionType eType)
        {
            this.RunTest(() => this.Checker.IsNotNullOrEmpty(str), eType);
        }

        [DataTestMethod]
        [DataRow(TestValues.TEST_STRING, TestExceptionType.ValidationPassed)]
        [DataRow(TestValues.TEST_WHITESPACE_STRING, TestExceptionType.ValidationFailed)]
        [DataRow(StringUtils.EmptyString, TestExceptionType.ValidationFailed)]
        [DataRow(null, TestExceptionType.ValidationFailed)]
        public void IsNotNullOrWhiteSpace(string str, TestExceptionType eType)
        {
            this.RunTest(() => this.Checker.IsNotNullOrWhiteSpace(str), eType);
        }

        [DataTestMethod]
        [DataRow(TestValues.INT_0, TestExceptionType.ValidationFailed)]
        [DataRow(TestValues.INT_10, TestExceptionType.ValidationPassed)]
        public void IsNotZero_int(int value, TestExceptionType eType)
        {
            this.RunTest(() => this.Checker.IsNotZero(value), eType);
        }

        [DataTestMethod]
        [DataRow(TestValues.FLOAT_0, TestValues.FLOAT_PRECISION, TestExceptionType.ValidationFailed)]
        [DataRow(TestValues.FLOAT_PRECISION_CHECK_0, TestValues.FLOAT_PRECISION, TestExceptionType.ValidationFailed)]
        [DataRow(TestValues.FLOAT_10, TestValues.FLOAT_PRECISION, TestExceptionType.ValidationPassed)]
        public void IsNotZero_float(float value, float precision, TestExceptionType eType)
        {
            this.RunTest(() => this.Checker.IsNotZero(value, precision), eType);
        }

        [DataTestMethod]
        [DataRow(TestValues.DOUBLE_0, TestValues.DOUBLE_PRECISION, TestExceptionType.ValidationFailed)]
        [DataRow(TestValues.DOUBLE_PRECISION_CHECK_0, TestValues.DOUBLE_PRECISION, TestExceptionType.ValidationFailed)]
        [DataRow(TestValues.DOUBLE_10, TestValues.DOUBLE_PRECISION, TestExceptionType.ValidationPassed)]
        public void IsNotZero_double(double value, double precision, TestExceptionType eType)
        {
            this.RunTest(() => this.Checker.IsNotZero(value, precision), eType);
        }

        [DataTestMethod]
        [DataRow(TestObject.ObjectA, TestExceptionType.ValidationFailed)]
        [DataRow(TestObject.Null, TestExceptionType.ValidationPassed)]
        public void IsNull(TestObject a, TestExceptionType eType)
        {
            this.RunTest(() => this.Checker.IsNull(a.GetObject()), eType);
        }

        [DataTestMethod]
        [DataRow(TestValues.TEST_STRING, TestExceptionType.ValidationFailed)]
        [DataRow(StringUtils.EmptyString, TestExceptionType.ValidationPassed)]
        [DataRow(null, TestExceptionType.ValidationPassed)]
        public void IsNullOrEmpty(string str, TestExceptionType eType)
        {
            this.RunTest(() => this.Checker.IsNullOrEmpty(str), eType);
        }

        [DataTestMethod]
        [DataRow(TestValues.TEST_STRING, TestExceptionType.ValidationFailed)]
        [DataRow(TestValues.TEST_WHITESPACE_STRING, TestExceptionType.ValidationPassed)]
        [DataRow(StringUtils.EmptyString, TestExceptionType.ValidationPassed)]
        [DataRow(null, TestExceptionType.ValidationPassed)]
        public void IsNullOrWhiteSpace(string str, TestExceptionType eType)
        {
            this.RunTest(() => this.Checker.IsNullOrWhiteSpace(str), eType);
        }

        [DataTestMethod]
        [DataRow(false, TestExceptionType.ValidationFailed)]
        [DataRow(true, TestExceptionType.ValidationPassed)]
        public void IsTrue(bool value, TestExceptionType eType)
        {
            this.RunTest(() => this.Checker.IsTrue(value), eType);
        }

        [DataTestMethod]
        [DataRow(TestObject.ComparableLess, TestExceptionType.ValidationPassed)]
        [DataRow(TestObject.ObjectA, TestExceptionType.ValidationFailed)]
        [DataRow(TestObject.Null, TestExceptionType.ValidationFailed)]
        public void IsType(TestObject val, TestExceptionType eType)
        {
            object value = val.GetObject();
            this.RunTest(() => this.Checker.IsType<string>(value), eType);
        }

        [TestMethod]
        public void IsType_Inherited()
        {
            this.RunTest(
                () => this.Checker.IsType<IDisposable>(new TestDisposable(false)),
                TestExceptionType.ValidationPassed);
        }

        [DataTestMethod]
        [DataRow(TestObject.ComparableLess, TestExceptionType.ValidationPassed)]
        [DataRow(TestObject.ObjectA, TestExceptionType.ValidationFailed)]
        [DataRow(TestObject.Null, TestExceptionType.ValidationPassed)]
        public void IsTypeOrNull(TestObject val, TestExceptionType eType)
        {
            object value = val.GetObject();
            this.RunTest(() => this.Checker.IsTypeOrNull<string>(value), eType);
        }

        [TestMethod]
        public void IsTypeOrNull_Inherited()
        {
            this.RunTest(
                () => this.Checker.IsTypeOrNull<IDisposable>(new TestDisposable(false)),
                TestExceptionType.ValidationPassed);
        }
    }
}