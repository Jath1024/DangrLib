// -----------------------------------------------------------------------
//  <copyright file="MultiThreadedTaskSchedulerTest.cs" company="Phoenix Game Studios, LLC">
//      Copyright (c) 2017 Phoenix Game Studios, LLC. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/PhoenixGameStudios/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------
namespace Dangr.Core.Async
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Dangr.Core.Diagnostics;
    using Dangr.Core.Test;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Summary description for MultiThreadedTaskSchedulerTest
    /// </summary>
    [TestClass]
    public class MultiThreadedTaskSchedulerTest
    {
        private const int DefaultNumThreads = 5;

        public TestContext TestContext { get; set; }
        
        [TestMethod]
        public void Test_TwoTasks()
        {
            MultiThreadedTaskScheduler scheduler = new MultiThreadedTaskScheduler(MultiThreadedTaskSchedulerTest.DefaultNumThreads);
            TaskFactory factory = new TaskFactory(scheduler);
            
            for(int i = 0; i < 2; i++)
            {
                factory.StartNew(MultiThreadedTaskSchedulerTest.TestTask);
            }

            Validate.Value.AreEqual(scheduler.NumThreadsRunning, 2, "Incorrent number of threads running");
        }

        [TestMethod]
        public void Test_TwoTooManyTasks()
        {
            MultiThreadedTaskScheduler scheduler = new MultiThreadedTaskScheduler(MultiThreadedTaskSchedulerTest.DefaultNumThreads);
            TaskFactory factory = new TaskFactory(scheduler);

            for (int i = 0; i < MultiThreadedTaskSchedulerTest.DefaultNumThreads + 2; i++)
            {
                factory.StartNew(MultiThreadedTaskSchedulerTest.TestTask);
            }

            Validate.Value.AreEqual(scheduler.NumThreadsRunning, MultiThreadedTaskSchedulerTest.DefaultNumThreads, "Incorrent number of threads running");
        }

        [TestMethod]
        public void Test_AtLeastOneThread()
        {
            TestUtils.TestForError<ArgumentOutOfRangeException>(
                () => new MultiThreadedTaskScheduler(0),
                "Should not be able to create task scheduler with 0 threads.");
        }

        [TestMethod]
        public void Test_QueueTask()
        {
            bool taskRan = false;
            MultiThreadedTaskScheduler scheduler = new MultiThreadedTaskScheduler(MultiThreadedTaskSchedulerTest.DefaultNumThreads);
            PrivateObject privateScheduler = new PrivateObject(scheduler, new PrivateType(typeof(MultiThreadedTaskScheduler)));
            privateScheduler.Invoke("QueueTask", TestUtils.PrivateInstanceFlags, new Task(() => taskRan = true));

            SpinWait.SpinUntil(() => taskRan && scheduler.NumThreadsRunning == 0, TimeSpan.FromSeconds(3));
        }

        [TestMethod]
        public void Test_QueueNullTask()
        {
            MultiThreadedTaskScheduler scheduler = new MultiThreadedTaskScheduler(MultiThreadedTaskSchedulerTest.DefaultNumThreads);
            PrivateObject privateScheduler = new PrivateObject(scheduler, new PrivateType(typeof(MultiThreadedTaskScheduler)));

            TestUtils.TestForError<ArgumentNullException>(
                () => privateScheduler.Invoke("QueueTask", TestUtils.PrivateInstanceFlags, (Task)null),
                "Should not be able to queue null tasks.");
        }

        [TestMethod]
        public void Test_InlineNullTask()
        {
            MultiThreadedTaskScheduler scheduler = new MultiThreadedTaskScheduler(MultiThreadedTaskSchedulerTest.DefaultNumThreads);
            PrivateObject privateScheduler = new PrivateObject(scheduler, new PrivateType(typeof(MultiThreadedTaskScheduler)));
            TestUtils.TestForError<ArgumentNullException>(
                () => privateScheduler.Invoke("TryExecuteTaskInline", TestUtils.PrivateInstanceFlags, (Task)null, false),
                "Should not be able to inline execute null tasks.");
        }

        [TestMethod]
        public void Test_InlineWrongThread()
        {
            MultiThreadedTaskScheduler scheduler = new MultiThreadedTaskScheduler(MultiThreadedTaskSchedulerTest.DefaultNumThreads);
            PrivateObject privateScheduler = new PrivateObject(scheduler, new PrivateType(typeof(MultiThreadedTaskScheduler)));
            bool executedTask = (bool)privateScheduler.Invoke(
                "TryExecuteTaskInline",
                TestUtils.PrivateInstanceFlags,
                new Task(MultiThreadedTaskSchedulerTest.TestTask),
                false);
            Validate.Value.IsFalse(executedTask, "Should not be able to inline execute tasks from non running thread.");
        }

        [TestMethod]
        public void Test_InlinePreviouslyQueued()
        {
            MultiThreadedTaskScheduler scheduler = new MultiThreadedTaskScheduler(MultiThreadedTaskSchedulerTest.DefaultNumThreads);
            PrivateObject privateScheduler = new PrivateObject(scheduler, new PrivateType(typeof(MultiThreadedTaskScheduler)));

            privateScheduler.SetField("currentThreadIsProcessingItems", TestUtils.PrivateStaticFlags, true);

            bool executedTask = (bool)privateScheduler.Invoke(
                "TryExecuteTaskInline",
                TestUtils.PrivateInstanceFlags,
                new Task(MultiThreadedTaskSchedulerTest.TestTask),
                true);
            Validate.Value.IsFalse(executedTask, "Should not be able to inline execute previously scheduled tasks.");
        }
        
        [TestMethod]
        public void Test_DequeueNullTask()
        {
            MultiThreadedTaskScheduler scheduler = new MultiThreadedTaskScheduler(MultiThreadedTaskSchedulerTest.DefaultNumThreads);
            PrivateObject privateScheduler = new PrivateObject(scheduler, new PrivateType(typeof(MultiThreadedTaskScheduler)));

            TestUtils.TestForError<ArgumentNullException>(
                () => privateScheduler.Invoke("TryDequeue", TestUtils.PrivateInstanceFlags, (Task)null),
                "Should not be able to dequeue null tasks.");
        }


        [TestMethod]
        public void Test_GetScheduledTasks()
        {
            MultiThreadedTaskScheduler scheduler = new MultiThreadedTaskScheduler(MultiThreadedTaskSchedulerTest.DefaultNumThreads);
            PrivateObject privateScheduler = new PrivateObject(scheduler, new PrivateType(typeof(MultiThreadedTaskScheduler)));
            object tasks = privateScheduler.Invoke("GetScheduledTasks", TestUtils.PrivateInstanceFlags);
            Validate.Value.IsNotNull(tasks, "Could not get scheduled tasks.");
        }
        
        private static void TestTask()
        {
            Thread.Sleep(TimeSpan.FromSeconds(1));
        }
    }
}
