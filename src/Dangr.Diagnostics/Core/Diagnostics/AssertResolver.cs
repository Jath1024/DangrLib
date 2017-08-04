// -----------------------------------------------------------------------
//  <copyright file="AssertResolver.cs" company="DangerDan9631">
//      Copyright (c) 2017 Dan Garvey. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/Dangerdan9631/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.Core.Diagnostics
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using System.Text;
    using Dangr.Core.Logging;
    using Dangr.Core.Util;
    using Dangr.Internal.Diagnostics;

    /// <summary>
    /// Contains various checks that can be used to verify application behavior.
    /// </summary>
    public abstract class AssertResolver
    {
        private readonly HashSet<string> assertPaths;
        private readonly bool rememberAsserts;

        /// <summary>
        /// Initializes a new instance of the <see cref="AssertResolver" /> class.
        /// </summary>
        /// <param name="rememberAsserts">
        /// Indicates if specific asserts should be remembered and only shown once.
        /// </param>
        protected AssertResolver(bool rememberAsserts)
        {
            this.rememberAsserts = rememberAsserts;
            this.assertPaths = rememberAsserts ? new HashSet<string>() : null;
        }

        /// <summary>
        /// Show a <paramref name="message" /> if the specified <paramref name="condition" /> is false.
        /// </summary>
        /// <param name="condition">The condition to check.</param>
        /// <param name="message">The message to show.</param>
        /// <param name="logSource">
        /// The <see cref="ILogSource" /> used to log messages on failure.
        /// </param>
        /// <param name="filePath">
        /// The file path of the caller. (Do not use)
        /// </param>
        /// <param name="lineNumber">
        /// The line number of the caller. (Do not use)
        /// </param>
        /// <returns>
        /// True only if the assert <paramref name="condition" /> passed. Otherwise false.
        /// </returns>
        public bool IsTrue(
            bool condition,
            string message,
            ILogSource logSource = null,
            [CallerFilePath] string filePath = "",
            [CallerLineNumber] int lineNumber = 0)
        {
            return this.Check(
                AssertType.IsTrue,
                condition,
                message,
                logSource,
                filePath,
                lineNumber,
                "IsTrue check failed.");
        }

        /// <summary>
        /// Show a <paramref name="message" /> if the specified <paramref name="condition" /> is true.
        /// </summary>
        /// <param name="logSource">
        /// The <see cref="ILogSource" /> used to log messages on failure.
        /// </param>
        /// <param name="condition">The condition to check.</param>
        /// <param name="message">The message to show.</param>
        /// <param name="filePath">
        /// The file path of the caller. (Do not use)
        /// </param>
        /// <param name="lineNumber">
        /// The line number of the caller. (Do not use)
        /// </param>
        /// <returns>
        /// True only if the assert <paramref name="condition" /> passed. Otherwise false.
        /// </returns>
        public bool IsFalse(
            bool condition,
            string message,
            ILogSource logSource = null,
            [CallerFilePath] string filePath = "",
            [CallerLineNumber] int lineNumber = 0)
        {
            return this.Check(
                AssertType.IsFalse,
                !condition,
                message,
                logSource,
                filePath,
                lineNumber,
                "IsFalse check failed.");
        }

        /// <summary>
        /// Show a <paramref name="message" /> if the specified values are not equal.
        /// </summary>
        /// <param name="logSource">
        /// The <see cref="ILogSource" /> used to log messages on failure.
        /// </param>
        /// <param name="a">The first value to compare.</param>
        /// <param name="b">The second value to compare.</param>
        /// <param name="message">The message to show.</param>
        /// <param name="filePath">
        /// The file path of the caller. (Do not use)
        /// </param>
        /// <param name="lineNumber">
        /// The line number of the caller. (Do not use)
        /// </param>
        /// <returns>
        /// True only if the assert condition passed. Otherwise false.
        /// </returns>
        public bool AreEqual(
            object a,
            object b,
            string message,
            ILogSource logSource = null,
            [CallerFilePath] string filePath = "",
            [CallerLineNumber] int lineNumber = 0)
        {
            bool bothNull = (a == null) && (b == null);

            return this.Check(
                AssertType.AreEqual,
                bothNull || ((a != null) && a.Equals(b)),
                message,
                logSource,
                filePath,
                lineNumber,
                "AreEqual check failed. [{0}, {1}]",
                a,
                b);
        }

        /// <summary>
        /// Show a <paramref name="message" /> if the specified values are equal.
        /// </summary>
        /// <param name="logSource">
        /// The <see cref="ILogSource" /> used to log messages on failure.
        /// </param>
        /// <param name="a">The first value to compare.</param>
        /// <param name="b">The second value to compare.</param>
        /// <param name="message">The message to show.</param>
        /// <param name="filePath">
        /// The file path of the caller. (Do not use)
        /// </param>
        /// <param name="lineNumber">
        /// The line number of the caller. (Do not use)
        /// </param>
        /// <returns>
        /// True only if the assert condition passed. Otherwise false.
        /// </returns>
        public bool AreNotEqual(
            object a,
            object b,
            string message,
            ILogSource logSource = null,
            [CallerFilePath] string filePath = "",
            [CallerLineNumber] int lineNumber = 0)
        {
            bool bothNull = (a == null) && (b == null);

            return this.Check(
                AssertType.AreNotEqual,
                !bothNull && !((a != null) && a.Equals(b)),
                message,
                logSource,
                filePath,
                lineNumber,
                "AreNotEqual check failed. [{0}, {1}]",
                a,
                b);
        }

        /// <summary>
        /// Show a <paramref name="message" /> if the specified object is null.
        /// </summary>
        /// <param name="logSource">
        /// The <see cref="ILogSource" /> used to log messages on failure.
        /// </param>
        /// <param name="value">The object to check.</param>
        /// <param name="message">The message to show.</param>
        /// <param name="filePath">
        /// The file path of the caller. (Do not use)
        /// </param>
        /// <param name="lineNumber">
        /// The line number of the caller. (Do not use)
        /// </param>
        /// <returns>
        /// True only if the assert condition passed. Otherwise false.
        /// </returns>
        public bool IsNotNull(
            object value,
            string message,
            ILogSource logSource = null,
            [CallerFilePath] string filePath = "",
            [CallerLineNumber] int lineNumber = 0)
        {
            return this.Check(
                AssertType.IsNotNull,
                value != null,
                message,
                logSource,
                filePath,
                lineNumber,
                "IsNotNull check failed.");
        }

        /// <summary>
        /// Show a <paramref name="message" /> if the specified object is not null.
        /// </summary>
        /// <param name="logSource">
        /// The <see cref="ILogSource" /> used to log messages on failure.
        /// </param>
        /// <param name="value">The object to check.</param>
        /// <param name="message">The message to show.</param>
        /// <param name="filePath">
        /// The file path of the caller. (Do not use)
        /// </param>
        /// <param name="lineNumber">
        /// The line number of the caller. (Do not use)
        /// </param>
        /// <returns>
        /// True only if the assert condition passed. Otherwise false.
        /// </returns>
        public bool IsNull(
            object value,
            string message,
            ILogSource logSource = null,
            [CallerFilePath] string filePath = "",
            [CallerLineNumber] int lineNumber = 0)
        {
            return this.Check(
                AssertType.IsNull,
                value == null,
                message,
                logSource,
                filePath,
                lineNumber,
                "IsNull check failed. [{0}]",
                value);
        }

        /// <summary>
        /// Show a <paramref name="message" /> if the specified string is <c>null</c> or empty.
        /// </summary>
        /// <param name="logSource">
        /// The <see cref="ILogSource" /> used to log messages on failure.
        /// </param>
        /// <param name="value">The string to check.</param>
        /// <param name="message">The message to show.</param>
        /// <param name="filePath">
        /// The file path of the caller. (Do not use)
        /// </param>
        /// <param name="lineNumber">
        /// The line number of the caller. (Do not use)
        /// </param>
        /// <returns>
        /// True only if the assert condition passed. Otherwise false.
        /// </returns>
        public bool IsNotNullOrEmpty(
            string value,
            string message,
            ILogSource logSource = null,
            [CallerFilePath] string filePath = "",
            [CallerLineNumber] int lineNumber = 0)
        {
            return this.Check(
                AssertType.IsNotNullOrEmpty,
                !string.IsNullOrEmpty(value),
                message,
                logSource,
                filePath,
                lineNumber,
                "IsNotNullOrEmpty check failed. [{0}]",
                value);
        }

        /// <summary>
        /// Show a <paramref name="message" /> if the specified string is not <c>null</c> or white space.
        /// </summary>
        /// <param name="logSource">
        /// The <see cref="ILogSource" /> used to log messages on failure.
        /// </param>
        /// <param name="value">The string to check.</param>
        /// <param name="message">The message to show.</param>
        /// <param name="filePath">
        /// The file path of the caller. (Do not use)
        /// </param>
        /// <param name="lineNumber">
        /// The line number of the caller. (Do not use)
        /// </param>
        /// <returns>
        /// True only if the assert condition passed. Otherwise false.
        /// </returns>
        public bool IsNullOrWhiteSpace(
            string value,
            string message,
            ILogSource logSource = null,
            [CallerFilePath] string filePath = "",
            [CallerLineNumber] int lineNumber = 0)
        {
            return this.Check(
                AssertType.IsNullOrWhiteSpace,
                string.IsNullOrWhiteSpace(value),
                message,
                logSource,
                filePath,
                lineNumber,
                "IsNullOrWhiteSpace check failed. [{0}]",
                value);
        }

        /// <summary>
        /// Show a <paramref name="message" /> if the specified string is <c>null</c> or white space.
        /// </summary>
        /// <param name="logSource">
        /// The <see cref="ILogSource" /> used to log messages on failure.
        /// </param>
        /// <param name="value">The string to check.</param>
        /// <param name="message">The message to show.</param>
        /// <param name="filePath">
        /// The file path of the caller. (Do not use)
        /// </param>
        /// <param name="lineNumber">
        /// The line number of the caller. (Do not use)
        /// </param>
        /// <returns>
        /// True only if the assert condition passed. Otherwise false.
        /// </returns>
        public bool IsNotNullOrWhiteSpace(
            string value,
            string message,
            ILogSource logSource = null,
            [CallerFilePath] string filePath = "",
            [CallerLineNumber] int lineNumber = 0)
        {
            return this.Check(
                AssertType.IsNotNullOrWhiteSpace,
                !string.IsNullOrWhiteSpace(value),
                message,
                logSource,
                filePath,
                lineNumber,
                "IsNotNullOrWhiteSpace check failed. [{0}]",
                value);
        }

        /// <summary>
        /// Show a <paramref name="message" /> if the specified string is not <c>null</c> or empty.
        /// </summary>
        /// <param name="logSource">
        /// The <see cref="Dangr.Core.Logging.ILogSource" /> used to log messages on failure.
        /// </param>
        /// <param name="value">The string to check.</param>
        /// <param name="message">The message to show.</param>
        /// <param name="filePath">
        /// The file path of the caller. (Do not use)
        /// </param>
        /// <param name="lineNumber">
        /// The line number of the caller. (Do not use)
        /// </param>
        /// <returns>
        /// True only if the assert condition passed. Otherwise false.
        /// </returns>
        public bool IsNullOrEmpty(
            string value,
            string message,
            ILogSource logSource = null,
            [CallerFilePath] string filePath = "",
            [CallerLineNumber] int lineNumber = 0)
        {
            return this.Check(
                AssertType.IsNullOrEmpty,
                string.IsNullOrEmpty(value),
                message,
                logSource,
                filePath,
                lineNumber,
                "IsNullOrEmpty check failed. [{0}]",
                value);
        }

        /// <summary>
        /// Show a <paramref name="message" /> if the specified <paramref name="collection" /> is empty.
        /// </summary>
        /// <param name="logSource">
        /// The <see cref="ILogSource" /> used to log messages on failure.
        /// </param>
        /// <param name="collection">The collection to check.</param>
        /// <param name="message">The message to show.</param>
        /// <param name="filePath">
        /// The file path of the caller. (Do not use)
        /// </param>
        /// <param name="lineNumber">
        /// The line number of the caller. (Do not use)
        /// </param>
        /// <returns>
        /// True only if the assert condition passed. Otherwise false.
        /// </returns>
        public bool IsNotEmpty(
            ICollection collection,
            string message,
            ILogSource logSource = null,
            [CallerFilePath] string filePath = "",
            [CallerLineNumber] int lineNumber = 0)
        {
            return this.Check(
                AssertType.IsNotEmpty,
                collection.Count > 0,
                message,
                logSource,
                filePath,
                lineNumber,
                "IsNotEmpty check failed. [{0}]",
                collection);
        }

        /// <summary>
        /// Show a <paramref name="message" /> if the specified <paramref name="collection" /> is not empty.
        /// </summary>
        /// <param name="logSource">
        /// The <see cref="ILogSource" /> used to log messages on failure.
        /// </param>
        /// <param name="collection">The collection to check.</param>
        /// <param name="message">The message to show.</param>
        /// <param name="filePath">
        /// The file path of the caller. (Do not use)
        /// </param>
        /// <param name="lineNumber">
        /// The line number of the caller. (Do not use)
        /// </param>
        /// <returns>
        /// True only if the assert condition passed. Otherwise false.
        /// </returns>
        public bool IsEmpty(
            ICollection collection,
            string message,
            ILogSource logSource = null,
            [CallerFilePath] string filePath = "",
            [CallerLineNumber] int lineNumber = 0)
        {
            return this.Check(
                AssertType.IsEmpty,
                collection.Count == 0,
                message,
                logSource,
                filePath,
                lineNumber,
                "IsEmpty check failed. [{0}: size {1}]",
                collection,
                collection.Count);
        }

        /// <summary>
        /// Show a <paramref name="message" /> if the specified <paramref name="value" /> is 0.
        /// </summary>
        /// <param name="logSource">
        /// The <see cref="ILogSource" /> used to log messages on failure.
        /// </param>
        /// <param name="value">The value to check.</param>
        /// <param name="message">The message to show.</param>
        /// <param name="filePath">
        /// The file path of the caller. (Do not use)
        /// </param>
        /// <param name="lineNumber">
        /// The line number of the caller. (Do not use)
        /// </param>
        /// <returns>
        /// True only if the assert condition passed. Otherwise false.
        /// </returns>
        public bool IsNotZero(
            int value,
            string message,
            ILogSource logSource = null,
            [CallerFilePath] string filePath = "",
            [CallerLineNumber] int lineNumber = 0)
        {
            return this.Check(
                AssertType.IsNotZero,
                value != 0,
                message,
                logSource,
                filePath,
                lineNumber,
                "IsNotZero check failed.");
        }

        /// <summary>
        /// Show a <paramref name="message" /> if the specified <paramref name="value" /> is 0.
        /// </summary>
        /// <param name="logSource">
        /// The <see cref="ILogSource" /> used to log messages on failure.
        /// </param>
        /// <param name="value">The value to check.</param>
        /// <param name="message">The message to show.</param>
        /// <param name="filePath">
        /// The file path of the caller. (Do not use)
        /// </param>
        /// <param name="lineNumber">
        /// The line number of the caller. (Do not use)
        /// </param>
        /// <returns>
        /// True only if the assert condition passed. Otherwise false.
        /// </returns>
        public bool IsNotZero(
            float value,
            string message,
            ILogSource logSource = null,
            [CallerFilePath] string filePath = "",
            [CallerLineNumber] int lineNumber = 0)
        {
            return this.Check(
                AssertType.IsNotZero,
                Math.Abs(value) >= float.Epsilon,
                message,
                logSource,
                filePath,
                lineNumber,
                "IsNotZero check failed.");
        }

        /// <summary>
        /// Show a <paramref name="message" /> if the specified <paramref name="value" /> is 0.
        /// </summary>
        /// <param name="logSource">
        /// The <see cref="ILogSource" /> used to log messages on failure.
        /// </param>
        /// <param name="value">The value to check.</param>
        /// <param name="message">The message to show.</param>
        /// <param name="filePath">
        /// The file path of the caller. (Do not use)
        /// </param>
        /// <param name="lineNumber">
        /// The line number of the caller. (Do not use)
        /// </param>
        /// <returns>
        /// True only if the assert condition passed. Otherwise false.
        /// </returns>
        public bool IsNotZero(
            double value,
            string message,
            ILogSource logSource = null,
            [CallerFilePath] string filePath = "",
            [CallerLineNumber] int lineNumber = 0)
        {
            return this.Check(
                AssertType.IsNotZero,
                Math.Abs(value) >= double.Epsilon,
                message,
                logSource,
                filePath,
                lineNumber,
                "IsNotZero check failed.");
        }

        /// <summary>
        /// Show a <paramref name="message" /> if the <paramref name="value" /> is outside of the specified range.
        /// </summary>
        /// <param name="logSource">
        /// The <see cref="ILogSource" /> used to log messages on failure.
        /// </param>
        /// <param name="value">The value to check.</param>
        /// <param name="min">
        /// The minimum <paramref name="value" /> of the range inclusive.
        /// </param>
        /// <param name="max">
        /// The maximum <paramref name="value" /> of the range inclusive.
        /// </param>
        /// <param name="message">The message to show.</param>
        /// <param name="filePath">
        /// The file path of the caller. (Do not use)
        /// </param>
        /// <param name="lineNumber">
        /// The line number of the caller. (Do not use)
        /// </param>
        /// <returns>
        /// True only if the assert condition passed. Otherwise false.
        /// </returns>
        public bool IsInRange<T>(
            T value,
            T min,
            T max,
            string message,
            ILogSource logSource = null,
            [CallerFilePath] string filePath = "",
            [CallerLineNumber] int lineNumber = 0)
            where T : IComparable
        {
            return this.Check(
                AssertType.IsInRange,
                min.CompareTo(value) <= 0 && value.CompareTo(max) <= 0,
                message,
                logSource,
                filePath,
                lineNumber,
                "IsInRange check failed.[{0} ({1}:{2})]",
                value,
                min,
                max);
        }

        /// <summary>
        /// Show a <paramref name="message" /> if the specified values do not compare in the specified way.
        /// </summary>
        /// <param name="logSource">
        /// The <see cref="ILogSource" /> used to log messages on failure.
        /// </param>
        /// <param name="a">The first value to compare.</param>
        /// <param name="operation">
        /// The <see cref="CompareOperation" /> to perform.
        /// </param>
        /// <param name="b">The second value to compare.</param>
        /// <param name="message">The message to show.</param>
        /// <param name="filePath">
        /// The file path of the caller. (Do not use)
        /// </param>
        /// <param name="lineNumber">
        /// The line number of the caller. (Do not use)
        /// </param>
        /// <returns>
        /// True only if the assert condition passed. Otherwise false.
        /// </returns>
        public bool Compare<T>(
            T a,
            CompareOperation operation,
            T b,
            string message,
            ILogSource logSource = null,
            [CallerFilePath] string filePath = "",
            [CallerLineNumber] int lineNumber = 0)
            where T : IComparable
        {
            bool check = false;
            switch (operation)
            {
                case CompareOperation.Equal:
                    check = a.CompareTo(b) == 0;
                    break;

                case CompareOperation.Greater:
                    check = a.CompareTo(b) > 0;
                    break;

                case CompareOperation.GreaterEqual:
                    check = a.CompareTo(b) >= 0;
                    break;

                case CompareOperation.Less:
                    check = a.CompareTo(b) < 0;
                    break;

                case CompareOperation.LessEqual:
                    check = a.CompareTo(b) <= 0;
                    break;
            }

            return this.Check(
                AssertType.Compare,
                check,
                message,
                logSource,
                filePath,
                lineNumber,
                "Compare check failed. [{0} {1} {2}]",
                a,
                operation.GetOperation(),
                b);
        }

        /// <summary>
        /// Show a message if the specified <see cref="ICheckedDisposable" /> is disposed.
        /// </summary>
        /// <param name="disposable">
        /// The <see cref="ICheckedDisposable" /> to check.
        /// </param>
        /// <param name="name">
        /// The name of the <see cref="ICheckedDisposable" /> .
        /// </param>
        /// <param name="logSource">
        /// The <see cref="ILogSource" /> used to log messages on failure.
        /// </param>
        /// <param name="filePath">
        /// The file path of the caller. (Do not use)
        /// </param>
        /// <param name="lineNumber">
        /// The line number of the caller. (Do not use)
        /// </param>
        /// <returns>
        /// True only if the assert condition passed. Otherwise false.
        /// </returns>
        public bool NotDisposed(
            ICheckedDisposable disposable,
            string name,
            ILogSource logSource = null,
            [CallerFilePath] string filePath = "",
            [CallerLineNumber] int lineNumber = 0)
        {
            return this.Check(
                AssertType.NotDisposed,
                !disposable.IsDisposed,
                name,
                logSource,
                filePath,
                lineNumber,
                "NotDisposed check failed. [{0}]",
                disposable);
        }

        /// <summary>
        /// Show a <paramref name="message" /> if the specified object is not of the specified type.
        /// </summary>
        /// <typeparam name="T">The type to check.</typeparam>
        /// <param name="logSource">
        /// The <see cref="ILogSource" /> used to log messages on failure.
        /// </param>
        /// <param name="obj">The object to check.</param>
        /// <param name="message">The message to show.</param>
        /// <param name="filePath">
        /// The file path of the caller. (Do not use)
        /// </param>
        /// <param name="lineNumber">
        /// The line number of the caller. (Do not use)
        /// </param>
        /// <returns>
        /// True only if the assert condition passed. Otherwise false.
        /// </returns>
        public bool IsType<T>(
            object obj,
            string message,
            ILogSource logSource = null,
            [CallerFilePath] string filePath = "",
            [CallerLineNumber] int lineNumber = 0)
        {
            return this.Check(
                AssertType.IsType,
                obj is T,
                message,
                logSource,
                filePath,
                lineNumber,
                "IsType check failed. [{0} expecting:{1}]",
                obj?.GetType().Name ?? "null",
                typeof(T).Name);
        }

        /// <summary>
        /// Show a <paramref name="message" /> if the specified object is not of the specified type or null.
        /// </summary>
        /// <typeparam name="T">The type to check.</typeparam>
        /// <param name="logSource">
        /// The <see cref="ILogSource" /> used to log messages on failure.
        /// </param>
        /// <param name="obj">The object to check.</param>
        /// <param name="message">The message to show.</param>
        /// <param name="filePath">
        /// The file path of the caller. (Do not use)
        /// </param>
        /// <param name="lineNumber">
        /// The line number of the caller. (Do not use)
        /// </param>
        /// <returns>
        /// True only if the assert condition passed. Otherwise false.
        /// </returns>
        public bool IsTypeOrNull<T>(
            object obj,
            string message,
            ILogSource logSource = null,
            [CallerFilePath] string filePath = "",
            [CallerLineNumber] int lineNumber = 0)
        {
            return this.Check(
                AssertType.IsTypeOrNull,
                (obj == null) || obj is T,
                message,
                logSource,
                filePath,
                lineNumber,
                "IsTypeOrNull check failed. [{0} expecting:{1}]",
                obj?.GetType().Name ?? "null",
                typeof(T).Name);
        }

        /// <summary>
        /// Unconditionally Show a message.
        /// </summary>
        /// <param name="logSource">
        /// The <see cref="ILogSource" /> used to log messages on failure.
        /// </param>
        /// <param name="message">The message to show.</param>
        /// <param name="filePath">
        /// The file path of the caller. (Do not use)
        /// </param>
        /// <param name="lineNumber">
        /// The line number of the caller. (Do not use)
        /// </param>
        /// <returns>
        /// True only if the assert condition passed. Otherwise false.
        /// </returns>
        public bool Fail(
            string message,
            ILogSource logSource = null,
            [CallerFilePath] string filePath = "",
            [CallerLineNumber] int lineNumber = 0)
        {
            return this.Check(AssertType.Fail, false, message, logSource, filePath, lineNumber, "Fail");
        }

        /// <summary>
        /// Shows a <paramref name="message" /> and gets an exception that should be thrown.
        /// </summary>
        /// <param name="type">
        /// The type of assert condition that was evaluated.
        /// </param>
        /// <param name="message">The message that should be shown.</param>
        /// <param name="logSource">
        /// The <see cref="ILogSource" /> used to log messages on failure.
        /// </param>
        /// <param name="ex">
        /// Out param for an exception that should be thrown or null.
        /// </param>
        /// <returns>True if the assert should be remembered.</returns>
        protected abstract bool Failed(AssertType type, string message, ILogSource logSource, out Exception ex);

        private bool Check(
            AssertType type,
            bool condition,
            string message,
            ILogSource logSource,
            string filePath,
            int lineNumber,
            string assertMessageFormat,
            params object[] args)
        {
            if (this.rememberAsserts && this.assertPaths.Contains($"{filePath}?{lineNumber}"))
            {
                return condition;
            }

            if (!condition)
            {
                StringBuilder builder = new StringBuilder();
                builder.AppendFormat(assertMessageFormat, args);
                builder.AppendLine();
                builder.Append("\t");
                builder.AppendLine(message);
                builder.AppendFormat("\tat {0}({1}) : ", filePath, lineNumber);

                Exception ex;
                if (this.Failed(type, builder.ToString(), logSource, out ex) && this.rememberAsserts)
                {
                    this.assertPaths.Add($"{filePath}?{lineNumber}");
                }

                if (ex != null)
                {
                    throw ex;
                }
            }

            return condition;
        }
    }
}