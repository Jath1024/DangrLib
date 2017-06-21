// -----------------------------------------------------------------------
//  <copyright file="SimulationComponent.cs" company="DangerDan9631">
//      Copyright (c) 2017 Dan Garvey. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/Dangerdan9631/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
//  <dateCreated>2017-06-14</dateCreated>
//  <dateModified>2017-06-20</dateModified>
//  <lastModifiedBy>Dan Garvey</lastModifiedBy>
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