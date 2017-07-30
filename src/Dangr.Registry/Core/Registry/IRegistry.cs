// -----------------------------------------------------------------------
//  <copyright file="IRegistry.cs" company="DangerDan9631">
//      Copyright (c) 2017 Dan Garvey. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/Dangerdan9631/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.Core.Registry
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    ///     Provides access to a shared set of data
    /// </summary>
    public interface IRegistry
    {
        /// <summary>
        ///     Occurs when a value stored in this <see cref="IRegistry" /> is added, updated, or removed.
        /// </summary>
        event EventHandler<RegistryValueChangedEventArgs> ValueChanged;

        /// <summary>
        ///     Gets the number of elements stored in this <see cref="IRegistry" />.
        /// </summary>
        int Count { get; }

        /// <summary>
        ///     Gets all values from the registry.
        /// </summary>
        /// <returns> A <see cref="IDictionary{TKey, TValue}" /> containing all the values in the registry. </returns>
        IDictionary<string, string> GetValues();

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
        bool GetBool(string key, bool defaultValue);

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
        int GetInt(string key, int defaultValue);

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
        long GetLong(string key, long defaultValue);

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
        float GetFloat(string key, float defaultValue);

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
        double GetDouble(string key, double defaultValue);

        /// <summary>
        ///     Gets a string value from the <see cref="IRegistry" />.
        /// </summary>
        /// <param name="key"> The key used to store the value in the <see cref="IRegistry" />. </param>
        /// <param name="defaultValue"> The default value to return if the specified key is not found. </param>
        /// <returns> The value stored in the registry with the specified key, or the given default value if not found. </returns>
        string GetString(string key, string defaultValue);

        /// <summary>
        ///     Create a new editor for this registry.
        /// </summary>
        /// <returns> A new editor for this registry. </returns>
        IRegistryEditor Edit();
    }
}