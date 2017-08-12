// -----------------------------------------------------------------------
//  <copyright file="ReadConnection.cs" company="Phoenix Game Studios, LLC">
//      Copyright (c) 2017 Phoenix Game Studios, LLC. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/PhoenixGameStudios/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.Simulation.Connections
{
    using System;
    using Dangr.Diagnostics;
    using Dangr.Simulation.Types;

    /// <summary>
    /// Defines an <see cref="IConnection"/> used to read a value from a
    /// connected <see cref="Wire"/>.
    /// </summary>
    /// <seealso cref="IConnection" />
    public class ReadConnection : IConnection
    {
        /// <summary>
        /// Gets the <see cref="Types.DataValue"/> that was read from the connected <see cref="Wire"/>.
        /// All bits will be <see cref="BitValue.Floating"/> if the connection has not been written to.
        /// </summary>
        public DataValue DataValue { get; private set; }

        /// <summary>
        /// Gets the number of bits in the <see cref="IConnection" />.
        /// </summary>
        public int DataBitWidth { get; }

        private Wire ConnectedWire { get; set; }

        /// <summary>
        /// Occurs when a <see cref="Types.DataValue"/> is written to this <see cref="ReadConnection"/>.
        /// </summary>
        public event EventHandler<DataValueChangedEventArgs> DataValueChanged;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReadConnection"/> class.
        /// </summary>
        /// <param name="dataBitWidth">The number of bits in the <see cref="ReadConnection"/>.</param>
        public ReadConnection(int dataBitWidth)
        {
            this.DataBitWidth = dataBitWidth;
            this.DataValue = DataValue.Floating(this.DataBitWidth);
        }

        /// <summary>
        /// Connects this <see cref="IConnection" /> to a <see cref="Wire" />.
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
            this.ConnectedWire.DataValueChanged += this.ConnectedWireDataValueChanged;
        }

        private void ConnectedWireDataValueChanged(object sender, DataValueChangedEventArgs args)
        {
            this.DataValue = args.Value;
            this.OnDataValueChanged(args);
        }

        private void OnDataValueChanged(DataValueChangedEventArgs valueChangedEventArgs)
        {
            this.DataValueChanged?.Invoke(this, valueChangedEventArgs);
        }
    }
}