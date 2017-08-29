// -----------------------------------------------------------------------
//  <copyright file="ValidateResolverTest.cs" company="Phoenix Game Studios, LLC">
//      Copyright (c) 2017 Phoenix Game Studios, LLC. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/PhoenixGameStudios/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.Diagnostics
{
    using System;
    using Dangr.Core.Diagnostics;
    using Dangr.Internal.Diagnostics;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ValidateResolverTest : ConditionCheckerTestBase
    {
        public ValidateResolverTest() : base(new ValidateResolver())
        {
        }

        protected override Type GetExceptionType(TestExceptionType exceptionType)
        {
            switch (exceptionType)
            {
                case TestExceptionType.ValidationPassed:
                    return null;
                case TestExceptionType.ValidationFailed:
                case TestExceptionType.BoundsCheckFailed:
                case TestExceptionType.NullCheckFailed:
                    return typeof(ValidationFailedException);
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