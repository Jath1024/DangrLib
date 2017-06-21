// -----------------------------------------------------------------------
//  <copyright file="EvenParityGate.cs" company="DangerDan9631">
//      Copyright (c) 2017 Dan Garvey. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/Dangerdan9631/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.Simulation.Components.Gates
{
    using Dangr.Simulation.Types;

    public class EvenParityGate : LogicGate
    {
        public EvenParityGate(SimulationEngine engine, int numberOfInputs, int bitWidth)
            : base(engine, numberOfInputs, bitWidth)
        { }

        protected override void OnInputDataValueChanged(object sender, DataValueChangedEventArgs eventArgs)
        {
            BitValue[] result = this.In[0].DataValue.CopyBitValues();
            for (var input = 1; input < this.NumberOfInputs; input++)
            {
                BitValue[] otherValues = this.In[input].DataValue.CopyBitValues();
                if (this.InvertInput[input])
                {
                    otherValues.Invert(ref otherValues);
                }

                result.Xor(otherValues, ref result, this.Engine.Properties.LogicGatesIgnoreFloating);
            }

            result.Invert(ref result);
            this.OutputType.Convert(result, ref result);
            this.Out.WriteValue(DataValue.FromValues(result));
        }
    }
}