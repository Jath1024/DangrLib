// -----------------------------------------------------------------------
//  <copyright file="InjectionProvider.cs" company="DangerDan9631">
//      Copyright (c) 2017 Dan Garvey. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/Dangerdan9631/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.Inject
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    internal class InjectionProvider
    {
        public class ProviderContext
        {
            public readonly ISet<string> NamedDependencies = new HashSet<string>();
            public readonly ISet<Type> TypedDependencies = new HashSet<Type>();
        }

        private readonly MethodBase providerMethod;

        public InjectionProvider(MethodBase providerMethod)
        {
            this.providerMethod = providerMethod;
        }

        public virtual object GetInstance(InjectionCore injectionCore, ProviderContext context)
        {
            if (context == null)
            {
                context = new ProviderContext();
            }

            ParameterInfo[] parameterInfoList = this.providerMethod.GetParameters();
            var parameters = new object[parameterInfoList.Length];
            for (int i = 0; i < parameterInfoList.Length; i++)
            {
                NamedAttribute namedAttribute = parameterInfoList[i].GetCustomAttribute<NamedAttribute>();
                if (namedAttribute == null)
                {
                    if (context.TypedDependencies.Contains(parameterInfoList[i].ParameterType))
                    {
                        throw new InvalidOperationException(
                            $"Dependency loop detected when providing dependency type {parameterInfoList[i].ParameterType.Name}.");
                    }

                    context.TypedDependencies.Add(parameterInfoList[i].ParameterType);
                    parameters[i] = injectionCore.Get(parameterInfoList[i].ParameterType, context);
                    context.TypedDependencies.Remove(parameterInfoList[i].ParameterType);
                }
                else
                {
                    if (context.NamedDependencies.Contains(namedAttribute.Name))
                    {
                        throw new InvalidOperationException(
                            $"Dependency loop detected when providing named dependency '{namedAttribute.Name}'.");
                    }

                    context.NamedDependencies.Add(namedAttribute.Name);
                    parameters[i] = injectionCore.Get(namedAttribute.Name, context);
                    context.NamedDependencies.Remove(namedAttribute.Name);
                }
            }

            ConstructorInfo constructor = this.providerMethod as ConstructorInfo;
            return constructor != null
                ? constructor.Invoke(parameters)
                : this.providerMethod.Invoke(null, parameters);
        }
    }
}