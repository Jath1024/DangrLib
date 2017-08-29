// -----------------------------------------------------------------------
//  <copyright file="TestDisposable.cs" company="Phoenix Game Studios, LLC">
//      Copyright (c) 2017 Phoenix Game Studios, LLC. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/PhoenixGameStudios/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.Core.Test
{
    using Dangr.Core.Util;

    /// <summary>
    /// An <see cref="ICheckedDisposable"/> that can be set and used inside test cases.
    /// </summary>
    public sealed class TestDisposable : ICheckedDisposable
    {
        /// <summary>
        /// Gets a value that indicates whether the object is disposed.
        /// </summary>
        public bool IsDisposed { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TestDisposable"/> class.
        /// </summary>
        /// <param name="isDisposed">Set to <c>true</c> if the object is disposed.</param>
        public TestDisposable(bool isDisposed)
        {
            this.IsDisposed = isDisposed;
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.IsDisposed = true;
        }
    }
}