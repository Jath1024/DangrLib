// -----------------------------------------------------------------------
//  <copyright file="IConditionChecker.cs" company="Phoenix Game Studios, LLC">
//      Copyright (c) 2017 Phoenix Game Studios, LLC. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/PhoenixGameStudios/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.Core.Diagnostics
{
    using System;
    using System.Collections;
    using Dangr.Core.Util;

    /// <summary>
    /// Provides methods that can be used to check if conditions are true.
    /// </summary>
    public interface IConditionChecker
    {
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
        bool AreEqual(object a, object b, string message, params object[] args);

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
        bool AreEqual(float a, float b, float precision, string message, params object[] args);

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
        bool AreEqual(double a, double b, double precision, string message, params object[] args);

        /// <summary>
        /// Show a message if the specified values are not equal.
        /// </summary>
        /// <param name="a">The first value to compare.</param>
        /// <param name="b">The second value to compare.</param>
        /// <returns>
        /// True only if the assert condition passed. Otherwise false.
        /// </returns>
        bool AreEqual(object a, object b);

        /// <summary>
        /// Show a message if the specified values are not equal.
        /// </summary>
        /// <param name="a">The first value to compare.</param>
        /// <param name="b">The second value to compare.</param>
        /// <param name="precision">The acceptable difference when comparing the floating point value.</param>
        /// <returns>
        /// True only if the assert condition passed. Otherwise false.
        /// </returns>
        bool AreEqual(float a, float b, float precision);

        /// <summary>
        /// Show a message if the specified values are not equal.
        /// </summary>
        /// <param name="a">The first value to compare.</param>
        /// <param name="b">The second value to compare.</param>
        /// <param name="precision">The acceptable difference when comparing the floating point value.</param>
        /// <returns>
        /// True only if the assert condition passed. Otherwise false.
        /// </returns>
        bool AreEqual(double a, double b, double precision);

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
        bool AreNotEqual(object a, object b, string message, params object[] args);

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
        bool AreNotEqual(float a, float b, float precision, string message, params object[] args);

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
        bool AreNotEqual(double a, double b, double precision, string message, params object[] args);

        /// <summary>
        /// Show a message if the specified values are equal.
        /// </summary>
        /// <param name="a">The first value to compare.</param>
        /// <param name="b">The second value to compare.</param>
        /// <returns>
        /// True only if the assert condition passed. Otherwise false.
        /// </returns>
        bool AreNotEqual(object a, object b);

        /// <summary>
        /// Show a message if the specified values are equal.
        /// </summary>
        /// <param name="a">The first value to compare.</param>
        /// <param name="b">The second value to compare.</param>
        /// <param name="precision">The acceptable difference when comparing the floating point value.</param>
        /// <returns>
        /// True only if the assert condition passed. Otherwise false.
        /// </returns>
        bool AreNotEqual(float a, float b, float precision);

        /// <summary>
        /// Show a message if the specified values are equal.
        /// </summary>
        /// <param name="a">The first value to compare.</param>
        /// <param name="b">The second value to compare.</param>
        /// <param name="precision">The acceptable difference when comparing the floating point value.</param>
        /// <returns>
        /// True only if the assert condition passed. Otherwise false.
        /// </returns>
        bool AreNotEqual(double a, double b, double precision);

        /// <summary>
        /// Show a message if the specified values do not compare in the specified way.
        /// </summary>
        /// <param name="a">The first value to compare.</param>
        /// <param name="operation">
        /// The <see cref="CompareOperation" /> to perform.
        /// </param>
        /// <param name="b">The second value to compare.</param>
        /// <param name="message">The message to show.</param>
        /// <param name="args">The arguments to the message to display.</param>
        /// <returns>
        /// True only if the assert condition passed. Otherwise false.
        /// </returns>
        bool Comparison<T>(T a, CompareOperation operation, T b, string message, params object[] args)
            where T : IComparable;

        /// <summary>
        /// Show a message if the specified values do not compare in the specified way.
        /// </summary>
        /// <param name="a">The first value to compare.</param>
        /// <param name="operation">
        /// The <see cref="CompareOperation" /> to perform.
        /// </param>
        /// <param name="b">The second value to compare.</param>
        /// <param name="precision">The acceptable difference when comparing the floating point value.</param>
        /// <param name="message">The message to show.</param>
        /// <param name="args">The arguments to the message to display.</param>
        /// <returns>
        /// True only if the assert condition passed. Otherwise false.
        /// </returns>
        bool Comparison(
            float a,
            CompareOperation operation,
            float b,
            float precision,
            string message,
            params object[] args);

        /// <summary>
        /// Show a message if the specified values do not compare in the specified way.
        /// </summary>
        /// <param name="a">The first value to compare.</param>
        /// <param name="operation">
        /// The <see cref="CompareOperation" /> to perform.
        /// </param>
        /// <param name="b">The second value to compare.</param>
        /// <param name="precision">The acceptable difference when comparing the floating point value.</param>
        /// <param name="message">The message to show.</param>
        /// <param name="args">The arguments to the message to display.</param>
        /// <returns>
        /// True only if the assert condition passed. Otherwise false.
        /// </returns>
        bool Comparison(
            double a,
            CompareOperation operation,
            double b,
            double precision,
            string message,
            params object[] args);

        /// <summary>
        /// Show a message if the specified values do not compare in the specified way.
        /// </summary>
        /// <param name="a">The first value to compare.</param>
        /// <param name="operation">
        /// The <see cref="CompareOperation" /> to perform.
        /// </param>
        /// <param name="b">The second value to compare.</param>
        /// <returns>
        /// True only if the assert condition passed. Otherwise false.
        /// </returns>
        bool Comparison<T>(T a, CompareOperation operation, T b) where T : IComparable;

        /// <summary>
        /// Show a message if the specified values do not compare in the specified way.
        /// </summary>
        /// <param name="a">The first value to compare.</param>
        /// <param name="operation">
        /// The <see cref="CompareOperation" /> to perform.
        /// </param>
        /// <param name="b">The second value to compare.</param>
        /// <param name="precision">The acceptable difference when comparing the floating point value.</param>
        /// <returns>
        /// True only if the assert condition passed. Otherwise false.
        /// </returns>
        bool Comparison(float a, CompareOperation operation, float b, float precision);

        /// <summary>
        /// Show a message if the specified values do not compare in the specified way.
        /// </summary>
        /// <param name="a">The first value to compare.</param>
        /// <param name="operation">
        /// The <see cref="CompareOperation" /> to perform.
        /// </param>
        /// <param name="b">The second value to compare.</param>
        /// <param name="precision">The acceptable difference when comparing the floating point value.</param>
        /// <returns>
        /// True only if the assert condition passed. Otherwise false.
        /// </returns>
        bool Comparison(double a, CompareOperation operation, double b, double precision);

        /// <summary>
        /// Unconditionally Show a message.
        /// </summary>
        /// <param name="message">The message to show.</param>
        /// <param name="args">The arguments to the message to display.</param>
        /// <returns>
        /// True only if the assert condition passed. Otherwise false.
        /// </returns>
        bool Fail(string message, params object[] args);

        /// <summary>
        /// Show a message if the specified <see cref="ICheckedDisposable" /> is not disposed.
        /// </summary>
        /// <param name="disposable">
        /// The <see cref="ICheckedDisposable" /> to check.
        /// </param>
        /// <param name="name">
        /// The name of the <see cref="ICheckedDisposable" /> .
        /// </param>
        /// <returns>
        /// True only if the assert condition passed. Otherwise false.
        /// </returns>
        bool IsDisposed(ICheckedDisposable disposable, string name);

        /// <summary>
        /// Show a message if the specified collection is not empty.
        /// </summary>
        /// <param name="collection">The collection to check.</param>
        /// <param name="message">The message to show.</param>
        /// <param name="args">The arguments to the message to display.</param>
        /// <returns>
        /// True only if the assert condition passed. Otherwise false.
        /// </returns>
        bool IsEmpty(ICollection collection, string message, params object[] args);

        /// <summary>
        /// Show a message if the specified collection is not empty.
        /// </summary>
        /// <param name="collection">The collection to check.</param>
        /// <returns>
        /// True only if the assert condition passed. Otherwise false.
        /// </returns>
        bool IsEmpty(ICollection collection);

        /// <summary>
        /// Show a message if the specified condition is true.
        /// </summary>
        /// <param name="condition">The condition to check.</param>
        /// <param name="message">The message to show.</param>
        /// <param name="args">The arguments to the message to display.</param>
        /// <returns>
        /// True only if the assert condition passed. Otherwise false.
        /// </returns>
        bool IsFalse(bool condition, string message, params object[] args);

        /// <summary>
        /// Show a message if the specified condition is true.
        /// </summary>
        /// <param name="condition">The condition to check.</param>
        /// <returns>
        /// True only if the assert condition passed. Otherwise false.
        /// </returns>
        bool IsFalse(bool condition);

        /// <summary>
        /// Show a message if the value is outside of the specified range.
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <param name="min">The minimum value of the range inclusive.</param>
        /// <param name="max">The maximum value of the range inclusive.</param>
        /// <param name="message">The message to show.</param>
        /// <param name="args">The arguments to the message to display.</param>
        /// <returns>
        /// True only if the assert condition passed. Otherwise false.
        /// </returns>
        bool IsInRange<T>(T value, T min, T max, string message, params object[] args) where T : IComparable;

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
        bool IsInRange(float value, float min, float max, float precision, string message, params object[] args);

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
        bool IsInRange(double value, double min, double max, double precision, string message, params object[] args);

        /// <summary>
        /// Show a message if the value is outside of the specified range.
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <param name="min">The minimum value of the range inclusive.</param>
        /// <param name="max">The maximum value of the range inclusive.</param>
        /// <returns>
        /// True only if the assert condition passed. Otherwise false.
        /// </returns>
        bool IsInRange<T>(T value, T min, T max) where T : IComparable;

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
        bool IsInRange(float value, float min, float max, float precision);

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
        bool IsInRange(double value, double min, double max, double precision);

        /// <summary>
        /// Show a message if the specified <see cref="ICheckedDisposable" /> is disposed.
        /// </summary>
        /// <param name="disposable">
        /// The <see cref="ICheckedDisposable" /> to check.
        /// </param>
        /// <param name="name">
        /// The name of the <see cref="ICheckedDisposable" /> .
        /// </param>
        /// <returns>
        /// True only if the assert condition passed. Otherwise false.
        /// </returns>
        bool IsNotDisposed(ICheckedDisposable disposable, string name);

        /// <summary>
        /// Show a message if the specified collection is empty.
        /// </summary>
        /// <param name="collection">The collection to check.</param>
        /// <param name="message">The message to show.</param>
        /// <param name="args">The arguments to the message to display.</param>
        /// <returns>
        /// True only if the assert condition passed. Otherwise false.
        /// </returns>
        bool IsNotEmpty(ICollection collection, string message, params object[] args);

        /// <summary>
        /// Show a message if the specified collection is empty.
        /// </summary>
        /// <param name="collection">The collection to check.</param>
        /// <returns>
        /// True only if the assert condition passed. Otherwise false.
        /// </returns>
        bool IsNotEmpty(ICollection collection);

        /// <summary>
        /// Show a message if the specified object is null.
        /// </summary>
        /// <param name="value">The object to check.</param>
        /// <param name="message">The message to show.</param>
        /// <param name="args">The arguments to the message to display.</param>
        /// <returns>
        /// True only if the assert condition passed. Otherwise false.
        /// </returns>
        bool IsNotNull(object value, string message, params object[] args);

        /// <summary>
        /// Show a message if the specified object is null.
        /// </summary>
        /// <param name="value">The object to check.</param>
        /// <returns>
        /// True only if the assert condition passed. Otherwise false.
        /// </returns>
        bool IsNotNull(object value);

        /// <summary>
        /// Show a message if the specified string is <c>null</c> or empty.
        /// </summary>
        /// <param name="value">The string to check.</param>
        /// <param name="message">The message to show.</param>
        /// <param name="args">The arguments to the message to display.</param>
        /// <returns>
        /// True only if the assert condition passed. Otherwise false.
        /// </returns>
        bool IsNotNullOrEmpty(string value, string message, params object[] args);

        /// <summary>
        /// Show a message if the specified string is <c>null</c> or empty.
        /// </summary>
        /// <param name="value">The string to check.</param>
        /// <returns>
        /// True only if the assert condition passed. Otherwise false.
        /// </returns>
        bool IsNotNullOrEmpty(string value);

        /// <summary>
        /// Show a message if the specified string is <c>null</c> or white space.
        /// </summary>
        /// <param name="value">The string to check.</param>
        /// <param name="message">The message to show.</param>
        /// <param name="args">The arguments to the message to display.</param>
        /// <returns>
        /// True only if the assert condition passed. Otherwise false.
        /// </returns>
        bool IsNotNullOrWhiteSpace(string value, string message, params object[] args);

        /// <summary>
        /// Show a message if the specified string is <c>null</c> or white space.
        /// </summary>
        /// <param name="value">The string to check.</param>
        /// <returns>
        /// True only if the assert condition passed. Otherwise false.
        /// </returns>
        bool IsNotNullOrWhiteSpace(string value);

        /// <summary>
        /// Show a message if the specified value is 0.
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <param name="message">The message to show.</param>
        /// <param name="args">The arguments to the message to display.</param>
        /// <returns>
        /// True only if the assert condition passed. Otherwise false.
        /// </returns>
        bool IsNotZero(int value, string message, params object[] args);

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
        bool IsNotZero(float value, float precision, string message, params object[] args);

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
        bool IsNotZero(double value, double precision, string message, params object[] args);

        /// <summary>
        /// Show a message if the specified value is 0.
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <returns>
        /// True only if the assert condition passed. Otherwise false.
        /// </returns>
        bool IsNotZero(int value);

        /// <summary>
        /// Show a message if the specified value is 0.
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <param name="precision">The acceptable difference when comparing the floating point value.</param>
        /// <returns>
        /// True only if the assert condition passed. Otherwise false.
        /// </returns>
        bool IsNotZero(float value, float precision);

        /// <summary>
        /// Show a message if the specified value is 0.
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <param name="precision">The acceptable difference when comparing the floating point value.</param>
        /// <returns>
        /// True only if the assert condition passed. Otherwise false.
        /// </returns>
        bool IsNotZero(double value, double precision);

        /// <summary>
        /// Show a message if the specified object is not null.
        /// </summary>
        /// <param name="value">The object to check.</param>
        /// <param name="message">The message to show.</param>
        /// <param name="args">The arguments to the message to display.</param>
        /// <returns>
        /// True only if the assert condition passed. Otherwise false.
        /// </returns>
        bool IsNull(object value, string message, params object[] args);

        /// <summary>
        /// Show a message if the specified object is not null.
        /// </summary>
        /// <param name="value">The object to check.</param>
        /// <returns>
        /// True only if the assert condition passed. Otherwise false.
        /// </returns>
        bool IsNull(object value);

        /// <summary>
        /// Show a message if the specified string is not <c>null</c> or empty.
        /// </summary>
        /// <param name="value">The string to check.</param>
        /// <param name="message">The message to show.</param>
        /// <param name="args">The arguments to the message to display.</param>
        /// <returns>
        /// True only if the assert condition passed. Otherwise false.
        /// </returns>
        bool IsNullOrEmpty(string value, string message, params object[] args);

        /// <summary>
        /// Show a message if the specified string is not <c>null</c> or empty.
        /// </summary>
        /// <param name="value">The string to check.</param>
        /// <returns>
        /// True only if the assert condition passed. Otherwise false.
        /// </returns>
        bool IsNullOrEmpty(string value);

        /// <summary>
        /// Show a message if the specified string is not <c>null</c> or white space.
        /// </summary>
        /// <param name="value">The string to check.</param>
        /// <param name="message">The message to show.</param>
        /// <param name="args">The arguments to the message to display.</param>
        /// <returns>
        /// True only if the assert condition passed. Otherwise false.
        /// </returns>
        bool IsNullOrWhiteSpace(string value, string message, params object[] args);

        /// <summary>
        /// Show a message if the specified string is not <c>null</c> or white space.
        /// </summary>
        /// <param name="value">The string to check.</param>
        /// <returns>
        /// True only if the assert condition passed. Otherwise false.
        /// </returns>
        bool IsNullOrWhiteSpace(string value);

        /// <summary>
        /// Show a message if the specified condition is false.
        /// </summary>
        /// <param name="condition">The condition to check.</param>
        /// <param name="message">The message to show.</param>
        /// <param name="args">The arguments to the message to display.</param>
        /// <returns>
        /// True only if the assert condition passed. Otherwise false.
        /// </returns>
        bool IsTrue(bool condition, string message, params object[] args);

        /// <summary>
        /// Show a message if the specified condition is false.
        /// </summary>
        /// <param name="condition">The condition to check.</param>
        /// <returns>
        /// True only if the assert condition passed. Otherwise false.
        /// </returns>
        bool IsTrue(bool condition);

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
        bool IsType<T>(object obj, string message, params object[] args);

        /// <summary>
        /// Show a message if the specified object is not of the specified type.
        /// </summary>
        /// <typeparam name="T">The type to check.</typeparam>
        /// <param name="obj">The object to check.</param>
        /// <returns>
        /// True only if the assert condition passed. Otherwise false.
        /// </returns>
        bool IsType<T>(object obj);

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
        bool IsTypeOrNull<T>(object obj, string message, params object[] args);

        /// <summary>
        /// Show a message if the specified object is not of the specified type or null.
        /// </summary>
        /// <typeparam name="T">The type to check.</typeparam>
        /// <param name="obj">The object to check.</param>
        /// <returns>
        /// True only if the assert condition passed. Otherwise false.
        /// </returns>
        bool IsTypeOrNull<T>(object obj);
    }
}