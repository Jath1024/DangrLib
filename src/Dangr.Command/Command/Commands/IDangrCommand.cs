namespace Dangr.Command.Commands
{
    /// <summary>
    /// Defines a command that can be executed.
    /// </summary>
    public interface IDangrCommand
    {
        /// <summary>
        /// Executes this <see cref="IDangrCommand"/>.
        /// </summary>
        void Execute(ICommandContext executionContext);
    }
}
