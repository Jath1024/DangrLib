// -----------------------------------------------------------------------
//  <copyright file="ArgumentResolverTest.cs" company="Phoenix Game Studios, LLC">
//      Copyright (c) 2017 Phoenix Game Studios, LLC. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/PhoenixGameStudios/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.Diagnostics
{
    using System;
    using Dangr.Internal.Diagnostics;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ArgumentResolverTest : ConditionCheckerTestBase
    {
        public ArgumentResolverTest() : base(new ArgumentResolver())
        {
        }

        protected override Type GetExceptionType(TestExceptionType exceptionType)
        {
            switch (exceptionType)
            {
                case TestExceptionType.ValidationPassed:
                    return null;
                case TestExceptionType.ValidationFailed:
                    return typeof(ArgumentException);
                case TestExceptionType.NullCheckFailed:
                    return typeof(ArgumentNullException);
                case TestExceptionType.BoundsCheckFailed:
                    return typeof(ArgumentOutOfRangeException);
                case TestExceptionType.NotDisposedCheckFailed:
                    return typeof(ObjectDisposedException);
                case TestExceptionType.NullReferenceException:
                    return typeof(NullReferenceException);
                case TestExceptionType.IndexOutOfBoundsException:
                    return typeof(IndexOutOfRangeException);
                default:
                    throw new ArgumentOutOfRangeException(nameof(exceptionType), exceptionType, null);
            }
        }

        protected override bool CheckShouldPass(TestExceptionType exceptionType)
        {
            return exceptionType == TestExceptionType.ValidationPassed;
        }
    }
}