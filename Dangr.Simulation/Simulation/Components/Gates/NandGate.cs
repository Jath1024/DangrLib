// -----------------------------------------------------------------------
//  <copyright file="NandGate.cs" company="DangerDan9631">
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
    using Dangr.Simulation.Types;

    public class NandGate : LogicGate
    {
        public NandGate(SimulationEngine engine, int numberOfInputs, int bitWidth)
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

                result.And(otherValues, ref result, this.Engine.Properties.LogicGatesIgnoreFloating);
            }

            result.Invert(ref result);
            this.OutputType.Convert(result, ref result);
            this.Out.WriteValue(DataValue.FromValues(result));
        }
    }
}