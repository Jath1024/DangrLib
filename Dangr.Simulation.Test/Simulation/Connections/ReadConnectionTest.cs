// -----------------------------------------------------------------------
//  <copyright file="ReadConnectionTest.cs" company="DangerDan9631">
//      Copyright (c) 2017 Dan Garvey. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/Dangerdan9631/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
//  <dateCreated>2017-06-14</dateCreated>
//  <dateModified>2017-06-20</dateModified>
//  <lastModifiedBy>Dan Garvey</lastModifiedBy>
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