// -----------------------------------------------------------------------
//  <copyright file="FlexDoublyLinkedList.T.cs" company="Phoenix Game Studios, LLC">
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
    /// A generic implementation of a <see cref="FlexDoublyLinkedList"/>.
    /// </summary>
    /// <typeparam name="T">The type of objects contained in the FlexList.</typeparam>
    /// <seealso cref="Dangr.Core.FlexCollections.List.FlexDoublyLinkedList.IGeneric{T}" />
    public class FlexDoublyLinkedList<T> : FlexDoublyLinkedList.IGeneric<T>
    {
        private LinkedListNode head;
        private LinkedListNode tail;

        /// <inheritdoc />
        public int Count { get; private set; }

        /// <inheritdoc />
        public bool IsEmpty => this.Count == 0;

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
        
        public FlexDoublyLinkedList()
        {
        }

        public FlexDoublyLinkedList(IEnumerable<T> items)
        {
            this.AddAll(items);
        }

        /// <inheritdoc />
        public T Get(int index)
        {
            return this.GetNodeAt(index).Value;
        }

        /// <inheritdoc />
        public T GetFirst()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Cannot get first element of empty list.");
            }

            return this.head.Value;
        }

        /// <inheritdoc />
        public T GetLast()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Cannot get last element of empty list.");
            }

            return this.tail.Value;
        }

        /// <inheritdoc />
        public void Set(int index, T value)
        {
            Validate.Argument.IsNotNull(value);
            Validate.Argument.IsInRange(index, 0, this.Count - 1);
            if (index == 0)
            {
                this.head = this.ReplaceNode(this.head, value);
            }
            else
            {
                this.ReplaceNode(this.GetNodeAt(index), value);
            }
        }

        /// <inheritdoc />
        public void Add(T item)
        {
            Validate.Argument.IsNotNull(item);
            
            if(this.tail == null)
            {
                LinkedListNode newNode = this.AppendNode(null, item);
                this.head = newNode;
                this.tail = newNode;
            }
            else
            {
                LinkedListNode newNode = this.AppendNode(this.tail, item);
                this.tail = newNode;
            }

            this.Count++;
        }

        /// <inheritdoc />
        public void AddAll(IEnumerable<T> items)
        {
            int numNewNodes = this.CreateSubList(items, out var subListHead, out var subListTail);
            if(this.tail == null)
            {
                this.head = subListHead;
            }
            else
            {
                this.AppendNode(this.tail, subListHead);
            }

            this.tail = subListTail;
            this.Count += numNewNodes;
        }

        /// <inheritdoc />
        public void Insert(int index, T value)
        {
            Validate.Argument.IsNotNull(value);
            Validate.Argument.IsInRange(index, 0, this.Count);
            if (index == 0)
            {
                this.head = this.InsertNode(null, this.head, value);
            }
            else if (index == this.Count)
            {
                this.tail = this.InsertNode(this.tail, null, value);
            }
            else
            {
                LinkedListNode prevNode = this.GetNodeAt(index - 1);
                this.InsertNode(prevNode, prevNode.Next, value);
            }

            this.Count++;
        }

        /// <inheritdoc />
        public void InsertAll(int index, IEnumerable<T> values)
        {
            Validate.Argument.IsInRange(index, 0, this.Count);

            int numNewNodes = this.CreateSubList(values, out var subListHead, out var subListTail);
            if (index == this.Count)
            {
                this.AppendNode(this.tail, subListHead);
                this.tail = subListTail;
            }
            else if (index == 0)
            {
                this.AppendNode(subListTail, this.head);
                this.head = subListHead;
            }
            else
            {
                LinkedListNode prevNode = this.GetNodeAt(index - 1);
                this.AppendNode(subListTail, prevNode.Next);
                this.AppendNode(prevNode, subListHead);
            }

            this.Count += numNewNodes;
        }

        /// <inheritdoc />
        public bool Remove(object item)
        {
            if (!(item is T))
            {
                return false;
            }

            return this.Remove((T)item);
        }

        /// <inheritdoc />
        public bool Remove(T item)
        {
            if (item == null)
            {
                return false;
            }

            if(this.GetNode(item, out var prevNode, out var itemNode))
            {
                if(prevNode == null)
                {
                    this.head = itemNode.Next;
                }

                this.RemoveNode(prevNode, itemNode);
                if(this.tail.Equals(itemNode))
                {
                    this.tail = prevNode;
                }

                this.Count--;
                return true;
            }

            return false;
        }

        /// <inheritdoc />
        public bool RemoveLast(object item)
        {
            if (!(item is T))
            {
                return false;
            }

            return this.RemoveLast((T)item);
        }

        /// <inheritdoc />
        public bool RemoveLast(T item)
        {
            if (item == null)
            {
                return false;
            }

            if (this.GetLastNode(item, out var prevNode, out var itemNode))
            {
                if (prevNode == null)
                {
                    this.head = itemNode.Next;
                }

                this.RemoveNode(prevNode, itemNode);
                if (this.tail.Equals(itemNode))
                {
                    this.tail = prevNode;
                }

                this.Count--;
                return true;
            }

            return false;
        }

        /// <inheritdoc />
        public void RemoveAt(int index)
        {
            Validate.Argument.IsInRange(index, 0, this.Count - 1);

            if(index == 0)
            {
                if (this.Count == 1)
                {
                    this.head = null;
                    this.tail = null;
                }
                else
                {
                    this.head = this.head.Next;
                    this.head.Prev = null;
                }
            }
            else
            {
                LinkedListNode prevNode = this.GetNodeAt(index - 1);
                if(prevNode.Next.Equals(this.tail))
                {
                    this.tail = prevNode;
                }

                this.RemoveNode(prevNode, prevNode.Next);
            }

            this.Count--;
        }

        /// <inheritdoc />
        public int RemoveAll(IEnumerable items)
        {
            int numRemoved = 0;
            foreach(var item in items)
            {
                if(this.Remove(item))
                {
                    numRemoved++;
                }
            }

            return numRemoved;
        }

        /// <inheritdoc />
        public int RemoveAll(IEnumerable<T> items)
        {
            int numRemoved = 0;
            foreach (var item in items)
            {
                if (this.Remove(item))
                {
                    numRemoved++;
                }
            }

            return numRemoved;
        }

        /// <inheritdoc />
        public int RemoveWhere(Predicate<object> predicate)
        {
            int numRemoved = 0;
            LinkedListNode prevNode = null;
            LinkedListNode currentNode = this.head;
            while (currentNode != null)
            {
                if (predicate.Invoke(currentNode.Value))
                {
                    this.RemoveNode(prevNode, currentNode);
                    if (currentNode.Equals(this.head))
                    {
                        this.head = currentNode.Next;
                    }

                    if (currentNode.Equals(this.tail))
                    {
                        this.tail = prevNode;
                    }

                    currentNode = currentNode.Next;
                    numRemoved++;
                }
                else
                {
                    prevNode = currentNode;
                    currentNode = currentNode.Next;
                }
            }

            this.Count -= numRemoved;
            return numRemoved;
        }

        /// <inheritdoc />
        public int RemoveWhere(Predicate<T> predicate)
        {
            int numRemoved = 0;
            LinkedListNode prevNode = null;
            LinkedListNode currentNode = this.head;
            while (currentNode != null)
            {
                if (predicate.Invoke(currentNode.Value))
                {
                    this.RemoveNode(prevNode, currentNode);
                    if(currentNode.Equals(this.head))
                    {
                        this.head = currentNode.Next;
                    }

                    if(currentNode.Equals(this.tail))
                    {
                        this.tail = prevNode;
                    }

                    currentNode = currentNode.Next;
                    numRemoved++;
                }
                else
                {
                    prevNode = currentNode;
                    currentNode = currentNode.Next;
                }
            }

            this.Count -= numRemoved;
            return numRemoved;
        }

        /// <inheritdoc />
        public bool RemoveFirstElement()
        {
            if (this.Count == 0)
            {
                return false;
            }

            this.head = this.head.Next;
            this.Count--;
            return true;
        }

        /// <inheritdoc />
        public bool RemoveLastElement()
        {
            if (this.Count == 0)
            {
                return false;
            }

            this.tail = this.tail.Prev;
            this.Count--;
            return true;
        }

        /// <inheritdoc />
        public void Clear()
        {
            this.head = null;
            this.tail = null;
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

            return this.IndexOf((T)item);
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

            return this.IndexOf((T)item, start);
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

            return this.IndexOf((T)item, start, count);
        }

        /// <inheritdoc />
        public int IndexOf(T item, int start, int count)
        {
            if (item == null)
            {
                return FlexList.INDEX_NOT_FOUND;
            }

            return this.GetIndex(item, start, count);
        }

        /// <inheritdoc />
        public int LastIndexOf(object item)
        {
            if (!(item is T))
            {
                return FlexList.INDEX_NOT_FOUND;
            }

            return this.LastIndexOf((T)item);
        }

        /// <inheritdoc />
        public int LastIndexOf(T item)
        {
            return this.LastIndexOf(item, this.Count - 1, this.Count);
        }

        /// <inheritdoc />
        public int LastIndexOf(object item, int end)
        {
            if (!(item is T))
            {
                return FlexList.INDEX_NOT_FOUND;
            }

            return this.LastIndexOf((T)item, end);
        }

        /// <inheritdoc />
        public int LastIndexOf(T item, int end)
        {
            return this.LastIndexOf(item, end, Math.Max(this.Count, this.Count - end));
        }

        /// <inheritdoc />
        public int LastIndexOf(object item, int end, int count)
        {
            if (!(item is T))
            {
                return FlexList.INDEX_NOT_FOUND;
            }

            return this.LastIndexOf((T)item, end, count);
        }

        /// <inheritdoc />
        public int LastIndexOf(T item, int end, int count)
        {
            if (item == null)
            {
                return FlexList.INDEX_NOT_FOUND;
            }

            return this.GetLastIndex(item, end, count);
        }

        /// <inheritdoc />
        public IEnumerator<T> GetEnumerator()
        {
            return new ListEnumerator(this.head);
        }

        /// <inheritdoc />
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        /// <inheritdoc />
        public IEnumerator<T> GetReverseEnumerator()
        {
            return new ListReverseEnumerator(this.tail);
        }

        /// <summary>
        /// Gets the node at the specified index.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns>The node at that index.</returns>
        /// <exception cref="ArgumentOutOfRangeException"> Thrown if the index &lt; 0 or &gt;= Count.</exception>
        private LinkedListNode GetNodeAt(int index)
        {
            Validate.Argument.IsInRange(index, 0, this.Count - 1);
            LinkedListNode currentNode = this.head;
            for (int i = 0; i < index; i++)
            {
                currentNode = currentNode.Next;
            }

            return currentNode;
        }

        /// <summary>
        /// Gets the first node that contains the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="prevNode">The node before the node with the specified item. Will be null if 
        /// the head node contains the item.</param>
        /// <param name="itemNode">The node that contains the item.</param>
        /// <returns><c>true</c> if a node containing the item was found, otherwise <c>false</c>.</returns>
        /// <remarks>The value of prevNode, and itemNode is undefined if the return value is false.</remarks>
        private bool GetNode(T item, out LinkedListNode prevNode, out LinkedListNode itemNode)
        {
            prevNode = null;
            itemNode = this.head;
            while(itemNode != null)
            {
                if(itemNode.Value.Equals(item))
                {
                    return true;
                }

                prevNode = itemNode;
                itemNode = itemNode.Next;
            }

            return false;
        }

        /// <summary>
        /// Gets the last node that contains the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="prevNode">The node before the last node with the specified item. Will be null if 
        /// the head node contains the item.</param>
        /// <param name="itemNode">The last node that contains the item.</param>
        /// <returns><c>true</c> if a node containing the item was found, otherwise <c>false</c>.</returns>
        /// <remarks>The value of prevNode, and itemNode is undefined if the return value is false.</remarks>
        private bool GetLastNode(T item, out LinkedListNode prevNode, out LinkedListNode itemNode)
        {
            prevNode = this.tail.Prev;
            itemNode = this.tail;
            while (itemNode != null)
            {
                if (itemNode.Value.Equals(item))
                {
                    return true;
                }

                itemNode = prevNode;
                prevNode = prevNode?.Prev;
            }

            return false;
        }

        /// <summary>
        /// Gets the index of the node that contains the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="start">The index to start looking from.</param>
        /// <param name="count">The number of nodes after the start index to begin searching.</param>
        /// <returns>The index of the first node in range that contains the item, or -1 if the item was not found.</returns>
        private int GetIndex(T item, int start, int count)
        {
            int index = 0;
            LinkedListNode itemNode = this.head;
            while (itemNode != null && index < start + count)
            {
                if (index >= start && itemNode.Value.Equals(item))
                {
                    return index;
                }
                
                itemNode = itemNode.Next;
                index++;
            }

            return FlexList.INDEX_NOT_FOUND;
        }

        /// <summary>
        /// Gets the index of the last node that contains the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="end">The index to start looking from.</param>
        /// <param name="count">The number of nodes before the end index to begin searching.</param>
        /// <returns>The index of the first node in range that contains the item, or -1 if the item was not found.</returns>
        private int GetLastIndex(T item, int end, int count)
        {
            int index = this.Count - 1;
            LinkedListNode itemNode = this.tail;
            while (itemNode != null && index >= end - count)
            {
                if (index < end && itemNode.Value.Equals(item))
                {
                    return index;
                }

                itemNode = itemNode.Prev;
                index--;
            }

            return FlexList.INDEX_NOT_FOUND;
        }

        /// <summary>
        /// Creates the a sub list of LinkedListNodes from the given IEnumerable.
        /// </summary>
        /// <param name="values">The values to create the sublist from.</param>
        /// <param name="head">The head of the sublist.</param>
        /// <param name="tail">The tail of the sublist.</param>
        /// <returns>The number of items in the sublist.</returns>
        /// <remarks>Both head and tail will be null if the given enumerable does not contain any items.</remarks>
        private int CreateSubList(IEnumerable<T> values, out LinkedListNode head, out LinkedListNode tail)
        {
            int numNewNodes = 0;
            head = null;
            tail = null;
            foreach (T value in values)
            {
                tail = this.AppendNode(tail, value);
                numNewNodes++;
                if (head == null)
                {
                    // This was the first node created.
                    head = tail;
                }
            }

            return numNewNodes;
        }

        /// <summary>
        /// Appends a new node with the given value to the given prevNode.
        /// </summary>
        /// <param name="prevNode">The previous node to append to. Can be null.</param>
        /// <param name="newValue">The new value to append.</param>
        /// <returns>The newly created node.</returns>
        private LinkedListNode AppendNode(LinkedListNode prevNode, T newValue)
        {
            return this.AppendNode(prevNode, new LinkedListNode(newValue));
        }

        /// <summary>
        /// Appends a node to the given prevNode.
        /// </summary>
        /// <param name="prevNode">The previous node to append to. Can be null.</param>
        /// <param name="newNode">The new node.</param>
        /// <returns>The given New Node.</returns>
        private LinkedListNode AppendNode(LinkedListNode prevNode, LinkedListNode newNode)
        {
            if (prevNode != null)
            {
                prevNode.Next = newNode;
            }

            if(newNode != null)
            {
                newNode.Prev = prevNode;
            }

            return newNode;
        }

        /// <summary>
        /// Inserts a new node with the given value inbetween the two given nodes.
        /// </summary>
        /// <param name="prevNode">The node to insert the new node after. Can be null.</param>
        /// <param name="nextNode">The node to insert the new node before. Can be null.</param>
        /// <param name="newValue">The new value to insert.</param>
        /// <returns>The newly created node.</returns>
        private LinkedListNode InsertNode(LinkedListNode prevNode, LinkedListNode nextNode, T newValue)
        {
            LinkedListNode newNode = this.AppendNode(prevNode, newValue);
            this.AppendNode(newNode, nextNode);

            return newNode;
        }

        /// <summary>
        /// Replaces the node with a new node containing the given value.
        /// </summary>
        /// <param name="oldNode">The old node to replace.</param>
        /// <param name="newValue">The new value.</param>
        /// <returns>The newly created node.</returns>
        private LinkedListNode ReplaceNode(LinkedListNode oldNode, T newValue)
        {
            LinkedListNode newNode = this.AppendNode(oldNode.Prev, newValue);
            newNode.Next = oldNode.Next;

            return newNode;
        }

        /// <summary>
        /// Removes the node.
        /// </summary>
        /// <param name="prevNode">The previous node.</param>
        /// <param name="removeNode">The remove node.</param>
        private void RemoveNode(LinkedListNode prevNode, LinkedListNode removeNode)
        {
            if (prevNode != null)
            {
                prevNode.Next = removeNode.Next;
            }

            if(removeNode.Next != null)
            {
                removeNode.Prev = prevNode;
            }
        }

        /// <summary>
        /// A node in the linked list.
        /// </summary>
        /// <seealso cref="Dangr.Core.FlexCollections.List.FlexDoublyLinkedList.IGeneric{T}" />
        private class LinkedListNode
        {
            /// <summary>
            /// Gets the value contained in this linked list node.
            /// </summary>
            public T Value { get; }

            /// <summary>
            /// Gets or sets the next node in the linked list. Can be null.
            /// </summary>
            public LinkedListNode Next { get; set; }
            
            /// <summary>
            /// Gets or sets the previous node in the linked list. Can be null.
            /// </summary>
            public LinkedListNode Prev { get; set; }

            /// <summary>
            /// Initializes a new instance of the <see cref="LinkedListNode"/> class.
            /// </summary>
            /// <param name="value">The value contained in the node.</param>
            public LinkedListNode(T value)
            {
                this.Value = value;
            }
        }

        /// <summary>
        /// Enumerator for a FlexDoublyLinkedList instance.
        /// </summary>
        /// <seealso cref="Dangr.Core.FlexCollections.List.FlexDoublyLinkedList.IGeneric{T}" />
        private class ListEnumerator : IEnumerator<T>
        {
            private LinkedListNode headNode;
            private LinkedListNode currentNode;

            /// <inheritdoc />
            public T Current => this.currentNode == null ? default(T) : this.currentNode.Value;
            
            /// <inheritdoc />
            object IEnumerator.Current => this.Current;

            /// <summary>
            /// Initializes a new instance of the <see cref="ListEnumerator"/> class.
            /// </summary>
            /// <param name="headNode">The headNode in the list to enumerate. Can be null.</param>
            public ListEnumerator(LinkedListNode headNode)
            {
                this.headNode = headNode;
                this.currentNode = null;
            }

            /// <inheritdoc />
            public void Dispose()
            {
                this.headNode = null;
                this.currentNode = null;
            }

            /// <inheritdoc />
            public bool MoveNext()
            {
                this.currentNode = this.currentNode == null
                    ? this.headNode 
                    : this.currentNode.Next;

                return this.currentNode != null;
            }

            /// <inheritdoc />
            public void Reset()
            {
                this.currentNode = null;
            }
        }


        /// <summary>
        /// Reverse Enumerator for a FlexDoublyLinkedList instance.
        /// </summary>
        /// <seealso cref="Dangr.Core.FlexCollections.List.FlexDoublyLinkedList.IGeneric{T}" />
        private class ListReverseEnumerator : IEnumerator<T>
        {
            private LinkedListNode tailNode;
            private LinkedListNode currentNode;

            /// <inheritdoc />
            public T Current => this.currentNode == null ? default(T) : this.currentNode.Value;

            /// <inheritdoc />
            object IEnumerator.Current => this.Current;

            /// <summary>
            /// Initializes a new instance of the <see cref="ListEnumerator"/> class.
            /// </summary>
            /// <param name="tailNode">The tailNode in the list to enumerate. Can be null.</param>
            public ListReverseEnumerator(LinkedListNode tailNode)
            {
                this.tailNode = tailNode;
                this.currentNode = null;
            }

            /// <inheritdoc />
            public void Dispose()
            {
                this.tailNode = null;
                this.currentNode = null;
            }

            /// <inheritdoc />
            public bool MoveNext()
            {
                this.currentNode = this.currentNode == null
                    ? this.tailNode
                    : this.tailNode.Prev;

                return this.currentNode != null;
            }

            /// <inheritdoc />
            public void Reset()
            {
                this.currentNode = null;
            }
        }
    }
}