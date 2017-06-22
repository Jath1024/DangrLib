// -----------------------------------------------------------------------
//  <copyright file="PullBehavior.cs" company="DangerDan9631">
//      Copyright (c) 2017 Dan Garvey. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/Dangerdan9631/DangrLib/blob/master/LICENSE for full license information.
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