// -----------------------------------------------------------------------
//  <copyright file="LogicGate.cs" company="Phoenix Game Studios, LLC">
//      Copyright (c) 2017 Phoenix Game Studios, LLC. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/PhoenixGameStudios/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.Simulation.Components.Gates
{
    using Dangr.Simulation.Connections;
    using Dangr.Simulation.Types;

    public abstract class LogicGate : SimulationEntity
    {
        public int DataBitWidth { get; }

        public int NumberOfInputs { get; }

        public OutputType OutputType { get; set; } = OutputType.ZeroOne;

        public ReadConnection[] In { get; }

        public bool[] InvertInput { get; }

        public WriteConnection Out { get; }

        protected LogicGate(SimulationEngine engine, int numberOfInputs, int bitWidth)
            : base(engine)
        {
            this.NumberOfInputs = numberOfInputs;
            this.DataBitWidth = bitWidth;

            this.In = new ReadConnection[this.NumberOfInputs];
            this.InvertInput = new bool[this.NumberOfInputs];
            for (var i = 0; i < this.NumberOfInputs; i++)
            {
                this.In[i] = new ReadConnection(this.DataBitWidth);
                this.In[i].DataValueChanged += this.OnInputDataValueChanged;
                this.InvertInput[i] = false;
            }

            this.Out = new WriteConnection(this.DataBitWidth);
        }

        protected abstract void OnInputDataValueChanged(object sender, DataValueChangedEventArgs eventArgs);
    }
}