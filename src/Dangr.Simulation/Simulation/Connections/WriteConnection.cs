// -----------------------------------------------------------------------
//  <copyright file="WriteConnection.cs" company="Phoenix Game Studios, LLC">
//      Copyright (c) 2017 Phoenix Game Studios, LLC. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/PhoenixGameStudios/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.Simulation.Connections
{
    using Dangr.Diagnostics;
    using Dangr.Simulation.Types;

    /// <summary>
    /// Defines an <see cref="IConnection" /> used to write a value to a
    /// connected <see cref="Wire" /> .
    /// </summary>
    /// <seealso cref="T:Dangr.Simulation.Connections.IConnection" />
    public class WriteConnection : IConnection
    {
        /// <summary>
        /// Gets the number of data bits in the <see cref="IConnection" /> .
        /// </summary>
        public int DataBitWidth { get; }

        private Wire ConnectedWire { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WriteConnection" /> class.
        /// </summary>
        /// <param name="dataBitWidth">
        /// The number of bits in the <see cref="WriteConnection" /> .
        /// </param>
        public WriteConnection(int dataBitWidth)
        {
            this.DataBitWidth = dataBitWidth;
        }

        /// <summary>
        /// Connects this <see cref="IConnection" /> to a <see cref="Wire" /> .
        /// </summary>
        /// <param name="wire">The <see cref="Wire" /> to connect to.</param>
        public void ConnectTo(Wire wire)
        {
            Assert.Validate.IsNull(
                this.ConnectedWire,
                "Cannot connect wire. Connection is already connected.");
            Assert.Validate.AreEqual(
                this.DataBitWidth,
                wire.BitWidth,
                "Cannot connect wire. Bit width does not match.");
            this.ConnectedWire = wire;
            this.ConnectedWire.UpdateInput(this, DataValue.Floating(this.DataBitWidth));
        }

        /// <summary>
        /// Writes the specified <see cref="Dangr.Simulation.Types.DataValue" /> to this <see cref="WriteConnection" /> .
        /// </summary>
        /// <param name="value">
        /// The <see cref="Dangr.Simulation.Types.DataValue" /> .
        /// </param>
        public void WriteValue(DataValue value)
        {
            Assert.Validate.AreEqual(
                this.DataBitWidth,
                value.BitWidth,
                $"Cannot set value. Bit width must be {this.DataBitWidth}.");
            this.ConnectedWire?.UpdateInput(this, value);
        }
    }
}