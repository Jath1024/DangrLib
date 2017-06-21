﻿// -----------------------------------------------------------------------
//  <copyright file="ProvidesAttribute.cs" company="DangerDan9631">
//      Copyright (c) 2017 Dan Garvey. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/Dangerdan9631/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.Inject
{
    using System;

    public class ProvidesAttribute : Attribute
    {
        public Type ProvidesType { get; }
        public string Name { get; }

        public ProvidesAttribute(Type type)
        {
            this.ProvidesType = type;
            this.Name = null;
        }

        public ProvidesAttribute(string name)
        {
            this.ProvidesType = null;
            this.Name = name;
        }

        public ProvidesAttribute(Type type, string name)
        {
            this.ProvidesType = type;
            this.Name = name;
        }
    }
}