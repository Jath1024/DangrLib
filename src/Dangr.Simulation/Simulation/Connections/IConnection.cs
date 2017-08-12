// -----------------------------------------------------------------------
//  <copyright file="IConnection.cs" company="Phoenix Game Studios, LLC">
//      Copyright (c) 2017 Phoenix Game Studios, LLC. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/PhoenixGameStudios/DangrLib/blob/master/LICENSE for full license information.
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