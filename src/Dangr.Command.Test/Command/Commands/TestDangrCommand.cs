namespace Dangr.Command.Commands
{
    using Dangr.Command;

    /// <summary>
    /// A test <see cref="IDangrCommand"/>.
    /// </summary>
    [DangrCommand(summary: "A test command.")]
    public class DangrCommandTest : IDangrCommand
    {
        /// <summary>
        /// Gets or sets the positional parameter0.
        /// </summary>
        [Parameter(0, Mandatory = false, Summary ="Parameter at position 0.")]
        public string Parameter0 { get; set; }

        /// <summary>
        /// Gets or sets the positional parameter1.
        /// </summary>
        [Parameter(1, Mandatory = false, Summary = "Parameter at position 1.")]
        public string Parameter1 { get; set; }

        /// <summary>
        /// Gets or sets the named parameter.
        /// </summary>
        [Parameter(-1, Mandatory = true, Summary = "A named parameter.")]
        [Alias("name")]
        [Alias("fuck")]
        public string Named0 { get; set; }

        /// <summary>
        /// Executes the command.
        /// </summary>
        public void Execute(ICommandContext executionContext)
        {
            executionContext.Output($"P0: {this.Parameter0} P1: {this.Parameter1} Named0: {this.Named0}");
        }
    }
}
