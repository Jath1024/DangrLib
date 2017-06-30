// -----------------------------------------------------------------------
//  <copyright file="ConcurrentScheduledQueue.cs" company="DangerDan9631">
//      Copyright (c) 2017 Dan Garvey. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/Dangerdan9631/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.Collections
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// <para>Maintains a queue of items that can be scheduled to be retrieved
    /// immediately, after a delay, or after a specific time. The 
    /// <see cref="ConcurrentScheduledQueue{T}" /></para>
    /// <para>can be safely accessed and enumerated from multiple threads
    /// concurrently.</para>
    /// </summary>
    /// <typeparam name="T">
    /// The type of value stored in this 
    /// <see cref="ConcurrentScheduledQueue{T}" /> .
    /// </typeparam>
    public class ConcurrentScheduledQueue<T>
    {
        private readonly SortedList<long, T> delayedQueue;
        private readonly object delayedQueueLock = new object();

        private readonly LinkedList<T> immediateQueue;
        private readonly object immediateQueueLock = new object();

        /// <summary>
        /// Gets the number of items enqueued in this <see cref="ConcurrentScheduledQueue{T}" /> .
        /// </summary>
        public int Count
        {
            get
            {
                lock (this.immediateQueueLock)
                    lock (this.delayedQueue)
                    {
                        return this.immediateQueue.Count + this.delayedQueue.Count;
                    }
            }
        }

        /// <summary>
        /// <para>Gets the number of items enqueued in this <see cref="ConcurrentScheduledQueue{T}" /></para>
        /// <para>that are ready to be retrieved immediately.</para>
        /// </summary>
        public int ReadyCount
        {
            get
            {
                lock (this.immediateQueueLock)
                    lock (this.delayedQueue)
                    {
                        long currentTime = DateTimeOffset.UtcNow.UtcTicks;
                        return this.immediateQueue.Count + this.delayedQueue.Count(kvp => kvp.Key < currentTime);
                    }
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConcurrentScheduledQueue{T}" /> class.
        /// </summary>
        public ConcurrentScheduledQueue()
        {
            this.immediateQueue = new LinkedList<T>();
            this.delayedQueue = new SortedList<long, T>();
        }

        /// <summary>
        /// Queues a <paramref name="value" /> to be retrieved immediately.
        /// </summary>
        /// <param name="value">The value to enqueue.</param>
        public void Post(T value)
        {
            this.QueueImmediate(value);
        }

        /// <summary>
        /// Queues a <paramref name="value" /> to be retrieved after a delay.
        /// </summary>
        /// <param name="value">The value to enqueue.</param>
        /// <param name="delay">
        /// The time to wait before retrieving the value.
        /// </param>
        public void PostDelayed(T value, TimeSpan delay)
        {
            this.QueueDelayed(value, DateTimeOffset.UtcNow + delay);
        }

        /// <summary>
        /// Queues a <paramref name="value" /> to be retrieved at a specified time.
        /// </summary>
        /// <param name="value">The value to enqueue.</param>
        /// <param name="time">The time to retrieve the value.</param>
        public void PostAt(T value, DateTimeOffset time)
        {
            this.QueueDelayed(value, time);
        }

        private void QueueImmediate(T value)
        {
            lock (this.immediateQueueLock)
            {
                this.immediateQueue.AddLast(value);
            }
        }

        private void QueueDelayed(T value, DateTimeOffset time)
        {
            lock (this.delayedQueueLock)
            {
                this.delayedQueue.Add(time.UtcTicks, value);
            }
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// An enumerator that can be used to iterate through the collection.
        /// </returns>
        public bool TryGetNext(out T next)
        {
            lock (this.immediateQueueLock)
            {
                if (this.immediateQueue.Count > 0)
                {
                    next = this.immediateQueue.First();
                    this.immediateQueue.RemoveFirst();
                    return true;
                }
            }

            lock (this.delayedQueueLock)
            {
                if ((this.delayedQueue.Count > 0) && (this.delayedQueue.Keys[0] < DateTimeOffset.UtcNow.UtcTicks))
                {
                    next = this.delayedQueue.Values[0];
                    this.delayedQueue.RemoveAt(0);
                    return true;
                }
            }

            next = default(T);
            return false;
        }
    }
}