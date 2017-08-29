// -----------------------------------------------------------------------
//  <copyright file="TestObject.cs" company="Phoenix Game Studios, LLC">
//      Copyright (c) 2017 Phoenix Game Studios, LLC. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/PhoenixGameStudios/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.Diagnostics
{
    using System;

    public enum TestObject
    {
        ObjectA,
        ObjectB,
        ComparableLess,
        ComparableMiddle,
        ComparableMore,
        Null
    }

    public static class TestObjectExtensions
    {
        private static readonly object ObjectA = new object();
        private static readonly object ObjectB = new object();

        public static object GetObject(this TestObject odr)
        {
            switch (odr)
            {
                case TestObject.ObjectA:
                    return TestObjectExtensions.ObjectA;
                case TestObject.ObjectB:
                    return TestObjectExtensions.ObjectB;
                case TestObject.ComparableLess:
                    return "A";
                case TestObject.ComparableMiddle:
                    return "M";
                case TestObject.ComparableMore:
                    return "Z";
                case TestObject.Null:
                    return null;
                default:
                    throw new ArgumentOutOfRangeException(nameof(odr), odr, null);
            }
        }
    }
}