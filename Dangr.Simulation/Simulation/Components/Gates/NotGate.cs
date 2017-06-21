// -----------------------------------------------------------------------
//  <copyright file="NotGate.cs" company="DangerDan9631">
//      Copyright (c) 2017 Dan Garvey. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/Dangerdan9631/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
//  <dateCreated>2017-06-14</dateCreated>
//  <dateModified>2017-06-20</dateModified>
//  <lastModifiedBy>Dan Garvey</lastModifiedBy>
// -----------------------------------------------------------------------

namespace Dangr.Simulation.Components.Gates
{
    using Dangr.Simulation.Connections;
    using Dangr.Simulation.Types;

    public class NotGate : SimulationEntity
    {
        public int DataBitWidth { get; }

        public OutputType OutputType { get; set; } = OutputType.ZeroOne;

        public ReadConnection In { get; }

        public WriteConnection Out { get; }

        public NotGate(SimulationEngine engine, int bitWidth)
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
            result.Invert(ref result);
            this.OutputType.Convert(result, ref result);
            this.Out.WriteValue(DataValue.FromValues(result));
        }
    }
}