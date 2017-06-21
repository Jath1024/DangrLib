namespace Dangr.Command
{
    using System;

    /// <summary>
    /// Defines an alias that can be used to access a named parameter of a <see cref="DangrCommand"/>.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = true)]
    public sealed class AliasAttribute : Attribute
    {
        /// <summary>
        /// Gets the alias that can be used to reference this parameter.
        /// </summary>
        public string Alias { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AliasAttribute"/> class.
        /// </summary>
        /// <param name="alias">The alias that can be used to reference this parameter.</param>
        public AliasAttribute(string alias)
        {
            this.Alias = alias;
        }
    }
}
