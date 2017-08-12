// -----------------------------------------------------------------------
//  <copyright file="InputPin.cs" company="Phoenix Game Studios, LLC">
//      Copyright (c) 2017 Phoenix Game Studios, LLC. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/PhoenixGameStudios/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.Simulation.Components.Wiring
{
    using Dangr.Diagnostics;
    using Dangr.Simulation.Connections;
    using Dangr.Simulation.Types;

    public class InputPin : SimulationEntity
    {
        public int DataBitWidth { get; }

        private DataValue value;
        public WriteConnection Out { get; }

        public InputPin(SimulationEngine engine, int dataBitWidth)
            : base(engine)
        {
            this.DataBitWidth = dataBitWidth;
            this.Out = new WriteConnection(this.DataBitWidth);
        }

        public void SetValue(DataValue value)
        {
            Assert.Validate.AreEqual(
                this.DataBitWidth,
                value.BitWidth,
                $"Cannot set value. Bit width must be {this.DataBitWidth}.");
            this.value = value;
            this.Out.WriteValue(this.value);
        }
    }
}