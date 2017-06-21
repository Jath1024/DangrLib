// -----------------------------------------------------------------------
//  <copyright file="IInitializable.cs" company="DangerDan9631">
//      Copyright (c) 2017 Dan Garvey. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/Dangerdan9631/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.Util
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