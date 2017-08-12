// -----------------------------------------------------------------------
//  <copyright file="IInitializable.cs" company="Phoenix Game Studios, LLC">
//      Copyright (c) 2017 Phoenix Game Studios, LLC. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/PhoenixGameStudios/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------
namespace Dangr.Core.Util
{
    /// <summary>
    /// Provides a mechanism for performing instance initialization as a
    /// separate step from construction, and provides a property to get whether
    /// this instance has been initialized.
    /// </summary>
    public interface IInitializable
    {
        /// <summary>
        /// Gets a value indicating whether this instance is initialized.
        /// </summary>
        bool IsInitialized { get; }

        /// <summary>
        /// Initializes this <see cref="IInitializable" /> instance.
        /// </summary>
        void Init();
    }
}