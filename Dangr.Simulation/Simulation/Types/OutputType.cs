// -----------------------------------------------------------------------
//  <copyright file="OutputType.cs" company="DangerDan9631">
//      Copyright (c) 2017 Dan Garvey. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/Dangerdan9631/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
//  <dateCreated>2017-06-14</dateCreated>
//  <dateModified>2017-06-20</dateModified>
//  <lastModifiedBy>Dan Garvey</lastModifiedBy>
// -----------------------------------------------------------------------

namespace Dangr.Simulation.Types
{
    using System;
    using Dangr.Diagnostics;

    /// <summary>
    /// Defines the different output types of components.
    /// </summary>
    public enum OutputType
    {
        /// <summary>
        /// Out put is <see cref="Dangr.Simulation.Types.BitValue.Zero" /> on low, and <see cref="Dangr.Simulation.Types.BitValue.One" /> on high.
        /// </summary>
        ZeroOne,

        /// <summary>
        /// Out put is <see cref="Dangr.Simulation.Types.BitValue.Zero" /> on low, and <see cref="Dangr.Simulation.Types.BitValue.Floating" /> on high.
        /// </summary>
        ZeroFloating,

        /// <summary>
        /// Out put is <see cref="Dangr.Simulation.Types.BitValue.Floating" /> on low, and <see cref="Dangr.Simulation.Types.BitValue.One" /> on high.
        /// </summary>
        FloatingOne
    }

    /// <summary>
    /// Provides extensions methods for the <see cref="OutputType" /> class.
    /// </summary>
    public static class OutputTypeExtensions
    {
        /// <summary>
        /// Converts the <see cref="BitValue" /> array using the <see cref="OutputType" /> .
        /// </summary>
        /// <param name="type">The <see cref="OutputType" /> .</param>
        /// <param name="value">The <see cref="BitValue" /> array.</param>
        /// <param name="output">
        /// The <see cref="BitValue" /> array to store the result in.
        /// </param>
        public static void Convert(this OutputType type, BitValue[] value, ref BitValue[] output)
        {
            Assert.Validate.IsNotNull(output, "Cannot perform operation. Output array is null");
            Assert.Validate.AreEqual(
                value.Length,
                output.Length,
                "Cannot perform operation. Output is not the correct length.");

            for (var i = 0; i < value.Length; i++)
            {
                output[i] = type.Convert(value[i]);
            }
        }

        /// <summary>
        /// Converts the <see cref="BitValue" /> using the <see cref="OutputType" /> .
        /// </summary>
        /// <param name="type">The <see cref="OutputType" /> .</param>
        /// <param name="value">The <see cref="BitValue" /> .</param>
        /// <returns>The converted <see cref="BitValue" /> .</returns>
        public static BitValue Convert(this OutputType type, BitValue value)
        {
            switch (type)
            {
                case OutputType.ZeroOne:
                    return OutputTypeExtensions.ConvertZeroOne(value);
                case OutputType.ZeroFloating:
                    return OutputTypeExtensions.ConvertZeroFloating(value);
                case OutputType.FloatingOne:
                    return OutputTypeExtensions.ConvertFloatingOne(value);
                default:
                    throw new NotImplementedException("Unknown Output Type.");
            }
        }

        private static BitValue ConvertZeroOne(BitValue input)
        {
            return input;
        }

        private static BitValue ConvertZeroFloating(BitValue input)
        {
            switch (input)
            {
                case BitValue.One:
                    return BitValue.Floating;
                    ;
                case BitValue.Zero:
                case BitValue.Error:
                case BitValue.Floating:
                default:
                    return input;
            }
        }

        private static BitValue ConvertFloatingOne(BitValue input)
        {
            switch (input)
            {
                case BitValue.Zero:
                    return BitValue.Floating;
                case BitValue.One:
                case BitValue.Error:
                case BitValue.Floating:
                default:
                    return input;
            }
        }
    }
}