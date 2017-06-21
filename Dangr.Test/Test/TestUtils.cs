﻿// -----------------------------------------------------------------------
//  <copyright file="TestUtils.cs" company="DangerDan9631">
//      Copyright (c) 2017 Dan Garvey. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/Dangerdan9631/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.Test
{
    using System;
    using Dangr.Diagnostics;

    /// <summary>
    /// Static class that provides utilities for running tests.
    /// </summary>
    public static class TestUtils
    {
        /// <summary>
        /// Runs a <paramref name="test" /> and validates that an error of the specified t ype was thrown.
        /// </summary>
        /// <typeparam name="T">The type of error to catch.</typeparam>
        /// <param name="test">The test to run.</param>
        /// <param name="message">
        /// The error message to display if the error is not caught.
        /// </param>
        public static void TestForError<T>(Action test, string message) where T : Exception
        {
            var caughtException = false;
            try
            {
                test();
            }
            catch (T e)
            {
                caughtException = true;
                Console.WriteLine($"Caught expected error: {e}");
            }
            catch (Exception e)
            {
                if (e.InnerException is T)
                {
                    caughtException = true;
                    Console.WriteLine($"Caught expected error: {e}");
                }
                else
                {
                    Console.WriteLine($"Caught unexpected error: {e}");
                    throw;
                }
            }

            Assert.Validate.IsTrue(caughtException, $"Did not catch expected exception {typeof(T).Name}. {message}");
        }
    }
}