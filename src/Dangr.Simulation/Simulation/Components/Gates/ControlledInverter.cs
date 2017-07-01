// -----------------------------------------------------------------------
//  <copyright file="ControlledInverter.cs" company="DangerDan9631">
//      Copyright (c) 2017 Dan Garvey. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/Dangerdan9631/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.Simulation.Components.Gates
{
    using Dangr.Simulation.Connections;
    using Dangr.Simulation.Types;

    public class ControlledInverter : ControlledBuffer
    {
        public ControlledInverter(SimulationEngine engine, int bitWidth)
            : base(engine, bitWidth)
        {
        }
        
        protected override void WriteValue(DataValue value)
        {
            BitValue[] result = value.CopyBitValues();
            result.Invert(ref result);
            return result;
        }
    }
}
