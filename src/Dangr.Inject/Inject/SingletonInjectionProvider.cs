// -----------------------------------------------------------------------
//  <copyright file="SingletonInjectionProvider.cs" company="DangerDan9631">
//      Copyright (c) 2017 Dan Garvey. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/Dangerdan9631/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.Inject
{
    using System.Reflection;

    internal class SingletonInjectionProvider : InjectionProvider
    {
        private object singletonInstance;

        public SingletonInjectionProvider(MethodBase constructor)
            : base(constructor)
        {
        }

        public override object GetInstance(InjectionCore injectionCore, ProviderContext context)
        {
            if (this.singletonInstance == null)
            {
                this.singletonInstance = base.GetInstance(injectionCore, context);
            }

            return this.singletonInstance;
        }
    }
}