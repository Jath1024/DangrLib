// -----------------------------------------------------------------------
//  <copyright file="MultiThreadedTaskScheduler.cs" company="DangerDan9631">
//      Copyright (c) 2017 Dan Garvey. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/Dangerdan9631/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
//  <dateCreated>2017-04-25</dateCreated>
//  <dateModified>2017-06-20</dateModified>
//  <lastModifiedBy>Dan Garvey</lastModifiedBy>
// -----------------------------------------------------------------------

namespace Dangr.Async
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Provides a task scheduler that ensures a maximum concurrency level while
    /// running on top of the thread pool.
    /// </summary>
    public class MultiThreadedTaskScheduler : TaskScheduler
    {
        [ThreadStatic] private static bool currentThreadIsProcessingItems;

        private readonly LinkedList<Task> tasks;

        private readonly object tasksLock = new object();

        /// <summary>
        /// Gets the number threads currently running.
        /// </summary>
        public int NumThreadsRunning { get; private set; }

        /// <summary>
        /// Gets the maximum concurrency level supported by this scheduler.
        /// </summary>
        public sealed override int MaximumConcurrencyLevel { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultiThreadedTaskScheduler" /> class.
        /// </summary>
        /// <param name="maxThreads">
        /// The maximum number of thread that can be run concurrently.
        /// </param>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// Thrown if the maximum number of threads is %lt;= 0.
        /// </exception>
        public MultiThreadedTaskScheduler(int maxThreads)
        {
            if (maxThreads < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(maxThreads), "The maximum number of threads must be >= 1.");
            }

            this.MaximumConcurrencyLevel = maxThreads;
            this.tasks = new LinkedList<Task>();
        }

        /// <summary>
        /// Queues a <paramref name="task" /> to the scheduler.
        /// </summary>
        /// <param name="task">The task.</param>
        protected sealed override void QueueTask(Task task)
        {
            if (task == null)
            {
                throw new ArgumentNullException(nameof(task));
            }

            lock (this.tasksLock)
            {
                this.tasks.AddLast(task);
                if (this.NumThreadsRunning < this.MaximumConcurrencyLevel)
                {
                    this.NumThreadsRunning++;
                    this.NotifyThreadPoolOfPendingWork();
                }
            }
        }

        /// <summary>
        /// Attempts to execute the specified <paramref name="task" /> on the current thread.
        /// </summary>
        /// <param name="task">The task to execute.</param>
        /// <param name="taskWasPreviouslyQueued">
        /// Indicates whether this <paramref name="task" /> was previously queued.
        /// </param>
        /// <returns>
        /// True if the <paramref name="task" /> was executed.
        /// </returns>
        protected sealed override bool TryExecuteTaskInline(Task task, bool taskWasPreviouslyQueued)
        {
            if (task == null)
            {
                throw new ArgumentNullException(nameof(task));
            }

            if (!MultiThreadedTaskScheduler.currentThreadIsProcessingItems)
            {
                return false;
            }

            if (!taskWasPreviouslyQueued || this.TryDequeue(task))
            {
                return this.TryExecuteTask(task);
            }

            return false;
        }

        /// <summary>
        /// Attempt to remove a previously scheduled <paramref name="task" /> from the scheduler.
        /// </summary>
        /// <param name="task">The task to remove.</param>
        /// <returns>
        /// <see langword="true" /> if the <paramref name="task" /> was removed.
        /// </returns>
        protected sealed override bool TryDequeue(Task task)
        {
            if (task == null)
            {
                throw new ArgumentNullException(nameof(task));
            }

            lock (this.tasksLock)
            {
                return this.tasks.Remove(task);
            }
        }

        /// <summary>
        /// Gets an enumerable of the <see cref="Dangr.Async.MultiThreadedTaskScheduler.tasks" /> currently scheduled on this scheduler.
        /// </summary>
        /// <returns>
        /// An enumerable of the <see cref="Dangr.Async.MultiThreadedTaskScheduler.tasks" /> currently scheduled on this scheduler.
        /// </returns>
        protected sealed override IEnumerable<Task> GetScheduledTasks()
        {
            var lockTaken = false;
            try
            {
                Monitor.TryEnter(this.tasksLock, ref lockTaken);
                if (lockTaken)
                {
                    return this.tasks;
                }

                throw new NotSupportedException();
            }
            finally
            {
                if (lockTaken)
                {
                    Monitor.Exit(this.tasks);
                }
            }
        }

        private void NotifyThreadPoolOfPendingWork()
        {
            ThreadPool.UnsafeQueueUserWorkItem(
                state =>
                {
                    MultiThreadedTaskScheduler.currentThreadIsProcessingItems = true;
                    try
                    {
                        while (true)
                        {
                            Task item;
                            lock (this.tasksLock)
                            {
                                if (this.tasks.Count == 0)
                                {
                                    this.NumThreadsRunning--;
                                    break;
                                }

                                item = this.tasks.First.Value;
                                this.tasks.RemoveFirst();
                            }

                            this.TryExecuteTask(item);
                        }
                    }
                    finally
                    {
                        MultiThreadedTaskScheduler.currentThreadIsProcessingItems = false;
                    }
                },
                null);
        }
    }
}