// -----------------------------------------------------------------------
//  <copyright file="MathHelper.cs" company="DangerDan9631">
//      Copyright (c) 2017 Dan Garvey. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/Dangerdan9631/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.Math
{
    /// <summary>
    ///     Contains common mathematical functions and constants.
    /// </summary>
    public static class MathHelper
    {
        /// <summary>
        ///     Defines the value of E.
        /// </summary>
        public const float E = 2.71828182845904523536f;

        /// <summary>
        ///     Defines the base-10 logarithm of E.
        /// </summary>
        public const float Log10E = 0.434294482f;

        /// <summary>
        ///     Defines the base-2 logarithm of E.
        /// </summary>
        public const float Log2E = 1.442695041f;

        /// <summary>
        ///     Defines the value of Pi.
        /// </summary>
        public const float Pi = 3.141592653589793238462643383279502884197169399f;

        /// <summary>
        ///     Defines the value of Pi divided by two.
        /// </summary>
        public const float PiOver2 = MathHelper.Pi/2;

        /// <summary>
        ///     Defines the value of Pi divided by three.
        /// </summary>
        public const float PiOver3 = MathHelper.Pi/3;

        /// <summary>
        ///     Definesthe value of  Pi divided by four.
        /// </summary>
        public const float PiOver4 = MathHelper.Pi/4;

        /// <summary>
        ///     Defines the value of Pi divided by six.
        /// </summary>
        public const float PiOver6 = MathHelper.Pi/6;

        /// <summary>
        ///     Defines the value of Pi multiplied by two.
        /// </summary>
        public const float TwoPi = 2*MathHelper.Pi;

        /// <summary>
        ///     Defines the value of Pi multiplied by 3 and divided by two.
        /// </summary>
        public const float ThreePiOver2 = 3*MathHelper.Pi/2;

        /// <summary>
        ///     Clamps a number between a minimum and a maximum.
        /// </summary>
        /// <param name="n"> The number to clamp. </param>
        /// <param name="min"> The minimum allowed value. </param>
        /// <param name="max"> The maximum allowed value. </param>
        /// <returns> min, if n is lower than min; max, if n is higher than max; n otherwise. </returns>
        public static int Clamp(int n, int min, int max)
        {
            return System.Math.Max(System.Math.Min(n, max), min);
        }

        /// <summary>
        ///     Clamps a number between a minimum and a maximum.
        /// </summary>
        /// <param name="n"> The number to clamp. </param>
        /// <param name="min"> The minimum allowed value. </param>
        /// <param name="max"> The maximum allowed value. </param>
        /// <returns> min, if n is lower than min; max, if n is higher than max; n otherwise. </returns>
        public static float Clamp(float n, float min, float max)
        {
            return System.Math.Max(System.Math.Min(n, max), min);
        }

        /// <summary>
        ///     Clamps a number between a minimum and a maximum.
        /// </summary>
        /// <param name="n"> The number to clamp. </param>
        /// <param name="min"> The minimum allowed value. </param>
        /// <param name="max"> The maximum allowed value. </param>
        /// <returns> min, if n is lower than min; max, if n is higher than max; n otherwise. </returns>
        public static double Clamp(double n, double min, double max)
        {
            return System.Math.Max(System.Math.Min(n, max), min);
        }
    }
}