// -----------------------------------------------------------------------
//  <copyright file="SimulationEntity.cs" company="DangerDan9631">
//      Copyright (c) 2017 Dan Garvey. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/Dangerdan9631/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.Simulation.Types
{
    using Dangr.Util;

    /// <summary>
    /// Base class for an entity that is part of the simulation engine.
    /// </summary>
    public abstract class SimulationEntity
    {
        private static readonly IdCounter IdCounter = new IdCounter(ulong.MinValue, ulong.MaxValue);

        /// <summary>
        /// Gets the globally unique identifier for this <see cref="SimulationEntity" /> .
        /// </summary>
        public ulong Id { get; }

        /// <summary>
        /// Gets the <see cref="SimulationEngine" /> this <see cref="SimulationEntity" /> is a part of.
        /// </summary>
        protected SimulationEngine Engine { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SimulationEntity" /> class.
        /// </summary>
        /// <param name="engine">
        /// The <see cref="SimulationEngine" /> this <see cref="SimulationEntity" /> is a part of.
        /// </param>
        protected SimulationEntity(SimulationEngine engine)
        {
            this.Id = SimulationEntity.IdCounter.GetId();
            this.Engine = engine;
        }
    }
}