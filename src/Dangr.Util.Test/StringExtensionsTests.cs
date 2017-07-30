// -----------------------------------------------------------------------
//  <copyright file="StringExtensionsTests.cs" company="DangerDan9631">
//      Copyright (c) 2017 Dan Garvey. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/Dangerdan9631/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.Core.Util
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Assert = Dangr.Diagnostics.Assert;

    [TestClass]
    public class StringExtensionsTests
    {
        [TestMethod]
        public void TestCapsToPascalCase_EmptyString()
        {
            string testStringAllCaps = "";
            string testStringPascal = "";
            Assert.Validate.AreEqual(
                testStringAllCaps.CapsToPascalCase(),
                testStringPascal,
                "Did not correctly convert string to PascalCase.");
        }

        [TestMethod]
        public void TestCapsToPascalCase_SingleWord()
        {
            string testStringAllCaps = "HELLO";
            string testStringPascal = "Hello";
            Assert.Validate.AreEqual(
                testStringAllCaps.CapsToPascalCase(),
                testStringPascal,
                "Did not correctly convert string to PascalCase.");
        }

        [TestMethod]
        public void TestCapsToPascalCase_TwoWord()
        {
            string testStringAllCaps = "HELLO_THERE";
            string testStringPascal = "HelloThere";
            Assert.Validate.AreEqual(
                testStringAllCaps.CapsToPascalCase(),
                testStringPascal,
                "Did not correctly convert string to PascalCase.");
        }

        [TestMethod]
        public void TestCapsToPascalCase_ThreeWord()
        {
            string testStringAllCaps = "HELLO_THERE_YOU";
            string testStringPascal = "HelloThereYou";
            Assert.Validate.AreEqual(
                testStringAllCaps.CapsToPascalCase(),
                testStringPascal,
                "Did not correctly convert string to PascalCase.");
        }

        [TestMethod]
        public void TestCapsToPascalCase_TwoUnderscore()
        {
            string testStringAllCaps = "HELLO__THERE";
            string testStringPascal = "HelloThere";
            Assert.Validate.AreEqual(
                testStringAllCaps.CapsToPascalCase(),
                testStringPascal,
                "Did not correctly convert string to PascalCase.");
        }

        [TestMethod]
        public void TestCapsToPascalCase_StartWithUnderscore()
        {
            string testStringAllCaps = "_HELLO";
            string testStringPascal = "Hello";
            Assert.Validate.AreEqual(
                testStringAllCaps.CapsToPascalCase(),
                testStringPascal,
                "Did not correctly convert string to PascalCase.");
        }

        [TestMethod]
        public void TestCapsToPascalCase_StartWithTwoUnderscores()
        {
            string testStringAllCaps = "__HELLO";
            string testStringPascal = "Hello";
            Assert.Validate.AreEqual(
                testStringAllCaps.CapsToPascalCase(),
                testStringPascal,
                "Did not correctly convert string to PascalCase.");
        }

        [TestMethod]
        public void TestCapsToPascalCase_EndWithUnderscore()
        {
            string testStringAllCaps = "HELLO_";
            string testStringPascal = "Hello";
            Assert.Validate.AreEqual(
                testStringAllCaps.CapsToPascalCase(),
                testStringPascal,
                "Did not correctly convert string to PascalCase.");
        }

        [TestMethod]
        public void TestCapsToPascalCase_EndWithTwoUnderscores()
        {
            string testStringAllCaps = "HELLO__";
            string testStringPascal = "Hello";
            Assert.Validate.AreEqual(
                testStringAllCaps.CapsToPascalCase(),
                testStringPascal,
                "Did not correctly convert string to PascalCase.");
        }

        [TestMethod]
        public void TestEscapeVerbatimString()
        {
            string testStringUnescaped = "\"";
            string testStringEscaped = "\"\"";

            Assert.Validate.AreEqual(
                testStringUnescaped.EscapeVerbatimString(),
                testStringEscaped,
                "Did not correctly escape verbatim string.");
        }

        [TestMethod]
        public void TestEscapeQuoteString()
        {
            string testStringUnescaped = "\"";
            string testStringEscaped = "\\\"";

            Assert.Validate.AreEqual(
                testStringUnescaped.EscapeStringQuotes(),
                testStringEscaped,
                "Did not correctly escape quoted string.");
        }
    }
}