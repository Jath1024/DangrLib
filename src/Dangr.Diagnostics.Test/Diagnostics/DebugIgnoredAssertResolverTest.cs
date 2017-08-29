// -----------------------------------------------------------------------
//  <copyright file="DebugIgnoredAssertResolverTest.cs" company="Phoenix Game Studios, LLC">
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
    public class DebugIgnoredAssertResolverTest : ConditionCheckerTestBase
    {
        private static readonly DebugAssertResolver resolver = new DebugAssertResolver();

        public DebugIgnoredAssertResolverTest() : base(DebugIgnoredAssertResolverTest.resolver)
        {
            DebugIgnoredAssertResolverTest.resolver.ShouldForceDialogResult = true;
        }

        protected override Type GetExceptionType(TestExceptionType exceptionType)
        {
            switch (exceptionType)
            {
                case TestExceptionType.ValidationPassed:
                case TestExceptionType.ValidationFailed:
                case TestExceptionType.BoundsCheckFailed:
                case TestExceptionType.NullCheckFailed:
                case TestExceptionType.NotDisposedCheckFailed:
                    return null;
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