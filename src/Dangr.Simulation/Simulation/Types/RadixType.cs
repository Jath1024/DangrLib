// -----------------------------------------------------------------------
//  <copyright file="RadixType.cs" company="DangerDan9631">
//      Copyright (c) 2017 Dan Garvey. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/Dangerdan9631/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.Simulation.Types
{
    using System;
    using System.Text;

    /// <summary>
    /// Enumerates possible radixes to use when displaying binary values.
    /// </summary>
    public enum RadixType
    {
        /// <summary>
        /// Interpret the binary values as a base 2 number.
        /// </summary>
        Binary,

        /// <summary>
        /// Interpret the binary values as a base 8 number.
        /// </summary>
        Octal,

        /// <summary>
        /// Interpret the binary values as a 2's complement signed base 10 number.
        /// </summary>
        SignedDecimal,

        /// <summary>
        /// Interpret the binary values as an unsigned base 10 number.
        /// </summary>
        UnsignedDecimal,

        /// <summary>
        /// Interpret the binary values as a base 16 number.
        /// </summary>
        Hex
    }

    /// <summary>
    /// Provides extension methods for the <see cref="RadixType" /> enumeration.
    /// </summary>
    public static class RadixTypeExtensions
    {
        private const int FLOATING = -1;
        private const int ERROR = -2;

        /// <summary>
        /// Converts the specified <see cref="DataValue" /> to a string using the given <see cref="RadixType" /> .
        /// </summary>
        /// <param name="radix">The <see cref="RadixType" /> .</param>
        /// <param name="value">The value.</param>
        /// <returns>
        /// A string of the <see cref="DataValue" /> interpreted using the given <see cref="RadixType" /> .
        /// </returns>
        public static string Convert(this RadixType radix, DataValue value)
        {
            switch (radix)
            {
                case RadixType.Binary:
                    return RadixTypeExtensions.ConvertToBinary(value);
                case RadixType.Octal:
                    return RadixTypeExtensions.ConvertToOctal(value);
                case RadixType.SignedDecimal:
                    return RadixTypeExtensions.ConvertToSignedDecimal(value);
                case RadixType.UnsignedDecimal:
                    return RadixTypeExtensions.ConvertToUnsignedDecimal(value);
                case RadixType.Hex:
                    return RadixTypeExtensions.ConvertToHex(value);
                default:
                    throw new NotImplementedException("Unknown Radix Type.");
            }
        }

        private static string ConvertToBinary(DataValue value)
        {
            return value.toString();
        }

        private static string ConvertToOctal(DataValue value)
        {
            var builder = new StringBuilder();

            var octalBit = 0;
            var octalTotal = 0;
            for (var i = 0; i < value.BitWidth; i++)
            {
                if (octalBit == 3)
                {
                    builder.Insert(0, octalTotal.ToString());
                    octalBit = 0;
                    octalTotal = 0;
                }

                switch (value[i])
                {
                    case BitValue.One:
                        octalTotal += 1 << octalBit++;
                        break;
                    case BitValue.Zero:
                        octalBit++;
                        break;
                    case BitValue.Error:
                        builder.Insert(0, "*");
                        i += 3 - octalBit;
                        octalBit = 0;
                        octalTotal = 0;
                        break;
                    case BitValue.Floating:
                        var hasError = false;
                        for (int f = octalBit; (f < 3) && (f + i < value.BitWidth); f++)
                        {
                            hasError = hasError || (value[f + i] == BitValue.Error);
                        }

                        builder.Insert(0, hasError ? "*" : "X");
                        i += 3 - octalBit;
                        octalBit = 0;
                        octalTotal = 0;
                        break;
                }
            }

            if (octalBit != 0)
            {
                builder.Insert(0, octalTotal.ToString());
            }

            builder.Insert(0, "8x");

            return builder.ToString();
        }

        private static string ConvertToSignedDecimal(DataValue value)
        {
            var isNegative = false;
            BitValue[] bitValue = value.CopyBitValues();
            if (bitValue[bitValue.Length - 1] == BitValue.One)
            {
                isNegative = true;
                bitValue.Negate(ref bitValue);
            }

            long total = RadixTypeExtensions.GetUnsignedTotal(bitValue);
            switch (total)
            {
                case RadixTypeExtensions.FLOATING:
                    return "X";
                case RadixTypeExtensions.ERROR:
                    return "*";
                default:
                    return isNegative ? $"-{total}" : total.ToString();
            }
        }

        private static string ConvertToUnsignedDecimal(DataValue value)
        {
            long total = RadixTypeExtensions.GetUnsignedTotal(value.CopyBitValues());
            switch (total)
            {
                case RadixTypeExtensions.FLOATING:
                    return "X";
                case RadixTypeExtensions.ERROR:
                    return "*";
                default:
                    return total.ToString();
            }
        }

        private static long GetUnsignedTotal(BitValue[] bitValue)
        {
            var total = 0;
            for (var i = 0; i < bitValue.Length; i++)
            {
                switch (bitValue[i])
                {
                    case BitValue.Zero:
                        break;
                    case BitValue.One:
                        total += 1 << i;
                        break;
                    case BitValue.Floating:
                        return RadixTypeExtensions.FLOATING;
                    case BitValue.Error:
                        return RadixTypeExtensions.ERROR;
                    default:
                        throw new NotImplementedException("Unknown BitValue.");
                }
            }

            return total;
        }

        private static string ConvertToHex(DataValue value)
        {
            var builder = new StringBuilder();

            var hexBit = 0;
            var hexTotal = 0;
            for (var i = 0; i < value.BitWidth; i++)
            {
                if (hexBit == 4)
                {
                    builder.Insert(0, RadixTypeExtensions.ToHexString(hexTotal));
                    hexBit = 0;
                    hexTotal = 0;
                }

                switch (value[i])
                {
                    case BitValue.One:
                        hexTotal += 1 << hexBit++;
                        break;
                    case BitValue.Zero:
                        hexBit++;
                        break;
                    case BitValue.Error:
                        builder.Insert(0, "*");
                        i += 4 - hexBit;
                        hexBit = 0;
                        hexTotal = 0;
                        break;
                    case BitValue.Floating:
                        var hasError = false;
                        for (int f = hexBit; (f < 4) && (f + i < value.BitWidth); f++)
                        {
                            hasError = hasError || (value[f + i] == BitValue.Error);
                        }

                        builder.Insert(0, hasError ? "*" : "X");
                        i += 4 - hexBit;
                        hexBit = 0;
                        hexTotal = 0;
                        break;
                }
            }

            if (hexBit != 0)
            {
                builder.Insert(0, RadixTypeExtensions.ToHexString(hexTotal));
            }

            builder.Insert(0, "0x");

            return builder.ToString();
        }

        private static string ToHexString(int val)
        {
            if (val < 10)
            {
                return val.ToString();
            }

            switch (val)
            {
                case 10:
                    return "A";
                case 11:
                    return "B";
                case 12:
                    return "C";
                case 13:
                    return "D";
                case 14:
                    return "E";
                case 15:
                    return "F";
                default:
                    throw new ArgumentException($"Invalid hex input value {val}.");
            }
        }
    }
}