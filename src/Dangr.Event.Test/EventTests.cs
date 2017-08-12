// -----------------------------------------------------------------------
//  <copyright file="EventTests.cs" company="Phoenix Game Studios, LLC">
//      Copyright (c) 2017 Phoenix Game Studios, LLC. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/PhoenixGameStudios/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------
namespace Dangr.Event
{
    using System;
    using Dangr.Core.Event;
    using Dangr.Core.Test;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class EventTests
    {
        public EventBus eventBus;
        public TestEventListener eventListener;

        [TestInitialize]
        public void TestInitialize()
        {
            this.eventBus = new EventBus();
            this.eventListener = new TestEventListener();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            this.eventBus = null;
            this.eventListener = null;
        }

        [TestMethod]
        public void EventRegisterTest()
        {
            // Successful register.
            this.eventBus.Register(this.eventListener);

            // Error cases.
            TestUtils.TestForError<ArgumentNullException>(() => this.eventBus.Register(null), "Register null.");
            TestUtils.TestForError<InvalidOperationException>(
                () => this.eventBus.Register(new InvalidTestEventListenerPrivateMethod()),
                "Register private method.");
            TestUtils.TestForError<InvalidOperationException>(
                () => this.eventBus.Register(new InvalidTestEventListenerTooManyParameters()),
                "Register too many parameters.");
            TestUtils.TestForError<InvalidOperationException>(
                () => this.eventBus.Register(new InvalidTestEventListenerTooFewParameters()),
                "Register too few parameters.");
        }

        [TestMethod]
        public void EventUnegisterTest()
        {
            // Setup
            this.eventBus.Register(this.eventListener);

            // Successful unregister.
            this.eventBus.Unregister(this.eventListener);

            // Successfully unregister a listener that isn't registered.
            this.eventBus.Register(new TestEventListener());

            // Error cases.
            TestUtils.TestForError<ArgumentNullException>(() => this.eventBus.Unregister(null), "Unregister null");
            TestUtils.TestForError<InvalidOperationException>(
                () => this.eventBus.Unregister(new InvalidTestEventListenerTooFewParameters()),
                "Unregister no parameters.");

            // Random edge cases that shouldn't fail.
            this.eventBus.Unregister(new InvalidTestEventListenerPrivateMethod());
            this.eventBus.Unregister(new InvalidTestEventListenerTooManyParameters());
        }

        [TestMethod]
        public void EventTest()
        {
            // Setup
            this.eventBus.Register(this.eventListener);
            TestEventListener listener2 = new TestEventListener();
            this.eventBus.Register(listener2);

            // Successful post.
            this.eventBus.Post(new TestEvent());
            Assert.IsTrue(this.eventListener.EventTriggered, "Event was not triggered");
            Assert.IsTrue(listener2.EventTriggered, "Event listener2 was not triggered");

            // Successful post with no listeners
            this.eventBus.Post(new object());

            // Event not posted after unregister.
            this.eventBus.Post(new TestResetEvent(false));
            Assert.IsFalse(this.eventListener.EventTriggered, "Event was not reset");
            Assert.IsFalse(listener2.EventTriggered, "Event listener2 was not reset");
            this.eventBus.Unregister(this.eventListener);
            this.eventBus.Post(new TestEvent());
            Assert.IsFalse(this.eventListener.EventTriggered, "Event was not unregistered.");
            Assert.IsTrue(listener2.EventTriggered, "Event listener2 was not triggered after unregister.");

            // Clear
            this.eventBus.Register(this.eventListener);
            this.eventBus.Post(new TestResetEvent(false));
            Assert.IsFalse(this.eventListener.EventTriggered, "Event was not reset");
            Assert.IsFalse(listener2.EventTriggered, "Event listener2 was not reset");
            this.eventBus.Clear();
            this.eventBus.Post(new TestEvent());
            Assert.IsFalse(this.eventListener.EventTriggered, "Event was not unregistered after clear.");
            Assert.IsFalse(listener2.EventTriggered, "Event was not unregistered after clear.");
        }
    }
}