// -----------------------------------------------------------------------
//  <copyright file="TestValues.cs" company="Phoenix Game Studios, LLC">
//      Copyright (c) 2017 Phoenix Game Studios, LLC. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/PhoenixGameStudios/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.Math
{
    public static class TestValues
    {
        public static readonly object OBJ_A = new object();
        public static readonly object OBJ_B = new object();

        public const int INT_0 = 0;
        public const int INT_10 = 10;
        public const int INT_15 = 15;

        public const float FLOAT_PRECISION_CHECK = 16.5457f;
        public const float FLOAT_PRECISION_CHECK_OPERAND = 3.8899982f;

        public const float FLOAT_PRECISION_CHECK_ERROR = TestValues.FLOAT_PRECISION_CHECK
                                                         * TestValues.FLOAT_PRECISION_CHECK_OPERAND
                                                         / TestValues.FLOAT_PRECISION_CHECK_OPERAND;

        public const float FLOAT_PRECISION_CHECK_0 =
            TestValues.FLOAT_PRECISION_CHECK_ERROR - TestValues.FLOAT_PRECISION_CHECK;

        public const float FLOAT_PRECISION = 0.00001f;
        public const int FLOAT_ULP = 5;

        public const float FLOAT_0 = 0f;
        public const float FLOAT_10 = 10f;
        public const float FLOAT_15 = 15f;

        public const double DOUBLE_PRECISION_CHECK = 16.5457;
        public const double DOUBLE_PRECISION_CHECK_OPERAND = 3.8899982;

        public const double DOUBLE_PRECISION_CHECK_ERROR = TestValues.DOUBLE_PRECISION_CHECK
                                                           * TestValues.DOUBLE_PRECISION_CHECK_OPERAND
                                                           / TestValues.DOUBLE_PRECISION_CHECK_OPERAND;

        public const double DOUBLE_PRECISION_CHECK_0 =
            TestValues.DOUBLE_PRECISION_CHECK_ERROR - TestValues.DOUBLE_PRECISION_CHECK;

        public const double DOUBLE_PRECISION = 0.000001;
        public const int DOUBLE_ULP = 5;

        public const double DOUBLE_0 = 0.0;
        public const double DOUBLE_10 = 10.0;
        public const double DOUBLE_15 = 15.0;

        public const string TEST_STRING = "Hello";
        public const string TEST_WHITESPACE_STRING = "\t\n\r \t";
    }
}