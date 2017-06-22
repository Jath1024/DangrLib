// -----------------------------------------------------------------------
//  <copyright file="BitValue.cs" company="DangerDan9631">
//      Copyright (c) 2017 Dan Garvey. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/Dangerdan9631/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.Simulation.Types
{
    using System;
    using System.Text;
    using Dangr.Diagnostics;

    /// <summary>
    /// Enumerates the possible values for a single bit.
    /// </summary>
    public enum BitValue
    {
        Zero,
        One,
        Floating,
        Error
    }

    /// <summary>
    /// Provides extension methods for the <see cref="BitValue" /> <c>enum</c> and <see cref="BitValue" /> arrays.
    /// </summary>
    public static class BitValueExtensions
    {
        /// <summary>
        /// Inverts the specified <paramref name="value" /> if it is binary. The <paramref name="value" /> is the same for non binary values.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The inverted value.</returns>
        public static BitValue Invert(this BitValue value)
        {
            switch (value)
            {
                case BitValue.Zero:
                    return BitValue.One;
                case BitValue.One:
                    return BitValue.Zero;
                default:
                    return value;
            }
        }

        /// <summary>
        /// Logical Ands the specified values if they ar binary. Returns <see cref="Dangr.Simulation.Types.BitValue.Error" /> if either value is <see cref="Dangr.Simulation.Types.BitValue.Error" /> . If either value is <see cref="Dangr.Simulation.Types.BitValue.Floating" /> , then the <paramref name="ignoreFloating" /> parameter determines if the result should be <see cref="Dangr.Simulation.Types.BitValue.Error" /> ( <c> false </c> ) or pass through the other value ( <c> true </c> ).
        /// </summary>
        /// <param name="a">The value.</param>
        /// <param name="b">The other value.</param>
        /// <param name="ignoreFloating">
        /// Indicates whether floating values should be ignored.
        /// </param>
        /// <returns>The result value.</returns>
        public static BitValue And(this BitValue a, BitValue b, bool ignoreFloating)
        {
            if ((a == BitValue.Error) || (b == BitValue.Error))
            {
                return BitValue.Error;
            }

            if (!ignoreFloating && ((a == BitValue.Floating) || (b == BitValue.Floating)))
            {
                return BitValue.Error;
            }

            switch (a)
            {
                case BitValue.Zero:
                    return BitValue.Zero;
                case BitValue.One:
                    return (b == BitValue.One) || (b == BitValue.Floating)
                        ? BitValue.One
                        : BitValue.Zero;
                case BitValue.Floating:
                    return b;
                case BitValue.Error:
                default:
                    return BitValue.Error;
            }
        }

        /// <summary>
        /// Logical Ors the specified values if they ar binary. Returns <see cref="Dangr.Simulation.Types.BitValue.Error" /> if either value is <see cref="Dangr.Simulation.Types.BitValue.Error" /> . If either value is <see cref="Dangr.Simulation.Types.BitValue.Floating" /> , then the <paramref name="ignoreFloating" /> parameter determines if the result should be <see cref="Dangr.Simulation.Types.BitValue.Error" /> ( <c> false </c> ) or pass through the other value ( <c> true </c> ).
        /// </summary>
        /// <param name="a">The value.</param>
        /// <param name="b">The other value.</param>
        /// <param name="ignoreFloating">
        /// Indicates whether floating values should be ignored.
        /// </param>
        /// <returns>The result value.</returns>
        public static BitValue Or(this BitValue a, BitValue b, bool ignoreFloating)
        {
            if ((a == BitValue.Error) || (b == BitValue.Error))
            {
                return BitValue.Error;
            }

            if (!ignoreFloating && ((a == BitValue.Floating) || (b == BitValue.Floating)))
            {
                return BitValue.Error;
            }

            switch (a)
            {
                case BitValue.One:
                    return BitValue.One;
                case BitValue.Zero:
                    return (b == BitValue.Zero) || (b == BitValue.Floating)
                        ? BitValue.Zero
                        : BitValue.One;
                case BitValue.Floating:
                    return b;
                case BitValue.Error:
                default:
                    return BitValue.Error;
            }
        }

        /// <summary>
        /// Logical Xors the specified values if they ar binary. Returns <see cref="Dangr.Simulation.Types.BitValue.Error" /> if either value is <see cref="Dangr.Simulation.Types.BitValue.Error" /> . If either value is <see cref="Dangr.Simulation.Types.BitValue.Floating" /> , then the <paramref name="ignoreFloating" /> parameter determines if the result should be <see cref="Dangr.Simulation.Types.BitValue.Error" /> ( <c> false </c> ) or pass through the other value ( <c> true </c> ).
        /// </summary>
        /// <param name="a">The value.</param>
        /// <param name="b">The other value.</param>
        /// <param name="ignoreFloating">
        /// Indicates whether floating values should be ignored.
        /// </param>
        /// <returns>The result value.</returns>
        public static BitValue Xor(this BitValue a, BitValue b, bool ignoreFloating)
        {
            if ((a == BitValue.Error) || (b == BitValue.Error))
            {
                return BitValue.Error;
            }

            if (!ignoreFloating && ((a == BitValue.Floating) || (b == BitValue.Floating)))
            {
                return BitValue.Error;
            }

            switch (a)
            {
                case BitValue.One:
                    return b == BitValue.One
                        ? BitValue.Zero
                        : BitValue.One;
                case BitValue.Zero:
                    return b == BitValue.One
                        ? BitValue.One
                        : BitValue.Zero;
                case BitValue.Floating:
                    return b;
                case BitValue.Error:
                default:
                    return BitValue.Error;
            }
        }

        /// <summary>
        /// Inverts the specified <paramref name="value" /> and stores the result in the array specified by output. Output can be equal to value.
        /// </summary>
        /// <param name="value">The value to invert.</param>
        /// <param name="output">The output array.</param>
        public static void Invert(this BitValue[] value, ref BitValue[] output)
        {
            Assert.Validate.IsNotNull(output, "Cannot perform operation. Output array is null");
            Assert.Validate.AreEqual(
                value.Length,
                output.Length,
                "Cannot perform operation. Output is not the correct length.");

            for (var i = 0; i < value.Length; i++)
            {
                output[i] = value[i].Invert();
            }
        }

        /// <summary>
        /// Performs a bitwise logcial <see cref="And" /> of the specified values and stores the result in the array specified by output. Output can be equal to one of the inputs.
        /// </summary>
        /// <param name="a">The value.</param>
        /// <param name="b">The other value.</param>
        /// <param name="output">The output array.</param>
        /// <param name="ignoreFloating">
        /// Indicates whether floating values should be ignored.
        /// </param>
        public static void And(this BitValue[] a, BitValue[] b, ref BitValue[] output, bool ignoreFloating)
        {
            Assert.Validate.IsNotNull(b, "Cannot perform operation. Input B is null");
            Assert.Validate.IsNotNull(output, "Cannot perform operation. Output array is null");
            Assert.Validate.AreEqual(a.Length, b.Length, "Cannot perform operation. Inputs are not the same length.");
            Assert.Validate.AreEqual(
                a.Length,
                output.Length,
                "Cannot perform operation. Output is not the correct length.");

            for (var i = 0; i < a.Length; i++)
            {
                output[i] = a[i].And(b[i], ignoreFloating);
            }
        }

        /// <summary>
        /// Performs a bitwise logcial <see cref="Or" /> of the specified values and stores the result in the array specified by output. Output can be equal to one of the inputs.
        /// </summary>
        /// <param name="a">The value.</param>
        /// <param name="b">The other value.</param>
        /// <param name="output">The output array.</param>
        /// <param name="ignoreFloating">
        /// Indicates whether floating values should be ignored.
        /// </param>
        public static void Or(this BitValue[] a, BitValue[] b, ref BitValue[] output, bool ignoreFloating)
        {
            Assert.Validate.IsNotNull(b, "Cannot perform operation. Input B is null");
            Assert.Validate.IsNotNull(output, "Cannot perform operation. Output array is null");
            Assert.Validate.AreEqual(a.Length, b.Length, "Cannot perform operation. Inputs are not the same length.");
            Assert.Validate.AreEqual(
                a.Length,
                output.Length,
                "Cannot perform operation. Output is not the correct length.");

            for (var i = 0; i < a.Length; i++)
            {
                output[i] = a[i].Or(b[i], ignoreFloating);
            }
        }

        /// <summary>
        /// Performs a bitwise logcial <see cref="Xor" /> of the specified values and stores the result in the array specified by output. Output can be equal to one of the inputs.
        /// </summary>
        /// <param name="a">The value.</param>
        /// <param name="b">The other value.</param>
        /// <param name="output">The output array.</param>
        /// <param name="ignoreFloating">
        /// Indicates whether floating values should be ignored.
        /// </param>
        public static void Xor(this BitValue[] a, BitValue[] b, ref BitValue[] output, bool ignoreFloating)
        {
            Assert.Validate.IsNotNull(b, "Cannot perform operation. Input B is null");
            Assert.Validate.IsNotNull(output, "Cannot perform operation. Output array is null");
            Assert.Validate.AreEqual(a.Length, b.Length, "Cannot perform operation. Inputs are not the same length.");
            Assert.Validate.AreEqual(
                a.Length,
                output.Length,
                "Cannot perform operation. Output is not the correct length.");

            for (var i = 0; i < a.Length; i++)
            {
                output[i] = a[i].Xor(b[i], ignoreFloating);
            }
        }

        /// <summary>
        /// Increments the specified <paramref name="value" /> and stores the result in the array specified by output. Overflows will wrap. Output can be equal to value.
        /// </summary>
        /// <param name="value">The value to increment.</param>
        /// <param name="output">The output array.</param>
        /// <returns>
        /// <c> true </c> If the operation overflowed. Otherwise <c> false </c> .
        /// </returns>
        public static bool Increment(this BitValue[] value, ref BitValue[] output)
        {
            Assert.Validate.IsNotNull(output, "Cannot perform operation. Output array is null");
            Assert.Validate.AreEqual(
                value.Length,
                output.Length,
                "Cannot perform operation. Output is not the correct length.");

            var overflow = false;
            var incremented = false;
            for (var i = 0; i < value.Length; i++)
            {
                switch (value[i])
                {
                    case BitValue.Zero:
                        if (incremented)
                        {
                            output[i] = BitValue.Zero;
                        }
                        else
                        {
                            incremented = true;
                            output[i] = BitValue.One;
                        }
                        break;
                    case BitValue.One:
                        if (incremented)
                        {
                            output[i] = BitValue.One;
                        }
                        else
                        {
                            output[i] = BitValue.Zero;
                            if (i == value.Length - 1)
                            {
                                overflow = true;
                            }
                        }
                        break;
                    case BitValue.Floating:
                    case BitValue.Error:
                    default:
                        for (var e = 0; e < value.Length; e++)
                        {
                            output[e] = BitValue.Error;
                        }
                        return false;
                }
            }

            return overflow;
        }

        /// <summary>
        /// Negates the specified <paramref name="value" /> and stores the result in the array specified by output. Output can be equal to value.
        /// </summary>
        /// <param name="value">The value to negate.</param>
        /// <param name="output">The output array.</param>
        /// <returns>
        /// <c> true </c> If the operation overflowed. Otherwise <c> false </c> .
        /// </returns>
        public static bool Negate(this BitValue[] value, ref BitValue[] output)
        {
            Assert.Validate.IsNotNull(output, "Cannot perform operation. Output array is null");
            Assert.Validate.AreEqual(
                value.Length,
                output.Length,
                "Cannot perform operation. Output is not the correct length.");

            bool valueIsNegative = (value != null) && (value.Length > 0) && value[value.Length - 1].Equals(BitValue.One);
            value.Invert(ref output);
            output.Increment(ref output);

            BitValue signBit = output[output.Length - 1];
            bool resultIsNegative = signBit.Equals(BitValue.One);
            bool possibleOverflow = valueIsNegative == resultIsNegative;
            if (possibleOverflow)
            {
                // Not an overflow if an error occurred.
                if (signBit.Equals(BitValue.Error))
                {
                    return false;
                }

                // Not an overflow if the value is zero.
                for (var i = 0; i < output.Length; i++)
                {
                    if (output[i] != BitValue.Zero)
                    {
                        return true;
                    }
                }

                return false;
            }

            return false;
        }

        /// <summary>
        /// Pulls the specified <paramref name="value" /> using the given <see cref="PullBehavior" /> and stores the result in the array specified by output. Output can be equal to value.
        /// </summary>
        /// <param name="value">The value to pull.</param>
        /// <param name="pullBehavior">The pull behavior.</param>
        /// <param name="output">The output array.</param>
        public static void Pull(this BitValue[] value, PullBehavior pullBehavior, ref BitValue[] output)
        {
            Assert.Validate.IsNotNull(output, "Cannot perform operation. Output array is null");
            Assert.Validate.AreEqual(
                value.Length,
                output.Length,
                "Cannot perform operation. Output is not the correct length.");

            if (pullBehavior == PullBehavior.Unchanged)
            {
                if (!object.ReferenceEquals(value, output))
                {
                    Array.Copy(value, output, value.Length);
                }

                return;
            }

            BitValue pulledValue = pullBehavior == PullBehavior.PullUp
                ? BitValue.One
                : BitValue.Zero;
            for (var i = 0; i < value.Length; i++)
            {
                output[i] = value[i] == BitValue.Floating
                    ? pulledValue
                    : value[i];
            }
        }

        /// <summary>
        /// Determines whether the specified <see cref="BitValue" /> arrays are equal.
        /// </summary>
        /// <param name="a">The first <see cref="BitValue" /> array.</param>
        /// <param name="b">The second <see cref="BitValue" /> array.</param>
        /// <returns>
        /// <c> true </c> if the specified <see cref="BitValue" /> array is equal; otherwise, <c> false </c> .
        /// </returns>
        public static bool IsEqual(this BitValue[] a, BitValue[] b)
        {
            if ((b == null) || (a.Length != b.Length))
            {
                return false;
            }

            for (var i = 0; i < a.Length; i++)
            {
                if (a[i] != b[i])
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Returns a string representation of a <see cref="BitValue" /> array.
        /// </summary>
        /// <param name="value">The <see cref="BitValue" /> array.</param>
        /// <returns>The string representation.</returns>
        public static string PrintString(this BitValue[] value)
        {
            var builder = new StringBuilder();
            for (int i = value.Length - 1; i >= 0; i--)
            {
                switch (value[i])
                {
                    case BitValue.Zero:
                        builder.Append("0");
                        break;
                    case BitValue.One:
                        builder.Append("1");
                        break;
                    case BitValue.Floating:
                        builder.Append("X");
                        break;
                    case BitValue.Error:
                        builder.Append("E");
                        break;
                }
            }

            return builder.ToString();
        }
    }
}