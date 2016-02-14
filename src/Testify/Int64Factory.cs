using System;

namespace Testify
{
    /// <summary>
    /// Defines factory methods for creating <see langword="long"/> values.
    /// </summary>
    public static class Int64Factory
    {
        /// <summary>
        /// Creates a random <see langword="long"/> value.
        /// </summary>
        /// <param name="factory">The factory instance.</param>
        /// <returns>A random <see langword="long"/> value.</returns>
        public static long CreateInt64(this IObjectFactory factory)
        {
            Argument.NotNull(factory, nameof(factory));

            return factory.CreateInt64(long.MinValue, long.MaxValue, Distribution.Uniform);
        }

        /// <summary>
        /// Creates a random <see langword="long"/> value within the specified range using a uniform
        /// distribution algorithm.
        /// </summary>
        /// <param name="factory">The factory instance.</param>
        /// <param name="minimum">The minimum value.</param>
        /// <param name="maximum">The maximum value.</param>
        /// <returns>A random <see langword="long"/> value.</returns>
        public static long CreateInt64(this IObjectFactory factory, long minimum, long maximum)
        {
            Argument.NotNull(factory, nameof(factory));
            Argument.InRange(maximum, minimum, long.MaxValue, nameof(maximum), "The maximum value must be greater than the minimum value.");

            return factory.CreateInt64(minimum, maximum, Distribution.Uniform);
        }

        /// <summary>
        /// Creates a random <see langword="long"/> value using the specified distribution algorithm.
        /// </summary>
        /// <param name="factory">The factory instance.</param>
        /// <param name="distribution">The distribution algorithm to use.</param>
        /// <returns>A random <see langword="long"/> value.</returns>
        public static long CreateInt64(this IObjectFactory factory, Distribution distribution)
        {
            Argument.NotNull(factory, nameof(factory));
            Argument.NotNull(distribution, nameof(distribution));

            return factory.CreateInt64(long.MinValue, long.MaxValue, distribution);
        }

        /// <summary>
        /// Creates a random <see langword="long"/> value within the specified range using the specified
        /// distribution algorithm.
        /// </summary>
        /// <param name="factory">The factory instance.</param>
        /// <param name="minimum">The minimum value.</param>
        /// <param name="maximum">The maximum value.</param>
        /// <param name="distribution">The distribution algorithm to use.</param>
        /// <returns>A random <see langword="long"/> value.</returns>
        public static long CreateInt64(this IObjectFactory factory, long minimum, long maximum, Distribution distribution)
        {
            Argument.NotNull(factory, nameof(factory));
            Argument.InRange(maximum, minimum, long.MaxValue, nameof(maximum), "The maximum value must be greater than the minimum value.");
            Argument.NotNull(distribution, nameof(distribution));

            var min = Math.Max(minimum, long.MinValue + 1);
            return min + (long)(factory.CreateDouble(0, 1, distribution) * ((double)maximum - (double)min));
        }
    }
}