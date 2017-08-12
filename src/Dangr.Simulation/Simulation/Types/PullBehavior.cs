// -----------------------------------------------------------------------
//  <copyright file="PullBehavior.cs" company="Phoenix Game Studios, LLC">
//      Copyright (c) 2017 Phoenix Game Studios, LLC. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/PhoenixGameStudios/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.Simulation.Types
{
    /// <summary>
    /// Enumerates possible component pull behaviors.
    /// </summary>
    public enum PullBehavior
    {
        /// <summary>
        /// <see cref="Dangr.Simulation.Types.BitValue.Floating" /> values are left unchanged.
        /// </summary>
        Unchanged,

        /// <summary>
        /// <see cref="Dangr.Simulation.Types.BitValue.Floating" /> values are pulled to <see cref="Dangr.Simulation.Types.BitValue.One" /> .
        /// </summary>
        PullUp,

        /// <summary>
        /// <see cref="Dangr.Simulation.Types.BitValue.Floating" /> values are pulled to <see cref="Dangr.Simulation.Types.BitValue.Zero" /> .
        /// </summary>
        PullDown
    }
}