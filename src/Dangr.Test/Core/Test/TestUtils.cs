// -----------------------------------------------------------------------
//  <copyright file="TestUtils.cs" company="Phoenix Game Studios, LLC">
//      Copyright (c) 2017 Phoenix Game Studios, LLC. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/PhoenixGameStudios/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.Core.Test
{
    using System;
    using System.Reflection;
    using Dangr.Core.Diagnostics;

    /// <summary>
    /// Static class that provides utilities for running tests.
    /// </summary>
    public static class TestUtils
    {
        /// <summary>
        /// Binding flags to use with <see cref="Microsoft.VisualStudio.TestTools.UnitTesting.PrivateObject"/> instances to bind to private or public instance members.
        /// </summary>
        public const BindingFlags PrivateInstanceFlags =
            BindingFlags.FlattenHierarchy | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;

        /// <summary>
        /// Binding flags to use with <see cref="Microsoft.VisualStudio.TestTools.UnitTesting.PrivateObject"/> instances to bind to private or public static members.
        /// </summary>
        public const BindingFlags PrivateStaticFlags =
            BindingFlags.FlattenHierarchy | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static;

        /// <summary>
        /// Runs a test and validates that an error of the specified type was thrown.
        /// </summary>
        /// <typeparam name="T">The type of error to catch.</typeparam>
        /// <param name="test">The test to run.</param>
        /// <returns>The caught exception.</returns>
        public static T TestForError<T>(Action test) where T : Exception
        {
            return TestUtils.TestForError<T>(test, string.Empty);
        }

        /// <summary>
        /// Runs a test and validates that an error of the specified type was thrown.
        /// </summary>
        /// <typeparam name="T">The type of error to catch.</typeparam>
        /// <param name="test">The test to run.</param>
        /// <param name="message">
        /// The error message to display if the error is not caught.
        /// </param>
        /// <returns>The caught exception.</returns>
        public static T TestForError<T>(Action test, string message) where T : Exception
        {
            T caughtException = null;
            try
            {
                test();
            }
            catch (T e)
            {
                caughtException = e;
                Console.WriteLine($"Caught expected error: {e}");
            }
            catch (Exception e)
            {
                if (e.InnerException is T)
                {
                    caughtException = (T) e;
                    Console.WriteLine($"Caught expected error: {e}");
                }
                else
                {
                    Console.WriteLine($"Caught unexpected error: {e}");
                    throw;
                }
            }

            Validate.Value.IsNotNull(caughtException, $"Did not catch expected exception {typeof(T).Name}. {message}");
            return caughtException;
        }

        /// <summary>
        /// Runs a test and validates that an error of the specified type was thrown.
        /// </summary>
        /// <param name="exceptionType">The type of error to catch.</param>
        /// <param name="test">The test to run.</param>
        /// <returns>The caught exception.</returns>
        public static Exception TestForError(Type exceptionType, Action test)
        {
            return TestUtils.TestForError(exceptionType, test, string.Empty);
        }

        /// <summary>
        /// Runs a test and validates that an error of the specified type was thrown.
        /// </summary>
        /// <param name="exceptionType">The type of error to catch.</param>
        /// <param name="test">The test to run.</param>
        /// <param name="message">
        /// The error message to display if the error is not caught.
        /// </param>
        /// <returns>The caught exception.</returns>
        public static Exception TestForError(Type exceptionType, Action test, string message)
        {
            Exception caughtException = null;
            try
            {
                test();
            }
            catch (Exception e)
            {
                if (exceptionType.IsInstanceOfType(e))
                {
                    caughtException = e;
                    Console.WriteLine($"Caught expected error: {e}");
                }
                else if (exceptionType.IsInstanceOfType(e.InnerException))
                {
                    caughtException = e.InnerException;
                    Console.WriteLine($"Caught expected error: {e}");
                }
                else
                {
                    Console.WriteLine($"Caught unexpected error: {e}");
                    throw;
                }
            }

            Validate.Value.IsNotNull(
                caughtException,
                $"Did not catch expected exception {exceptionType.Name}. {message}");
            return caughtException;
        }
    }
}