// -----------------------------------------------------------------------
//  <copyright file="FlexArrayList.T.cs" company="Phoenix Game Studios, LLC">
//      Copyright (c) 2017 Phoenix Game Studios, LLC. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/PhoenixGameStudios/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.Core.FlexCollections.List
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Dangr.Core.Diagnostics;

    /// <summary>
    /// A generic implementation of a <see cref="FlexArrayList"/>.
    /// </summary>
    /// <typeparam name="T">The type of objects contained in the FlexList.</typeparam>
    /// <seealso cref="Dangr.Core.FlexCollections.List.FlexArrayList.IGeneric{T}" />
    public sealed class FlexArrayList<T> : FlexArrayList.IGeneric<T>
    {
        private T[] items;

        /// <inheritdoc />
        public int Count { get; private set; }

        /// <inheritdoc />
        public bool IsEmpty => this.Count == 0;

        /// <inheritdoc />
        public int Capacity => this.items.Length;

        /// <summary>
        /// Gets or sets the object at the specified index.
        /// </summary>
        /// <param name="index">The index of the item.</param>
        /// <returns>The object at the specified index.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if the index is &lt; 0 or &gt;= Count.</exception>
        public T this[int index]
        {
            get => this.Get(index);
            set => this.Set(index, value);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FlexArrayList{T}"/> class.
        /// </summary>
        public FlexArrayList()
            : this(FlexArrayList.DEFAULT_CAPACITY)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FlexArrayList{T}"/> class.
        /// </summary>
        /// <param name="initialCapacity">The initial capacity.</param>
        public FlexArrayList(int initialCapacity)
        {
            this.items = new T[initialCapacity];
            this.Count = 0;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FlexArrayList{T}"/> class.
        /// </summary>
        /// <param name="items">The initial items.</param>
        public FlexArrayList(IEnumerable<T> items)
        {
            this.items = items.ToArray();
            this.Count = this.items.Length;
        }

        /// <inheritdoc />
        public T Get(int index)
        {
            Validate.Argument.IsInRange(index, 0, this.Count - 1);
            return this.items[index];
        }

        /// <inheritdoc />
        public void Set(int index, T value)
        {
            Validate.Argument.IsNotNull(value);
            Validate.Argument.IsInRange(index, 0, this.Count - 1);
            this.items[index] = value;
        }

        /// <inheritdoc />
        public void Add(T item)
        {
            Validate.Argument.IsNotNull(item);
            this.EnsureCapacity(this.Count + 1);
            this.items[this.Count] = item;
            this.Count++;
        }

        /// <inheritdoc />
        public void AddAll(IEnumerable<T> items)
        {
            T[] newItems = items.ToArray();
            this.EnsureCapacity(this.Count + newItems.Length);
            Array.Copy(newItems, 0, this.items, this.Count, newItems.Length);
            this.Count += newItems.Length;
        }

        /// <inheritdoc />
        public void Insert(int index, T value)
        {
            Validate.Argument.IsNotNull(value);
            this.EnsureCapacity(this.Count + 1);
            this.ShiftRight(index, 1);
            this.items[index] = value;
            this.Count++;
        }

        /// <inheritdoc />
        public void InsertAll(int index, IEnumerable<T> values)
        {
            T[] newItems = values.ToArray();
            this.EnsureCapacity(this.Count + newItems.Length);
            this.ShiftRight(index, newItems.Length);
            Array.Copy(newItems, 0, this.items, index, newItems.Length);
            this.Count += newItems.Length;
        }

        /// <inheritdoc />
        public bool Remove(object item)
        {
            if (!(item is T))
            {
                return false;
            }

            return this.Remove((T) item);
        }

        /// <inheritdoc />
        public bool Remove(T item)
        {
            if (item == null)
            {
                return false;
            }

            int index = this.FindIndex(item);
            if (index < 0)
            {
                return false;
            }

            this.RemoveAtIndex(index);
            return true;
        }

        /// <inheritdoc />
        public void RemoveAt(int index)
        {
            Validate.Argument.IsInRange(index, 0, this.Count - 1);
            this.RemoveAtIndex(index);
        }

        /// <inheritdoc />
        public int RemoveAll(IEnumerable items)
        {
            int count = 0;
            foreach (object item in items)
            {
                if (this.Remove(item))
                {
                    count++;
                }
            }

            return count;
        }

        /// <inheritdoc />
        public int RemoveAll(IEnumerable<T> items)
        {
            return items.Count(this.Remove);
        }

        /// <inheritdoc />
        public int RemoveWhere(Predicate<object> predicate)
        {
            int count = 0;
            for (int i = this.Count - 1; i >= 0; i--)
            {
                if (predicate.Invoke(this.items[i]))
                {
                    this.RemoveAt(i);
                    count++;
                }
            }

            return count;
        }

        /// <inheritdoc />
        public int RemoveWhere(Predicate<T> predicate)
        {
            int count = 0;
            for (int i = this.Count - 1; i >= 0; i--)
            {
                if (predicate.Invoke(this.items[i]))
                {
                    this.RemoveAt(i);
                    count++;
                }
            }

            return count;
        }

        /// <inheritdoc />
        public void Clear()
        {
            this.items = new T[FlexArrayList.DEFAULT_CAPACITY];
            this.Count = 0;
        }

        /// <inheritdoc />
        public bool Contains(object item)
        {
            return this.IndexOf(item) >= 0;
        }

        /// <inheritdoc />
        public bool Contains(T item)
        {
            return this.IndexOf(item) >= 0;
        }

        /// <inheritdoc />
        public bool ContainsAny(IEnumerable items)
        {
            foreach (object item in items)
            {
                if (this.IndexOf(item) >= 0)
                {
                    return true;
                }
            }

            return false;
        }

        /// <inheritdoc />
        public bool ContainsAny(IEnumerable<T> items)
        {
            return items.Any(item => this.IndexOf(item) >= 0);
        }

        /// <inheritdoc />
        public bool ContainsAll(IEnumerable items)
        {
            foreach (object item in items)
            {
                if (this.IndexOf(item) < 0)
                {
                    return false;
                }
            }

            return true;
        }

        /// <inheritdoc />
        public bool ContainsAll(IEnumerable<T> items)
        {
            return items.All(item => this.IndexOf(item) >= 0);
        }

        /// <inheritdoc />
        public int IndexOf(object item)
        {
            if (!(item is T))
            {
                return FlexList.INDEX_NOT_FOUND;
            }

            return this.IndexOf((T) item);
        }

        /// <inheritdoc />
        public int IndexOf(T item)
        {
            return this.IndexOf(item, 0, this.Count);
        }

        /// <inheritdoc />
        public int IndexOf(object item, int start)
        {
            if (!(item is T))
            {
                return FlexList.INDEX_NOT_FOUND;
            }

            return this.IndexOf((T) item, start);
        }

        /// <inheritdoc />
        public int IndexOf(T item, int start)
        {
            return this.IndexOf(item, start, this.Count - start);
        }

        /// <inheritdoc />
        public int IndexOf(object item, int start, int count)
        {
            if (!(item is T))
            {
                return FlexList.INDEX_NOT_FOUND;
            }

            return this.IndexOf((T) item, start, count);
        }

        /// <inheritdoc />
        public int IndexOf(T item, int start, int count)
        {
            if (item == null)
            {
                return FlexList.INDEX_NOT_FOUND;
            }

            for (int i = start; i < start + count && i < this.Count; i++)
            {
                if (this.items[i].Equals(item))
                {
                    return i;
                }
            }

            return FlexList.INDEX_NOT_FOUND;
        }

        /// <inheritdoc />
        public IEnumerator<T> GetEnumerator()
        {
            return new ListEnumerator(this);
        }

        /// <inheritdoc />
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        /// <summary>
        /// Finds the index of the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>The index of the specified item, or -1 if it isn't found.</returns>
        private int FindIndex(T item)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.items[i].Equals(item))
                {
                    return i;
                }
            }

            return FlexList.INDEX_NOT_FOUND;
        }

        /// <summary>
        /// Ensures the base array has the desired capacity, expanding it if necessary.
        /// </summary>
        /// <param name="desiredCapacity">The desired capacity.</param>
        private void EnsureCapacity(int desiredCapacity)
        {
            if (this.items.Length < desiredCapacity)
            {
                int newCapacity = this.items.Length * 2;
                if (newCapacity == 0)
                {
                    newCapacity = FlexArrayList.DEFAULT_CAPACITY;
                }

                while (newCapacity < desiredCapacity)
                {
                    newCapacity *= 2;
                }

                var newArray = new T[newCapacity];
                Array.Copy(this.items, newArray, this.items.Length);
                this.items = newArray;
            }
        }

        /// <summary>
        /// Removes a single item at the given index, collapsing the array afterwards.
        /// </summary>
        /// <param name="index">The index.</param>
        private void RemoveAtIndex(int index)
        {
            int length = this.Count - index - 1;
            Array.Copy(this.items, index + 1, this.items, index, length);
            this.items[this.Count - 1] = default(T);
            this.Count--;
        }

        /// <summary>
        /// Shifts elements in the array to the right by the given amount.
        /// </summary>
        /// <param name="startIndex">The start index.</param>
        /// <param name="amount">The amount.</param>
        private void ShiftRight(int startIndex, int amount)
        {
            int length = this.Count - startIndex;
            Array.Copy(this.items, startIndex, this.items, startIndex + amount, length);
        }

        /// <summary>
        /// Enumerator for a FlexArrayList instance.
        /// </summary>
        /// <seealso cref="Dangr.Core.FlexCollections.List.FlexArrayList.IGeneric{T}" />
        private class ListEnumerator : IEnumerator<T>
        {
            /// <summary>
            /// The initial value for current index.
            /// </summary>
            /// <remarks>
            /// currentIndex starts at -1 because MoveNext() will be called before
            /// the first item is accessed.
            /// </remarks>
            private const int START_INDEX = -1;

            private int currentIndex = FlexArrayList<T>.ListEnumerator.START_INDEX;
            private FlexArrayList<T> list;

            /// <inheritdoc />
            public T Current => this.list.items[this.currentIndex];

            /// <inheritdoc />
            object IEnumerator.Current => this.Current;

            /// <summary>
            /// Initializes a new instance of the <see cref="ListEnumerator"/> class.
            /// </summary>
            /// <param name="list">The list to enumerate.</param>
            public ListEnumerator(FlexArrayList<T> list)
            {
                this.list = list;
            }

            /// <inheritdoc />
            public void Dispose()
            {
                this.list = null;
            }

            /// <inheritdoc />
            public bool MoveNext()
            {
                this.currentIndex++;
                return this.currentIndex < this.list.Count;
            }

            /// <inheritdoc />
            public void Reset()
            {
                this.currentIndex = FlexArrayList<T>.ListEnumerator.START_INDEX;
            }
        }
    }
}