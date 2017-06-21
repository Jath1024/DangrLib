namespace Dangr.Command
{
    /// <summary>
    /// Provides an interface for creating new <see cref="DangrCommand"/> instances.
    /// </summary>
    public interface IDangrCommandFactory
    {
        /// <summary>
        /// Gets the name of the command.
        /// </summary>
        string CommandName { get; }

        /// <summary>
        /// Gets the command help.
        /// </summary>
        string CommandHelp { get; }

        /// <summary>
        /// Creates a new instance of the specified <see cref="DangrCommand"/> using the given command line.
        /// </summary>
        /// <param name="commandLine">The command line.</param>
        /// <returns>A new <see cref="DangrCommand"/> instance with parameters set from the given command line.</returns>
        DangrCommand Create(CommandLine commandLine);
    }
}
