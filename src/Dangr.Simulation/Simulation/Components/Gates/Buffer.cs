// -----------------------------------------------------------------------
//  <copyright file="Buffer.cs" company="Phoenix Game Studios, LLC">
//      Copyright (c) 2017 Phoenix Game Studios, LLC. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/PhoenixGameStudios/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.Simulation.Components.Gates
{
    using Dangr.Simulation.Connections;
    using Dangr.Simulation.Types;

    public class Buffer : SimulationEntity
    {
        public int DataBitWidth { get; }

        public OutputType OutputType { get; set; } = OutputType.ZeroOne;

        public ReadConnection In { get; }

        public WriteConnection Out { get; }

        public Buffer(SimulationEngine engine, int bitWidth)
            : base(engine)
        {
            this.DataBitWidth = bitWidth;

            this.In = new ReadConnection(bitWidth);
            this.In.DataValueChanged += this.OnInputDataValueChanged;

            this.Out = new WriteConnection(bitWidth);
        }

        private void OnInputDataValueChanged(object sender, DataValueChangedEventArgs eventArgs)
        {
            BitValue[] result = eventArgs.Value.CopyBitValues();
            this.OutputType.Convert(result, ref result);
            this.Out.WriteValue(DataValue.FromValues(result));
        }
    }
}