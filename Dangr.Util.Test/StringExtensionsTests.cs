// -----------------------------------------------------------------------
//  <copyright file="StringExtensionsTests.cs" company="DangerDan9631">
//      Copyright (c) 2017 Dan Garvey. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/Dangerdan9631/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
//  <dateCreated>2017-04-24</dateCreated>
//  <dateModified>2017-06-20</dateModified>
//  <lastModifiedBy>Dan Garvey</lastModifiedBy>
// -----------------------------------------------------------------------

namespace Dangr.Core.Util
{
    using Dangr.Util;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Assert = Dangr.Diagnostics.Assert;

    [TestClass]
    public class StringExtensionsTests
    {
        [TestMethod]
        public void TestCapsToPascalCase_EmptyString()
        {
            var testStringAllCaps = "";
            var testStringPascal = "";
            Assert.Validate.AreEqual(
                testStringAllCaps.CapsToPascalCase(),
                testStringPascal,
                "Did not correctly convert string to PascalCase.");
        }

        [TestMethod]
        public void TestCapsToPascalCase_SingleWord()
        {
            var testStringAllCaps = "HELLO";
            var testStringPascal = "Hello";
            Assert.Validate.AreEqual(
                testStringAllCaps.CapsToPascalCase(),
                testStringPascal,
                "Did not correctly convert string to PascalCase.");
        }

        [TestMethod]
        public void TestCapsToPascalCase_TwoWord()
        {
            var testStringAllCaps = "HELLO_THERE";
            var testStringPascal = "HelloThere";
            Assert.Validate.AreEqual(
                testStringAllCaps.CapsToPascalCase(),
                testStringPascal,
                "Did not correctly convert string to PascalCase.");
        }

        [TestMethod]
        public void TestCapsToPascalCase_ThreeWord()
        {
            var testStringAllCaps = "HELLO_THERE_YOU";
            var testStringPascal = "HelloThereYou";
            Assert.Validate.AreEqual(
                testStringAllCaps.CapsToPascalCase(),
                testStringPascal,
                "Did not correctly convert string to PascalCase.");
        }

        [TestMethod]
        public void TestCapsToPascalCase_TwoUnderscore()
        {
            var testStringAllCaps = "HELLO__THERE";
            var testStringPascal = "HelloThere";
            Assert.Validate.AreEqual(
                testStringAllCaps.CapsToPascalCase(),
                testStringPascal,
                "Did not correctly convert string to PascalCase.");
        }

        [TestMethod]
        public void TestCapsToPascalCase_StartWithUnderscore()
        {
            var testStringAllCaps = "_HELLO";
            var testStringPascal = "Hello";
            Assert.Validate.AreEqual(
                testStringAllCaps.CapsToPascalCase(),
                testStringPascal,
                "Did not correctly convert string to PascalCase.");
        }

        [TestMethod]
        public void TestCapsToPascalCase_StartWithTwoUnderscores()
        {
            var testStringAllCaps = "__HELLO";
            var testStringPascal = "Hello";
            Assert.Validate.AreEqual(
                testStringAllCaps.CapsToPascalCase(),
                testStringPascal,
                "Did not correctly convert string to PascalCase.");
        }

        [TestMethod]
        public void TestCapsToPascalCase_EndWithUnderscore()
        {
            var testStringAllCaps = "HELLO_";
            var testStringPascal = "Hello";
            Assert.Validate.AreEqual(
                testStringAllCaps.CapsToPascalCase(),
                testStringPascal,
                "Did not correctly convert string to PascalCase.");
        }

        [TestMethod]
        public void TestCapsToPascalCase_EndWithTwoUnderscores()
        {
            var testStringAllCaps = "HELLO__";
            var testStringPascal = "Hello";
            Assert.Validate.AreEqual(
                testStringAllCaps.CapsToPascalCase(),
                testStringPascal,
                "Did not correctly convert string to PascalCase.");
        }

        [TestMethod]
        public void TestEscapeVerbatimString()
        {
            var testStringUnescaped = "\"";
            var testStringEscaped = "\"\"";

            Assert.Validate.AreEqual(
                testStringUnescaped.EscapeVerbatimString(),
                testStringEscaped,
                "Did not correctly escape verbatim string.");
        }

        [TestMethod]
        public void TestEscapeQuoteString()
        {
            var testStringUnescaped = "\"";
            var testStringEscaped = "\\\"";

            Assert.Validate.AreEqual(
                testStringUnescaped.EscapeStringQuotes(),
                testStringEscaped,
                "Did not correctly escape quoted string.");
        }
    }
}