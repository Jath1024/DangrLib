// -----------------------------------------------------------------------
//  <copyright file="TestEventListener.cs" company="DangerDan9631">
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
    public class TestEventListener
    {
        public bool EventTriggered { get; private set; }

        [EventHandler]
        public void OnTestEvent(TestEvent evt)
        {
            this.EventTriggered = true;
        }

        [EventHandler]
        public void OnTestResetEvent(TestResetEvent evt)
        {
            this.EventTriggered = evt.Value;
        }
    }
}