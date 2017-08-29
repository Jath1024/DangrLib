// -----------------------------------------------------------------------
//  <copyright file="DebugAssertResolverTest.cs" company="Phoenix Game Studios, LLC">
//      Copyright (c) 2017 Phoenix Game Studios, LLC. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/PhoenixGameStudios/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.Diagnostics
{
    using System;
    using System.Windows.Forms;
    using Dangr.Core.Diagnostics;
    using Dangr.Internal.Diagnostics;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class DebugAssertResolverTest : ConditionCheckerTestBase
    {
        private static readonly DebugAssertResolver resolver = new DebugAssertResolver();

        public DebugAssertResolverTest() : base(DebugAssertResolverTest.resolver)
        {
            DebugAssertResolverTest.resolver.ShouldForceDialogResult = true;
            DebugAssertResolverTest.resolver.ForcedDialogResult = DialogResult.Abort;
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
                    return typeof(AssertionFailedException);
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