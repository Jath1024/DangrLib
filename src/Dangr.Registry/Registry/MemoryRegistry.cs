// -----------------------------------------------------------------------
//  <copyright file="MemoryRegistry.cs" company="DangerDan9631">
//      Copyright (c) 2017 Dan Garvey. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/Dangerdan9631/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.Registry
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Runtime.Serialization;
    using System.Text;
    using System.Threading;

    /// <summary>
    ///     Provides access to a shared set of data in memory.
    /// </summary>
    [DataContract]
    public sealed class MemoryRegistry : IRegistry
    {
        [DataMember]
        private Dictionary<string, string> values;

        [IgnoreDataMember]
        private object writeLock;

        /// <summary>
        ///     Gets the number of elements stored in this <see cref="IRegistry" />.
        /// </summary>
        public int Count => this.values.Count;

        /// <summary>
        ///     Occurs when a value stored in this <see cref="IRegistry" /> is added, updated, or removed.
        /// </summary>
        public event EventHandler<RegistryValueChangedEventArgs> ValueChanged;

        /// <summary>
        ///     Initializes a new instance of the <see cref="IRegistry" /> class.
        /// </summary>
        public MemoryRegistry()
        {
            this.values = new Dictionary<string, string>();
            this.Initialize();
        }

        [OnDeserialized]
        private void DeserializeInitialization(StreamingContext ctx)
        {
            this.Initialize();
        }

        private void Initialize()
        {
            this.writeLock = new object();
        }

        /// <summary>
        ///     Gets all values from the registry.
        /// </summary>
        /// <returns> A <see cref="IDictionary{TKey, TValue}" /> containing all the values in the registry. </returns>
        public IDictionary<string, string> GetValues()
        {
            return new Dictionary<string, string>(this.values);
        }

        /// <summary>
        ///     Gets a bool value from the <see cref="IRegistry" />.
        /// </summary>
        /// <param name="key"> The key used to store the value in the <see cref="IRegistry" />. </param>
        /// <param name="defaultValue"> The default value to return if the specified key is not found. </param>
        /// <exception cref="ArgumentException">
        ///     Thrown when the value stored with the specified key is not compatible with the
        ///     requested type.
        /// </exception>
        /// <returns> The value stored in the registry with the specified key, or the given default value if not found. </returns>
        public bool GetBool(string key, bool defaultValue)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw RegistryException.InvalidKeyException(key);
            }

            string valStr = this.GetValue(key);
            if (valStr == null)
            {
                return defaultValue;
            }

            bool ret;
            if (bool.TryParse(valStr, out ret))
            {
                return ret;
            }

            throw RegistryException.RegistryValueNotFoundException(key, typeof(bool));
        }

        /// <summary>
        ///     Gets an int value from the <see cref="IRegistry" />.
        /// </summary>
        /// <param name="key"> The key used to store the value in the <see cref="IRegistry" />. </param>
        /// <param name="defaultValue"> The default value to return if the specified key is not found. </param>
        /// <exception cref="ArgumentException">
        ///     Thrown when the value stored with the specified key is not compatible with the
        ///     requested type.
        /// </exception>
        /// <returns> The value stored in the registry with the specified key, or the given default value if not found. </returns>
        public int GetInt(string key, int defaultValue)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw RegistryException.InvalidKeyException(key);
            }

            string valStr = this.GetValue(key);
            if (valStr == null)
            {
                return defaultValue;
            }

            int ret;
            if (int.TryParse(valStr, out ret))
            {
                return ret;
            }

            throw RegistryException.RegistryValueNotFoundException(key, typeof(int));
        }

        /// <summary>
        ///     Gets an long value from the <see cref="IRegistry" />.
        /// </summary>
        /// <param name="key"> The key used to store the value in the <see cref="IRegistry" />. </param>
        /// <param name="defaultValue"> The default value to return if the specified key is not found. </param>
        /// <exception cref="ArgumentException">
        ///     Thrown when the value stored with the specified key is not compatible with the
        ///     requested type.
        /// </exception>
        /// <returns> The value stored in the registry with the specified key, or the given default value if not found. </returns>
        public long GetLong(string key, long defaultValue)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw RegistryException.InvalidKeyException(key);
            }

            string valStr = this.GetValue(key);
            if (valStr == null)
            {
                return defaultValue;
            }

            long ret;
            if (long.TryParse(valStr, out ret))
            {
                return ret;
            }

            throw RegistryException.RegistryValueNotFoundException(key, typeof(long));
        }

        /// <summary>
        ///     Gets a float value from the <see cref="IRegistry" />.
        /// </summary>
        /// <param name="key"> The key used to store the value in the <see cref="IRegistry" />. </param>
        /// <param name="defaultValue"> The default value to return if the specified key is not found. </param>
        /// <exception cref="ArgumentException">
        ///     Thrown when the value stored with the specified key is not compatible with the
        ///     requested type.
        /// </exception>
        /// <returns> The value stored in the registry with the specified key, or the given default value if not found. </returns>
        public float GetFloat(string key, float defaultValue)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw RegistryException.InvalidKeyException(key);
            }

            string valStr = this.GetValue(key);
            if (valStr == null)
            {
                return defaultValue;
            }

            float ret;
            if (float.TryParse(valStr, out ret))
            {
                return ret;
            }

            throw RegistryException.RegistryValueNotFoundException(key, typeof(float));
        }

        /// <summary>
        ///     Gets a double value from the <see cref="IRegistry" />.
        /// </summary>
        /// <param name="key"> The key used to store the value in the <see cref="IRegistry" />. </param>
        /// <param name="defaultValue"> The default value to return if the specified key is not found. </param>
        /// <exception cref="ArgumentException">
        ///     Thrown when the value stored with the specified key is not compatible with the
        ///     requested type.
        /// </exception>
        /// <returns> The value stored in the registry with the specified key, or the given default value if not found. </returns>
        public double GetDouble(string key, double defaultValue)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw RegistryException.InvalidKeyException(key);
            }

            string valStr = this.GetValue(key);
            if (valStr == null)
            {
                return defaultValue;
            }

            double ret;
            if (double.TryParse(valStr, out ret))
            {
                return ret;
            }

            throw RegistryException.RegistryValueNotFoundException(key, typeof(double));
        }

        /// <summary>
        ///     Gets a string value from the <see cref="IRegistry" />.
        /// </summary>
        /// <param name="key"> The key used to store the value in the <see cref="IRegistry" />. </param>
        /// <param name="defaultValue"> The default value to return if the specified key is not found. </param>
        /// <returns> The value stored in the registry with the specified key, or the given default value if not found. </returns>
        public string GetString(string key, string defaultValue)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw RegistryException.InvalidKeyException(key);
            }

            string valStr = this.GetValue(key);
            if (valStr == null)
            {
                return defaultValue;
            }

            return valStr;
        }

        /// <summary>
        ///     Create a new editor for this registry.
        /// </summary>
        /// <returns> A new editor for this registry. </returns>
        public IRegistryEditor Edit()
        {
            return new MemoryRegistryEditor(this);
        }

        /// <summary>
        ///     Returns a string that represents the current object.
        /// </summary>
        /// <returns> A string that represents the current object. </returns>
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            lock (this.writeLock)
            {
                foreach (KeyValuePair<string, string> kvp in this.values)
                {
                    builder.AppendFormat("{0}:{1}", kvp.Key, kvp.Value);
                    builder.AppendLine();
                }

                return builder.ToString();
            }
        }

        private string GetValue(string key)
        {
            lock (this.writeLock)
            {
                string outValue;
                if (this.values.TryGetValue(key, out outValue))
                {
                    return outValue;
                }

                return null;
            }
        }

        private void NotifyChanges(ISet<string> changes)
        {
            if (this.ValueChanged != null)
            {
                foreach (string key in changes)
                {
                    // ReSharper disable once PossibleNullReferenceException
                    this.ValueChanged(this, new RegistryValueChangedEventArgs(key));
                }
            }
        }

        /// <summary>
        ///     Allows editing of a <see cref="IRegistry" /> object. Changes are all made in a batch after <see cref="Apply" />.
        ///     A lock may also be manually acquired, and is released on <see cref="Apply" />.
        /// </summary>
        public sealed class MemoryRegistryEditor : IRegistryEditor
        {
            private readonly MemoryRegistry registry;
            private bool clearValues;
            private readonly HashSet<string> valuesToRemove = new HashSet<string>();
            private readonly Dictionary<string, string> newValues = new Dictionary<string, string>();
            private bool hasLock;

            internal MemoryRegistryEditor(MemoryRegistry registry)
            {
                this.registry = registry;
            }

            /// <summary>
            ///     Marks all values for deletion from the <see cref="IRegistry" /> after <see cref="Apply" />. Will be applied before
            ///     any
            ///     sets
            ///     in the same batch from this editor.
            /// </summary>
            /// <returns> A reference to this <see cref="IRegistryEditor" /> instance that can be used to chain calls together. </returns>
            public IRegistryEditor Clear()
            {
                this.clearValues = true;
                return this;
            }

            /// <summary>
            ///     Marks a value for deletion from the <see cref="IRegistry" /> after <see cref="Apply" />. Will be applied before any
            ///     sets
            ///     in the same batch from this editor.
            /// </summary>
            /// <param name="key"> The key used to store the value in the <see cref="IRegistry" />. </param>
            /// <returns> A reference to this <see cref="IRegistryEditor" /> instance that can be used to chain calls together. </returns>
            public IRegistryEditor Remove(string key)
            {
                if (string.IsNullOrWhiteSpace(key))
                {
                    throw RegistryException.InvalidKeyException(key);
                }

                this.valuesToRemove.Add(key);
                return this;
            }

            /// <summary>
            ///     Set a bool value to be written to the <see cref="IRegistry" /> after <see cref="Apply" />.
            /// </summary>
            /// <param name="key"> The key used to store the value in the <see cref="IRegistry" />. </param>
            /// <param name="value"> The value to store in the <see cref="IRegistry" />. </param>
            /// <returns> A reference to this <see cref="IRegistryEditor" /> instance that can be used to chain calls together. </returns>
            public IRegistryEditor SetBool(string key, bool value)
            {
                if (string.IsNullOrWhiteSpace(key))
                {
                    throw RegistryException.InvalidKeyException(key);
                }

                this.newValues[key] = value.ToString();
                return this;
            }

            /// <summary>
            ///     Set an int value to be written to the <see cref="IRegistry" /> after <see cref="Apply" />.
            /// </summary>
            /// <param name="key"> The key used to store the value in the <see cref="IRegistry" />. </param>
            /// <param name="value"> The value to store in the <see cref="IRegistry" />. </param>
            /// <returns> A reference to this <see cref="IRegistryEditor" /> instance that can be used to chain calls together. </returns>
            public IRegistryEditor SetInt(string key, int value)
            {
                if (string.IsNullOrWhiteSpace(key))
                {
                    throw RegistryException.InvalidKeyException(key);
                }

                this.newValues[key] = value.ToString();
                return this;
            }

            /// <summary>
            ///     Set a long value to be written to the <see cref="IRegistry" /> after <see cref="Apply" />.
            /// </summary>
            /// <param name="key"> The key used to store the value in the <see cref="IRegistry" />. </param>
            /// <param name="value"> The value to store in the <see cref="IRegistry" />. </param>
            /// <returns> A reference to this <see cref="IRegistryEditor" /> instance that can be used to chain calls together. </returns>
            public IRegistryEditor SetLong(string key, long value)
            {
                if (string.IsNullOrWhiteSpace(key))
                {
                    throw RegistryException.InvalidKeyException(key);
                }

                this.newValues[key] = value.ToString();
                return this;
            }

            /// <summary>
            ///     Set a float value to be written to the <see cref="IRegistry" /> after <see cref="Apply" />.
            /// </summary>
            /// <param name="key"> The key used to store the value in the <see cref="IRegistry" />. </param>
            /// <param name="value"> The value to store in the <see cref="IRegistry" />. </param>
            /// <returns> A reference to this <see cref="IRegistryEditor" /> instance that can be used to chain calls together. </returns>
            public IRegistryEditor SetFloat(string key, float value)
            {
                if (string.IsNullOrWhiteSpace(key))
                {
                    throw RegistryException.InvalidKeyException(key);
                }

                this.newValues[key] = value.ToString(CultureInfo.InvariantCulture);
                return this;
            }

            /// <summary>
            ///     Set a double value to be written to the <see cref="IRegistry" /> after <see cref="Apply" />.
            /// </summary>
            /// <param name="key"> The key used to store the value in the <see cref="IRegistry" />. </param>
            /// <param name="value"> The value to store in the <see cref="IRegistry" />. </param>
            /// <returns> A reference to this <see cref="IRegistryEditor" /> instance that can be used to chain calls together. </returns>
            public IRegistryEditor SetDouble(string key, double value)
            {
                if (string.IsNullOrWhiteSpace(key))
                {
                    throw RegistryException.InvalidKeyException(key);
                }

                this.newValues[key] = value.ToString(CultureInfo.InvariantCulture);
                return this;
            }

            /// <summary>
            ///     Set a string value to be written to the <see cref="IRegistry" /> after <see cref="Apply" />.
            /// </summary>
            /// <param name="key"> The key used to store the value in the <see cref="IRegistry" />. </param>
            /// <param name="value"> The value to store in the <see cref="IRegistry" />. </param>
            /// <returns> A reference to this <see cref="IRegistryEditor" /> instance that can be used to chain calls together. </returns>
            public IRegistryEditor SetString(string key, string value)
            {
                if (string.IsNullOrWhiteSpace(key))
                {
                    throw RegistryException.InvalidKeyException(key);
                }

                this.newValues[key] = value;
                return this;
            }

            /// <summary>
            ///     Commit the changes that have been made in this <see cref="IRegistryEditor" />.
            /// </summary>
            public void Apply()
            {
                var changedValues = new HashSet<string>();
                lock (this.registry.writeLock)
                {
                    if (this.clearValues)
                    {
                        changedValues.UnionWith(this.registry.values.Keys);
                        this.registry.values.Clear();
                    }
                    else
                    {
                        foreach (string val in this.valuesToRemove)
                        {
                            changedValues.Add(val);
                            this.registry.values.Remove(val);
                        }
                    }

                    foreach (KeyValuePair<string, string> kvp in this.newValues)
                    {
                        changedValues.Add(kvp.Key);
                        this.registry.values[kvp.Key] = kvp.Value;
                    }
                }

                if (this.hasLock)
                {
                    Monitor.Exit(this.registry.writeLock);
                    this.hasLock = false;
                }

                this.registry.NotifyChanges(changedValues);

                this.clearValues = false;
                this.valuesToRemove.Clear();
                this.newValues.Clear();
            }

            /// <summary>
            ///     Acquire a lock preventing any changes to this <see cref="IRegistryEditor" />'s <see cref="IRegistry" />.
            /// </summary>
            /// <returns> A reference to this <see cref="IRegistryEditor" /> instance that can be used to chain calls together. </returns>
            public IRegistryEditor Lock()
            {
                Monitor.Enter(this.registry.writeLock);
                this.hasLock = true;
                return this;
            }
        }
    }
}