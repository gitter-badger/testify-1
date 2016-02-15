﻿using System;
using System.Diagnostics;
using System.Linq;

namespace Testify
{
    /// <summary>
    /// Defines a range of acceptable values.
    /// </summary>
    internal sealed class Range
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Range"/> class.
        /// </summary>
        /// <param name="minimum">The minimum value.</param>
        /// <param name="maximum">The maximum value.</param>
        public Range(long minimum, long maximum)
        {
            Argument.InRange(maximum, minimum, double.MaxValue, nameof(maximum), "The maximum value must be greater than the minimum value.");

            this.Minimum = minimum;
            this.Maximum = maximum;
        }

        /// <summary>
        /// Gets the length of the range.
        /// </summary>
        public long Length => this.Maximum - this.Minimum;

        /// <summary>
        /// Gets the maximum value;
        /// </summary>
        public long Maximum { get; }

        /// <summary>
        /// Gets the minimum value.
        /// </summary>
        public long Minimum { get; }

        /// <summary>
        /// Creates a <see langword="long"/> value within the specified ranges using the specified factory
        /// and distribution algorithm.
        /// </summary>
        /// <param name="factory">The factory used to create the <see langword="long"/> value.</param>
        /// <param name="distribution">The distribution algorithm to use.</param>
        /// <param name="ranges">The ranges the value must be within.</param>
        /// <returns>A random <see langword="long"/> value that falls within the specified ranges.</returns>
        public static long CreateLongFromRanges(IObjectFactory factory, Distribution distribution, params Range[] ranges)
        {
            Argument.NotNull(factory, nameof(factory));
            Argument.NotNull(distribution, nameof(distribution));
            Argument.NotNull(ranges, nameof(ranges));
            if (ranges.Length == 0)
            {
                throw new ArgumentException("The ranges must not be empty.", nameof(ranges));
            }

            VerifyRanges(ranges);
            long length = ranges.Sum(r => r.Length);
            long index = factory.CreateInt64(0, length - 1, distribution);
            for (int i = 0; i < ranges.Length; ++i)
            {
                if (index < ranges[i].Length)
                {
                    var result = ranges[i].Minimum + index;
                    Debug.Assert(result >= ranges[i].Minimum && result <= ranges[i].Maximum, "Invalid range value.");
                    return result;
                }

                index -= ranges[i].Length;
            }

            throw new InvalidOperationException();
        }

        /// <summary>
        /// Verifies the ranges are valid.
        /// </summary>
        /// <param name="ranges">The ranges to verify.</param>
        [Conditional("Debug")]
        private static void VerifyRanges(Range[] ranges)
        {
            for (int i = 0; i < ranges.Length - 1; ++i)
            {
                if (ranges[i].Maximum > ranges[i + 1].Minimum)
                {
                    throw new ArgumentOutOfRangeException(nameof(ranges));
                }
            }
        }
    }
}