// -----------------------------------------------------------------------
//  <copyright file="SimulationComponent.cs" company="Phoenix Game Studios, LLC">
//      Copyright (c) 2017 Phoenix Game Studios, LLC. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/PhoenixGameStudios/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.Simulation.Components
{
    using System;
    using Dangr.Simulation.Types;

    public abstract class SimulationComponent : SimulationEntity
    {
        private bool updateScheduled;

        public SimulationComponent(SimulationEngine engine)
            : base(engine)
        {
        }

        public virtual void Update()
        {
            this.updateScheduled = false;
        }

        protected void OnInputUpdated(object sender, EventArgs e)
        {
            if (this.updateScheduled)
            {
                return;
            }

            this.updateScheduled = true;
            this.Engine.UpdateComponent(this);
        }
    }
}