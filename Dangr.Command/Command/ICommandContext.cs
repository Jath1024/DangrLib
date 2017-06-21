namespace Dangr.Command
{
    using Dangr.Util;

    /// <summary>
    /// Interface for the context within which a <see cref="DangrCommand"/> will run.
    /// </summary>
    public interface ICommandContext : INamedObject
    {
        /// <summary>
        /// Gets the name of the <see cref="ICommandContext"/>.
        /// </summary>
        /// <value>The name of the <see cref="ICommandContext"/>.</value>
        string ContextName { get; }

        /// <summary>
        /// Executes the specified command line.
        /// </summary>
        /// <param name="commandLine">The command line.</param>
        void Execute(string commandLine);

        /// <summary>
        /// Outputs the specified object to the <see cref="ICommandContext"/> output stream.
        /// </summary>
        /// <typeparam name="T">The type of output.</typeparam>
        /// <param name="output">The output.</param>
        void Output<T>(T output);

        /// <summary>
        /// Outputs the specified object to the <see cref="ICommandContext"/> error stream.
        /// </summary>
        /// <typeparam name="T">The type of error.</typeparam>
        /// <param name="error">The error.</param>
        void Error<T>(T error);
    }
}
