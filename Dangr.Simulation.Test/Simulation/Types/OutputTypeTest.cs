// -----------------------------------------------------------------------
//  <copyright file="OutputTypeTest.cs" company="DangerDan9631">
//      Copyright (c) 2017 Dan Garvey. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/Dangerdan9631/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
//  <dateCreated>2017-06-14</dateCreated>
//  <dateModified>2017-06-20</dateModified>
//  <lastModifiedBy>Dan Garvey</lastModifiedBy>
// -----------------------------------------------------------------------

namespace Dangr.Simulation.Test.Simulation.Types
{
    using Dangr.Diagnostics;
    using Dangr.Simulation.Types;
    using Dangr.Test;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Assert = Dangr.Diagnostics.Assert;

    [TestClass]
    public class OutputTypeTest
    {
        [TestMethod]
        public void ZeroOne()
        {
            BitValue[] input =
            {
                BitValue.Zero,
                BitValue.One,
                BitValue.Floating,
                BitValue.Error
            };
            BitValue[] expected =
            {
                BitValue.Zero,
                BitValue.One,
                BitValue.Floating,
                BitValue.Error
            };

            var actual = new BitValue[4];
            OutputType.ZeroOne.Convert(input, ref actual);

            Assert.Validate.IsTrue(
                expected.IsEqual(actual),
                $"Expected value '{expected.PrintString()}' is not equal to actual value '{actual.PrintString()}'.");
        }

        [TestMethod]
        public void ZeroFloating()
        {
            BitValue[] input =
            {
                BitValue.Zero,
                BitValue.One,
                BitValue.Floating,
                BitValue.Error
            };
            BitValue[] expected =
            {
                BitValue.Zero,
                BitValue.Floating,
                BitValue.Floating,
                BitValue.Error
            };

            var actual = new BitValue[4];
            OutputType.ZeroFloating.Convert(input, ref actual);

            Assert.Validate.IsTrue(
                expected.IsEqual(actual),
                $"Expected value '{expected.PrintString()}' is not equal to actual value '{actual.PrintString()}'.");
        }

        [TestMethod]
        public void FloatingOne()
        {
            BitValue[] input =
            {
                BitValue.Zero,
                BitValue.One,
                BitValue.Floating,
                BitValue.Error
            };
            BitValue[] expected =
            {
                BitValue.Floating,
                BitValue.One,
                BitValue.Floating,
                BitValue.Error
            };

            var actual = new BitValue[4];
            OutputType.FloatingOne.Convert(input, ref actual);

            Assert.Validate.IsTrue(
                expected.IsEqual(actual),
                $"Expected value '{expected.PrintString()}' is not equal to actual value '{actual.PrintString()}'.");
        }

        [TestMethod]
        public void Convert_SetInput()
        {
            BitValue[] input =
            {
                BitValue.Zero,
                BitValue.One,
                BitValue.Floating,
                BitValue.Error
            };
            BitValue[] expected =
            {
                BitValue.Zero,
                BitValue.Floating,
                BitValue.Floating,
                BitValue.Error
            };

            OutputType.ZeroFloating.Convert(input, ref input);

            Assert.Validate.IsTrue(
                expected.IsEqual(input),
                $"Expected value '{expected.PrintString()}' is not equal to actual value '{input.PrintString()}'.");
        }

        [TestMethod]
        public void InvertArray_NullOutput()
        {
            BitValue[] input =
            {
                BitValue.Zero,
                BitValue.One,
                BitValue.Floating,
                BitValue.Error
            };

            TestUtils.TestForError<ValidationFailedException>(
                () =>
                {
                    BitValue[] actual = null;
                    OutputType.ZeroOne.Convert(input, ref actual);
                },
                "Operation did not catch error.");
        }

        [TestMethod]
        public void InvertArray_DifferentSizedOutput()
        {
            BitValue[] input =
            {
                BitValue.Zero,
                BitValue.One,
                BitValue.Floating,
                BitValue.Error
            };

            TestUtils.TestForError<ValidationFailedException>(
                () =>
                {
                    var actual = new BitValue[3];
                    OutputType.ZeroOne.Convert(input, ref actual);
                },
                "Operation did not catch error.");
        }
    }
}