// -----------------------------------------------------------------------
//  <copyright file="IRegistryEditor.cs" company="DangerDan9631">
//      Copyright (c) 2017 Dan Garvey. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/Dangerdan9631/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
//  <dateCreated>2017-04-24</dateCreated>
//  <dateModified>2017-06-20</dateModified>
//  <lastModifiedBy>Dan Garvey</lastModifiedBy>
// -----------------------------------------------------------------------

namespace Dangr.Registry
{
    /// <summary>
    ///     Allows editing of a <see cref="IRegistry" /> object. Changes are all
    ///     made in a batch after <see cref="Apply" />. A lock may also be
    ///     manually acquired, and is released on <see cref="Apply" />.
    /// </summary>
    public interface IRegistryEditor
    {
        /// <summary>
        ///     Marks all values for deletion from the <see cref="IRegistry" /> after <see cref="Apply" />. Will be applied before
        ///     any
        ///     sets
        ///     in the same batch from this editor.
        /// </summary>
        /// <returns> A reference to this <see cref="IRegistryEditor" /> instance that can be used to chain calls together. </returns>
        IRegistryEditor Clear();

        /// <summary>
        ///     Marks a value for deletion from the <see cref="IRegistry" /> after <see cref="Apply" />. Will be applied before any
        ///     sets
        ///     in the same batch from this editor.
        /// </summary>
        /// <param name="key"> The key used to store the value in the <see cref="IRegistry" />. </param>
        /// <returns> A reference to this <see cref="IRegistryEditor" /> instance that can be used to chain calls together. </returns>
        IRegistryEditor Remove(string key);

        /// <summary>
        ///     Set a bool value to be written to the <see cref="IRegistry" /> after <see cref="Apply" />.
        /// </summary>
        /// <param name="key"> The key used to store the value in the <see cref="IRegistry" />. </param>
        /// <param name="value"> The value to store in the <see cref="IRegistry" />. </param>
        /// <returns> A reference to this <see cref="IRegistryEditor" /> instance that can be used to chain calls together. </returns>
        IRegistryEditor SetBool(string key, bool value);

        /// <summary>
        ///     Set an int value to be written to the <see cref="IRegistry" /> after <see cref="Apply" />.
        /// </summary>
        /// <param name="key"> The key used to store the value in the <see cref="IRegistry" />. </param>
        /// <param name="value"> The value to store in the <see cref="IRegistry" />. </param>
        /// <returns> A reference to this <see cref="IRegistryEditor" /> instance that can be used to chain calls together. </returns>
        IRegistryEditor SetInt(string key, int value);

        /// <summary>
        ///     Set a long value to be written to the <see cref="IRegistry" /> after <see cref="Apply" />.
        /// </summary>
        /// <param name="key"> The key used to store the value in the <see cref="IRegistry" />. </param>
        /// <param name="value"> The value to store in the <see cref="IRegistry" />. </param>
        /// <returns> A reference to this <see cref="IRegistryEditor" /> instance that can be used to chain calls together. </returns>
        IRegistryEditor SetLong(string key, long value);

        /// <summary>
        ///     Set a float value to be written to the <see cref="IRegistry" /> after <see cref="Apply" />.
        /// </summary>
        /// <param name="key"> The key used to store the value in the <see cref="IRegistry" />. </param>
        /// <param name="value"> The value to store in the <see cref="IRegistry" />. </param>
        /// <returns> A reference to this <see cref="IRegistryEditor" /> instance that can be used to chain calls together. </returns>
        IRegistryEditor SetFloat(string key, float value);

        /// <summary>
        ///     Set a double value to be written to the <see cref="IRegistry" /> after <see cref="Apply" />.
        /// </summary>
        /// <param name="key"> The key used to store the value in the <see cref="IRegistry" />. </param>
        /// <param name="value"> The value to store in the <see cref="IRegistry" />. </param>
        /// <returns> A reference to this <see cref="IRegistryEditor" /> instance that can be used to chain calls together. </returns>
        IRegistryEditor SetDouble(string key, double value);

        /// <summary>
        ///     Set a string value to be written to the <see cref="IRegistry" /> after <see cref="Apply" />.
        /// </summary>
        /// <param name="key"> The key used to store the value in the <see cref="IRegistry" />. </param>
        /// <param name="value"> The value to store in the <see cref="IRegistry" />. </param>
        /// <returns> A reference to this <see cref="IRegistryEditor" /> instance that can be used to chain calls together. </returns>
        IRegistryEditor SetString(string key, string value);

        /// <summary>
        ///     Commit the changes that have been made in this <see cref="IRegistryEditor" />.
        /// </summary>
        void Apply();

        /// <summary>
        ///     Acquire a lock preventing any changes to this <see cref="IRegistryEditor" />'s <see cref="IRegistry" />.
        /// </summary>
        /// <returns> A reference to this <see cref="IRegistryEditor" /> instance that can be used to chain calls together. </returns>
        IRegistryEditor Lock();
    }
}