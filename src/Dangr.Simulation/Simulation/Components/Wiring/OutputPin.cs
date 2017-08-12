// -----------------------------------------------------------------------
//  <copyright file="OutputPin.cs" company="Phoenix Game Studios, LLC">
//      Copyright (c) 2017 Phoenix Game Studios, LLC. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/PhoenixGameStudios/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
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