namespace Dangr.Command.Commands
{
    using System;

    /// <summary>
    /// Defines an object as an <see cref="IDangrCommand"/>.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public sealed class DangrCommandAttribute : Attribute
    {
        /// <summary>
        /// Gets the summary of the command.
        /// </summary>
        public string Summary { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DangrCommandAttribute"/> class.
        /// </summary>
        /// <param name="summary">The summary of the command.</param>
        public DangrCommandAttribute(string summary)
        {
            this.Summary = summary;
        }
    }
}
