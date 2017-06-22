// -----------------------------------------------------------------------
//  <copyright file="DataValue.cs" company="DangerDan9631">
//      Copyright (c) 2017 Dan Garvey. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/Dangerdan9631/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.Simulation.Types
{
    using System;
    using System.Collections.Generic;
    using Dangr.Diagnostics;

    /// <summary>
    /// Represents the value stored in a wire or component.
    /// </summary>
    public sealed class DataValue
    {
        /// <summary>
        /// The maximum bit width allowed for a single bit value.
        /// </summary>
        public const int MaxBitWidth = 64;

        private readonly BitValue[] bitValues;

        /// <summary>
        /// Gets the number of bits in this <see cref="DataValue" />.
        /// </summary>
        public int BitWidth { get; }

        /// <summary>
        /// Gets the <see cref="BitValue" /> of the bit at the specified index.
        /// </summary>
        /// <param name="index"> The index. </param>
        /// <returns> The <see cref="BitValue" />. </returns>
        /// <exception cref="IndexOutOfRangeException"> If the index specified is &lt; 0 or &gt;= <see cref="BitWidth" />. </exception>
        public BitValue this[int index] => this.bitValues[index];

        private DataValue(BitValue[] bitValues)
        {
            this.BitWidth = bitValues.Length;
            this.bitValues = bitValues;
        }

        /// <summary>
        /// Copies the bit values stored in this <see cref="DataValue" />.
        /// </summary>
        /// <returns> A new array containing a copy of the <see cref="BitValue" />s stored in this <see cref="DataValue" />. </returns>
        public BitValue[] CopyBitValues()
        {
            var result = new BitValue[this.BitWidth];
            Array.Copy(this.bitValues, result, this.BitWidth);
            return result;
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return this.bitValues.PrintString();
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj"> The <see cref="System.Object" /> to compare with this instance. </param>
        /// <returns>
        /// <c> true </c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c> false </c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            return this.Equals(obj as DataValue);
        }

        /// <summary>
        /// Determines whether the specified <see cref="DataValue" />, is equal to this instance.
        /// </summary>
        /// <param name="obj"> The <see cref="DataValue" /> to compare with this instance. </param>
        /// <returns>
        /// <c> true </c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c> false </c>.
        /// </returns>
        public bool Equals(DataValue obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (this.BitWidth != obj.BitWidth)
            {
                return false;
            }

            for (var i = 0; i < this.BitWidth; i++)
            {
                if (this.bitValues[i] != obj.bitValues[i])
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        public override int GetHashCode()
        {
            var hashCode = 0;
            for (var i = 0; i < this.BitWidth; i++)
            {
                hashCode = 17*hashCode + this.bitValues[i].GetHashCode();
            }

            return hashCode;
        }

        /// <summary>
        /// Creates a new <see cref="DataValue" /> from an array of <see cref="BitValue" />s.
        /// </summary>
        /// <param name="value"> An array of <see cref="BitValue" />s. </param>
        /// <returns> A newly created <see cref="DataValue" />. </returns>
        public static DataValue FromValues(BitValue[] value)
        {
            Assert.Validate.IsNotNull(value, "Value cannot be null");
            DataValue.ValidateBitWidth(value.Length);

            return new DataValue(value);
        }

        /// <summary>
        /// Creates a new <see cref="DataValue" /> that has a binary value of 0.
        /// </summary>
        /// <param name="bitWidth"> The bitwidth of the new <see cref="DataValue" />. </param>
        /// <returns> A newly created <see cref="DataValue" />. </returns>
        public static DataValue Zero(int bitWidth)
        {
            DataValue.ValidateBitWidth(bitWidth);
            return new DataValue(DataValue.FromULong(0ul, bitWidth));
        }

        /// <summary>
        /// Creates a new <see cref="DataValue" /> that has a binary value of 1.
        /// </summary>
        /// <param name="bitWidth"> The bitwidth of the new <see cref="DataValue" />. </param>
        /// <returns> A newly created <see cref="DataValue" />. </returns>
        public static DataValue One(int bitWidth)
        {
            DataValue.ValidateBitWidth(bitWidth);
            return new DataValue(DataValue.FromULong(1ul, bitWidth));
        }

        /// <summary>
        /// Creates a new <see cref="DataValue" /> that has a binary value equal to specified the unsigned long value.
        /// </summary>
        /// <param name="value"> The ulong value to create the <see cref="DataValue" /> from. </param>
        /// <param name="bitWidth">
        /// The bitwidth of the new <see cref="DataValue" />. The bit width must be large enough to
        /// contain the given value.
        /// </param>
        /// <returns> A newly created <see cref="DataValue" />. </returns>
        public static DataValue Unsigned(ulong value, int bitWidth)
        {
            DataValue.ValidateBitWidth(bitWidth);
            Assert.Validate.Compare(
                value,
                CompareOperation.Less,
                0x1 << bitWidth,
                "Value too large to fit in bit width.");
            return new DataValue(DataValue.FromULong(value, bitWidth));
        }

        /// <summary>
        /// Creates a new <see cref="DataValue" /> that has a binary value equal to specified the 2's complement signed long value.
        /// </summary>
        /// <param name="value"> The long value to create the <see cref="DataValue" />. </param>
        /// <param name="bitWidth">
        /// The bitwidth of the new <see cref="DataValue" />. The bit width must be large enough to
        /// contain the given value.
        /// </param>
        /// <returns> A newly created <see cref="DataValue" />. </returns>
        public static DataValue Signed(long value, int bitWidth)
        {
            DataValue.ValidateBitWidth(bitWidth);

            long maxValue;
            long minValue;
            if (bitWidth < DataValue.MaxBitWidth)
            {
                maxValue = 0x1 << (bitWidth - 1);
                minValue = maxValue*-1 - 1;
            }
            else
            {
                maxValue = long.MaxValue;
                minValue = long.MinValue;
            }

            Assert.Validate.IsInRange(
                value,
                minValue,
                maxValue,
                "Value too large to fit in bit width.");

            var isNegative = false;
            long signedValue = value;
            if (signedValue < 0)
            {
                isNegative = true;
                signedValue *= -1;
            }

            ulong unsignedValue = Convert.ToUInt64(signedValue);
            BitValue[] unsignedBits = DataValue.FromULong(unsignedValue, bitWidth);
            if (isNegative)
            {
                unsignedBits.Negate(ref unsignedBits);
            }

            return new DataValue(unsignedBits);
        }

        /// <summary>
        /// Creates a new <see cref="DataValue" /> from a boolean value. The binary value with be 1 for <c> true </c> and 0 for
        /// <c> false </c>.
        /// </summary>
        /// <param name="value"> The boolean value to create the <see cref="DataValue" />. </param>
        /// <param name="bitWidth">
        /// The bitwidth of the new <see cref="DataValue" />.
        /// </param>
        /// <returns> A newly created <see cref="DataValue" />. </returns>
        public static DataValue Boolean(bool value, int bitWidth)
        {
            DataValue.ValidateBitWidth(bitWidth);

            ulong bitValue = value ? 1ul : 0ul;
            return new DataValue(DataValue.FromULong(bitValue, bitWidth));
        }

        /// <summary>
        /// Creates a new <see cref="DataValue" /> with all bits initialized to <see cref="BitValue.Floating" />.
        /// </summary>
        /// <param name="bitWidth"> The bitwidth of the new <see cref="DataValue" />. </param>
        /// <returns> A newly created <see cref="DataValue" />. </returns>
        public static DataValue Floating(int bitWidth)
        {
            DataValue.ValidateBitWidth(bitWidth);

            var result = new BitValue[bitWidth];
            for (var i = 0; i < bitWidth; i++)
            {
                result[i] = BitValue.Floating;
            }

            return new DataValue(result);
        }

        /// <summary>
        /// Creates a new <see cref="DataValue" /> with all bits initialized to <see cref="BitValue.Error" />.
        /// </summary>
        /// <param name="bitWidth"> The bitwidth of the new <see cref="DataValue" />. </param>
        /// <returns> A newly created <see cref="DataValue" />. </returns>
        public static DataValue Error(int bitWidth)
        {
            DataValue.ValidateBitWidth(bitWidth);

            var result = new BitValue[bitWidth];
            for (var i = 0; i < bitWidth; i++)
            {
                result[i] = BitValue.Error;
            }

            return new DataValue(result);
        }

        /// <summary>
        /// Creates a new <see cref="DataValue" /> that has a value equal to all of the specified <see cref="DataValue" />s
        /// concatenated together. The sum of the bit widths of all input values must be less than
        /// <see cref="DataValue.MaxBitWidth" />.
        /// </summary>
        /// <param name="values"> The values to concatenate. </param>
        /// <returns> A newly created <see cref="DataValue" />. </returns>
        public static DataValue Concatenate(params DataValue[] values)
        {
            var bitWidth = 0;
            for (var i = 0; i < values.Length; i++)
            {
                Assert.Validate.IsNotNull(values[i], "Cannot combine null value.");
                bitWidth += values[i].BitWidth;
            }

            DataValue.ValidateBitWidth(bitWidth);

            var result = new BitValue[bitWidth];
            var resutlIndex = 0;
            foreach (DataValue value in values)
            {
                for (var i = 0; i < value.BitWidth; i++)
                {
                    result[resutlIndex++] = value.bitValues[i];
                }
            }

            return new DataValue(result);
        }

        /// <summary>
        /// Creates a new array of <see cref="DataValue" />s that are created by splitting the given <see cref="DataValue" />
        /// in chunks specified by the bitWidths parameter. The sum of all bit widths must be equal to the bitwidth of the input
        /// <see cref="DataValue" />.
        /// </summary>
        /// <param name="value"> The value to split. </param>
        /// <param name="bitWidths"> The bit widths of the requested split parts. </param>
        /// <returns> An array of newly created <see cref="DataValue" />s. </returns>
        public static DataValue[] Split(DataValue value, params int[] bitWidths)
        {
            var totalBitWidth = 0;
            for (var i = 0; i < bitWidths.Length; i++)
            {
                DataValue.ValidateBitWidth(bitWidths[i]);
                totalBitWidth += bitWidths[i];
            }

            Assert.Validate.AreEqual(totalBitWidth, value.BitWidth, "Sum of bitWidths does not equal bitWidth.");
            var currentBitIndex = 0;
            var results = new DataValue[bitWidths.Length];
            for (var i = 0; i < bitWidths.Length; i++)
            {
                var bitValues = new BitValue[bitWidths[i]];
                for (var b = 0; b < bitWidths[i]; b++)
                {
                    bitValues[b] = value[currentBitIndex++];
                }
                results[i] = DataValue.FromValues(bitValues);
            }

            return results;
        }

        /// <summary>
        /// Creates a new <see cref="DataValue" /> that has a value equal to all of the specified values merged together, using the
        /// specified
        /// pull behavior.
        /// To merge values, each bit is compared.
        /// If there is more than one non-<see cref="BitValue.Floating" /> value for that bit, the resulting bit is
        /// <see cref="BitValue.Error" />.
        /// If there is only one non-<see cref="BitValue.Floating" /> value for that bit, the resulting bit is equal to that value.
        /// If all values for that bit are <see cref="BitValue.Floating" />, the resulting bit is determined by the given
        /// <see cref="PullBehavior" />.
        /// </summary>
        /// <param name="values"> The values to merge. </param>
        /// <param name="pullBehavior">
        /// The pull behavior to use when a bit for all input values is
        /// <see cref="BitValue.Floating" />.
        /// </param>
        /// <returns> A newly created <see cref="DataValue" />. </returns>
        public static DataValue Merge(ICollection<DataValue> values, PullBehavior pullBehavior)
        {
            Assert.Validate.Compare(values.Count, CompareOperation.Greater, 0, "No values to merge.");

            BitValue[] result = null;
            var bitWidth = 0;
            foreach (DataValue value in values)
            {
                if (result == null)
                {
                    Assert.Validate.IsNotNull(value, "Cannot merge null value.");
                    bitWidth = value.BitWidth;
                    result = value.CopyBitValues();
                    continue;
                }

                Assert.Validate.IsNotNull(value, "Cannot merge null value.");
                Assert.Validate.AreEqual(value.BitWidth, bitWidth, "BitWidth of merged value does not equal bitWidth.");
                for (var i = 0; i < bitWidth; i++)
                {
                    if (value.bitValues[i] != BitValue.Floating)
                    {
                        result[i] = result[i] == BitValue.Floating
                            ? value.bitValues[i]
                            : BitValue.Error;
                    }
                }
            }

            result.Pull(pullBehavior, ref result);
            return new DataValue(result);
        }

        private static BitValue[] FromULong(ulong bits, int bitWidth)
        {
            var result = new BitValue[bitWidth];
            for (var i = 0; i < bitWidth; i++)
            {
                result[i] = (bits & (0x1ul << i)) > 0 ? BitValue.One : BitValue.Zero;
            }

            return result;
        }

        private static void ValidateBitWidth(int bitWidth)
        {
            Assert.Validate.IsInRange(
                bitWidth,
                1,
                DataValue.MaxBitWidth,
                $"BitWidth must be between 0 and {DataValue.MaxBitWidth}.");
        }
    }
}