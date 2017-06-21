// -----------------------------------------------------------------------
//  <copyright file="LogicGate.cs" company="DangerDan9631">
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