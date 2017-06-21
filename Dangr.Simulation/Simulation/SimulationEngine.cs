// -----------------------------------------------------------------------
//  <copyright file="SimulationEngine.cs" company="DangerDan9631">
//      Copyright (c) 2017 Dan Garvey. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/Dangerdan9631/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
//  <dateCreated>2017-06-14</dateCreated>
//  <dateModified>2017-06-20</dateModified>
//  <lastModifiedBy>Dan Garvey</lastModifiedBy>
// -----------------------------------------------------------------------

namespace Dangr.Simulation
{
    using System;
    using System.Collections.Generic;
    using Dangr.Simulation.Components;

    public class SimulationEngine
    {
        private readonly Queue<SimulationComponent> updatedComponents = new Queue<SimulationComponent>();

        public EngineProperties Properties { get; } = new EngineProperties();

        public void Tick()
        {
            while (this.updatedComponents.Count > 0)
            {
                try
                {
                    SimulationComponent component = this.updatedComponents.Dequeue();
                    Console.WriteLine($"Updating Component {component.GetType().Name}");
                    component.Update();
                }
                catch (Exception e)
                {
                    Console.WriteLine($"An error occurred{Environment.NewLine}{e}");
                }
            }
        }

        public void UpdateComponent(SimulationComponent component)
        {
            this.updatedComponents.Enqueue(component);
        }

        public class EngineProperties
        {
            public bool IgnoreDisconnected { get; } = true;
            public int DefaultBitWidth { get; } = 8;
            public bool LogicGatesIgnoreFloating { get; } = true;
        }
    }
}