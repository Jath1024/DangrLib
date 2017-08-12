// -----------------------------------------------------------------------
//  <copyright file="SimulationEngine.cs" company="Phoenix Game Studios, LLC">
//      Copyright (c) 2017 Phoenix Game Studios, LLC. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/PhoenixGameStudios/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
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