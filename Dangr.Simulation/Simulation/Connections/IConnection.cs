// -----------------------------------------------------------------------
//  <copyright file="IConnection.cs" company="DangerDan9631">
//      Copyright (c) 2017 Dan Garvey. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/Dangerdan9631/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.Simulation.Connections
{
    /// <summary>
    /// Defines the methods and properties used by a connection.
    /// </summary>
    public interface IConnection
    {
        /// <summary>
        /// Gets the number of bits in the <see cref="IConnection" /> .
        /// </summary>
        int DataBitWidth { get; }

        /// <summary>
        /// Connects this <see cref="IConnection" /> to a <see cref="Wire" /> .
        /// </summary>
        /// <param name="wire">The <see cref="Wire" /> to connect to.</param>
        void ConnectTo(Wire wire);
    }
}