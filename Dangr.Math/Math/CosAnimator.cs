// -----------------------------------------------------------------------
//  <copyright file="CosAnimator.cs" company="DangerDan9631">
//      Copyright (c) 2017 Dan Garvey. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/Dangerdan9631/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.Math
{
    using System;

    /// <summary>
    /// <see cref="Animator" /> that animates using the equation: V = 1 -
    /// Cos(Pi/2 * T) Starts out slow, speeds up to the end.
    /// </summary>
    public class CosAnimator : Animator
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CosAnimator" /> class.
        /// </summary>
        /// <param name="minValue">The minimum value.</param>
        /// <param name="maxValue">The maximum value.</param>
        public CosAnimator(float minValue, float maxValue)
            : base(minValue, maxValue)
        { }

        /// <summary>
        /// Calculates the new value as a scale from 0 to 1.
        /// </summary>
        /// <param name="v">The input parameter as a value from 0 to 1.</param>
        /// <returns>The new value as a scale from 0 to 1.</returns>
        protected override float CalculateScale(float v)
        {
            return 1.0f - (float) Math.Cos(MathHelper.PiOver2*v);
        }
    }
}