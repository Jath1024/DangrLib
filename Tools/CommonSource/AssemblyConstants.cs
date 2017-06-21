// -----------------------------------------------------------------------
//  <copyright file="AssemblyConstants.cs" company="DangerDan9631">
//      Copyright (c) 2017 Dan Garvey. All rights reserved.
//  </copyright>
//  <dateCreated>2017-04-24</dateCreated>
//  <dateModified>2017-04-24</dateModified>
//  <lastModifiedBy>Dan Garvey</lastModifiedBy>
// -----------------------------------------------------------------------

using System.Reflection;
using Dangr;

[assembly: AssemblyCompany(AssemblyConstants.AssemblyCompany)]
[assembly: AssemblyCopyright(AssemblyConstants.AssemblyCopyright)]
[assembly: AssemblyVersion(AssemblyConstants.AssemblyVersion)]
[assembly: AssemblyFileVersion(AssemblyConstants.AssemblyVersion)]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

namespace Dangr {    
    /// <summary>
    /// Provides constants for use in AssemblyInfo.cs.
    /// </summary>
    internal static class AssemblyConstants {
        /// <summary>
        /// The assembly version.
        /// </summary>
        public const string AssemblyVersion = "1.0.*";

        /// <summary>
        /// The assembly company.
        /// </summary>
        public const string AssemblyCompany = "DangerDan9631";

        /// <summary>
        /// The assembly copyright statement.
        /// </summary>
        public const string AssemblyCopyright = "Copyright © 2017 " + AssemblyConstants.AssemblyCompany;
    }
}
