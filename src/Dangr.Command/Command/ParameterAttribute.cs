namespace Dangr.Command
{
    using System;

    /// <summary>
    /// Attribute used to mark a parameter of a <see cref="DangrCommand"/>.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public sealed class ParameterAttribute : Attribute
    {
        /// <summary>
        /// Gets or sets a value indicating whether this parameter is mandatory.
        /// </summary>
        /// <value>
        ///   <c>true</c> if mandatory; otherwise, <c>false</c>.
        /// </value>
        public bool Mandatory { get; set; } = false;

        /// <summary>
        /// Gets or sets the position of this parameter in the command line.
        /// </summary>
        public int Position { get; set; }

        /// <summary>
        /// Gets or sets the summary of this parameter used in the command help.
        /// </summary>
        public string Summary { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ParameterAttribute" /> class.
        /// </summary>
        /// <param name="position">The position of this parameter in the command line. Use -1 for named parameters.</param>
        public ParameterAttribute(int position)
        {
            this.Position = position;
        }
    }
}
