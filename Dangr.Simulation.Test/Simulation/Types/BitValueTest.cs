// -----------------------------------------------------------------------
//  <copyright file="BitValueTest.cs" company="DangerDan9631">
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
    public class BitValueTest
    {
        #region Bit Operations

        [TestMethod]
        public void Invert()
        {
            BitValue[] input = BitValueTest.GetInputs();
            BitValue[] expected =
            {
                BitValue.One,
                BitValue.Zero,
                BitValue.Floating,
                BitValue.Error
            };

            for (var i = 0; i < input.Length; i++)
            {
                BitValue actual = input[i].Invert();
                Assert.Validate.AreEqual(
                    actual,
                    expected[i],
                    $"Operation failed at index {i}.");
            }
        }

        [TestMethod]
        public void And_DontIgnoreFloating()
        {
            BitValue[] inputA = BitValueTest.GetInputs();
            BitValue[] inputB = BitValueTest.GetInputs();
            BitValue[,] expected =
            {
                {
                    BitValue.Zero,
                    BitValue.Zero,
                    BitValue.Error,
                    BitValue.Error
                },
                {
                    BitValue.Zero,
                    BitValue.One,
                    BitValue.Error,
                    BitValue.Error
                },
                {
                    BitValue.Error,
                    BitValue.Error,
                    BitValue.Error,
                    BitValue.Error
                },
                {
                    BitValue.Error,
                    BitValue.Error,
                    BitValue.Error,
                    BitValue.Error
                }
            };

            for (var i = 0; i < inputA.Length; i++)
            {
                for (var j = 0; j < inputB.Length; j++)
                {
                    BitValue actual = inputA[i].And(inputB[j], false);
                    Assert.Validate.AreEqual(
                        actual,
                        expected[i, j],
                        $"Operation failed at index {i},{j}.");
                }
            }
        }

        [TestMethod]
        public void And_IgnoreFloating()
        {
            BitValue[] inputA = BitValueTest.GetInputs();
            BitValue[] inputB = BitValueTest.GetInputs();
            BitValue[,] expected =
            {
                {
                    BitValue.Zero,
                    BitValue.Zero,
                    BitValue.Zero,
                    BitValue.Error
                },
                {
                    BitValue.Zero,
                    BitValue.One,
                    BitValue.One,
                    BitValue.Error
                },
                {
                    BitValue.Zero,
                    BitValue.One,
                    BitValue.Floating,
                    BitValue.Error
                },
                {
                    BitValue.Error,
                    BitValue.Error,
                    BitValue.Error,
                    BitValue.Error
                }
            };

            for (var i = 0; i < inputA.Length; i++)
            {
                for (var j = 0; j < inputB.Length; j++)
                {
                    BitValue actual = inputA[i].And(inputB[j], true);
                    Assert.Validate.AreEqual(
                        actual,
                        expected[i, j],
                        $"Operation failed at index {i},{j}.");
                }
            }
        }

        [TestMethod]
        public void Or_DontIgnoreFloating()
        {
            BitValue[] inputA = BitValueTest.GetInputs();
            BitValue[] inputB = BitValueTest.GetInputs();
            BitValue[,] expected =
            {
                {
                    BitValue.Zero,
                    BitValue.One,
                    BitValue.Error,
                    BitValue.Error
                },
                {
                    BitValue.One,
                    BitValue.One,
                    BitValue.Error,
                    BitValue.Error
                },
                {
                    BitValue.Error,
                    BitValue.Error,
                    BitValue.Error,
                    BitValue.Error
                },
                {
                    BitValue.Error,
                    BitValue.Error,
                    BitValue.Error,
                    BitValue.Error
                }
            };

            for (var i = 0; i < inputA.Length; i++)
            {
                for (var j = 0; j < inputB.Length; j++)
                {
                    BitValue actual = inputA[i].Or(inputB[j], false);
                    Assert.Validate.AreEqual(
                        actual,
                        expected[i, j],
                        $"Operation failed at index {i},{j}.");
                }
            }
        }

        [TestMethod]
        public void Or_IgnoreFloating()
        {
            BitValue[] inputA = BitValueTest.GetInputs();
            BitValue[] inputB = BitValueTest.GetInputs();
            BitValue[,] expected =
            {
                {
                    BitValue.Zero,
                    BitValue.One,
                    BitValue.Zero,
                    BitValue.Error
                },
                {
                    BitValue.One,
                    BitValue.One,
                    BitValue.One,
                    BitValue.Error
                },
                {
                    BitValue.Zero,
                    BitValue.One,
                    BitValue.Floating,
                    BitValue.Error
                },
                {
                    BitValue.Error,
                    BitValue.Error,
                    BitValue.Error,
                    BitValue.Error
                }
            };

            for (var i = 0; i < inputA.Length; i++)
            {
                for (var j = 0; j < inputB.Length; j++)
                {
                    BitValue actual = inputA[i].Or(inputB[j], true);
                    Assert.Validate.AreEqual(
                        actual,
                        expected[i, j],
                        $"Operation failed at index {i},{j}.");
                }
            }
        }

        [TestMethod]
        public void Xor_DontIgnoreFloating()
        {
            BitValue[] inputA = BitValueTest.GetInputs();
            BitValue[] inputB = BitValueTest.GetInputs();
            BitValue[,] expected =
            {
                {
                    BitValue.Zero,
                    BitValue.One,
                    BitValue.Error,
                    BitValue.Error
                },
                {
                    BitValue.One,
                    BitValue.Zero,
                    BitValue.Error,
                    BitValue.Error
                },
                {
                    BitValue.Error,
                    BitValue.Error,
                    BitValue.Error,
                    BitValue.Error
                },
                {
                    BitValue.Error,
                    BitValue.Error,
                    BitValue.Error,
                    BitValue.Error
                }
            };

            for (var i = 0; i < inputA.Length; i++)
            {
                for (var j = 0; j < inputB.Length; j++)
                {
                    BitValue actual = inputA[i].Xor(inputB[j], false);
                    Assert.Validate.AreEqual(
                        actual,
                        expected[i, j],
                        $"Operation failed at index {i},{j}.");
                }
            }
        }

        [TestMethod]
        public void Xor_IgnoreFloating()
        {
            BitValue[] inputA = BitValueTest.GetInputs();
            BitValue[] inputB = BitValueTest.GetInputs();
            BitValue[,] expected =
            {
                {
                    BitValue.Zero,
                    BitValue.One,
                    BitValue.Zero,
                    BitValue.Error
                },
                {
                    BitValue.One,
                    BitValue.Zero,
                    BitValue.One,
                    BitValue.Error
                },
                {
                    BitValue.Zero,
                    BitValue.One,
                    BitValue.Floating,
                    BitValue.Error
                },
                {
                    BitValue.Error,
                    BitValue.Error,
                    BitValue.Error,
                    BitValue.Error
                }
            };

            for (var i = 0; i < inputA.Length; i++)
            {
                for (var j = 0; j < inputB.Length; j++)
                {
                    BitValue actual = inputA[i].Xor(inputB[j], true);
                    Assert.Validate.AreEqual(
                        actual,
                        expected[i, j],
                        $"Operation failed at index {i},{j}.");
                }
            }
        }

        #endregion Bit Operations

        #region Invert Array Operation

        [TestMethod]
        public void InvertArray_NewArray()
        {
            BitValue[] inputA = BitValueTest.GetInputs();
            BitValue[] expected =
            {
                BitValue.One,
                BitValue.Zero,
                BitValue.Floating,
                BitValue.Error
            };

            var actual = new BitValue[4];
            inputA.Invert(ref actual);

            BitValueTest.ValidateArraysEqual(actual, expected);
        }

        [TestMethod]
        public void InvertArray_SetA()
        {
            BitValue[] inputA = BitValueTest.GetInputs();
            BitValue[] expected =
            {
                BitValue.One,
                BitValue.Zero,
                BitValue.Floating,
                BitValue.Error
            };

            inputA.Invert(ref inputA);

            BitValueTest.ValidateArraysEqual(inputA, expected);
        }

        [TestMethod]
        public void InvertArray_NullOutput()
        {
            BitValue[] inputA = BitValueTest.GetInputs();

            TestUtils.TestForError<ValidationFailedException>(
                () =>
                {
                    BitValue[] actual = null;
                    inputA.Invert(ref actual);
                },
                "Operation did not catch error.");
        }

        [TestMethod]
        public void InvertArray_DifferentSizeOutput()
        {
            BitValue[] inputA = BitValueTest.GetInputs();

            TestUtils.TestForError<ValidationFailedException>(
                () =>
                {
                    var actual = new BitValue[3];
                    inputA.Invert(ref actual);
                },
                "Operation did not catch error.");
        }

        #endregion Invert Array Operation

        #region And Array Operation

        [TestMethod]
        public void AndArray_NewArray()
        {
            BitValue[] inputA = BitValueTest.GetInputs();
            BitValue[] inputB = BitValueTest.GetInputs();
            BitValue[] expected =
            {
                BitValue.Zero,
                BitValue.One,
                BitValue.Error,
                BitValue.Error
            };

            var actual = new BitValue[4];
            inputA.And(inputB, ref actual, false);

            BitValueTest.ValidateArraysEqual(actual, expected);
        }

        [TestMethod]
        public void AndArray_SetA()
        {
            BitValue[] inputA = BitValueTest.GetInputs();
            BitValue[] inputB = BitValueTest.GetInputs();
            BitValue[] expected =
            {
                BitValue.Zero,
                BitValue.One,
                BitValue.Error,
                BitValue.Error
            };

            inputA.And(inputB, ref inputA, false);

            BitValueTest.ValidateArraysEqual(inputA, expected);
        }

        [TestMethod]
        public void AndArray_NullB()
        {
            BitValue[] inputA = BitValueTest.GetInputs();
            BitValue[] inputB = null;

            TestUtils.TestForError<ValidationFailedException>(
                () =>
                {
                    var actual = new BitValue[4];
                    inputA.And(inputB, ref actual, false);
                },
                "Operation did not catch error.");
        }

        [TestMethod]
        public void AndArray_NullOutput()
        {
            BitValue[] inputA = BitValueTest.GetInputs();
            BitValue[] inputB = BitValueTest.GetInputs();

            TestUtils.TestForError<ValidationFailedException>(
                () =>
                {
                    BitValue[] actual = null;
                    inputA.And(inputB, ref actual, false);
                },
                "Operation did not catch error.");
        }

        [TestMethod]
        public void AndArray_DifferentSizeInput()
        {
            BitValue[] inputA = BitValueTest.GetInputs();
            BitValue[] inputB =
            {
                BitValue.One
            };

            TestUtils.TestForError<ValidationFailedException>(
                () =>
                {
                    var actual = new BitValue[4];
                    inputA.And(inputB, ref actual, false);
                },
                "Operation did not catch error.");
        }

        [TestMethod]
        public void AndArray_DifferentSizeOutput()
        {
            BitValue[] inputA = BitValueTest.GetInputs();
            BitValue[] inputB = BitValueTest.GetInputs();

            TestUtils.TestForError<ValidationFailedException>(
                () =>
                {
                    var actual = new BitValue[3];
                    inputA.And(inputB, ref actual, false);
                },
                "Operation did not catch error.");
        }

        #endregion And Array Operation

        #region Or Array Operation

        [TestMethod]
        public void OrArray_NewArray()
        {
            BitValue[] inputA = BitValueTest.GetInputs();
            BitValue[] inputB = BitValueTest.GetInputs();
            BitValue[] expected =
            {
                BitValue.Zero,
                BitValue.One,
                BitValue.Error,
                BitValue.Error
            };

            var actual = new BitValue[4];
            inputA.Or(inputB, ref actual, false);

            BitValueTest.ValidateArraysEqual(actual, expected);
        }

        [TestMethod]
        public void OrArray_SetA()
        {
            BitValue[] inputA = BitValueTest.GetInputs();
            BitValue[] inputB = BitValueTest.GetInputs();
            BitValue[] expected =
            {
                BitValue.Zero,
                BitValue.One,
                BitValue.Error,
                BitValue.Error
            };

            inputA.Or(inputB, ref inputA, false);

            BitValueTest.ValidateArraysEqual(inputA, expected);
        }

        [TestMethod]
        public void OrArray_NullB()
        {
            BitValue[] inputA = BitValueTest.GetInputs();
            BitValue[] inputB = null;

            TestUtils.TestForError<ValidationFailedException>(
                () =>
                {
                    var actual = new BitValue[4];
                    inputA.Or(inputB, ref actual, false);
                },
                "Operation did not catch error.");
        }

        [TestMethod]
        public void OrArray_NullOutput()
        {
            BitValue[] inputA = BitValueTest.GetInputs();
            BitValue[] inputB = BitValueTest.GetInputs();

            TestUtils.TestForError<ValidationFailedException>(
                () =>
                {
                    BitValue[] actual = null;
                    inputA.Or(inputB, ref actual, false);
                },
                "Operation did not catch error.");
        }

        [TestMethod]
        public void OrArray_DifferentSizeInput()
        {
            BitValue[] inputA = BitValueTest.GetInputs();
            BitValue[] inputB =
            {
                BitValue.One
            };

            TestUtils.TestForError<ValidationFailedException>(
                () =>
                {
                    var actual = new BitValue[4];
                    inputA.Or(inputB, ref actual, false);
                },
                "Operation did not catch error.");
        }

        [TestMethod]
        public void OrArray_DifferentSizeOutput()
        {
            BitValue[] inputA = BitValueTest.GetInputs();
            BitValue[] inputB = BitValueTest.GetInputs();

            TestUtils.TestForError<ValidationFailedException>(
                () =>
                {
                    var actual = new BitValue[3];
                    inputA.Or(inputB, ref actual, false);
                },
                "Operation did not catch error.");
        }

        #endregion Or Array Operation

        #region Xor Array Operation

        [TestMethod]
        public void XorArray_NewArray()
        {
            BitValue[] inputA = BitValueTest.GetInputs();
            BitValue[] inputB = BitValueTest.GetInputs();
            BitValue[] expected =
            {
                BitValue.Zero,
                BitValue.Zero,
                BitValue.Error,
                BitValue.Error
            };

            var actual = new BitValue[4];
            inputA.Xor(inputB, ref actual, false);

            BitValueTest.ValidateArraysEqual(actual, expected);
        }

        [TestMethod]
        public void XorArray_SetA()
        {
            BitValue[] inputA = BitValueTest.GetInputs();
            BitValue[] inputB = BitValueTest.GetInputs();
            BitValue[] expected =
            {
                BitValue.Zero,
                BitValue.Zero,
                BitValue.Error,
                BitValue.Error
            };

            inputA.Xor(inputB, ref inputA, false);

            BitValueTest.ValidateArraysEqual(inputA, expected);
        }

        [TestMethod]
        public void XorArray_NullB()
        {
            BitValue[] inputA = BitValueTest.GetInputs();
            BitValue[] inputB = null;

            TestUtils.TestForError<ValidationFailedException>(
                () =>
                {
                    var actual = new BitValue[4];
                    inputA.Xor(inputB, ref actual, false);
                },
                "Operation did not catch error.");
        }

        [TestMethod]
        public void XorArray_NullOutput()
        {
            BitValue[] inputA = BitValueTest.GetInputs();
            BitValue[] inputB = BitValueTest.GetInputs();

            TestUtils.TestForError<ValidationFailedException>(
                () =>
                {
                    BitValue[] actual = null;
                    inputA.Xor(inputB, ref actual, false);
                },
                "Operation did not catch error.");
        }

        [TestMethod]
        public void XorArray_DifferentSizeInput()
        {
            BitValue[] inputA = BitValueTest.GetInputs();
            BitValue[] inputB =
            {
                BitValue.One
            };

            TestUtils.TestForError<ValidationFailedException>(
                () =>
                {
                    var actual = new BitValue[4];
                    inputA.Xor(inputB, ref actual, false);
                },
                "Operation did not catch error.");
        }

        [TestMethod]
        public void XorArray_DifferentSizeOutput()
        {
            BitValue[] inputA = BitValueTest.GetInputs();
            BitValue[] inputB = BitValueTest.GetInputs();

            TestUtils.TestForError<ValidationFailedException>(
                () =>
                {
                    var actual = new BitValue[3];
                    inputA.Xor(inputB, ref actual, false);
                },
                "Operation did not catch error.");
        }

        #endregion Xor Array Operation

        #region Increment Array Operation

        [TestMethod]
        public void IncrementArray_NewArray()
        {
            BitValue[] inputA = BitValueTest.GetInputs();
            BitValue[] expected =
            {
                BitValue.Error,
                BitValue.Error,
                BitValue.Error,
                BitValue.Error
            };

            var actual = new BitValue[4];
            bool overflow = inputA.Increment(ref actual);

            BitValueTest.ValidateArraysEqual(actual, expected);
            Assert.Validate.IsFalse(overflow, "Operation should not have overflowed.");
        }

        [TestMethod]
        public void IncrementArray_SetA()
        {
            BitValue[] inputA = BitValueTest.GetInputs();
            BitValue[] expected =
            {
                BitValue.Error,
                BitValue.Error,
                BitValue.Error,
                BitValue.Error
            };

            bool overflow = inputA.Increment(ref inputA);

            BitValueTest.ValidateArraysEqual(inputA, expected);
            Assert.Validate.IsFalse(overflow, "Operation should not have overflowed.");
        }

        [TestMethod]
        public void IncrementArray_Zero()
        {
            BitValue[] inputA =
            {
                BitValue.Zero,
                BitValue.Zero,
                BitValue.Zero,
                BitValue.Zero
            };
            BitValue[] expected =
            {
                BitValue.One,
                BitValue.Zero,
                BitValue.Zero,
                BitValue.Zero
            };

            var actual = new BitValue[4];
            bool overflow = inputA.Increment(ref actual);

            BitValueTest.ValidateArraysEqual(actual, expected);
            Assert.Validate.IsFalse(overflow, "Operation should not have overflowed.");
        }

        [TestMethod]
        public void IncrementArray_One()
        {
            BitValue[] inputA =
            {
                BitValue.One,
                BitValue.Zero,
                BitValue.Zero,
                BitValue.Zero
            };
            BitValue[] expected =
            {
                BitValue.Zero,
                BitValue.One,
                BitValue.Zero,
                BitValue.Zero
            };

            var actual = new BitValue[4];
            bool overflow = inputA.Increment(ref actual);

            BitValueTest.ValidateArraysEqual(actual, expected);
            Assert.Validate.IsFalse(overflow, "Operation should not have overflowed.");
        }

        [TestMethod]
        public void IncrementArray_Ten()
        {
            BitValue[] inputA =
            {
                BitValue.Zero,
                BitValue.One,
                BitValue.Zero,
                BitValue.One
            };
            BitValue[] expected =
            {
                BitValue.One,
                BitValue.One,
                BitValue.Zero,
                BitValue.One
            };

            var actual = new BitValue[4];
            bool overflow = inputA.Increment(ref actual);

            BitValueTest.ValidateArraysEqual(actual, expected);
            Assert.Validate.IsFalse(overflow, "Operation should not have overflowed.");
        }

        [TestMethod]
        public void IncrementArray_Fifteen()
        {
            BitValue[] inputA =
            {
                BitValue.One,
                BitValue.One,
                BitValue.One,
                BitValue.One
            };
            BitValue[] expected =
            {
                BitValue.Zero,
                BitValue.Zero,
                BitValue.Zero,
                BitValue.Zero
            };

            var actual = new BitValue[4];
            bool overflow = inputA.Increment(ref actual);

            BitValueTest.ValidateArraysEqual(actual, expected);
            Assert.Validate.IsTrue(overflow, "Operation should have overflowed.");
        }

        [TestMethod]
        public void IncrementArray_NullOutput()
        {
            BitValue[] inputA = BitValueTest.GetInputs();

            TestUtils.TestForError<ValidationFailedException>(
                () =>
                {
                    BitValue[] actual = null;
                    inputA.Increment(ref actual);
                },
                "Operation did not catch error.");
        }

        [TestMethod]
        public void IncrementArray_DifferentSizeOutput()
        {
            BitValue[] inputA = BitValueTest.GetInputs();

            TestUtils.TestForError<ValidationFailedException>(
                () =>
                {
                    var actual = new BitValue[3];
                    inputA.Increment(ref actual);
                },
                "Operation did not catch error.");
        }

        #endregion Increment Array Operation

        #region Negate Array Operation

        [TestMethod]
        public void NegateArray_NewArray()
        {
            BitValue[] inputA = BitValueTest.GetInputs();
            BitValue[] expected =
            {
                BitValue.Error,
                BitValue.Error,
                BitValue.Error,
                BitValue.Error
            };

            var actual = new BitValue[4];
            bool overflow = inputA.Negate(ref actual);

            BitValueTest.ValidateArraysEqual(actual, expected);
            Assert.Validate.IsFalse(overflow, "Operation should not have overflowed.");
        }

        [TestMethod]
        public void NegateArray_SetA()
        {
            BitValue[] inputA = BitValueTest.GetInputs();
            BitValue[] expected =
            {
                BitValue.Error,
                BitValue.Error,
                BitValue.Error,
                BitValue.Error
            };

            bool overflow = inputA.Negate(ref inputA);

            BitValueTest.ValidateArraysEqual(inputA, expected);
            Assert.Validate.IsFalse(overflow, "Operation should not have overflowed.");
        }

        [TestMethod]
        public void NegateArray_Zero()
        {
            BitValue[] inputA =
            {
                BitValue.Zero,
                BitValue.Zero,
                BitValue.Zero,
                BitValue.Zero
            };
            BitValue[] expected =
            {
                BitValue.Zero,
                BitValue.Zero,
                BitValue.Zero,
                BitValue.Zero
            };

            var actual = new BitValue[4];
            bool overflow = inputA.Negate(ref actual);

            BitValueTest.ValidateArraysEqual(actual, expected);
            Assert.Validate.IsFalse(overflow, "Operation should not have overflowed.");
        }

        [TestMethod]
        public void NegateArray_One()
        {
            BitValue[] inputA =
            {
                BitValue.One,
                BitValue.Zero,
                BitValue.Zero,
                BitValue.Zero
            };
            BitValue[] expected =
            {
                BitValue.One,
                BitValue.One,
                BitValue.One,
                BitValue.One
            };

            var actual = new BitValue[4];
            bool overflow = inputA.Negate(ref actual);

            BitValueTest.ValidateArraysEqual(actual, expected);
            Assert.Validate.IsFalse(overflow, "Operation should not have overflowed.");
        }

        [TestMethod]
        public void NegateArray_NegativeSix()
        {
            BitValue[] inputA =
            {
                BitValue.Zero,
                BitValue.One,
                BitValue.Zero,
                BitValue.One
            };
            BitValue[] expected =
            {
                BitValue.Zero,
                BitValue.One,
                BitValue.One,
                BitValue.Zero
            };

            var actual = new BitValue[4];
            bool overflow = inputA.Negate(ref actual);

            BitValueTest.ValidateArraysEqual(actual, expected);
            Assert.Validate.IsFalse(overflow, "Operation should not have overflowed.");
        }

        [TestMethod]
        public void NegateArray_NegativeOne()
        {
            BitValue[] inputA =
            {
                BitValue.One,
                BitValue.One,
                BitValue.One,
                BitValue.One
            };
            BitValue[] expected =
            {
                BitValue.One,
                BitValue.Zero,
                BitValue.Zero,
                BitValue.Zero
            };

            var actual = new BitValue[4];
            bool overflow = inputA.Negate(ref actual);

            BitValueTest.ValidateArraysEqual(actual, expected);
            Assert.Validate.IsFalse(overflow, "Operation should not have overflowed.");
        }

        [TestMethod]
        public void NegateArray_NegativeEight()
        {
            BitValue[] inputA =
            {
                BitValue.Zero,
                BitValue.Zero,
                BitValue.Zero,
                BitValue.One
            };
            BitValue[] expected =
            {
                BitValue.Zero,
                BitValue.Zero,
                BitValue.Zero,
                BitValue.One
            };

            var actual = new BitValue[4];
            bool overflow = inputA.Negate(ref actual);

            BitValueTest.ValidateArraysEqual(actual, expected);
            Assert.Validate.IsTrue(overflow, "Operation should have overflowed.");
        }

        [TestMethod]
        public void NegateArray_NullOutput()
        {
            BitValue[] inputA = BitValueTest.GetInputs();

            TestUtils.TestForError<ValidationFailedException>(
                () =>
                {
                    BitValue[] actual = null;
                    inputA.Negate(ref actual);
                },
                "Operation did not catch error.");
        }

        [TestMethod]
        public void NegateArray_DifferentSizeOutput()
        {
            BitValue[] inputA = BitValueTest.GetInputs();

            TestUtils.TestForError<ValidationFailedException>(
                () =>
                {
                    var actual = new BitValue[3];
                    inputA.Negate(ref actual);
                },
                "Operation did not catch error.");
        }

        #endregion Negate Array Operation

        #region Pull Array Operation

        [TestMethod]
        public void PullArray_NewArrayPullUp()
        {
            BitValue[] inputA = BitValueTest.GetInputs();
            BitValue[] expected =
            {
                BitValue.Zero,
                BitValue.One,
                BitValue.One,
                BitValue.Error
            };

            var actual = new BitValue[4];
            inputA.Pull(PullBehavior.PullUp, ref actual);

            BitValueTest.ValidateArraysEqual(actual, expected);
        }

        [TestMethod]
        public void PullArray_SetAPullDown()
        {
            BitValue[] inputA = BitValueTest.GetInputs();
            BitValue[] expected =
            {
                BitValue.Zero,
                BitValue.One,
                BitValue.Zero,
                BitValue.Error
            };

            inputA.Pull(PullBehavior.PullDown, ref inputA);

            BitValueTest.ValidateArraysEqual(inputA, expected);
        }

        [TestMethod]
        public void PUllArray_NewArrayUnchanged()
        {
            BitValue[] inputA = BitValueTest.GetInputs();
            BitValue[] expected =
            {
                BitValue.Zero,
                BitValue.One,
                BitValue.Floating,
                BitValue.Error
            };

            var actual = new BitValue[4];
            inputA.Pull(PullBehavior.Unchanged, ref actual);

            BitValueTest.ValidateArraysEqual(actual, expected);
        }

        [TestMethod]
        public void PullArray_NullOutput()
        {
            BitValue[] inputA = BitValueTest.GetInputs();

            TestUtils.TestForError<ValidationFailedException>(
                () =>
                {
                    BitValue[] actual = null;
                    inputA.Pull(PullBehavior.PullUp, ref actual);
                },
                "Operation did not catch error.");
        }

        [TestMethod]
        public void PullArray_DifferentSizeOutput()
        {
            BitValue[] inputA = BitValueTest.GetInputs();

            TestUtils.TestForError<ValidationFailedException>(
                () =>
                {
                    var actual = new BitValue[3];
                    inputA.Pull(PullBehavior.PullUp, ref actual);
                },
                "Operation did not catch error.");
        }

        #endregion Pull Array Operation

        #region IsEqual

        [TestMethod]
        public void IsEqual_Equal()
        {
            BitValue[] a =
            {
                BitValue.One,
                BitValue.Zero,
                BitValue.Floating,
                BitValue.Error
            };
            BitValue[] b =
            {
                BitValue.One,
                BitValue.Zero,
                BitValue.Floating,
                BitValue.Error
            };

            Assert.Validate.IsTrue(a.IsEqual(b), "Values were not equal.");
        }

        [TestMethod]
        public void IsEqual_NotEqual()
        {
            BitValue[] a =
            {
                BitValue.One,
                BitValue.Zero,
                BitValue.Floating,
                BitValue.Error
            };
            BitValue[] b =
            {
                BitValue.One,
                BitValue.One,
                BitValue.Floating,
                BitValue.Error
            };

            Assert.Validate.IsFalse(a.IsEqual(b), "Values should not be equal.");
        }

        [TestMethod]
        public void IsEqual_NotEqualDifferentLength()
        {
            BitValue[] a =
            {
                BitValue.One,
                BitValue.Zero,
                BitValue.Floating,
                BitValue.Error
            };
            BitValue[] b =
            {
                BitValue.One,
                BitValue.Zero,
                BitValue.Floating
            };

            Assert.Validate.IsFalse(a.IsEqual(b), "Values should not be equal.");
        }

        [TestMethod]
        public void IsEqual_NotEqualNull()
        {
            BitValue[] a =
            {
                BitValue.One,
                BitValue.Zero,
                BitValue.Floating,
                BitValue.Error
            };
            BitValue[] b = null;

            Assert.Validate.IsFalse(a.IsEqual(b), "Values should not be equal.");
        }

        #endregion IsEqual

        #region PrintString

        [TestMethod]
        public void DataValue_ToString()
        {
            BitValue[] value =
            {
                BitValue.Zero,
                BitValue.One,
                BitValue.Floating,
                BitValue.Error
            };

            var expected = "EX10";

            string actual = value.PrintString();

            Assert.Validate.AreEqual(expected, actual, "String values don't match.");
        }

        #endregion PrintString

        private static BitValue[] GetInputs()
        {
            var input = new BitValue[4];
            input[0] = BitValue.Zero;
            input[1] = BitValue.One;
            input[2] = BitValue.Floating;
            input[3] = BitValue.Error;

            return input;
        }

        private static void ValidateArraysEqual(BitValue[] a, BitValue[] b)
        {
            Assert.Validate.IsTrue(
                a.IsEqual(b),
                $"Expected value '{a.PrintString()}' is not equal to actual value '{b.PrintString()}'.");
        }
    }
}