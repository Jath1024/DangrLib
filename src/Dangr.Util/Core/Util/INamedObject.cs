// -----------------------------------------------------------------------
//  <copyright file="INamedObject.cs" company="Phoenix Game Studios, LLC">
//      Copyright (c) 2017 Phoenix Game Studios, LLC. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/PhoenixGameStudios/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------
namespace Dangr.Core.Util
{
    /// <summary>
    /// Defines a property to retrieve the name of an object.
    /// </summary>
    public interface INamedObject
    {
        /// <summary>
        /// Gets the name of this <see cref="INamedObject" /> .
        /// </summary>
        string Name { get; }
    }
}