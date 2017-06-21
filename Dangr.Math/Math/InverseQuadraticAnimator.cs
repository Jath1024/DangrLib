// -----------------------------------------------------------------------
//  <copyright file="InverseQuadraticAnimator.cs" company="DangerDan9631">
//      Copyright (c) 2017 Dan Garvey. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/Dangerdan9631/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.Math
{
    /// <summary>
    /// <see cref="Animator" /> that animates using the equation: V = 1 - (T -
    /// 1) ^ 2 Starts out fast, slows down to the end.
    /// </summary>
    public class InverseQuadraticAnimator : Animator
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InverseQuadraticAnimator" /> class.
        /// </summary>
        /// <param name="minValue">The minimum value.</param>
        /// <param name="maxValue">The maximum value.</param>
        public InverseQuadraticAnimator(float minValue, float maxValue)
            : base(minValue, maxValue)
        { }

        /// <summary>
        /// Calculates the new value as a scale from 0 to 1.
        /// </summary>
        /// <param name="v">The input parameter as a value from 0 to 1.</param>
        /// <returns>The new value as a scale from 0 to 1.</returns>
        protected override float CalculateScale(float v)
        {
            float vMinus1 = v - 1.0f;
            return 1.0f - vMinus1*vMinus1;
        }
    }
}