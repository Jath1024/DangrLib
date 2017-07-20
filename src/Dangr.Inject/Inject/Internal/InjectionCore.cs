// -----------------------------------------------------------------------
//  <copyright file="InjectionCore.cs" company="DangerDan9631">
//      Copyright (c) 2017 Dan Garvey. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/Dangerdan9631/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.Inject.Internal
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using Dangr.Inject.Core;
    using Dangr.Inject.Core.Attributes;

    internal class InjectionCore : IInjectionCore
    {
        private readonly Dictionary<Type, InjectionProvider> providerMap = new Dictionary<Type, InjectionProvider>();

        private readonly Dictionary<string, InjectionProvider> namedProviderMap =
            new Dictionary<string, InjectionProvider>();
        
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
        
        public void LoadModule(Type module)
        {
            PropertyInfo[] properties = module.GetProperties();
            foreach (PropertyInfo property in properties)
            {
                ProviderAttribute providerAttribute = property.GetCustomAttribute<ProviderAttribute>();
                if (providerAttribute != null)
                {
                    ConstructorInfo constructor = this.GetConstructor(property.PropertyType);
                    this.CreateProvider(property, providerAttribute, constructor);
                }
            }

            MethodInfo[] methods = module.GetMethods(BindingFlags.Public | BindingFlags.Static);
            foreach (MethodInfo method in methods)
            {
                ProviderAttribute providerAttribute = method.GetCustomAttribute<ProviderAttribute>();
                if (providerAttribute != null)
                {
                    this.CreateProvider(method, providerAttribute, method);
                }
            }
        }
        
        public T Get<T>()
        {
            return this.GetDependency<T>(typeof(T));
        }
        
        public T Get<T>(string name)
        {
            return this.GetDependency<T>(name);
        }
        
        private T GetDependency<T>(Type type)
        {
            using (InjectionContext.NewContext())
            {
                return default(T);
            }
        }

        private T GetDependency<T>(string name)
        {
            using (InjectionContext.NewContext())
            {
                InjectionProvider provider;
                if (this.namedProviderMap.TryGetValue(name, out provider))
                {
                    return provider.GetInstance(this);
                }

                throw new InvalidOperationException($"No dependency with name '{name}' defined.");
            }
        }
        
        private object Get(Type type, InjectionProvider.ProviderContext context)
        {
            Type dependencyType = type;

            if (typeof(ISet<>).IsAssignableFrom(type))
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

        private T Get<T>(InjectionProvider.ProviderContext context)
        {
            return (T) this.Get(typeof(T), context);
        }
        
        private void CreateProvider(MemberInfo memberInfo, ProviderAttribute providerAttribute, MethodBase method)
        {
            if (memberInfo.IsDefined(typeof(ProvidesSetAttribute)))
            {
                this.CreateSetProvider(
                    method,
                    providerAttribute,
                    memberInfo.IsDefined(typeof(SingletonAttribute)));
            }
            else
            {
                this.CreateInstanceProvider(method, providerAttribute, memberInfo.IsDefined(typeof(SingletonAttribute)));
            }
        }

        private void CreateInstanceProvider(MethodBase method, ProviderAttribute providerAttribute, bool isSingleton)
        {
            InjectionProvider provider = isSingleton
                ? new SingletonInjectionProvider(method)
                : new InjectionProvider(method);

            if (providerAttribute.Name != null)
            {
                this.namedProviderMap.Add(providerAttribute.Name, provider);
            }

            if (providerAttribute.ProvidesType != null)
            {
                this.providerMap.Add(providerAttribute.ProvidesType, provider);
            }
        }

        private void CreateSetProvider(MethodBase method, ProviderAttribute providesSetAttribute, bool isSingleton)
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