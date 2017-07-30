// -----------------------------------------------------------------------
//  <copyright file="InvalidTestEventListenerTooFewParameters.cs" company="DangerDan9631">
//      Copyright (c) 2017 Dan Garvey. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/Dangerdan9631/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.Event
{
    using Dangr.Core.Event;

    public class InvalidTestEventListenerTooFewParameters
    {
        [EventHandler]
        public void OnTestEvent()
        {
        }
    }
}