// -----------------------------------------------------------------------
//  <copyright file="SimulationComponent.cs" company="DangerDan9631">
//      Copyright (c) 2017 Dan Garvey. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/Dangerdan9631/DangrLib/blob/master/LICENSE for full license information.
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
        { }

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