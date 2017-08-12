// -----------------------------------------------------------------------
//  <copyright file="EventHandlerAttribute.cs" company="Phoenix Game Studios, LLC">
//      Copyright (c) 2017 Phoenix Game Studios, LLC. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/PhoenixGameStudios/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------
namespace Dangr.Core.Event
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