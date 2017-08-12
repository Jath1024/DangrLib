// -----------------------------------------------------------------------
//  <copyright file="ParameterAttribute.cs" company="Phoenix Game Studios, LLC">
//      Copyright (c) 2017 Phoenix Game Studios, LLC. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/PhoenixGameStudios/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------
namespace Dangr.Core.Command.Annotation
{
    using System;

    /// <summary>
    /// Attribute used to mark a parameter of a <see cref="IDangrCommand"/>.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class ParameterAttribute : Attribute
    {
        /// <summary>
        /// Gets or sets a value indicating whether this parameter is mandatory.
        /// </summary>
        public bool Mandatory { get; set; } = false;

        /// <summary>
        /// Gets or sets the position of this parameter in the command line.
        /// </summary>
        public int Position { get; set; } = -1;

        /// <summary>
        /// Gets the summary of this parameter used in the command help.
        /// </summary>
        public string Summary { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ParameterAttribute" /> class.
        /// </summary>
        /// <param name="summary">The summary of this parameter used in the command help.</param>
        public ParameterAttribute(string summary)
        {
            this.Summary = summary;
        }
    }
}