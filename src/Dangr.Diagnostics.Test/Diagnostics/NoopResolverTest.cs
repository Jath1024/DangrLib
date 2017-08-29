// -----------------------------------------------------------------------
//  <copyright file="NoopResolverTest.cs" company="Phoenix Game Studios, LLC">
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
    public class NoopResolverTest : ConditionCheckerTestBase
    {
        public NoopResolverTest() : base(new NoopResolver())
        {
        }

        protected override Type GetExceptionType(TestExceptionType exceptionType)
        {
            return null;
        }

        protected override bool CheckShouldPass(TestExceptionType exceptionType)
        {
            return true;
        }
    }
}