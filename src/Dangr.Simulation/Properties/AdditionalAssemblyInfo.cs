// -----------------------------------------------------------------------
//  <copyright file="AssemblyConstants.cs" company="DangerDan9631">
//      Copyright (c) 2017 Dan Garvey. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/Dangerdan9631/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

/*
    This file Is generated using T4 Text Templates. Do Not Modify. 
    Make changes to "/Tools/CommonSource/AssemblyConstants.t4" directly.
*/
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Dangr;
    
[assembly: AssemblyTitle(AssemblyConstants.AssemblyName)]
[assembly: AssemblyProduct(AssemblyConstants.AssemblyName)]
[assembly: AssemblyDescription(AssemblyConstants.AssemblyDescription)]
[assembly: AssemblyCompany(AssemblyConstants.AssemblyCompany)]
[assembly: AssemblyCopyright(AssemblyConstants.AssemblyCopyright)]
[assembly: AssemblyVersion(AssemblyConstants.AssemblyVersion)]
[assembly: AssemblyFileVersion(AssemblyConstants.AssemblyVersion)]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

[assembly: ComVisible(false)]

[assembly:InternalsVisibleTo("Dangr.Simulation.Test")]

// ReSharper disable once CheckNamespace
namespace Dangr {    
    /// <summary>
    /// Provides constants for use in AssemblyInfo.cs.
    /// </summary>
    internal static partial class AssemblyConstants {

        /// <summary>
        /// The name of the assembly.
        /// </summary>
        public const string AssemblyName = "Dangr.Simulation";

        /// <summary>
        /// The assembly version.
        /// </summary>
        public const string AssemblyVersion = "1.1.0";

        /// <summary>
        /// The assembly company.
        /// </summary>
        public const string AssemblyCompany = "DangerDan9631";

        /// <summary>
        /// The assembly copyright statement.
        /// </summary>
        public const string AssemblyCopyright = "Copyright � 2017 " + AssemblyConstants.AssemblyCompany;
    }
}