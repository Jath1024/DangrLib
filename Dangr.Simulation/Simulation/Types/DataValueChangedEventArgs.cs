﻿// -----------------------------------------------------------------------
//  <copyright file="DataValueChangedEventArgs.cs" company="DangerDan9631">
//      Copyright (c) 2017 Dan Garvey. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/Dangerdan9631/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.Simulation.Types
{
    using System;

    /// <summary>
    /// Event args used when a <see cref="DataValue" /> is changed.
    /// </summary>
    /// <seealso cref="T:System.EventArgs" />
    public class DataValueChangedEventArgs : EventArgs
    {
        /// <summary>
        /// Gets the DataValueChanged <see cref="DataValue" />
        /// </summary>
        public DataValue Value { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataValueChangedEventArgs" /> class.
        /// </summary>
        /// <param name="value">The updated <see cref="DataValue" /> .</param>
        public DataValueChangedEventArgs(DataValue value)
        {
            this.Value = value;
        }
    }
}