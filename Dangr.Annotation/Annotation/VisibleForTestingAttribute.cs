// -----------------------------------------------------------------------
//  <copyright file="VisibleForTestingAttribute.cs" company="DangerDan9631">
//      Copyright (c) 2017 Dan Garvey. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/Dangerdan9631/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
//  <dateCreated>2017-04-24</dateCreated>
//  <dateModified>2017-06-20</dateModified>
//  <lastModifiedBy>Dan Garvey</lastModifiedBy>
// -----------------------------------------------------------------------

namespace Dangr.Annotation
{
    using System;

    /// <summary>
    /// Annotation attribute used to denote that a code element has been made
    /// visible for testing purposes.
    /// </summary>
    /// <seealso cref="T:System.Attribute" />
    [AttributeUsage(AttributeTargets.All, Inherited = false)]
    public sealed class VisibleForTestingAttribute : Attribute
    { }
}