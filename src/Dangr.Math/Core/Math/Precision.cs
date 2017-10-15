// -----------------------------------------------------------------------
//  <copyright file="Precision.cs" company="Phoenix Game Studios, LLC">
//      Copyright (c) 2017 Phoenix Game Studios, LLC. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/PhoenixGameStudios/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------


namespace Dangr.Core.Math
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Utilities for comparing floating point numbers.
    /// </summary>
    public static class Precision
    {
        private const int FLOAT_SHIFT_BITS = 31;
        private const int DOUBLE_SHIFT_BITS = 63;
        private const uint FLOAT_BIT_MASK = 0x80000000;
        private const ulong DOUBLE_BIT_MASK = 0x8000000000000000;

        /// <summary>
        /// Union of a floating point variable and an integer.
        /// </summary>
        [StructLayout(LayoutKind.Explicit)]
        private struct FloatIntUnion
        {
            /// <summary>
            /// The union's value as a floating point variable.
            /// </summary>
            [FieldOffset(0)]
            public float Float;

            /// <summary>
            /// The union's value as an integer.
            /// </summary>
            [FieldOffset(0)]
            public int Int;

            /// <summary>
            /// The union's value as an unsigned integer.
            /// </summary>
            [FieldOffset(0)]
            public uint UInt;
        }

        /// <summary>
        /// Union of a double precision floating point variable and a long.
        /// </summary>
        [StructLayout(LayoutKind.Explicit)]
        private struct DoubleLongUnion
        {
            /// <summary>
            /// The union's value as a double precision floating point variable.
            /// </summary>
            [FieldOffset(0)]
            public double Double;

            /// <summary>
            /// The union's value as a long.
            /// </summary>
            [FieldOffset(0)]
            public long Long;

            /// <summary>
            /// The union's value as an unsigned long.
            /// </summary>
            [FieldOffset(0)]
            public ulong ULong;
        }

        /// <summary>
        /// Compares two numbers given some amount of allowed error.
        /// </summary>
        /// <param name="x">The first number.</param>
        /// <param name="y">The second number.</param>
        /// <param name="epsilon">The amount of error allowed when checking for equality.</param>
        /// <returns>0 if x equals y, -1 if x is less than y, 1 if x is greater than y.</returns>
        public static int CompareTo(float x, float y, double epsilon)
        {
            if (Precision.Equals(x, y, epsilon))
            {
                return 0;
            }

            return x < y
                ? -1
                : 1;
        }

        /// <summary>
        /// Compares two numbers given some amount of allowed error.
        /// </summary>
        /// <param name="x">The first number.</param>
        /// <param name="y">The second number.</param>
        /// <param name="epsilon">The amount of error allowed when checking for equality.</param>
        /// <returns>0 if x equals y, -1 if x is less than y, 1 if x is greater than y.</returns>
        public static int CompareTo(double x, double y, double epsilon)
        {
            if (Precision.Equals(x, y, epsilon))
            {
                return 0;
            }

            return x < y
                ? -1
                : 1;
        }

        /// <summary>
        /// Compares two numbers given some amount of allowed distance.
        /// https://randomascii.wordpress.com/2012/02/25/comparing-floating-point-numbers-2012-edition/
        /// </summary>
        /// <param name="x">The first number.</param>
        /// <param name="y">The second number.</param>
        /// <param name="maxUlp">The number of discreet floating point values that are allowed between the two values.</param>
        /// <returns>0 if x equals y, -1 if x is less than y, 1 if x is greater than y.</returns>
        public static int CompareTo(float x, float y, int maxUlp)
        {
            if (Precision.Equals(x, y, maxUlp))
            {
                return 0;
            }

            return x < y
                ? -1
                : 1;
        }

        /// <summary>
        /// Compares two numbers given some amount of allowed distance.
        /// https://randomascii.wordpress.com/2012/02/25/comparing-floating-point-numbers-2012-edition/
        /// </summary>
        /// <param name="x">The first number.</param>
        /// <param name="y">The second number.</param>
        /// <param name="maxUlp">The number of discreet floating point values that are allowed between the two values.</param>
        /// <returns>0 if x equals y, -1 if x is less than y, 1 if x is greater than y.</returns>
        public static int CompareTo(double x, double y, int maxUlp)
        {
            if(Precision.Equals(x, y, maxUlp))
            {
                return 0;
            }

            return x < y
                ? -1
                : 1;
        }

        /// <summary>
        /// Compares two numbers.
        /// https://randomascii.wordpress.com/2012/02/25/comparing-floating-point-numbers-2012-edition/
        /// </summary>
        /// <param name="x">The first number.</param>
        /// <param name="y">The second number.</param>
        /// <returns><c>true</c> if the two values are equal, otherwise false.</returns>
        /// <remarks>
        /// This will check if the two numbers are adjacent or equal to each other. This is equivalent to
        /// calling Equals(x, y, 1).
        /// </remarks>
        public static bool Equals(float x, float y)
        {
            return Precision.Equals(x, y, 1);
        }

        /// <summary>
        /// Compares two numbers.
        /// https://randomascii.wordpress.com/2012/02/25/comparing-floating-point-numbers-2012-edition/
        /// </summary>
        /// <param name="x">The first number.</param>
        /// <param name="y">The second number.</param>
        /// <returns><c>true</c> if the two values are equal, otherwise false.</returns>
        /// <remarks>
        /// This will check if the two numbers are adjacent or equal to each other. This is equivalent to
        /// calling Equals(x, y, 1).
        /// </remarks>
        public static bool Equals(double x, double y)
        {
            return Precision.Equals(x, y, 1);
        }

        /// <summary>
        /// Compares two numbers given some amount of allowed error.
        /// </summary>
        /// <param name="x">The first number.</param>
        /// <param name="y">The second number.</param>
        /// <param name="epsilon">The amount of error allowed when checking for equality.</param>
        /// <returns><c>true</c> if the two values are equal, otherwise false.</returns>
        public static bool Equals(float x, float y, float epsilon)
        {
            if (epsilon <= 0)
            {
                throw new ArgumentOutOfRangeException("Epsilon must be greater than 0.");
            }

            // ReSharper disable once CompareOfFloatsByEqualityOperator
            return x == y || Math.Abs(x - y) <= epsilon;
        }

        /// <summary>
        /// Compares two numbers given some amount of allowed error.
        /// </summary>
        /// <param name="x">The first number.</param>
        /// <param name="y">The second number.</param>
        /// <param name="epsilon">The amount of error allowed when checking for equality.</param>
        /// <returns><c>true</c> if the two values are equal, otherwise false.</returns>
        public static bool Equals(double x, double y, double epsilon)
        {
            if (epsilon <= 0)
            {
                throw new ArgumentOutOfRangeException("Epsilon must be greater than 0.");
            }

            // ReSharper disable once CompareOfFloatsByEqualityOperator
            return x == y || Math.Abs(x - y) <= epsilon;
        }

        /// <summary>
        /// Compares two numbers given some amount of allowed distance.
        /// https://randomascii.wordpress.com/2012/02/25/comparing-floating-point-numbers-2012-edition/
        /// </summary>
        /// <param name="x">The first number.</param>
        /// <param name="y">The second number.</param>
        /// <param name="maxUlp">The number of discreet floating point values that are allowed between the two values.</param>
        /// <returns><c>true</c> if the two values are equal, otherwise false.</returns>
        public static bool Equals(float x, float y, int maxUlp)
        {
            if(maxUlp <= 0)
            {
                throw new ArgumentOutOfRangeException("Max Ulp must be greater than 0.");
            }

            FloatIntUnion xUnion = new FloatIntUnion
            {
                Float = x
            };
            FloatIntUnion yUnion = new FloatIntUnion
            {
                Float = y
            };

            // Convert to 2s complement if negative.
            uint xSignMask = xUnion.UInt >> Precision.FLOAT_SHIFT_BITS;
            uint ySignMask = yUnion.UInt >> Precision.FLOAT_SHIFT_BITS;

            uint xTemp = ((Precision.FLOAT_BIT_MASK - xUnion.UInt) & xSignMask);
            xUnion.UInt = xTemp | (xUnion.UInt & ~xSignMask);

            // Convert to 2s complement if negative.
            uint yTemp = ((Precision.FLOAT_BIT_MASK - yUnion.UInt) & ySignMask);
            yUnion.UInt = yTemp | (yUnion.UInt & ~ySignMask);

            // Return if the difference <= maxUlp
            return Math.Abs(xUnion.Int - yUnion.Int) <= maxUlp;
        }

        /// <summary>
        /// Compares two numbers given some amount of allowed distance.
        /// https://randomascii.wordpress.com/2012/02/25/comparing-floating-point-numbers-2012-edition/
        /// </summary>
        /// <param name="x">The first number.</param>
        /// <param name="y">The second number.</param>
        /// <param name="maxUlp">The number of discreet floating point values that are allowed between the two values.</param>
        /// <returns><c>true</c> if the two values are equal, otherwise false.</returns>
        public static bool Equals(double x, double y, int maxUlp)
        {
            if (maxUlp <= 0)
            {
                throw new ArgumentOutOfRangeException("Max Ulp must be greater than 0.");
            }

            DoubleLongUnion xUnion = new DoubleLongUnion
            {
                Double = x
            };
            DoubleLongUnion yUnion = new DoubleLongUnion
            {
                Double = y
            };

            // Convert to 2s complement if negative.
            ulong xSignMask = xUnion.ULong >> Precision.DOUBLE_SHIFT_BITS;
            ulong ySignMask = yUnion.ULong >> Precision.DOUBLE_SHIFT_BITS;

            ulong xTemp = ((Precision.DOUBLE_BIT_MASK - xUnion.ULong) & xSignMask);
            xUnion.ULong = xTemp | (xUnion.ULong & ~xSignMask);

            // Convert to 2s complement if negative.
            ulong yTemp = ((Precision.DOUBLE_BIT_MASK - yUnion.ULong) & ySignMask);
            yUnion.ULong = yTemp | (yUnion.ULong & ~ySignMask);

            // Return if the difference <= maxUlp
            return Math.Abs(xUnion.Long - yUnion.Long) <= maxUlp;
        }
    }
}