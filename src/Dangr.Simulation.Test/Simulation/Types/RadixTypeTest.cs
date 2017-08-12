// -----------------------------------------------------------------------
//  <copyright file="RadixTypeTest.cs" company="Phoenix Game Studios, LLC">
//      Copyright (c) 2017 Phoenix Game Studios, LLC. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/PhoenixGameStudios/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.Simulation.Test.Simulation.Types
{
    using System.Collections.Generic;
    using Dangr.Simulation.Types;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Assert = Dangr.Diagnostics.Assert;

    [TestClass]
    public class RadixTypeTest
    {
        #region Binary

        [TestMethod]
        public void Binary()
        {
            DataValue value = DataValue.FromValues(
                new[]
                {
                    BitValue.Zero,
                    BitValue.One,
                    BitValue.Zero,
                    BitValue.One
                });
            var expected = "1010";

            string actual = RadixType.Binary.Convert(value);

            Assert.Validate.AreEqual(expected, actual, "Incorrect string value.");
        }

        [TestMethod]
        public void Binary_WithFloating()
        {
            DataValue value = DataValue.FromValues(
                new[]
                {
                    BitValue.Zero,
                    BitValue.One,
                    BitValue.Zero,
                    BitValue.Floating
                });
            var expected = "X010";

            string actual = RadixType.Binary.Convert(value);

            Assert.Validate.AreEqual(expected, actual, "Incorrect string value.");
        }

        [TestMethod]
        public void Binary_WithError()
        {
            DataValue value = DataValue.FromValues(
                new[]
                {
                    BitValue.Zero,
                    BitValue.One,
                    BitValue.Zero,
                    BitValue.Error
                });
            var expected = "*010";

            string actual = RadixType.Binary.Convert(value);

            Assert.Validate.AreEqual(expected, actual, "Incorrect string value.");
        }

        #endregion Binary

        #region Octal

        [TestMethod]
        public void Octal()
        {
            DataValue value = DataValue.FromValues(
                new[]
                {
                    BitValue.Zero,
                    BitValue.One,
                    BitValue.Zero
                });
            var expected = "8x2";

            string actual = RadixType.Octal.Convert(value);

            Assert.Validate.AreEqual(expected, actual, "Incorrect string value.");
        }

        [TestMethod]
        public void Octal_WithFloating()
        {
            DataValue value = DataValue.FromValues(
                new[]
                {
                    BitValue.Zero,
                    BitValue.One,
                    BitValue.Zero,
                    BitValue.Floating,
                    BitValue.One,
                    BitValue.Zero
                });
            var expected = "8xX2";

            string actual = RadixType.Octal.Convert(value);

            Assert.Validate.AreEqual(expected, actual, "Incorrect string value.");
        }

        [TestMethod]
        public void Octal_WithError()
        {
            DataValue value = DataValue.FromValues(
                new[]
                {
                    BitValue.Zero,
                    BitValue.One,
                    BitValue.Zero,
                    BitValue.Error,
                    BitValue.One,
                    BitValue.Zero
                });
            var expected = "8x*2";

            string actual = RadixType.Octal.Convert(value);

            Assert.Validate.AreEqual(expected, actual, "Incorrect string value.");
        }

        #endregion Octal

        #region Signed Decimal

        [TestMethod]
        public void SignedDecimal()
        {
            DataValue value = DataValue.FromValues(
                new[]
                {
                    BitValue.Zero,
                    BitValue.One,
                    BitValue.Zero
                });
            var expected = "2";

            string actual = RadixType.SignedDecimal.Convert(value);

            Assert.Validate.AreEqual(expected, actual, "Incorrect string value.");
        }

        [TestMethod]
        public void SignedDecimal_Negative()
        {
            DataValue value = DataValue.FromValues(
                new[]
                {
                    BitValue.One,
                    BitValue.One,
                    BitValue.One
                });
            var expected = "-1";

            string actual = RadixType.SignedDecimal.Convert(value);

            Assert.Validate.AreEqual(expected, actual, "Incorrect string value.");
        }

        [TestMethod]
        public void SignedDecimal_WithFloating()
        {
            DataValue value = DataValue.FromValues(
                new[]
                {
                    BitValue.Zero,
                    BitValue.One,
                    BitValue.Zero,
                    BitValue.Floating
                });
            var expected = "X";

            string actual = RadixType.SignedDecimal.Convert(value);

            Assert.Validate.AreEqual(expected, actual, "Incorrect string value.");
        }

        [TestMethod]
        public void SignedDecimal_WithError()
        {
            DataValue value = DataValue.FromValues(
                new[]
                {
                    BitValue.Zero,
                    BitValue.One,
                    BitValue.Zero,
                    BitValue.Error
                });
            var expected = "*";

            string actual = RadixType.SignedDecimal.Convert(value);

            Assert.Validate.AreEqual(expected, actual, "Incorrect string value.");
        }

        #endregion Signed Decimal

        #region Unsigned Decimal

        [TestMethod]
        public void UnsignedDecimal()
        {
            DataValue value = DataValue.FromValues(
                new[]
                {
                    BitValue.Zero,
                    BitValue.One,
                    BitValue.Zero
                });
            var expected = "2";

            string actual = RadixType.UnsignedDecimal.Convert(value);

            Assert.Validate.AreEqual(expected, actual, "Incorrect string value.");
        }

        [TestMethod]
        public void UnsignedDecimal_WithFloating()
        {
            DataValue value = DataValue.FromValues(
                new[]
                {
                    BitValue.Zero,
                    BitValue.One,
                    BitValue.Zero,
                    BitValue.Floating
                });
            var expected = "X";

            string actual = RadixType.UnsignedDecimal.Convert(value);

            Assert.Validate.AreEqual(expected, actual, "Incorrect string value.");
        }

        [TestMethod]
        public void UnsignedDecimal_WithError()
        {
            DataValue value = DataValue.FromValues(
                new[]
                {
                    BitValue.Zero,
                    BitValue.One,
                    BitValue.Zero,
                    BitValue.Error
                });
            var expected = "*";

            string actual = RadixType.UnsignedDecimal.Convert(value);

            Assert.Validate.AreEqual(expected, actual, "Incorrect string value.");
        }

        #endregion Unsigned Decimal

        #region Hex

        [TestMethod]
        public void Hex()
        {
            DataValue value = DataValue.FromValues(
                new[]
                {
                    BitValue.Zero,
                    BitValue.One,
                    BitValue.Zero,
                    BitValue.Zero,
                    BitValue.Zero,
                    BitValue.Zero,
                    BitValue.Zero,
                    BitValue.Zero
                });
            var expected = "0x02";

            string actual = RadixType.Hex.Convert(value);

            Assert.Validate.AreEqual(expected, actual, "Incorrect string value.");
        }

        [TestMethod]
        public void Hex_WithFloating()
        {
            DataValue value = DataValue.FromValues(
                new[]
                {
                    BitValue.Zero,
                    BitValue.One,
                    BitValue.Zero,
                    BitValue.Floating,
                    BitValue.Zero,
                    BitValue.Zero,
                    BitValue.Zero,
                    BitValue.Zero
                });
            var expected = "0x0X";

            string actual = RadixType.Hex.Convert(value);

            Assert.Validate.AreEqual(expected, actual, "Incorrect string value.");
        }

        [TestMethod]
        public void Hex_WithError()
        {
            DataValue value = DataValue.FromValues(
                new[]
                {
                    BitValue.Zero,
                    BitValue.One,
                    BitValue.Zero,
                    BitValue.Error,
                    BitValue.Zero,
                    BitValue.Zero,
                    BitValue.Zero,
                    BitValue.Zero
                });
            var expected = "0x0*";

            string actual = RadixType.Hex.Convert(value);

            Assert.Validate.AreEqual(expected, actual, "Incorrect string value.");
        }

        [TestMethod]
        public void Hex_AllValues()
        {
            var hexMap = new Dictionary<ulong, string>();
            hexMap.Add(0, "0x0");
            hexMap.Add(1, "0x1");
            hexMap.Add(2, "0x2");
            hexMap.Add(3, "0x3");
            hexMap.Add(4, "0x4");
            hexMap.Add(5, "0x5");
            hexMap.Add(6, "0x6");
            hexMap.Add(7, "0x7");
            hexMap.Add(8, "0x8");
            hexMap.Add(9, "0x9");
            hexMap.Add(10, "0xA");
            hexMap.Add(11, "0xB");
            hexMap.Add(12, "0xC");
            hexMap.Add(13, "0xD");
            hexMap.Add(14, "0xE");
            hexMap.Add(15, "0xF");

            foreach (KeyValuePair<ulong, string> entry in hexMap)
            {
                DataValue value = DataValue.Unsigned(entry.Key, 4);
                string expected = entry.Value;
                string actual = RadixType.Hex.Convert(value);
                Assert.Validate.AreEqual(expected, actual, "Incorrect string value.");
            }
        }

        #endregion Hex
    }
}