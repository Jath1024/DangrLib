// -----------------------------------------------------------------------
//  <copyright file="TestResetEvent.cs" company="DangerDan9631">
//      Copyright (c) 2017 Dan Garvey. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/Dangerdan9631/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
//  <dateCreated>2017-04-24</dateCreated>
//  <dateModified>2017-06-20</dateModified>
//  <lastModifiedBy>Dan Garvey</lastModifiedBy>
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