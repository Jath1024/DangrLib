// -----------------------------------------------------------------------
//  <copyright file="SmoothTrigAnimator.cs" company="Phoenix Game Studios, LLC">
//      Copyright (c) 2017 Phoenix Game Studios, LLC. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/PhoenixGameStudios/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------
namespace Dangr.Core.Math
{
    using System;

    /// <summary>
    /// <see cref="Animator" /> that animates using the equation: V = (1 - Cos(Pi * T)) / 2 Starts 
    /// out slow, speeds up in the middle, ends slow.
    /// </summary>
    public class SmoothTrigAnimator : Animator
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SmoothTrigAnimator" /> class.
        /// </summary>
        /// <param name="minValue">The minimum value.</param>
        /// <param name="maxValue">The maximum value.</param>
        public SmoothTrigAnimator(float minValue, float maxValue)
            : base(minValue, maxValue)
        {
        }

        /// <summary>
        /// Calculates the new value as a scale from 0 to 1.
        /// </summary>
        /// <param name="v">The input parameter as a value from 0 to 1.</param>
        /// <returns>The new value as a scale from 0 to 1.</returns>
        protected override float CalculateScale(float v)
        {
            return (1.0f - (float) Math.Cos(MathHelper.Pi * v)) / 2.0f;
        }
    }
}