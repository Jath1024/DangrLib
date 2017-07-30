// -----------------------------------------------------------------------
//  <copyright file="EventBus.cs" company="DangerDan9631">
//      Copyright (c) 2017 Dan Garvey. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/Dangerdan9631/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.Core.Event
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    /// <summary>
    /// Event bus object that listeners can register to and receive posted
    /// events.
    /// </summary>
    public class EventBus
    {
        private readonly Dictionary<Type, EventWrapper> eventMap = new Dictionary<Type, EventWrapper>();
        private readonly object eventMapLock = new object();

        /// <summary>
        /// Registers an object to receive events.
        /// </summary>
        /// <param name="listener">The object to register</param>
        /// <exception cref="System.ArgumentNullException">
        /// If the object is null.
        /// </exception>
        /// <exception cref="System.InvalidOperationException">
        /// If the object contains a non-public method witout exactly one parameter marked with an <see cref="EventHandlerAttribute" /> .
        /// </exception>
        public void Register(object listener)
        {
            if (listener == null)
            {
                throw new ArgumentNullException($"{nameof(listener)}");
            }

            Type objectType = listener.GetType();
            IEnumerable<MethodInfo> methods = objectType.GetRuntimeMethods();
            foreach (MethodInfo methodInfo in methods)
            {
                object eventHandlerAttribute =
                    methodInfo.GetCustomAttributes(typeof(EventHandlerAttribute), false).FirstOrDefault();
                if (eventHandlerAttribute == null)
                {
                    continue;
                }

                if (!methodInfo.IsPublic)
                {
                    string errorMessage =
                        $"Cannot register EventHandler. Method {objectType.Name}.{methodInfo.Name}() must be declared public.";

                    throw new InvalidOperationException(errorMessage);
                }

                ParameterInfo[] parameters = methodInfo.GetParameters();
                if (parameters.Length != 1)
                {
                    string errorMessage =
                        $"Cannot register EventHandler. Method {objectType.Name}.{methodInfo.Name}({parameters.Length}) must have exactly one parameter.";

                    throw new InvalidOperationException(errorMessage);
                }

                Type eventType = parameters.First().ParameterType;
                EventWrapper eventWrapper;
                lock (this.eventMapLock)
                {
                    if (!this.eventMap.TryGetValue(eventType, out eventWrapper))
                    {
                        eventWrapper = new EventWrapper(methodInfo);
                        this.eventMap.Add(eventType, eventWrapper);
                    }
                }

                eventWrapper.Add(listener);
            }
        }

        /// <summary>
        /// Unregisters an object from receiving events.
        /// </summary>
        /// <param name="listener">The object to unregister</param>
        /// <exception cref="System.ArgumentNullException">
        /// If the object is null.
        /// </exception>
        /// <exception cref="System.InvalidOperationException">
        /// If the object contains a non-public method witout exactly one parameter marked with an <see cref="EventHandlerAttribute" /> .
        /// </exception>
        public void Unregister(object listener)
        {
            if (listener == null)
            {
                throw new ArgumentNullException($"{nameof(listener)}");
            }

            Type objectType = listener.GetType();
            IEnumerable<MethodInfo> methods = objectType.GetRuntimeMethods();
            foreach (MethodInfo methodInfo in methods)
            {
                object eventHandlerAttribute =
                    methodInfo.GetCustomAttributes(typeof(EventHandlerAttribute), false).FirstOrDefault();
                if (eventHandlerAttribute == null)
                {
                    continue;
                }

                ParameterInfo parameter = methodInfo.GetParameters().FirstOrDefault();
                if (parameter == null)
                {
                    string errorMessage =
                        $"Cannot unregister EventHandler. Method {objectType.Name}.{methodInfo.Name}() must have exactly one parameter.";

                    throw new InvalidOperationException(errorMessage);
                }

                Type eventType = parameter.ParameterType;
                lock (this.eventMapLock)
                {
                    EventWrapper eventWrapper;
                    if (this.eventMap.TryGetValue(eventType, out eventWrapper))
                    {
                        eventWrapper.Remove(listener);
                        if (eventWrapper.Count == 0)
                        {
                            this.eventMap.Remove(eventType);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Posts an event to the <see cref="EventBus" /> to be handled by all event handlers registered for the object's type.
        /// </summary>
        /// <param name="evt">The event object.</param>
        public void Post(object evt)
        {
            lock (this.eventMapLock)
            {
                EventWrapper eventWrapper;
                if (this.eventMap.TryGetValue(evt.GetType(), out eventWrapper))
                {
                    eventWrapper.Trigger(evt);
                }
            }
        }

        /// <summary>
        /// Clears all registered listeners from this <see cref="EventBus" /> .
        /// </summary>
        public void Clear()
        {
            lock (this.eventMapLock)
            {
                foreach (EventWrapper eventWrapper in this.eventMap.Values)
                {
                    eventWrapper.Clear();
                }

                this.eventMap.Clear();
            }
        }

        private class EventWrapper
        {
            private readonly object listenerLock = new object();
            private readonly HashSet<object> listeners = new HashSet<object>();
            private readonly MethodInfo methodInfo;

            internal int Count
            {
                get
                {
                    lock (this.listenerLock)
                    {
                        return this.listeners.Count;
                    }
                }
            }

            internal EventWrapper(MethodInfo methodInfo)
            {
                this.methodInfo = methodInfo;
            }

            internal void Add(object obj)
            {
                lock (this.listenerLock)
                {
                    this.listeners.Add(obj);
                }
            }

            internal void Remove(object obj)
            {
                lock (this.listenerLock)
                {
                    this.listeners.Remove(obj);
                }
            }

            internal void Trigger(object argument)
            {
                HashSet<object> temp;
                lock (this.listenerLock)
                {
                    temp = new HashSet<object>(this.listeners);
                }

                var args = new[] { argument };
                foreach (object obj in temp)
                {
                    this.methodInfo.Invoke(obj, args);
                }
            }

            internal void Clear()
            {
                lock (this.listenerLock)
                {
                    this.listeners.Clear();
                }
            }
        }
    }
}