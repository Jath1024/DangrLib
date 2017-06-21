namespace Dangr.Command.Commands
{
    /// <summary>
    /// <see cref="DangrCommand"/> that provides help for DangrCommands within the current command context.
    /// </summary>
    [DangrCommand(summary: "Provides help for DangrCommands within the current command context.")]
    public class DangrCommandHelp : DangrCommand
    {
        /// <summary>
        /// Executes the command.
        /// </summary>
        protected override void ExecuteCommand()
        {
            this.Output(this.ExecutionContext.ToString());
        }
    }
}
