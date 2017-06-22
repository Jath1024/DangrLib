// -----------------------------------------------------------------------
//  <copyright file="AndGateTests.cs" company="DangerDan9631">
//      Copyright (c) 2017 Dan Garvey. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/Dangerdan9631/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.Simulation.Test.Simulation.Components.Gates
{
    using Dangr.Simulation.Components.Gates;
    using Dangr.Simulation.Connections;
    using Dangr.Simulation.Types;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Assert = Dangr.Diagnostics.Assert;

    [TestClass]
    public class AndGateTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var engine = new SimulationEngine();

            var input = new TestInput(engine, 2, 2);

            var output = new TestOutput(engine, 2);

            var gate = new AndGate(engine, 2, 2);

            input.Connect(gate.In);
            output.Connect(gate.Out);

            input.SetValues(DataValue.Unsigned(1, 2), DataValue.Unsigned(1, 2));

            for (var i = 0; i < 10; i++)
            {
                engine.Tick();
            }

            output.ValidateValues(DataValue.Unsigned(1, 2));
        }
    }

    public class TestInput
    {
        private readonly SimulationEngine engine;
        public readonly WriteConnection[] connections;

        public TestInput(SimulationEngine engine, params int[] bitWidths)
        {
            this.engine = engine;
            int numInputs = bitWidths.Length;
            this.connections = new WriteConnection[numInputs];

            for (var i = 0; i < numInputs; i++)
            {
                this.connections[i] = new WriteConnection(bitWidths[i]);
            }
        }

        public void Connect(params ReadConnection[] connections)
        {
            for (var i = 0; i < this.connections.Length; i++)
            {
                Wire.Connect(this.engine, this.connections[i], connections[i]);
            }
        }

        public void SetValues(params DataValue[] values)
        {
            for (var i = 0; i < values.Length; i++)
            {
                this.connections[i].WriteValue(values[i]);
            }
        }
    }

    public class TestOutput
    {
        private readonly SimulationEngine engine;
        public readonly ReadConnection[] connections;

        public TestOutput(SimulationEngine engine, params int[] bitWidths)
        {
            this.engine = engine;
            int numOutputs = bitWidths.Length;
            this.connections = new ReadConnection[numOutputs];

            for (var i = 0; i < numOutputs; i++)
            {
                this.connections[i] = new ReadConnection(bitWidths[i]);
            }
        }

        public void Connect(params WriteConnection[] connections)
        {
            for (var i = 0; i < this.connections.Length; i++)
            {
                Wire.Connect(this.engine, connections[i], this.connections[i]);
            }
        }

        public void ValidateValues(params DataValue[] values)
        {
            for (var i = 0; i < values.Length; i++)
            {
                Assert.Validate.AreEqual(this.connections[i].DataValue, values[i], "");
            }
        }
    }
}