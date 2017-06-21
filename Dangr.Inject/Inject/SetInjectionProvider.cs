// -----------------------------------------------------------------------
//  <copyright file="SetInjectionProvider.cs" company="DangerDan9631">
//      Copyright (c) 2017 Dan Garvey. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/Dangerdan9631/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.Inject
{
    using System.Collections.Generic;

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

        public override object GetInstance(InjectionCore injectionCore, ProviderContext context)
        {
            var instanceList = new List<object>();
            foreach (InjectionProvider provider in this.providerList)
            {
                instanceList.Add(provider.GetInstance(injectionCore, context));
            }

            return instanceList;
        }
    }
}