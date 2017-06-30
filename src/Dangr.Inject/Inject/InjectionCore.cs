// -----------------------------------------------------------------------
//  <copyright file="InjectionCore.cs" company="DangerDan9631">
//      Copyright (c) 2017 Dan Garvey. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/Dangerdan9631/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.Inject
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Reflection;

    /// <summary>
    /// Component that is responsible for gathering and exposing provided
    /// dependencies.
    /// </summary>
    public class InjectionCore
    {
        private readonly Dictionary<Type, InjectionProvider> providerMap = new Dictionary<Type, InjectionProvider>();

        private readonly Dictionary<string, InjectionProvider> namedProviderMap =
            new Dictionary<string, InjectionProvider>();

        /// <summary>
        /// Scans the <paramref name="assembly" /> for all classes with the <see cref="InjectionModuleAttribute" /> and loads them into the <see cref="InjectionCore" /> .
        /// </summary>
        /// <param name="assembly">The assembly to scan.</param>
        public void ScanAssembly(Assembly assembly)
        {
            Type[] types = assembly.GetExportedTypes();
            foreach (Type type in types)
            {
                if (type.IsDefined(typeof(InjectionModuleAttribute)))
                {
                    this.LoadModule(type);
                }
            }
        }

        /// <summary>
        /// Loads the providers defined in the given module.
        /// </summary>
        /// <param name="module">The module object.</param>
        public void LoadModule(Type module)
        {
            PropertyInfo[] properties = module.GetProperties();
            foreach (PropertyInfo property in properties)
            {
                var providesAttribute = property.GetCustomAttribute<ProvidesAttribute>();
                if (providesAttribute != null)
                {
                    ConstructorInfo constructor = this.GetConstructor(property.PropertyType);
                    this.CreateProvider(constructor, providesAttribute, property.IsDefined(typeof(SingletonAttribute)));
                }

                var providesSetAttribute = property.GetCustomAttribute<ProvidesSetAttribute>();
                if (providesSetAttribute != null)
                {
                    ConstructorInfo constructor = this.GetConstructor(property.PropertyType);
                    this.CreateSetProvider(constructor, providesSetAttribute,
                        property.IsDefined(typeof(SingletonAttribute)));
                }
            }

            MethodInfo[] methods = module.GetMethods(BindingFlags.Public | BindingFlags.Static);
            foreach (MethodInfo method in methods)
            {
                var providesAttribute = method.GetCustomAttribute<ProvidesAttribute>();
                if (providesAttribute != null)
                {
                    this.CreateProvider(method, providesAttribute, method.IsDefined(typeof(SingletonAttribute)));
                }

                var providesSetAttribute = method.GetCustomAttribute<ProvidesSetAttribute>();
                if (providesSetAttribute != null)
                {
                    this.CreateSetProvider(method, providesSetAttribute,
                        method.IsDefined(typeof(SingletonAttribute)));
                }
            }
        }

        /// <summary>
        /// Gets an instance of the dependency defined with the specified name.
        /// </summary>
        /// <param name="name">The dependency name.</param>
        /// <exception cref="System.InvalidOperationException">
        /// If no dependency with the specified <paramref name="name" /> is defined.
        /// </exception>
        public object Get(string name)
        {
            return this.Get(name, null);
        }

        internal object Get(string name, InjectionProvider.ProviderContext context)
        {
            InjectionProvider provider;
            if (this.namedProviderMap.TryGetValue(name, out provider))
            {
                return provider.GetInstance(this, context);
            }

            throw new InvalidOperationException($"No dependency with name '{name}' defined.");
        }

        /// <summary>
        /// Gets an instance of the dependency defined with the specified type.
        /// </summary>
        /// <param name="type">The dependency type.</param>
        /// <exception cref="System.InvalidOperationException">
        /// If no dependency with the specified <paramref name="type" /> is defined.
        /// </exception>
        public object Get(Type type)
        {
            return this.Get(type, null);
        }

        internal object Get(Type type, InjectionProvider.ProviderContext context)
        {
            Type dependencyType = type;

            if (typeof(IEnumerable).IsAssignableFrom(type))
            {
                Type[] generics = type.GetGenericArguments();
                if (generics.Length == 1)
                {
                    dependencyType = generics[0];
                }
            }

            InjectionProvider provider;
            if (this.providerMap.TryGetValue(dependencyType, out provider))
            {
                return provider.GetInstance(this, context);
            }

            throw new InvalidOperationException($"No dependency with type '{type.Name}' defined.");
        }

        /// <summary>
        /// Gets an instance of the dependency defined with the specified type.
        /// </summary>
        /// <typeparam name="T">The dependency type.</typeparam>
        /// <exception cref="System.InvalidOperationException">
        /// If no dependency with the specified type is defined.
        /// </exception>
        public T Get<T>()
        {
            return this.Get<T>(null);
            ;
        }

        internal T Get<T>(InjectionProvider.ProviderContext context)
        {
            return (T) this.Get(typeof(T), context);
        }

        private void CreateProvider(MethodBase method, ProvidesAttribute providesAttribute, bool isSingleton)
        {
            InjectionProvider provider = isSingleton
                ? new SingletonInjectionProvider(method)
                : new InjectionProvider(method);

            if (providesAttribute.Name != null)
            {
                this.namedProviderMap.Add(providesAttribute.Name, provider);
            }

            if (providesAttribute.ProvidesType != null)
            {
                this.providerMap.Add(providesAttribute.ProvidesType, provider);
            }
        }

        private void CreateSetProvider(MethodBase method, ProvidesSetAttribute providesSetAttribute, bool isSingleton)
        {
            InjectionProvider mappedProvider;
            SetInjectionProvider setProvider = null;

            if (providesSetAttribute.Name != null)
            {
                if (this.namedProviderMap.TryGetValue(providesSetAttribute.Name, out mappedProvider))
                {
                    setProvider = mappedProvider as SetInjectionProvider;
                }
                else
                {
                    setProvider = new SetInjectionProvider();
                    this.namedProviderMap.Add(providesSetAttribute.Name, setProvider);
                }
            }

            if (providesSetAttribute.ProvidesType != null)
            {
                if (this.providerMap.TryGetValue(providesSetAttribute.ProvidesType, out mappedProvider))
                {
                    setProvider = mappedProvider as SetInjectionProvider;
                }
                else
                {
                    setProvider = new SetInjectionProvider();
                    this.providerMap.Add(providesSetAttribute.ProvidesType, setProvider);
                }
            }

            if (setProvider != null)
            {
                InjectionProvider provider = isSingleton
                    ? new SingletonInjectionProvider(method)
                    : new InjectionProvider(method);
                setProvider.AddProvider(provider);
            }
        }

        private ConstructorInfo GetConstructor(Type type)
        {
            ConstructorInfo[] constructors = type.GetConstructors();
            foreach (ConstructorInfo constructor in constructors)
            {
                if (constructor.IsDefined(typeof(InjectAttribute))
                    || (constructor.GetParameters().Length == 0))
                {
                    return constructor;
                }
            }

            throw new InvalidOperationException("Could not find a suitable constructor for injection.");
        }
    }
}