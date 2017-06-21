// -----------------------------------------------------------------------
//  <copyright file="ProvidesSetAttribute.cs" company="DangerDan9631">
//      Copyright (c) 2017 Dan Garvey. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/Dangerdan9631/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
//  <dateCreated>2017-04-24</dateCreated>
//  <dateModified>2017-06-20</dateModified>
//  <lastModifiedBy>Dan Garvey</lastModifiedBy>
// -----------------------------------------------------------------------

namespace Dangr.Inject
{
    using System;

    public class ProvidesSetAttribute : Attribute
    {
        public Type ProvidesType { get; }
        public string Name { get; }

        public ProvidesSetAttribute(Type type)
        {
            this.ProvidesType = type;
            this.Name = null;
        }

        public ProvidesSetAttribute(string name)
        {
            this.ProvidesType = null;
            this.Name = name;
        }

        public ProvidesSetAttribute(Type type, string name)
        {
            this.ProvidesType = type;
            this.Name = name;
        }
    }
}