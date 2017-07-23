﻿// -----------------------------------------------------------------------
//  <copyright file="AssemblyInfo.cs" company="DangerDan9631">
//      Copyright (c) 2017 Dan Garvey. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/Dangerdan9631/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Dangr.Logging.Test")]

// ReSharper disable once CheckNamespace
namespace Dangr
{
    internal static partial class AssemblyConstants
    {
        public const string AssemblyDescription =
            "WCF based logging utilities for use with DangrLib's logging framework.";
    }
}