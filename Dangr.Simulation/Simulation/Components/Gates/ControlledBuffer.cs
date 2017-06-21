// -----------------------------------------------------------------------
//  <copyright file="ControlledBuffer.cs" company="DangerDan9631">
//      Copyright (c) 2017 Dan Garvey. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/Dangerdan9631/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.Simulation.Components.Gates
{
    using Dangr.Simulation.Connections;
    using Dangr.Simulation.Types;

    public class ControlledBuffer : SimulationEntity
    {
        public int DataBitWidth { get; }

        public OutputType OutputType { get; set; } = OutputType.ZeroOne;

        public ReadConnection In { get; }

        public ReadConnection Enabled { get; }

        public WriteConnection Out { get; }

        public ControlledBuffer(SimulationEngine engine, int bitWidth)
            : base(engine)
        {
            this.DataBitWidth = bitWidth;

            this.In = new ReadConnection(bitWidth);
            this.In.DataValueChanged += this.OnInputDataValueChanged;

            this.Enabled = new ReadConnection(1);
            this.Enabled.DataValueChanged += this.OnInputDataValueChanged;

            this.Out = new WriteConnection(bitWidth);
        }

        private void OnInputDataValueChanged(object sender, DataValueChangedEventArgs eventArgs)
        {
            BitValue enabled = this.Enabled.DataValue[0];
            switch (enabled)
            {
                case BitValue.Error:
                    this.Out.WriteValue(DataValue.Error(this.DataBitWidth));
                    break;
                case BitValue.Zero:
                case BitValue.Floating:
                    this.Out.WriteValue(DataValue.Floating(this.DataBitWidth));
                    break;
                case BitValue.One:
                    BitValue[] result = eventArgs.Value.CopyBitValues();
                    this.OutputType.Convert(result, ref result);
                    this.Out.WriteValue(DataValue.FromValues(result));
                    break;
            }
        }
    }
}