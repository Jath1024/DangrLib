// -----------------------------------------------------------------------
//  <copyright file="XorGate.cs" company="DangerDan9631">
//      Copyright (c) 2017 Dan Garvey. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/Dangerdan9631/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.Simulation.Components.Gates
{
    using Dangr.Simulation.Types;

    public class XorGate : LogicGate
    {
        public XorGate(SimulationEngine engine, int numberOfInputs, int bitWidth)
            : base(engine, numberOfInputs, bitWidth)
        {
        }

        protected override void OnInputDataValueChanged(object sender, DataValueChangedEventArgs eventArgs)
        {
            var result = new BitValue[this.DataBitWidth];

            for (var i = 0; i < this.DataBitWidth; i++)
            {
                var count = 0;
                var error = false;
                var floating = true;

                for (var input = 0; input < this.NumberOfInputs; input++)
                {
                    BitValue bitValue = this.In[input].DataValue[i];
                    if (this.InvertInput[input])
                    {
                        bitValue = bitValue.Invert();
                    }

                    if (floating && (bitValue != BitValue.Floating))
                    {
                        floating = false;
                    }

                    if (bitValue == BitValue.One)
                    {
                        count++;
                    }
                    else if (bitValue == BitValue.Error)
                    {
                        error = true;
                        break;
                    }
                }

                result[i] = error
                    ? BitValue.Error
                    : floating
                        ? BitValue.Floating
                        : count == 1
                            ? BitValue.One
                            : BitValue.Zero;
            }

            this.OutputType.Convert(result, ref result);
            this.Out.WriteValue(DataValue.FromValues(result));
        }
    }
}