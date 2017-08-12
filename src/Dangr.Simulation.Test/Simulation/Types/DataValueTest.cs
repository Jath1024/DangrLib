// -----------------------------------------------------------------------
//  <copyright file="DataValueTest.cs" company="Phoenix Game Studios, LLC">
//      Copyright (c) 2017 Phoenix Game Studios, LLC. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/PhoenixGameStudios/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.Simulation.Test.Simulation.Types
{
    using System.Collections.Generic;
    using Dangr.Diagnostics;
    using Dangr.Simulation.Types;
    using Dangr.Test;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Assert = Dangr.Diagnostics.Assert;

    [TestClass]
    public class DataValueTest
    {
        #region FromValues

        [TestMethod]
        public void FromValues_NonNull()
        {
            BitValue[] input =
            {
                BitValue.One,
                BitValue.Zero,
                BitValue.Floating,
                BitValue.Error
            };
            BitValue[] expected =
            {
                BitValue.One,
                BitValue.Zero,
                BitValue.Floating,
                BitValue.Error
            };

            DataValue actual = DataValue.FromValues(input);

            DataValueTest.ValidateValuesEqual(actual, expected);
        }

        [TestMethod]
        public void FromValues_Null()
        {
            BitValue[] input = null;

            TestUtils.TestForError<ValidationFailedException>(
                () => DataValue.FromValues(input),
                "Did not fail validation on null input.");
        }

        [TestMethod]
        public void FromValues_EmptyArray()
        {
            var input = new BitValue[0];

            TestUtils.TestForError<ValidationFailedException>(
                () => DataValue.FromValues(input),
                "Did not fail validation on empty input.");
        }

        #endregion FromValues

        #region Zero

        [TestMethod]
        public void Zero()
        {
            var bitWidth = 2;
            BitValue[] expected =
            {
                BitValue.Zero,
                BitValue.Zero
            };

            DataValue actual = DataValue.Zero(bitWidth);

            DataValueTest.ValidateValuesEqual(actual, expected);
        }

        [TestMethod]
        public void Zero_ZeroBitWidth()
        {
            var bitWidth = 0;

            TestUtils.TestForError<ValidationFailedException>(
                () => DataValue.Zero(bitWidth),
                "Did not fail validation on zero bit width input.");
        }

        [TestMethod]
        public void Zero_HighBitWidth()
        {
            int bitWidth = DataValue.MaxBitWidth + 1;

            TestUtils.TestForError<ValidationFailedException>(
                () => DataValue.Zero(bitWidth),
                "Did not fail validation on high bit width input.");
        }

        #endregion Zero

        #region One

        [TestMethod]
        public void One()
        {
            var bitWidth = 2;
            BitValue[] expected =
            {
                BitValue.One,
                BitValue.Zero
            };

            DataValue actual = DataValue.One(bitWidth);

            DataValueTest.ValidateValuesEqual(actual, expected);
        }

        [TestMethod]
        public void One_ZeroBitWidth()
        {
            var bitWidth = 0;

            TestUtils.TestForError<ValidationFailedException>(
                () => DataValue.One(bitWidth),
                "Did not fail validation on zero bit width input.");
        }

        [TestMethod]
        public void One_HighBitWidth()
        {
            int bitWidth = DataValue.MaxBitWidth + 1;

            TestUtils.TestForError<ValidationFailedException>(
                () => DataValue.One(bitWidth),
                "Did not fail validation on high bit width input.");
        }

        #endregion One

        #region Unsigned

        [TestMethod]
        public void Unsigned()
        {
            var bitWidth = 4;
            ulong value = 3;
            BitValue[] expected =
            {
                BitValue.One,
                BitValue.One,
                BitValue.Zero,
                BitValue.Zero
            };

            DataValue actual = DataValue.Unsigned(value, bitWidth);

            DataValueTest.ValidateValuesEqual(actual, expected);
        }

        [TestMethod]
        public void Unsigned_ZeroBitWidth()
        {
            var bitWidth = 0;
            ulong value = 3;

            TestUtils.TestForError<ValidationFailedException>(
                () => DataValue.Unsigned(value, bitWidth),
                "Did not fail validation on zero bit width input.");
        }

        [TestMethod]
        public void Unsigned_HighBitWidth()
        {
            int bitWidth = DataValue.MaxBitWidth + 1;
            ulong value = 3;

            TestUtils.TestForError<ValidationFailedException>(
                () => DataValue.Unsigned(value, bitWidth),
                "Did not fail validation on high bit width input.");
        }

        [TestMethod]
        public void Unsigned_SmallBitWidth()
        {
            var bitWidth = 8;
            ulong value = 0x1 << 9;

            TestUtils.TestForError<ValidationFailedException>(
                () => DataValue.Unsigned(value, bitWidth),
                "Did not fail validation on small bit width input.");
        }

        #endregion Unsigned

        #region Signed

        [TestMethod]
        public void Signed()
        {
            var bitWidth = 4;
            long value = 3;
            BitValue[] expected =
            {
                BitValue.One,
                BitValue.One,
                BitValue.Zero,
                BitValue.Zero
            };

            DataValue actual = DataValue.Signed(value, bitWidth);

            DataValueTest.ValidateValuesEqual(actual, expected);
        }

        [TestMethod]
        public void Signed_Negative()
        {
            var bitWidth = 4;
            long value = -3;
            BitValue[] expected =
            {
                BitValue.One,
                BitValue.Zero,
                BitValue.One,
                BitValue.One
            };

            DataValue actual = DataValue.Signed(value, bitWidth);

            DataValueTest.ValidateValuesEqual(actual, expected);
        }

        [TestMethod]
        public void Signed_MaxBitWidth()
        {
            int bitWidth = DataValue.MaxBitWidth;
            long value = long.MaxValue;
            var expected = new BitValue[bitWidth];
            for (var i = 0; i < bitWidth; i++)
            {
                expected[i] = i == bitWidth - 1
                    ? BitValue.Zero
                    : BitValue.One;
            }

            DataValue actual = DataValue.Signed(value, bitWidth);

            DataValueTest.ValidateValuesEqual(actual, expected);
        }

        [TestMethod]
        public void Signed_ZeroBitWidth()
        {
            var bitWidth = 0;
            long value = 3;

            TestUtils.TestForError<ValidationFailedException>(
                () => DataValue.Signed(value, bitWidth),
                "Did not fail validation on zero bit width input.");
        }

        [TestMethod]
        public void Signed_HighBitWidth()
        {
            int bitWidth = DataValue.MaxBitWidth + 1;
            long value = 3;

            TestUtils.TestForError<ValidationFailedException>(
                () => DataValue.Signed(value, bitWidth),
                "Did not fail validation on high bit width input.");
        }

        [TestMethod]
        public void Signed_SmallBitWidth()
        {
            var bitWidth = 8;
            long value = 0x1 << 9;

            TestUtils.TestForError<ValidationFailedException>(
                () => DataValue.Signed(value, bitWidth),
                "Did not fail validation on small bit width input.");
        }

        [TestMethod]
        public void Signed_SmallBitWidthNegative()
        {
            var bitWidth = 8;
            long value = -1*(0x1 << 9);

            TestUtils.TestForError<ValidationFailedException>(
                () => DataValue.Signed(value, bitWidth),
                "Did not fail validation on small bit width input.");
        }

        #endregion Signed

        #region Boolean

        [TestMethod]
        public void Boolean_True()
        {
            var value = true;
            var bitWidth = 2;
            BitValue[] expected =
            {
                BitValue.One,
                BitValue.Zero
            };

            DataValue actual = DataValue.Boolean(value, bitWidth);

            DataValueTest.ValidateValuesEqual(actual, expected);
        }

        [TestMethod]
        public void Boolean_False()
        {
            var value = false;
            var bitWidth = 2;
            BitValue[] expected =
            {
                BitValue.Zero,
                BitValue.Zero
            };

            DataValue actual = DataValue.Boolean(value, bitWidth);

            DataValueTest.ValidateValuesEqual(actual, expected);
        }

        [TestMethod]
        public void Boolean_ZeroBitWidth()
        {
            var value = true;
            var bitWidth = 0;

            TestUtils.TestForError<ValidationFailedException>(
                () => DataValue.Boolean(value, bitWidth),
                "Did not fail validation on zero bit width input.");
        }

        [TestMethod]
        public void Boolean_HighBitWidth()
        {
            var value = true;
            int bitWidth = DataValue.MaxBitWidth + 1;

            TestUtils.TestForError<ValidationFailedException>(
                () => DataValue.Boolean(value, bitWidth),
                "Did not fail validation on high bit width input.");
        }

        #endregion Boolean

        #region Floating

        [TestMethod]
        public void Floating()
        {
            var bitWidth = 2;
            BitValue[] expected =
            {
                BitValue.Floating,
                BitValue.Floating
            };

            DataValue actual = DataValue.Floating(bitWidth);

            DataValueTest.ValidateValuesEqual(actual, expected);
        }

        [TestMethod]
        public void Floating_ZeroBitWidth()
        {
            var bitWidth = 0;

            TestUtils.TestForError<ValidationFailedException>(
                () => DataValue.Floating(bitWidth),
                "Did not fail validation on zero bit width input.");
        }

        [TestMethod]
        public void Floating_HighBitWidth()
        {
            int bitWidth = DataValue.MaxBitWidth + 1;

            TestUtils.TestForError<ValidationFailedException>(
                () => DataValue.Floating(bitWidth),
                "Did not fail validation on high bit width input.");
        }

        #endregion Floating

        #region Error

        [TestMethod]
        public void Error()
        {
            var bitWidth = 2;
            BitValue[] expected =
            {
                BitValue.Error,
                BitValue.Error
            };

            DataValue actual = DataValue.Error(bitWidth);

            DataValueTest.ValidateValuesEqual(actual, expected);
        }

        [TestMethod]
        public void Error_ZeroBitWidth()
        {
            var bitWidth = 0;

            TestUtils.TestForError<ValidationFailedException>(
                () => DataValue.Error(bitWidth),
                "Did not fail validation on zero bit width input.");
        }

        [TestMethod]
        public void Error_HighBitWidth()
        {
            int bitWidth = DataValue.MaxBitWidth + 1;

            TestUtils.TestForError<ValidationFailedException>(
                () => DataValue.Error(bitWidth),
                "Did not fail validation on high bit width input.");
        }

        #endregion Error

        #region Concatenate

        [TestMethod]
        public void Concatenate()
        {
            DataValue input1 = DataValue.FromValues(
                new[]
                {
                    BitValue.One,
                    BitValue.One
                });
            DataValue input2 = DataValue.FromValues(
                new[]
                {
                    BitValue.Zero,
                    BitValue.Zero
                });
            DataValue input3 = DataValue.FromValues(
                new[]
                {
                    BitValue.Floating,
                    BitValue.Floating,
                    BitValue.Floating
                });

            BitValue[] expected =
            {
                BitValue.One,
                BitValue.One,
                BitValue.Zero,
                BitValue.Zero,
                BitValue.Floating,
                BitValue.Floating,
                BitValue.Floating
            };

            DataValue actual = DataValue.Concatenate(
                input1,
                input2,
                input3);

            DataValueTest.ValidateValuesEqual(actual, expected);
        }

        [TestMethod]
        public void Concatenate_NullValue()
        {
            DataValue input1 = DataValue.FromValues(
                new[]
                {
                    BitValue.One,
                    BitValue.One
                });
            DataValue input2 = null;
            DataValue input3 = DataValue.FromValues(
                new[]
                {
                    BitValue.Floating,
                    BitValue.Floating,
                    BitValue.Floating
                });

            TestUtils.TestForError<ValidationFailedException>(
                () =>
                    DataValue.Concatenate(
                        input1,
                        input2,
                        input3),
                "Did not fail operation with null input.");
        }

        [TestMethod]
        public void Concatenate_LargeValue()
        {
            DataValue input1 = DataValue.Zero(DataValue.MaxBitWidth);
            DataValue input2 = DataValue.One(1);

            TestUtils.TestForError<ValidationFailedException>(
                () =>
                        DataValue.Concatenate(input1, input2),
                "Did not fail operation with large input.");
        }

        [TestMethod]
        public void Concatenate_EmptyValue()
        {
            TestUtils.TestForError<ValidationFailedException>(
                () =>
                        DataValue.Concatenate(),
                "Did not fail operation with empty input.");
        }

        #endregion Concatenate

        #region Split

        [TestMethod]
        public void Split()
        {
            DataValue input = DataValue.FromValues(
                new[]
                {
                    BitValue.One,
                    BitValue.One,
                    BitValue.Zero,
                    BitValue.Zero,
                    BitValue.Floating,
                    BitValue.Floating,
                    BitValue.Floating
                });

            BitValue[][] expected =
            {
                new[]
                {
                    BitValue.One,
                    BitValue.One
                },
                new[]
                {
                    BitValue.Zero,
                    BitValue.Zero
                },
                new[]
                {
                    BitValue.Floating,
                    BitValue.Floating,
                    BitValue.Floating
                }
            };

            DataValue[] actual = DataValue.Split(input, 2, 2, 3);

            for (var i = 0; i < 3; i++)
            {
                DataValueTest.ValidateValuesEqual(actual[i], expected[i]);
            }
        }

        [TestMethod]
        public void Split_InvalidBitWidth()
        {
            DataValue input = DataValue.FromValues(
                new[]
                {
                    BitValue.One,
                    BitValue.One,
                    BitValue.Zero,
                    BitValue.Zero,
                    BitValue.Floating,
                    BitValue.Floating,
                    BitValue.Floating
                });

            TestUtils.TestForError<ValidationFailedException>(
                () =>
                        DataValue.Split(input, 2, 0, 5),
                "Did not fail operation with invalid bit width.");
        }

        [TestMethod]
        public void Split_InvalidTotalBitWidth()
        {
            DataValue input = DataValue.FromValues(
                new[]
                {
                    BitValue.One,
                    BitValue.One,
                    BitValue.Zero,
                    BitValue.Zero,
                    BitValue.Floating,
                    BitValue.Floating,
                    BitValue.Floating
                });

            TestUtils.TestForError<ValidationFailedException>(
                () =>
                        DataValue.Split(input, 2, 1, 3),
                "Did not fail operation with invalid bit width.");
        }

        #endregion Split

        #region Merge

        [TestMethod]
        public void Merge()
        {
            var pullBehavior = PullBehavior.Unchanged;
            var input = new List<DataValue>();
            input.Add(
                DataValue.FromValues(
                    new[]
                    {
                        BitValue.One,
                        BitValue.Floating,
                        BitValue.Floating
                    }));
            input.Add(
                DataValue.FromValues(
                    new[]
                    {
                        BitValue.Floating,
                        BitValue.Zero,
                        BitValue.Floating
                    }));

            BitValue[] expected =
            {
                BitValue.One,
                BitValue.Zero,
                BitValue.Floating
            };

            DataValue actual = DataValue.Merge(input, pullBehavior);

            DataValueTest.ValidateValuesEqual(actual, expected);
        }

        [TestMethod]
        public void Merge_Conflicts()
        {
            var pullBehavior = PullBehavior.Unchanged;
            var input = new List<DataValue>();
            input.Add(
                DataValue.FromValues(
                    new[]
                    {
                        BitValue.One,
                        BitValue.Floating,
                        BitValue.One
                    }));
            input.Add(
                DataValue.FromValues(
                    new[]
                    {
                        BitValue.Floating,
                        BitValue.Zero,
                        BitValue.Floating
                    }));
            input.Add(
                DataValue.FromValues(
                    new[]
                    {
                        BitValue.Floating,
                        BitValue.Floating,
                        BitValue.One
                    }));

            BitValue[] expected =
            {
                BitValue.One,
                BitValue.Zero,
                BitValue.Error
            };

            DataValue actual = DataValue.Merge(input, pullBehavior);

            DataValueTest.ValidateValuesEqual(actual, expected);
        }

        [TestMethod]
        public void Merge_Pulled()
        {
            var pullBehavior = PullBehavior.PullUp;
            var input = new List<DataValue>();
            input.Add(
                DataValue.FromValues(
                    new[]
                    {
                        BitValue.One,
                        BitValue.Floating,
                        BitValue.Floating
                    }));
            input.Add(
                DataValue.FromValues(
                    new[]
                    {
                        BitValue.Floating,
                        BitValue.Zero,
                        BitValue.Floating
                    }));

            BitValue[] expected =
            {
                BitValue.One,
                BitValue.Zero,
                BitValue.One
            };

            DataValue actual = DataValue.Merge(input, pullBehavior);

            DataValueTest.ValidateValuesEqual(actual, expected);
        }

        [TestMethod]
        public void Merge_EmptyValue()
        {
            var pullBehavior = PullBehavior.Unchanged;
            var input = new List<DataValue>();

            TestUtils.TestForError<ValidationFailedException>(
                () =>
                        DataValue.Merge(input, pullBehavior),
                "Did not fail validation.");
        }

        [TestMethod]
        public void Merge_NullFirstValue()
        {
            var pullBehavior = PullBehavior.Unchanged;
            var input = new List<DataValue>();
            input.Add(null);
            input.Add(
                DataValue.FromValues(
                    new[]
                    {
                        BitValue.One,
                        BitValue.Floating,
                        BitValue.Floating
                    }));

            TestUtils.TestForError<ValidationFailedException>(
                () =>
                        DataValue.Merge(input, pullBehavior),
                "Did not fail validation.");
        }

        [TestMethod]
        public void Merge_NullSecondValue()
        {
            var pullBehavior = PullBehavior.Unchanged;
            var input = new List<DataValue>();
            input.Add(
                DataValue.FromValues(
                    new[]
                    {
                        BitValue.One,
                        BitValue.Floating,
                        BitValue.Floating
                    }));
            input.Add(null);

            TestUtils.TestForError<ValidationFailedException>(
                () =>
                        DataValue.Merge(input, pullBehavior),
                "Did not fail validation.");
        }

        [TestMethod]
        public void Merge_MismatchedBitWidth()
        {
            var pullBehavior = PullBehavior.Unchanged;
            var input = new List<DataValue>();
            input.Add(
                DataValue.FromValues(
                    new[]
                    {
                        BitValue.One,
                        BitValue.Floating,
                        BitValue.Floating
                    }));
            input.Add(
                DataValue.FromValues(
                    new[]
                    {
                        BitValue.One,
                        BitValue.Floating
                    }));

            TestUtils.TestForError<ValidationFailedException>(
                () =>
                        DataValue.Merge(input, pullBehavior),
                "Did not fail validation.");
        }

        #endregion Concatenate

        #region Overrides

        [TestMethod]
        public void DataValue_ToString()
        {
            DataValue value = DataValue.FromValues(
                new[]
                {
                    BitValue.Zero,
                    BitValue.One,
                    BitValue.Floating,
                    BitValue.Error
                });

            var expected = "EX10";

            string actual = value.ToString();

            Assert.Validate.AreEqual(expected, actual, "String values don't match.");
        }

        [TestMethod]
        public void DataValue_EqualsDataValue()
        {
            DataValue value = DataValue.FromValues(
                new[]
                {
                    BitValue.Zero,
                    BitValue.One,
                    BitValue.Floating,
                    BitValue.Error
                });
            DataValue other = DataValue.FromValues(
                new[]
                {
                    BitValue.Zero,
                    BitValue.One,
                    BitValue.Floating,
                    BitValue.Error
                });

            Assert.Validate.IsTrue(value.Equals(other), "Data values don't match.");
        }

        [TestMethod]
        public void DataValue_NotEqualsDataValue()
        {
            DataValue value = DataValue.FromValues(
                new[]
                {
                    BitValue.Zero,
                    BitValue.One,
                    BitValue.Floating,
                    BitValue.Error
                });
            DataValue other = DataValue.FromValues(
                new[]
                {
                    BitValue.One,
                    BitValue.One,
                    BitValue.Floating,
                    BitValue.Error
                });

            Assert.Validate.IsFalse(value.Equals(other), "Data values should not match.");
        }

        [TestMethod]
        public void DataValue_NotEqualsNull()
        {
            DataValue value = DataValue.FromValues(
                new[]
                {
                    BitValue.Zero,
                    BitValue.One,
                    BitValue.Floating,
                    BitValue.Error
                });
            DataValue other = null;

            Assert.Validate.IsFalse(value.Equals(other), "Data values should not match.");
        }

        [TestMethod]
        public void DataValue_NotEqualsDifferentBitWidths()
        {
            DataValue value = DataValue.FromValues(
                new[]
                {
                    BitValue.Zero,
                    BitValue.One,
                    BitValue.Floating,
                    BitValue.Error
                });
            DataValue other = DataValue.FromValues(
                new[]
                {
                    BitValue.One,
                    BitValue.One,
                    BitValue.Floating
                });

            Assert.Validate.IsFalse(value.Equals(other), "Data values should not match.");
        }

        [TestMethod]
        public void DataValue_EqualsObject()
        {
            DataValue value = DataValue.FromValues(
                new[]
                {
                    BitValue.Zero,
                    BitValue.One,
                    BitValue.Floating,
                    BitValue.Error
                });
            object other = DataValue.FromValues(
                new[]
                {
                    BitValue.Zero,
                    BitValue.One,
                    BitValue.Floating,
                    BitValue.Error
                });

            Assert.Validate.IsTrue(value.Equals(other), "Data values don't match.");
        }

        [TestMethod]
        public void DataValue_GetHashCode()
        {
            DataValue value = DataValue.FromValues(
                new[]
                {
                    BitValue.Zero,
                    BitValue.One,
                    BitValue.Floating,
                    BitValue.Error
                });
            DataValue other = DataValue.FromValues(
                new[]
                {
                    BitValue.Zero,
                    BitValue.One,
                    BitValue.Floating,
                    BitValue.Error
                });

            Assert.Validate.AreEqual(value.GetHashCode(), other.GetHashCode(), "Hash codes don't match.");
        }

        #endregion Overrides

        private static void ValidateValuesEqual(DataValue a, BitValue[] b)
        {
            Assert.Validate.AreEqual(a.BitWidth, b.Length, "Values are different sizes.");
            for (var i = 0; i < a.BitWidth; i++)
            {
                Assert.Validate.AreEqual(a[i], b[i], $"Values are different at index {i}.");
            }
        }
    }
}