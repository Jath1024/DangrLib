// -----------------------------------------------------------------------
//  <copyright file="PrecisionTest.cs" company="Phoenix Game Studios, LLC">
//      Copyright (c) 2017 Phoenix Game Studios, LLC. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/PhoenixGameStudios/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.Math
{
    using Dangr.Core.Diagnostics;
    using Dangr.Core.Math;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class PrecisionTest
    {
        [DataTestMethod]
        [DataRow(
            TestValues.FLOAT_10,
            TestValues.FLOAT_15,
            TestValues.FLOAT_PRECISION,
            TestValues.FLOAT_ULP,
            false)]
        [DataRow(
            TestValues.FLOAT_10,
            TestValues.FLOAT_10,
            TestValues.FLOAT_PRECISION,
            TestValues.FLOAT_ULP,
            true)]
        [DataRow(
            TestValues.FLOAT_PRECISION_CHECK,
            TestValues.FLOAT_PRECISION_CHECK_ERROR,
            TestValues.FLOAT_PRECISION,
            TestValues.FLOAT_ULP,
            true)]
        public void Equals_float(float a, float b, float precision, int ulp, bool expected)
        {
            Validate.Value.AreEqual(Precision.Equals(a, b, precision), expected);
            Validate.Value.AreEqual(Precision.Equals(a, b, ulp), expected);
        }

        [DataTestMethod]
        [DataRow(
            TestValues.DOUBLE_10,
            TestValues.DOUBLE_15,
            TestValues.DOUBLE_PRECISION,
            TestValues.DOUBLE_ULP,
            false)]
        [DataRow(
            TestValues.DOUBLE_10,
            TestValues.DOUBLE_10,
            TestValues.DOUBLE_PRECISION,
            TestValues.DOUBLE_ULP,
            true)]
        [DataRow(
            TestValues.DOUBLE_PRECISION_CHECK,
            TestValues.DOUBLE_PRECISION_CHECK_ERROR,
            TestValues.DOUBLE_PRECISION,
            TestValues.DOUBLE_ULP,
            true)]
        public void Equals_double(double a, double b, double precision, int ulp, bool expected)
        {
            Validate.Value.AreEqual(Precision.Equals(a, b, precision), expected);
            Validate.Value.AreEqual(Precision.Equals(a, b, ulp), expected);
        }

        [DataTestMethod]
        [DataRow(
            TestValues.FLOAT_10,
            TestValues.FLOAT_15,
            TestValues.FLOAT_PRECISION,
            TestValues.FLOAT_ULP,
            -1)]
        [DataRow(
            TestValues.FLOAT_10,
            TestValues.FLOAT_10,
            TestValues.FLOAT_PRECISION,
            TestValues.FLOAT_ULP,
            0)]
        [DataRow(
            TestValues.FLOAT_15,
            TestValues.FLOAT_10,
            TestValues.FLOAT_PRECISION,
            TestValues.FLOAT_ULP,
            1)]
        [DataRow(
            TestValues.FLOAT_PRECISION_CHECK,
            TestValues.FLOAT_PRECISION_CHECK_ERROR,
            TestValues.FLOAT_PRECISION,
            TestValues.FLOAT_ULP,
            0)]
        public void CompareTo_float(float a, float b, float precision, int ulp, int expected)
        {
            Validate.Value.AreEqual(Precision.CompareTo(a, b, precision), expected);
            Validate.Value.AreEqual(Precision.CompareTo(a, b, ulp), expected);
        }
        
        [DataTestMethod]
        [DataRow(
            TestValues.DOUBLE_10,
            TestValues.DOUBLE_15,
            TestValues.DOUBLE_PRECISION,
            TestValues.DOUBLE_ULP,
            -1)]
        [DataRow(
            TestValues.DOUBLE_10,
            TestValues.DOUBLE_10,
            TestValues.DOUBLE_PRECISION,
            TestValues.DOUBLE_ULP,
            0)]
        [DataRow(
            TestValues.DOUBLE_15,
            TestValues.DOUBLE_10,
            TestValues.DOUBLE_PRECISION,
            TestValues.DOUBLE_ULP,
            1)]
        [DataRow(
            TestValues.DOUBLE_PRECISION_CHECK,
            TestValues.DOUBLE_PRECISION_CHECK_ERROR,
            TestValues.DOUBLE_PRECISION,
            TestValues.DOUBLE_ULP,
            0)]
        public void CompareTo_double(double a, double b, double precision, int ulp, int expected)
        {
            Validate.Value.AreEqual(Precision.CompareTo(a, b, precision), expected);
            Validate.Value.AreEqual(Precision.CompareTo(a, b, ulp), expected);
        }
    }
}