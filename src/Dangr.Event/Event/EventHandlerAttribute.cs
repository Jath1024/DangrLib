// -----------------------------------------------------------------------
//  <copyright file="EventHandlerAttribute.cs" company="DangerDan9631">
//      Copyright (c) 2017 Dan Garvey. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/Dangerdan9631/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.Event
{
    using System;

    /// <summary>
    /// Marks a method as an event handler. Used to register a method to an
    /// event bus.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, Inherited = false)]
    public sealed class EventHandlerAttribute : Attribute
    {
    }
}