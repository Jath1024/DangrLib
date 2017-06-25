namespace Dangr.Command
{
    using Dangr.Command.Commands;

    /// <summary>
    /// Provides an interface for creating new <see cref="IDangrCommand"/> instances.
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
        /// Creates a new instance of the specified <see cref="IDangrCommand"/> using the given command line.
        /// </summary>
        /// <param name="commandLine">The command line.</param>
        /// <returns>A new <see cref="IDangrCommand"/> instance with parameters set from the given command line.</returns>
        IDangrCommand Create(CommandLine commandLine);
    }
}
