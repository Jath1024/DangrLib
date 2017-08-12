// -----------------------------------------------------------------------
//  <copyright file="ControlledInverter.cs" company="Phoenix Game Studios, LLC">
//      Copyright (c) 2017 Phoenix Game Studios, LLC. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/PhoenixGameStudios/DangrLib/blob/master/LICENSE for full license information.
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
