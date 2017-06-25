namespace Dangr.Command.Commands
{
    /// <summary>
    /// <see cref="IDangrCommand"/> that provides help for DangrCommands within the current command context.
    /// </summary>
    [DangrCommand(summary: "Provides help for DangrCommands within the current command context.")]
    public class DangrCommandHelp : IDangrCommand
    {
        /// <summary>
        /// Executes this <see cref="IDangrCommand" />.
        /// </summary>
        /// <param name="executionContext"></param>
        public void Execute(ICommandContext executionContext)
        {
            executionContext.Output(executionContext.ToString());
        }
    }
}
