// -----------------------------------------------------------------------
//  <copyright file="TestResetEvent.cs" company="Phoenix Game Studios, LLC">
//      Copyright (c) 2017 Phoenix Game Studios, LLC. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/PhoenixGameStudios/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------
namespace Dangr.Event
{
    public class TestResetEvent
    {
        public bool Value { get; private set; }

        public TestResetEvent(bool value)
        {
            this.Value = value;
        }
    }
}