// -----------------------------------------------------------------------
//  <copyright file="NoopResolver.cs" company="Phoenix Game Studios, LLC">
//      Copyright (c) 2017 Phoenix Game Studios, LLC. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/PhoenixGameStudios/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.Internal.Diagnostics
{
    using System;
    using System.Collections;
    using Dangr.Core.Diagnostics;
    using Dangr.Core.Util;

    /// <inheritdoc />
    /// <summary>
    /// Assert resolver that does nothing.
    /// </summary>
    internal class NoopResolver : IConditionChecker
    {
        public bool AreEqual(object a, object b, string message, params object[] args)
        {
            return true;
        }

        public bool AreEqual(float a, float b, float precision, string message, params object[] args)
        {
            return true;
        }

        public bool AreEqual(double a, double b, double precision, string message, params object[] args)
        {
            return true;
        }

        public bool AreEqual(object a, object b)
        {
            return this.AreEqual(a, b, null);
        }

        public bool AreEqual(float a, float b, float precision)
        {
            return this.AreEqual(a, b, precision, null);
        }

        public bool AreEqual(double a, double b, double precision)
        {
            return this.AreEqual(a, b, precision, null);
        }

        public bool AreNotEqual(object a, object b, string message, params object[] args)
        {
            return true;
        }

        public bool AreNotEqual(float a, float b, float precision, string message, params object[] args)
        {
            return true;
        }

        public bool AreNotEqual(double a, double b, double precision, string message, params object[] args)
        {
            return true;
        }

        public bool AreNotEqual(object a, object b)
        {
            return this.AreNotEqual(a, b, null);
        }

        public bool AreNotEqual(float a, float b, float precision)
        {
            return this.AreNotEqual(a, b, precision, null);
        }

        public bool AreNotEqual(double a, double b, double precision)
        {
            return this.AreNotEqual(a, b, precision, null);
        }

        public bool Comparison<T>(T a, CompareOperation operation, T b, string message, params object[] args)
            where T : IComparable
        {
            return true;
        }

        public bool Comparison(
            float a,
            CompareOperation operation,
            float b,
            float precision,
            string message,
            params object[] args)
        {
            return true;
        }

        public bool Comparison(
            double a,
            CompareOperation operation,
            double b,
            double precision,
            string message,
            params object[] args)
        {
            return true;
        }

        public bool Comparison<T>(T a, CompareOperation operation, T b) where T : IComparable
        {
            return this.Comparison(a, operation, b, null);
        }

        public bool Comparison(float a, CompareOperation operation, float b, float precision)
        {
            return this.Comparison(a, operation, b, precision, null);
        }

        public bool Comparison(double a, CompareOperation operation, double b, double precision)
        {
            return this.Comparison(a, operation, b, precision, null);
        }

        public bool Fail(string message, params object[] args)
        {
            return true;
        }

        public bool IsDisposed(ICheckedDisposable disposable, string name)
        {
            return true;
        }

        public bool IsEmpty(ICollection collection, string message, params object[] args)
        {
            return true;
        }

        public bool IsEmpty(ICollection collection)
        {
            return this.IsEmpty(collection, null);
        }

        public bool IsFalse(bool condition, string message, params object[] args)
        {
            return true;
        }

        public bool IsFalse(bool condition)
        {
            return this.IsFalse(condition, null);
        }

        public bool IsInRange<T>(T value, T min, T max, string message, params object[] args) where T : IComparable
        {
            return true;
        }

        public bool IsInRange(float value, float min, float max, float precision, string message, params object[] args)
        {
            return true;
        }

        public bool IsInRange(
            double value,
            double min,
            double max,
            double precision,
            string message,
            params object[] args)
        {
            return true;
        }

        public bool IsInRange<T>(T value, T min, T max) where T : IComparable
        {
            return this.IsInRange(value, min, max, null);
        }

        public bool IsInRange(float value, float min, float max, float precision)
        {
            return this.IsInRange(value, min, max, precision, null);
        }

        public bool IsInRange(double value, double min, double max, double precision)
        {
            return this.IsInRange(value, min, max, precision, null);
        }

        public bool IsNotDisposed(ICheckedDisposable disposable, string name)
        {
            return true;
        }

        public bool IsNotEmpty(ICollection collection, string message, params object[] args)
        {
            return true;
        }

        public bool IsNotEmpty(ICollection collection)
        {
            return this.IsNotEmpty(collection, null);
        }

        public bool IsNotNull(object value, string message, params object[] args)
        {
            return true;
        }

        public bool IsNotNull(object value)
        {
            return this.IsNotNull(value, null);
        }

        public bool IsNotNullOrEmpty(string value, string message, params object[] args)
        {
            return true;
        }

        public bool IsNotNullOrEmpty(string value)
        {
            return this.IsNotNullOrEmpty(value, null);
        }

        public bool IsNotNullOrWhiteSpace(string value, string message, params object[] args)
        {
            return true;
        }

        public bool IsNotNullOrWhiteSpace(string value)
        {
            return this.IsNotNullOrWhiteSpace(value, null);
        }

        public bool IsNotZero(int value, string message, params object[] args)
        {
            return true;
        }

        public bool IsNotZero(float value, float precision, string message, params object[] args)
        {
            return true;
        }

        public bool IsNotZero(double value, double precision, string message, params object[] args)
        {
            return true;
        }

        public bool IsNotZero(int value)
        {
            return this.IsNotZero(value, null);
        }

        public bool IsNotZero(float value, float precision)
        {
            return this.IsNotZero(value, precision, null);
        }

        public bool IsNotZero(double value, double precision)
        {
            return this.IsNotZero(value, precision, null);
        }

        public bool IsNull(object value, string message, params object[] args)
        {
            return true;
        }

        public bool IsNull(object value)
        {
            return this.IsNull(value, null);
        }

        public bool IsNullOrEmpty(string value, string message, params object[] args)
        {
            return true;
        }

        public bool IsNullOrEmpty(string value)
        {
            return this.IsNullOrEmpty(value, null);
        }

        public bool IsNullOrWhiteSpace(string value, string message, params object[] args)
        {
            return true;
        }

        public bool IsNullOrWhiteSpace(string value)
        {
            return this.IsNullOrWhiteSpace(value, null);
        }

        public bool IsTrue(bool condition, string message, params object[] args)
        {
            return true;
        }

        public bool IsTrue(bool condition)
        {
            return this.IsTrue(condition, null);
        }

        public bool IsType<T>(object obj, string message, params object[] args)
        {
            return true;
        }

        public bool IsType<T>(object obj)
        {
            return this.IsType<T>(obj, null);
        }

        public bool IsTypeOrNull<T>(object obj, string message, params object[] args)
        {
            return true;
        }

        public bool IsTypeOrNull<T>(object obj)
        {
            return this.IsTypeOrNull<T>(obj, null);
        }
    }
}