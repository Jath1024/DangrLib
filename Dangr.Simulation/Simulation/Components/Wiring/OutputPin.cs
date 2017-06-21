// -----------------------------------------------------------------------
//  <copyright file="OutputPin.cs" company="DangerDan9631">
//      Copyright (c) 2017 Dan Garvey. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/Dangerdan9631/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
//  <dateCreated>2017-06-14</dateCreated>
//  <dateModified>2017-06-20</dateModified>
//  <lastModifiedBy>Dan Garvey</lastModifiedBy>
// -----------------------------------------------------------------------

namespace Dangr.Simulation.Components.Wiring
{
    using System;
    using Dangr.Simulation.Connections;
    using Dangr.Simulation.Types;

    public class OutputPin : SimulationEntity
    {
        public int DataBitWidth { get; }

        public DataValue Value { get; private set; }

        public ReadConnection In { get; }

        public event EventHandler<DataValueChangedEventArgs> OutputUpdated;

        public OutputPin(SimulationEngine engine, int dataBitWidth)
            : base(engine)
        {
            this.DataBitWidth = dataBitWidth;
            this.In = new ReadConnection(this.DataBitWidth);
            this.In.DataValueChanged += this.OnInputDataValueChanged;
        }

        private void OnInputDataValueChanged(object sender, DataValueChangedEventArgs eventArgs)
        {
            this.Value = eventArgs.Value;
            this.OnOutputUpdated(this.Value);
        }

        private void OnOutputUpdated(DataValue value)
        {
            this.OutputUpdated?.Invoke(this, new DataValueChangedEventArgs(value));
        }
    }
}