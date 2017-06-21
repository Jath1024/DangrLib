namespace Dangr.Command
{
    /// <summary>
    /// Defines a command that can be executed.
    /// </summary>
    public abstract class DangrCommand
    {
        /// <summary>
        /// Gets the <see cref="ICommandContext"/>.
        /// </summary>
        protected ICommandContext ExecutionContext { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DangrCommand"/> class.
        /// </summary>
        public DangrCommand()
        {
        }

        /// <summary>
        /// Executes this <see cref="DangrCommand"/>.
        /// </summary>
        public void Execute(ICommandContext executionContext)
        {
            this.ExecutionContext = executionContext;
            this.ExecuteCommand();
            this.ExecutionContext = null;
        }

        /// <summary>
        /// Executes the command.
        /// </summary>
        protected abstract void ExecuteCommand();

        /// <summary>
        /// Outputs the specified output to the <see cref="ICommandContext"/>.
        /// </summary>
        /// <typeparam name="T">The type of output.</typeparam>
        /// <param name="output">The output.</param>
        protected void Output<T>(T output)
        {
            this.ExecutionContext.Output(output);
        }

        /// <summary>
        /// Outputs the specified error to the <see cref="ICommandContext"/>.
        /// </summary>
        /// <typeparam name="T">The type of error.</typeparam>
        /// <param name="error">The error.</param>
        protected void Error<T>(T error)
        {
            this.ExecutionContext.Error(error);
        }
    }
}
