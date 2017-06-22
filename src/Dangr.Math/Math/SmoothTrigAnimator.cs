// -----------------------------------------------------------------------
//  <copyright file="SmoothTrigAnimator.cs" company="DangerDan9631">
//      Copyright (c) 2017 Dan Garvey. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/Dangerdan9631/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.Math
{
    using System;

    /// <summary>
    /// <para><see cref="Animator" /> that animates using the equation: V = (1 -
    /// Cos(Pi</para>
    /// <list type="bullet">
    /// <item><description></description></item>
    /// <item><description></description></item>
    /// <item><description></description></item>
    /// <item><description></description></item>
    /// <item><description></description></item>
    /// <item><description></description></item>
    /// <item><description></description></item>
    /// <item>
    /// <description>
    /// T)) / 2 Starts out slow, speeds up in the middle, ends slow.
    /// </description>
    /// </item>
    /// <item><description></description></item>
    /// <item><description></description></item>
    /// <item><description></description></item>
    /// <item><description></description></item>
    /// <item><description></description></item>
    /// <item><description></description></item>
    /// <item><description></description></item>
    /// </list>
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
        { }

        /// <summary>
        /// Calculates the new value as a scale from 0 to 1.
        /// </summary>
        /// <param name="v">The input parameter as a value from 0 to 1.</param>
        /// <returns>The new value as a scale from 0 to 1.</returns>
        protected override float CalculateScale(float v)
        {
            return (1.0f - (float) Math.Cos(MathHelper.Pi*v))/2.0f;
        }
    }
}