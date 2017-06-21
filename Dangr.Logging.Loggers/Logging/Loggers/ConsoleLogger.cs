// -----------------------------------------------------------------------
//  <copyright file="ConsoleLogger.cs" company="DangerDan9631">
//      Copyright (c) 2017 Dan Garvey. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/Dangerdan9631/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
//  <dateCreated>2017-04-24</dateCreated>
//  <dateModified>2017-06-20</dateModified>
//  <lastModifiedBy>Dan Garvey</lastModifiedBy>
// -----------------------------------------------------------------------

namespace Dangr.Logging.Loggers
{
    using System;
    using System.Runtime.InteropServices;
    using Dangr.Diagnostics;
    using Dangr.Util;

    /// <summary>
    /// Logger pipeline logger that will log a message to the console.
    /// </summary>
    public class ConsoleLogger : ILogEndpoint, ICancelable
    {
        #region Interop

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool AllocConsole();

        [DllImport("kernel32.dll")]
        private static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        private const int SW_HIDE = 0;
        private const int SW_SHOW = 5;

        /// <summary>
        /// Shows the console window.
        /// </summary>
        public static void ShowConsoleWindow()
        {
            IntPtr handle = ConsoleLogger.GetConsoleWindow();

            if (handle == IntPtr.Zero)
            {
                ConsoleLogger.AllocConsole();
            }
            else
            {
                ConsoleLogger.ShowWindow(handle, ConsoleLogger.SW_SHOW);
            }
        }

        /// <summary>
        /// Hides the console window.
        /// </summary>
        public static void HideConsoleWindow()
        {
            IntPtr handle = ConsoleLogger.GetConsoleWindow();

            ConsoleLogger.ShowWindow(handle, ConsoleLogger.SW_HIDE);
        }

        #endregion Interop

        /// <summary>
        /// Gets a value indicating whether this object is disposed.
        /// </summary>
        public bool IsDisposed { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConsoleLogger" /> class.
        /// </summary>
        public ConsoleLogger()
        {
            ConsoleLogger.ShowConsoleWindow();
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="ConsoleLogger" /> class.
        /// </summary>
        ~ConsoleLogger()
        {
            this.Dispose(false);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="isDisposing">
        /// <c> true </c> to release both managed and unmanaged resources; <c> false </c> to release only unmanaged resources.
        /// </param>
        protected virtual void Dispose(bool isDisposing)
        {
            ConsoleLogger.HideConsoleWindow();

            if (isDisposing && !this.IsDisposed)
            {
                this.IsDisposed = true;
            }
        }

        /// <summary>
        /// Logs the specified entry.
        /// </summary>
        /// <param name="entry">The entry.</param>
        public void Log(LogEntry entry)
        {
            Assert.Validate.NotDisposed(this, nameof(ConsoleLogger));

            ConsoleColor fg = Console.ForegroundColor;
            ConsoleColor bg = Console.BackgroundColor;

            switch (entry.LogLevel)
            {
                case LogLevel.Debug:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.BackgroundColor = ConsoleColor.Black;
                    break;
                case LogLevel.Verbose:
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.BackgroundColor = ConsoleColor.Black;
                    break;
                case LogLevel.Warning:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.BackgroundColor = ConsoleColor.Black;
                    break;
                case LogLevel.Critical:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.BackgroundColor = ConsoleColor.Black;
                    break;
                case LogLevel.Fatal:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    break;
                case LogLevel.Status:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.BackgroundColor = ConsoleColor.Black;
                    break;
                case LogLevel.Info:
                    break;
            }

            Console.WriteLine(entry.ToString());

            Console.ForegroundColor = fg;
            Console.BackgroundColor = bg;
        }
    }
}