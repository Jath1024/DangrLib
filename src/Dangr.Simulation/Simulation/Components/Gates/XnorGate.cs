// -----------------------------------------------------------------------
//  <copyright file="XnorGate.cs" company="Phoenix Game Studios, LLC">
//      Copyright (c) 2017 Phoenix Game Studios, LLC. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/PhoenixGameStudios/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.Simulation.Components.Gates
{
    using Dangr.Simulation.Types;

    public class XnorGate : XorGate
    {
        protected virtual BitValue OutputWhenOne => BitValue.Zero;
        protected virtual BitValue OutputWhenNotOne => BitValue.One;

        public XnorGate(SimulationEngine engine, int numberOfInputs, int bitWidth)
            : base(engine, numberOfInputs, bitWidth)
        {
        }
    }
}