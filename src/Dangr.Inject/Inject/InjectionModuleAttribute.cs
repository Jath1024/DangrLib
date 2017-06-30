// -----------------------------------------------------------------------
//  <copyright file="InjectionModuleAttribute.cs" company="DangerDan9631">
//      Copyright (c) 2017 Dan Garvey. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/Dangerdan9631/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.Inject
{
    using System;

    /// <summary>
    /// Attribute used to mark a module class that contains <see cref="InjectionProvider"/>s.
    /// </summary>
    /// <seealso cref="System.Attribute" />
    [AttributeUsage(AttributeTargets.Class)]
    public class InjectionModuleAttribute : Attribute
    { }
}