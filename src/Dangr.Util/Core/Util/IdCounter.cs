// -----------------------------------------------------------------------
//  <copyright file="IdCounter.cs" company="Phoenix Game Studios, LLC">
//      Copyright (c) 2017 Phoenix Game Studios, LLC. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/PhoenixGameStudios/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------
namespace Dangr.Core.Util
{
    using System;

    /// <summary>
    ///     A counter that keeps track of the next ID within a range of IDs.
    /// </summary>
    public class IdCounter : IIdCounter
    {
        private readonly ulong max;
        private readonly ulong min;
        private ulong next;

        /// <summary>
        ///     Initializes a new instance of the <see cref="IdCounter" /> class.
        /// </summary>
        /// <param name="min"> The minimum value used by this <see cref="IdCounter" />. </param>
        /// <param name="size"> The size of the range of this <see cref="IdCounter" />. </param>
        /// <exception cref="ArgumentOutOfRangeException"> If the specified range overflows uint.MaxValue. </exception>
        public IdCounter(ulong min, ulong size)
        {
            if (size - 1 > ulong.MaxValue - min)
            {
                throw new ArgumentOutOfRangeException(
                    $"IdCounter size '{size}' is too large. With min value '{min}', the range is larger than ulong.MaxValue.");
            }

            this.min = min;
            this.max = min + size - 1;
            this.next = min;
        }

        /// <summary>
        ///     Gets the next available ID.
        /// </summary>
        /// <returns> The next available Id. </returns>
        /// <exception cref="IdCounterOutOfRangeException">
        ///     If the next value would be larger than the max value of this <see cref="IdCounter" />.
        /// </exception>
        public ulong GetId()
        {
            if (this.next > this.max)
            {
                throw new IdCounterOutOfRangeException(this.min, this.max, this.next);
            }

            return this.next++;
        }

        /// <summary>
        ///     Helper class with constants definine ranges.
        /// </summary>
        public static class Range
        {
            /// <summary>
            ///     A range of one hundred.
            /// </summary>
            public const ulong OneHundred = 100;

            /// <summary>
            ///     A range of one thousand.
            /// </summary>
            public const ulong OneThousand = 1000;

            /// <summary>
            ///     A range of one million.
            /// </summary>
            public const ulong OneMillion = 1000000;

            /// <summary>
            ///     A range of one hundred million.
            /// </summary>
            public const ulong OneHundredMillion = 100000000;

            /// <summary>
            ///     The maximum possible range.
            /// </summary>
            public const ulong Max = ulong.MaxValue;
        }
    }
}