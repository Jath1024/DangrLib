// -----------------------------------------------------------------------
//  <copyright file="InjectionCoreFactory.cs" company="DangerDan9631">
//      Copyright (c) 2017 Dan Garvey. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/Dangerdan9631/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------
namespace Dangr.Inject.Core
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using Dangr.Inject.Core.Attributes;
    using Dangr.Inject.Internal;

    /// <summary>
    /// Factory used to construct an <see cref="IInjectionCore"/> using the specified Assemblies and Modules.
    /// </summary>
    public class InjectionCoreFactory
    {
        private readonly ISet<Assembly> assemblies = new HashSet<Assembly>();
        private readonly ISet<Type> modules = new HashSet<Type>();

        /// <summary>
        /// Specifies that the given assembly should be scanned for classes with an <see cref="InjectionModuleAttribute"/> that should be loaded.
        /// </summary>
        /// <param name="assembly">The assembly to scan.</param>
        /// <returns>A reference to this <see cref="InjectionCoreFactory"/>.</returns>
        public InjectionCoreFactory ScanAssembly(Assembly assembly)
        {
            this.assemblies.Add(assembly);
            return this;
        }

        /// <summary>
        /// Specifies that the given type should be loaded as a module.
        /// </summary>
        /// <param name="type">The type to load.</param>
        /// <returns>A reference to this <see cref="InjectionCoreFactory"/>.</returns>
        public InjectionCoreFactory LoadModule(Type type)
        {
            this.modules.Add(type);
            return this;
        }

        /// <summary>
        /// Builds a new <see cref="IInjectionCore"/> with the specified modules loaded.
        /// </summary>
        /// <returns>A new <see cref="IInjectionCore"/> instance.</returns>
        public IInjectionCore Build()
        {
            InjectionCore core = new InjectionCore();
            foreach(Assembly assembly in this.assemblies)
            {
                core.ScanAssembly(assembly);
            }

            foreach(Type module in this.modules)
            {
                core.LoadModule(module);
            }

            return core;
        }
    }
}