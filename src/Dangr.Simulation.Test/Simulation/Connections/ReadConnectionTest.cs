// -----------------------------------------------------------------------
//  <copyright file="ReadConnectionTest.cs" company="Phoenix Game Studios, LLC">
//      Copyright (c) 2017 Phoenix Game Studios, LLC. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/PhoenixGameStudios/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.Simulation.Test.Simulation.Connections
{
    using Dangr.Simulation.Connections;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ReadConnectionTest
    {
        [TestMethod]
        public void ReadConnection()
        {
            var bitWidth = 2;

            var connection = new ReadConnection(bitWidth);
        }
    }
}