// -----------------------------------------------------------------------
//  <copyright file="SetInjectionProvider.cs" company="DangerDan9631">
//      Copyright (c) 2017 Dan Garvey. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/Dangerdan9631/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.Inject.Internal
{
    using System.Collections.Generic;
    using Dangr.Inject.Core;

    internal class SetInjectionProvider : InjectionProvider
    {
        private readonly List<InjectionProvider> providerList;

        public SetInjectionProvider()
            : base(null)
        {
            this.providerList = new List<InjectionProvider>();
        }

        public void AddProvider(InjectionProvider provider)
        {
            this.providerList.Add(provider);
        }

        public override ISet<T> GetInstance<T>(InjectionCore injectionCore, ProviderContext context)
        {
            HashSet<T> instanceList = new HashSet<T>();
            foreach (InjectionProvider provider in this.providerList)
            {
                instanceList.Add((T)provider.GetInstance(injectionCore, context));
            }

            return instanceList;
        }
    }
}