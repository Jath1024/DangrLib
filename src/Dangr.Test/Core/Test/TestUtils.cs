// -----------------------------------------------------------------------
//  <copyright file="TestUtils.cs" company="DangerDan9631">
//      Copyright (c) 2017 Dan Garvey. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/Dangerdan9631/DangrLib/blob/master/LICENSE for full license information.
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
        public static readonly BindingFlags PrivateInstanceFlags = BindingFlags.FlattenHierarchy | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;
        
        /// <summary>
        /// Binding flags to use with <see cref="Microsoft.VisualStudio.TestTools.UnitTesting.PrivateObject"/> instances to bind to private or public static members.
        /// </summary>
        public static readonly BindingFlags PrivateStaticFlags = BindingFlags.FlattenHierarchy | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static;

        /// <summary>
        /// Runs a <paramref name="test" /> and validates that an error of the specified t ype was thrown.
        /// </summary>
        /// <typeparam name="T">The type of error to catch.</typeparam>
        /// <param name="test">The test to run.</param>
        /// <param name="message">
        /// The error message to display if the error is not caught.
        /// </param>
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

            Assert.Validate.IsNotNull(caughtException, $"Did not catch expected exception {typeof(T).Name}. {message}");
            return caughtException;
        }
    }
}