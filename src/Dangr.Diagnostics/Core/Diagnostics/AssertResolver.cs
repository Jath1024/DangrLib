// -----------------------------------------------------------------------
//  <copyright file="AssertResolver.cs" company="Phoenix Game Studios, LLC">
//      Copyright (c) 2017 Phoenix Game Studios, LLC. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/PhoenixGameStudios/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.Core.Diagnostics
{
    using System;
    using System.Collections;
    using System.Text;
    using Dangr.Core.Math;
    using Dangr.Core.Util;
    using Dangr.Internal.Diagnostics;

    /// <summary>
    /// Contains various checks that can be used to verify application behavior.
    /// </summary>
    public abstract class AssertResolver : IConditionChecker
    {
        /// <summary>
        /// Show a message if the specified condition is false.
        /// </summary>
        /// <param name="condition">The condition to check.</param>
        /// <param name="message">The message to show.</param>
        /// <param name="args">The arguments to the message to display.</param>
        /// <returns>
        /// True only if the assert condition passed. Otherwise false.
        /// </returns>
        public bool IsTrue(bool condition, string message, params object[] args)
        {
            return this.Check(
                AssertType.IsTrue,
                condition,
                message,
                args,
                "IsTrue check failed.");
        }

        /// <summary>
        /// Show a message if the specified condition is false.
        /// </summary>
        /// <param name="condition">The condition to check.</param>
        /// <returns>
        /// True only if the assert condition passed. Otherwise false.
        /// </returns>
        public bool IsTrue(bool condition)
        {
            return this.IsTrue(condition, null);
        }

        /// <summary>
        /// Show a message if the specified condition is true.
        /// </summary>
        /// <param name="condition">The condition to check.</param>
        /// <param name="message">The message to show.</param>
        /// <param name="args">The arguments to the message to display.</param>
        /// <returns>
        /// True only if the assert condition passed. Otherwise false.
        /// </returns>
        public bool IsFalse(bool condition, string message, params object[] args)
        {
            return this.Check(
                AssertType.IsFalse,
                !condition,
                message,
                args,
                "IsFalse check failed.");
        }

        /// <summary>
        /// Show a message if the specified condition is true.
        /// </summary>
        /// <param name="condition">The condition to check.</param>
        /// <returns>
        /// True only if the assert condition passed. Otherwise false.
        /// </returns>
        public bool IsFalse(bool condition)
        {
            return this.IsFalse(condition, null);
        }

        /// <summary>
        /// Show a message if the specified values are not equal.
        /// </summary>
        /// <param name="a">The first value to compare.</param>
        /// <param name="b">The second value to compare.</param>
        /// <param name="message">The message to show.</param>
        /// <param name="args">The arguments to the message to display.</param>
        /// <returns>
        /// True only if the assert condition passed. Otherwise false.
        /// </returns>
        public bool AreEqual(object a, object b, string message, params object[] args)
        {
            bool bothNull = (a == null) && (b == null);

            return this.Check(
                AssertType.AreEqual,
                bothNull || ((a != null) && a.Equals(b)),
                message,
                args,
                "AreEqual check failed. [{0}, {1}]",
                a,
                b);
        }

        /// <summary>
        /// Show a message if the specified values are not equal.
        /// </summary>
        /// <param name="a">The first value to compare.</param>
        /// <param name="b">The second value to compare.</param>
        /// <param name="precision">The acceptable difference when comparing the floating point value.</param>
        /// <param name="message">The message to show.</param>
        /// <param name="args">The arguments to the message to display.</param>
        /// <returns>
        /// True only if the assert condition passed. Otherwise false.
        /// </returns>
        public bool AreEqual(float a, float b, float precision, string message, params object[] args)
        {
            return this.Check(
                AssertType.AreEqual,
                Precision.Equals(a, b, precision),
                message,
                args,
                "AreEqual check failed. [{0}, {1}]",
                a,
                b);
        }

        /// <summary>
        /// Show a message if the specified values are not equal.
        /// </summary>
        /// <param name="a">The first value to compare.</param>
        /// <param name="b">The second value to compare.</param>
        /// <param name="precision">The acceptable difference when comparing the floating point value.</param>
        /// <param name="message">The message to show.</param>
        /// <param name="args">The arguments to the message to display.</param>
        /// <returns>
        /// True only if the assert condition passed. Otherwise false.
        /// </returns>
        public bool AreEqual(double a, double b, double precision, string message, params object[] args)
        {
            return this.Check(
                AssertType.AreEqual,
                Precision.Equals(a, b, precision),
                message,
                args,
                "AreEqual check failed. [{0}, {1}]",
                a,
                b);
        }

        /// <summary>
        /// Show a message if the specified values are not equal.
        /// </summary>
        /// <param name="a">The first value to compare.</param>
        /// <param name="b">The second value to compare.</param>
        /// <returns>
        /// True only if the assert condition passed. Otherwise false.
        /// </returns>
        public bool AreEqual(object a, object b)
        {
            return this.AreEqual(a, b, null);
        }

        /// <summary>
        /// Show a message if the specified values are not equal.
        /// </summary>
        /// <param name="a">The first value to compare.</param>
        /// <param name="b">The second value to compare.</param>
        /// <param name="precision">The acceptable difference when comparing the floating point value.</param>
        /// <returns>
        /// True only if the assert condition passed. Otherwise false.
        /// </returns>
        public bool AreEqual(float a, float b, float precision)
        {
            return this.AreEqual(a, b, precision, null);
        }

        /// <summary>
        /// Show a message if the specified values are not equal.
        /// </summary>
        /// <param name="a">The first value to compare.</param>
        /// <param name="b">The second value to compare.</param>
        /// <param name="precision">The acceptable difference when comparing the floating point value.</param>
        /// <returns>
        /// True only if the assert condition passed. Otherwise false.
        /// </returns>
        public bool AreEqual(double a, double b, double precision)
        {
            return this.AreEqual(a, b, precision, null);
        }

        /// <summary>
        /// Show a message if the specified values are equal.
        /// </summary>
        /// <param name="a">The first value to compare.</param>
        /// <param name="b">The second value to compare.</param>
        /// <param name="message">The message to show.</param>
        /// <param name="args">The arguments to the message to display.</param>
        /// <returns>
        /// True only if the assert condition passed. Otherwise false.
        /// </returns>
        public bool AreNotEqual(object a, object b, string message, params object[] args)
        {
            bool bothNull = (a == null) && (b == null);

            return this.Check(
                AssertType.AreNotEqual,
                !bothNull && !((a != null) && a.Equals(b)),
                message,
                args,
                "AreNotEqual check failed. [{0}, {1}]",
                a,
                b);
        }

        /// <summary>
        /// Show a message if the specified values are equal.
        /// </summary>
        /// <param name="a">The first value to compare.</param>
        /// <param name="b">The second value to compare.</param>
        /// <param name="precision">The acceptable difference when comparing the floating point value.</param>
        /// <param name="message">The message to show.</param>
        /// <param name="args">The arguments to the message to display.</param>
        /// <returns>
        /// True only if the assert condition passed. Otherwise false.
        /// </returns>
        public bool AreNotEqual(float a, float b, float precision, string message, params object[] args)
        {
            return this.Check(
                AssertType.AreNotEqual,
                !Precision.Equals(a, b, precision),
                message,
                args,
                "AreNotEqual check failed. [{0}, {1}]",
                a,
                b);
        }

        /// <summary>
        /// Show a message if the specified values are equal.
        /// </summary>
        /// <param name="a">The first value to compare.</param>
        /// <param name="b">The second value to compare.</param>
        /// <param name="precision">The acceptable difference when comparing the floating point value.</param>
        /// <param name="message">The message to show.</param>
        /// <param name="args">The arguments to the message to display.</param>
        /// <returns>
        /// True only if the assert condition passed. Otherwise false.
        /// </returns>
        public bool AreNotEqual(double a, double b, double precision, string message, params object[] args)
        {
            return this.Check(
                AssertType.AreNotEqual,
                !Precision.Equals(a, b, precision),
                message,
                args,
                "AreNotEqual check failed. [{0}, {1}]",
                a,
                b);
        }

        /// <summary>
        /// Show a message if the specified values are equal.
        /// </summary>
        /// <param name="a">The first value to compare.</param>
        /// <param name="b">The second value to compare.</param>
        /// <returns>
        /// True only if the assert condition passed. Otherwise false.
        /// </returns>
        public bool AreNotEqual(object a, object b)
        {
            return this.AreNotEqual(a, b, null);
        }

        /// <summary>
        /// Show a message if the specified values are equal.
        /// </summary>
        /// <param name="a">The first value to compare.</param>
        /// <param name="b">The second value to compare.</param>
        /// <param name="precision">The acceptable difference when comparing the floating point value.</param>
        /// <returns>
        /// True only if the assert condition passed. Otherwise false.
        /// </returns>
        public bool AreNotEqual(float a, float b, float precision)
        {
            return this.AreNotEqual(a, b, precision, null);
        }

        /// <summary>
        /// Show a message if the specified values are equal.
        /// </summary>
        /// <param name="a">The first value to compare.</param>
        /// <param name="b">The second value to compare.</param>
        /// <param name="precision">The acceptable difference when comparing the floating point value.</param>
        /// <returns>
        /// True only if the assert condition passed. Otherwise false.
        /// </returns>
        public bool AreNotEqual(double a, double b, double precision)
        {
            return this.AreNotEqual(a, b, precision, null);
        }

        /// <summary>
        /// Show a message if the specified object is null.
        /// </summary>
        /// <param name="value">The object to check.</param>
        /// <param name="message">The message to show.</param>
        /// <param name="args">The arguments to the message to display.</param>
        /// <returns>
        /// True only if the assert condition passed. Otherwise false.
        /// </returns>
        public bool IsNotNull(object value, string message, params object[] args)
        {
            return this.Check(
                AssertType.IsNotNull,
                value != null,
                message,
                args,
                "IsNotNull check failed.");
        }

        /// <summary>
        /// Show a message if the specified object is null.
        /// </summary>
        /// <param name="value">The object to check.</param>
        /// <returns>
        /// True only if the assert condition passed. Otherwise false.
        /// </returns>
        public bool IsNotNull(object value)
        {
            return this.IsNotNull(value, null);
        }

        /// <summary>
        /// Show a message if the specified object is not null.
        /// </summary>
        /// <param name="value">The object to check.</param>
        /// <param name="message">The message to show.</param>
        /// <param name="args">The arguments to the message to display.</param>
        /// <returns>
        /// True only if the assert condition passed. Otherwise false.
        /// </returns>
        public bool IsNull(object value, string message, params object[] args)
        {
            return this.Check(
                AssertType.IsNull,
                value == null,
                message,
                args,
                "IsNull check failed. [{0}]",
                value);
        }

        /// <summary>
        /// Show a message if the specified object is not null.
        /// </summary>
        /// <param name="value">The object to check.</param>
        /// <returns>
        /// True only if the assert condition passed. Otherwise false.
        /// </returns>
        public bool IsNull(object value)
        {
            return this.IsNull(value, null);
        }

        /// <summary>
        /// Show a message if the specified string is <c>null</c> or empty.
        /// </summary>
        /// <param name="value">The string to check.</param>
        /// <param name="message">The message to show.</param>
        /// <param name="args">The arguments to the message to display.</param>
        /// <returns>
        /// True only if the assert condition passed. Otherwise false.
        /// </returns>
        public bool IsNotNullOrEmpty(string value, string message, params object[] args)
        {
            return this.Check(
                AssertType.IsNotNullOrEmpty,
                !string.IsNullOrEmpty(value),
                message,
                args,
                "IsNotNullOrEmpty check failed. [{0}]",
                value);
        }

        /// <summary>
        /// Show a message if the specified string is <c>null</c> or empty.
        /// </summary>
        /// <param name="value">The string to check.</param>
        /// <returns>
        /// True only if the assert condition passed. Otherwise false.
        /// </returns>
        public bool IsNotNullOrEmpty(string value)
        {
            return this.IsNotNullOrEmpty(value, null);
        }

        /// <summary>
        /// Show a message if the specified string is not <c>null</c> or white space.
        /// </summary>
        /// <param name="value">The string to check.</param>
        /// <param name="message">The message to show.</param>
        /// <param name="args">The arguments to the message to display.</param>
        /// <returns>
        /// True only if the assert condition passed. Otherwise false.
        /// </returns>
        public bool IsNullOrWhiteSpace(string value, string message, params object[] args)
        {
            return this.Check(
                AssertType.IsNullOrWhiteSpace,
                string.IsNullOrWhiteSpace(value),
                message,
                args,
                "IsNullOrWhiteSpace check failed. [{0}]",
                value);
        }

        /// <summary>
        /// Show a message if the specified string is not <c>null</c> or white space.
        /// </summary>
        /// <param name="value">The string to check.</param>
        /// <returns>
        /// True only if the assert condition passed. Otherwise false.
        /// </returns>
        public bool IsNullOrWhiteSpace(string value)
        {
            return this.IsNullOrWhiteSpace(value, null);
        }

        /// <summary>
        /// Show a message if the specified string is <c>null</c> or white space.
        /// </summary>
        /// <param name="value">The string to check.</param>
        /// <param name="message">The message to show.</param>
        /// <param name="args">The arguments to the message to display.</param>
        /// <returns>
        /// True only if the assert condition passed. Otherwise false.
        /// </returns>
        public bool IsNotNullOrWhiteSpace(string value, string message, params object[] args)
        {
            return this.Check(
                AssertType.IsNotNullOrWhiteSpace,
                !string.IsNullOrWhiteSpace(value),
                message,
                args,
                "IsNotNullOrWhiteSpace check failed. [{0}]",
                value);
        }

        /// <summary>
        /// Show a message if the specified string is <c>null</c> or white space.
        /// </summary>
        /// <param name="value">The string to check.</param>
        /// <returns>
        /// True only if the assert condition passed. Otherwise false.
        /// </returns>
        public bool IsNotNullOrWhiteSpace(string value)
        {
            return this.IsNotNullOrWhiteSpace(value, null);
        }

        /// <summary>
        /// Show a message if the specified string is not <c>null</c> or empty.
        /// </summary>
        /// <param name="value">The string to check.</param>
        /// <param name="message">The message to show.</param>
        /// <param name="args">The arguments to the message to display.</param>
        /// <returns>
        /// True only if the assert condition passed. Otherwise false.
        /// </returns>
        public bool IsNullOrEmpty(string value, string message, params object[] args)
        {
            return this.Check(
                AssertType.IsNullOrEmpty,
                string.IsNullOrEmpty(value),
                message,
                args,
                "IsNullOrEmpty check failed. [{0}]",
                value);
        }

        /// <summary>
        /// Show a message if the specified string is not <c>null</c> or empty.
        /// </summary>
        /// <param name="value">The string to check.</param>
        /// <returns>
        /// True only if the assert condition passed. Otherwise false.
        /// </returns>
        public bool IsNullOrEmpty(string value)
        {
            return this.IsNullOrEmpty(value, null);
        }

        /// <summary>
        /// Show a message if the specified collection is empty.
        /// </summary>
        /// <param name="collection">The collection to check.</param>
        /// <param name="message">The message to show.</param>
        /// <param name="args">The arguments to the message to display.</param>
        /// <returns>
        /// True only if the assert condition passed. Otherwise false.
        /// </returns>
        /// <exception cref="System.NullReferenceException"></exception>
        public bool IsNotEmpty(ICollection collection, string message, params object[] args)
        {
            if (collection == null)
            {
                throw new NullReferenceException();
            }

            return this.Check(
                AssertType.IsNotEmpty,
                collection.Count > 0,
                message,
                args,
                "IsNotEmpty check failed. [{0}]",
                collection);
        }

        /// <summary>
        /// Show a message if the specified collection is empty.
        /// </summary>
        /// <param name="collection">The collection to check.</param>
        /// <returns>
        /// True only if the assert condition passed. Otherwise false.
        /// </returns>
        public bool IsNotEmpty(ICollection collection)
        {
            return this.IsNotEmpty(collection, null);
        }

        /// <summary>
        /// Show a message if the specified collection is not empty.
        /// </summary>
        /// <param name="collection">The collection to check.</param>
        /// <param name="message">The message to show.</param>
        /// <param name="args">The arguments to the message to display.</param>
        /// <returns>
        /// True only if the assert condition passed. Otherwise false.
        /// </returns>
        /// <exception cref="System.NullReferenceException"></exception>
        public bool IsEmpty(ICollection collection, string message, params object[] args)
        {
            if (collection == null)
            {
                throw new NullReferenceException();
            }

            return this.Check(
                AssertType.IsEmpty,
                collection.Count == 0,
                message,
                args,
                "IsEmpty check failed. [{0}: size {1}]",
                collection,
                collection.Count);
        }

        /// <summary>
        /// Show a message if the specified collection is not empty.
        /// </summary>
        /// <param name="collection">The collection to check.</param>
        /// <returns>
        /// True only if the assert condition passed. Otherwise false.
        /// </returns>
        public bool IsEmpty(ICollection collection)
        {
            return this.IsEmpty(collection, null);
        }

        /// <summary>
        /// Show a message if the specified value is 0.
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <param name="message">The message to show.</param>
        /// <param name="args">The arguments to the message to display.</param>
        /// <returns>
        /// True only if the assert condition passed. Otherwise false.
        /// </returns>
        public bool IsNotZero(int value, string message, params object[] args)
        {
            return this.Check(
                AssertType.IsNotZero,
                value != 0,
                message,
                args,
                "IsNotZero check failed.");
        }

        /// <summary>
        /// Show a message if the specified value is 0.
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <param name="precision">The acceptable difference when comparing the floating point value.</param>
        /// <param name="message">The message to show.</param>
        /// <param name="args">The arguments to the message to display.</param>
        /// <returns>
        /// True only if the assert condition passed. Otherwise false.
        /// </returns>
        public bool IsNotZero(float value, float precision, string message, params object[] args)
        {
            return this.Check(
                AssertType.IsNotZero,
                !Precision.Equals(value, 0, precision),
                message,
                args,
                "IsNotZero check failed.");
        }

        /// <summary>
        /// Show a message if the specified value is 0.
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <param name="precision">The acceptable difference when comparing the floating point value.</param>
        /// <param name="message">The message to show.</param>
        /// <param name="args">The arguments to the message to display.</param>
        /// <returns>
        /// True only if the assert condition passed. Otherwise false.
        /// </returns>
        public bool IsNotZero(double value, double precision, string message, params object[] args)
        {
            return this.Check(
                AssertType.IsNotZero,
                !Precision.Equals(value, 0, precision),
                message,
                args,
                "IsNotZero check failed.");
        }

        /// <summary>
        /// Show a message if the specified value is 0.
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <returns>
        /// True only if the assert condition passed. Otherwise false.
        /// </returns>
        public bool IsNotZero(int value)
        {
            return this.IsNotZero(value, null);
        }

        /// <summary>
        /// Show a message if the specified value is 0.
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <param name="precision">The acceptable difference when comparing the floating point value.</param>
        /// <returns>
        /// True only if the assert condition passed. Otherwise false.
        /// </returns>
        public bool IsNotZero(float value, float precision)
        {
            return this.IsNotZero(value, precision, null);
        }

        /// <summary>
        /// Show a message if the specified value is 0.
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <param name="precision">The acceptable difference when comparing the floating point value.</param>
        /// <returns>
        /// True only if the assert condition passed. Otherwise false.
        /// </returns>
        public bool IsNotZero(double value, double precision)
        {
            return this.IsNotZero(value, precision, null);
        }

        /// <summary>
        /// Show a message if the value is outside of the specified range.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">The value to check.</param>
        /// <param name="min">The minimum value of the range inclusive.</param>
        /// <param name="max">The maximum value of the range inclusive.</param>
        /// <param name="message">The message to show.</param>
        /// <param name="args">The arguments to the message to display.</param>
        /// <returns>
        /// True only if the assert condition passed. Otherwise false.
        /// </returns>
        /// <exception cref="System.IndexOutOfRangeException"></exception>
        public bool IsInRange<T>(T value, T min, T max, string message, params object[] args)
            where T : IComparable
        {
            return this.Check(
                AssertType.IsInRange,
                CompareOperation.LessEqual.Compare(min, value)
                    && CompareOperation.LessEqual.Compare(value, max),
                message,
                args,
                "IsInRange check failed.[{0} ({1}:{2})]",
                value,
                min,
                max);
        }

        /// <summary>
        /// Show a message if the value is outside of the specified range.
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <param name="min">The minimum value of the range inclusive.</param>
        /// <param name="max">The maximum value of the range inclusive.</param>
        /// <param name="precision">The acceptable difference when comparing the floating point value.</param>
        /// <param name="message">The message to show.</param>
        /// <param name="args">The arguments to the message to display.</param>
        /// <returns>
        /// True only if the assert condition passed. Otherwise false.
        /// </returns>
        /// <exception cref="System.IndexOutOfRangeException"></exception>
        public bool IsInRange(float value, float min, float max, float precision, string message, params object[] args)
        {
            return this.Check(
                AssertType.IsInRange,
                CompareOperation.LessEqual.Compare(min, value, precision)
                    && CompareOperation.LessEqual.Compare(value, max, precision),
                message,
                args,
                "IsInRange check failed.[{0} ({1}:{2})]",
                value,
                min,
                max);
        }

        /// <summary>
        /// Show a message if the value is outside of the specified range.
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <param name="min">The minimum value of the range inclusive.</param>
        /// <param name="max">The maximum value of the range inclusive.</param>
        /// <param name="precision">The acceptable difference when comparing the floating point value.</param>
        /// <param name="message">The message to show.</param>
        /// <param name="args">The arguments to the message to display.</param>
        /// <returns>
        /// True only if the assert condition passed. Otherwise false.
        /// </returns>
        /// <exception cref="System.IndexOutOfRangeException"></exception>
        public bool IsInRange(
            double value,
            double min,
            double max,
            double precision,
            string message,
            params object[] args)
        {
            return this.Check(
                AssertType.IsInRange,
                CompareOperation.LessEqual.Compare(min, value, precision)
                    && CompareOperation.LessEqual.Compare(value, max, precision),
                message,
                args,
                "IsInRange check failed.[{0} ({1}:{2})]",
                value,
                min,
                max);
        }

        /// <summary>
        /// Show a message if the value is outside of the specified range.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">The value to check.</param>
        /// <param name="min">The minimum value of the range inclusive.</param>
        /// <param name="max">The maximum value of the range inclusive.</param>
        /// <returns>
        /// True only if the assert condition passed. Otherwise false.
        /// </returns>
        public bool IsInRange<T>(T value, T min, T max) where T : IComparable
        {
            return this.IsInRange(value, min, max, null);
        }

        /// <summary>
        /// Show a message if the value is outside of the specified range.
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <param name="min">The minimum value of the range inclusive.</param>
        /// <param name="max">The maximum value of the range inclusive.</param>
        /// <param name="precision">The acceptable difference when comparing the floating point value.</param>
        /// <returns>
        /// True only if the assert condition passed. Otherwise false.
        /// </returns>
        public bool IsInRange(float value, float min, float max, float precision)
        {
            return this.IsInRange(value, min, max, precision, null);
        }

        /// <summary>
        /// Show a message if the value is outside of the specified range.
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <param name="min">The minimum value of the range inclusive.</param>
        /// <param name="max">The maximum value of the range inclusive.</param>
        /// <param name="precision">The acceptable difference when comparing the floating point value.</param>
        /// <returns>
        /// True only if the assert condition passed. Otherwise false.
        /// </returns>
        public bool IsInRange(double value, double min, double max, double precision)
        {
            return this.IsInRange(value, min, max, precision, null);
        }

        /// <summary>
        /// Show a message if the specified values do not compare in the specified way.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="a">The first value to compare.</param>
        /// <param name="operation">The <see cref="CompareOperation" /> to perform.</param>
        /// <param name="b">The second value to compare.</param>
        /// <param name="message">The message to show.</param>
        /// <param name="args">The arguments to the message to display.</param>
        /// <returns>
        /// True only if the assert condition passed. Otherwise false.
        /// </returns>
        public bool Comparison<T>(T a, CompareOperation operation, T b, string message, params object[] args)
            where T : IComparable
        {
            return this.Check(
                AssertType.Compare,
                operation.Compare(a, b),
                message,
                args,
                "Compare check failed. [{0} {1} {2}]",
                a,
                operation.GetOperation(),
                b);
        }

        /// <summary>
        /// Show a message if the specified values do not compare in the specified way.
        /// </summary>
        /// <param name="a">The first value to compare.</param>
        /// <param name="operation">The <see cref="CompareOperation" /> to perform.</param>
        /// <param name="b">The second value to compare.</param>
        /// <param name="precision">The acceptable difference when comparing the floating point value.</param>
        /// <param name="message">The message to show.</param>
        /// <param name="args">The arguments to the message to display.</param>
        /// <returns>
        /// True only if the assert condition passed. Otherwise false.
        /// </returns>
        public bool Comparison(
            float a,
            CompareOperation operation,
            float b,
            float precision,
            string message,
            params object[] args)
        {
            return this.Check(
                AssertType.Compare,
                operation.Compare(a, b, precision),
                message,
                args,
                "Compare check failed. [{0} {1} {2}]",
                a,
                operation.GetOperation(),
                b);
        }

        /// <summary>
        /// Show a message if the specified values do not compare in the specified way.
        /// </summary>
        /// <param name="a">The first value to compare.</param>
        /// <param name="operation">The <see cref="CompareOperation" /> to perform.</param>
        /// <param name="b">The second value to compare.</param>
        /// <param name="precision">The acceptable difference when comparing the floating point value.</param>
        /// <param name="message">The message to show.</param>
        /// <param name="args">The arguments to the message to display.</param>
        /// <returns>
        /// True only if the assert condition passed. Otherwise false.
        /// </returns>
        public bool Comparison(
            double a,
            CompareOperation operation,
            double b,
            double precision,
            string message,
            params object[] args)
        {
            return this.Check(
                AssertType.Compare,
                operation.Compare(a, b, precision),
                message,
                args,
                "Compare check failed. [{0} {1} {2}]",
                a,
                operation.GetOperation(),
                b);
        }

        /// <summary>
        /// Show a message if the specified values do not compare in the specified way.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="a">The first value to compare.</param>
        /// <param name="operation">The <see cref="CompareOperation" /> to perform.</param>
        /// <param name="b">The second value to compare.</param>
        /// <returns>
        /// True only if the assert condition passed. Otherwise false.
        /// </returns>
        public bool Comparison<T>(T a, CompareOperation operation, T b) where T : IComparable
        {
            return this.Comparison(a, operation, b, null);
        }

        /// <summary>
        /// Show a message if the specified values do not compare in the specified way.
        /// </summary>
        /// <param name="a">The first value to compare.</param>
        /// <param name="operation">The <see cref="CompareOperation" /> to perform.</param>
        /// <param name="b">The second value to compare.</param>
        /// <param name="precision">The acceptable difference when comparing the floating point value.</param>
        /// <returns>
        /// True only if the assert condition passed. Otherwise false.
        /// </returns>
        public bool Comparison(float a, CompareOperation operation, float b, float precision)
        {
            return this.Comparison(a, operation, b, precision, null);
        }

        /// <summary>
        /// Show a message if the specified values do not compare in the specified way.
        /// </summary>
        /// <param name="a">The first value to compare.</param>
        /// <param name="operation">The <see cref="CompareOperation" /> to perform.</param>
        /// <param name="b">The second value to compare.</param>
        /// <param name="precision">The acceptable difference when comparing the floating point value.</param>
        /// <returns>
        /// True only if the assert condition passed. Otherwise false.
        /// </returns>
        public bool Comparison(double a, CompareOperation operation, double b, double precision)
        {
            return this.Comparison(a, operation, b, precision, null);
        }

        /// <summary>
        /// Show a message if the specified <see cref="ICheckedDisposable" /> is disposed.
        /// </summary>
        /// <param name="disposable">The <see cref="ICheckedDisposable" /> to check.</param>
        /// <param name="name">The name of the <see cref="ICheckedDisposable" /> .</param>
        /// <returns>
        /// True only if the assert condition passed. Otherwise false.
        /// </returns>
        /// <exception cref="System.NullReferenceException"></exception>
        public bool IsNotDisposed(ICheckedDisposable disposable, string name)
        {
            if (disposable == null)
            {
                throw new NullReferenceException();
            }

            return this.Check(
                AssertType.NotDisposed,
                !disposable.IsDisposed,
                name,
                null,
                "NotDisposed check failed. [{0}]",
                disposable);
        }

        /// <summary>
        /// Show a message if the specified <see cref="ICheckedDisposable" /> is not disposed.
        /// </summary>
        /// <param name="disposable">The <see cref="ICheckedDisposable" /> to check.</param>
        /// <param name="name">The name of the <see cref="ICheckedDisposable" /> .</param>
        /// <returns>
        /// True only if the assert condition passed. Otherwise false.
        /// </returns>
        /// <exception cref="System.NullReferenceException"></exception>
        public bool IsDisposed(ICheckedDisposable disposable, string name)
        {
            if (disposable == null)
            {
                throw new NullReferenceException();
            }

            return this.Check(
                AssertType.IsDisposed,
                disposable.IsDisposed,
                name,
                null,
                "IsDisposed check failed. [{0}]",
                disposable);
        }

        /// <summary>
        /// Show a message if the specified object is not of the specified type.
        /// </summary>
        /// <typeparam name="T">The type to check.</typeparam>
        /// <param name="obj">The object to check.</param>
        /// <param name="message">The message to show.</param>
        /// <param name="args">The arguments to the message to display.</param>
        /// <returns>
        /// True only if the assert condition passed. Otherwise false.
        /// </returns>
        public bool IsType<T>(object obj, string message, params object[] args)
        {
            return this.Check(
                AssertType.IsType,
                obj is T,
                message,
                args,
                "IsType check failed. [{0} expecting:{1}]",
                obj?.GetType().Name ?? "null",
                typeof(T).Name);
        }

        /// <summary>
        /// Show a message if the specified object is not of the specified type.
        /// </summary>
        /// <typeparam name="T">The type to check.</typeparam>
        /// <param name="obj">The object to check.</param>
        /// <returns>
        /// True only if the assert condition passed. Otherwise false.
        /// </returns>
        public bool IsType<T>(object obj)
        {
            return this.IsType<T>(obj, null);
        }

        /// <summary>
        /// Show a message if the specified object is not of the specified type or null.
        /// </summary>
        /// <typeparam name="T">The type to check.</typeparam>
        /// <param name="obj">The object to check.</param>
        /// <param name="message">The message to show.</param>
        /// <param name="args">The arguments to the message to display.</param>
        /// <returns>
        /// True only if the assert condition passed. Otherwise false.
        /// </returns>
        public bool IsTypeOrNull<T>(object obj, string message, params object[] args)
        {
            return this.Check(
                AssertType.IsTypeOrNull,
                (obj == null) || obj is T,
                message,
                args,
                "IsTypeOrNull check failed. [{0} expecting:{1}]",
                obj?.GetType().Name ?? "null",
                typeof(T).Name);
        }

        /// <summary>
        /// Show a message if the specified object is not of the specified type or null.
        /// </summary>
        /// <typeparam name="T">The type to check.</typeparam>
        /// <param name="obj">The object to check.</param>
        /// <returns>
        /// True only if the assert condition passed. Otherwise false.
        /// </returns>
        public bool IsTypeOrNull<T>(object obj)
        {
            return this.IsTypeOrNull<T>(obj, null);
        }

        /// <summary>
        /// Unconditionally Show a message.
        /// </summary>
        /// <param name="message">The message to show.</param>
        /// <param name="args">The arguments to the message to display.</param>
        /// <returns>
        /// True only if the assert condition passed. Otherwise false.
        /// </returns>
        public bool Fail(string message, params object[] args)
        {
            return this.Check(AssertType.Fail, false, message, args, "Fail");
        }

        /// <summary>
        /// Checks the specified type.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="condition">if set to <c>true</c> [condition].</param>
        /// <param name="message">The message.</param>
        /// <param name="messageArgs">The message arguments.</param>
        /// <param name="assertMessageFormat">The assert message format.</param>
        /// <param name="args">The arguments.</param>
        /// <returns></returns>
        private bool Check(
            AssertType type,
            bool condition,
            string message,
            object[] messageArgs,
            string assertMessageFormat,
            params object[] args)
        {
            if (!condition)
            {
                StringBuilder builder = new StringBuilder()
                    .AppendFormat(assertMessageFormat, args)
                    .AppendLine();

                if (message != null)
                {
                    builder.Append("\t");
                    if (messageArgs == null)
                    {
                        builder.Append(message);
                    }
                    else
                    {
                        builder.AppendFormat(message, messageArgs);
                    }

                    builder.AppendLine();
                }

                Exception ex = this.Failed(type, builder.ToString());
                if (ex != null)
                {
                    throw ex;
                }
            }

            return condition;
        }

        /// <summary>
        /// Shows a message and gets an exception that should be thrown.
        /// </summary>
        /// <param name="type">
        /// The type of assert condition that was evaluated.
        /// </param>
        /// <param name="message">The message that should be shown.</param>
        /// <returns>The exception that should be thrown, or null.</returns>
        protected abstract Exception Failed(AssertType type, string message);
    }
}