// -----------------------------------------------------------------------
//  <copyright file="SingletonInjectionProvider.cs" company="Phoenix Game Studios, LLC">
//      Copyright (c) 2017 Phoenix Game Studios, LLC. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/PhoenixGameStudios/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.Inject.Internal
{
    using System.Reflection;
    using Dangr.Inject.Core;

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