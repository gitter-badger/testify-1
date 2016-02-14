using System;

namespace Testify
{
    /// <summary>
    /// Defines factory methods for creating <see langword="DateTime"/> values.
    /// </summary>
    public static class DateTimeFactory
    {
        /// <summary>
        /// Creates a random <see langword="DateTime"/> value using a uniform distribution algorithm.
        /// </summary>
        /// <param name="factory">The factory instance.</param>
        /// <returns>A random <see langword="DateTime"/> value.</returns>
        public static DateTime CreateDateTime(this IObjectFactory factory)
        {
            Argument.NotNull(factory, nameof(factory));

            return factory.CreateDateTime(DateTime.MinValue, DateTime.MaxValue, Distribution.Uniform);
        }

        /// <summary>
        /// Creates a random <see langword="DateTime"/> value within the specified range using a uniform
        /// distribution algorithm.
        /// </summary>
        /// <param name="factory">The factory instance.</param>
        /// <param name="minimum">The minimum value.</param>
        /// <param name="maximum">The maximum value.</param>
        /// <returns>A random <see langword="DateTime"/> value.</returns>
        public static DateTime CreateDateTime(this IObjectFactory factory, DateTime minimum, DateTime maximum)
        {
            Argument.NotNull(factory, nameof(factory));
            Argument.InRange(maximum, minimum, DateTime.MaxValue, nameof(maximum), "The maximum value must be greater than the minimum value.");

            return factory.CreateDateTime(minimum, maximum, Distribution.Uniform);
        }

        /// <summary>
        /// Creates a random <see langword="DateTime"/> value using the specified distribution algorithm.
        /// </summary>
        /// <param name="factory">The factory instance.</param>
        /// <param name="distribution">The distribution algorithm to use.</param>
        /// <returns>A random <see langword="DateTime"/> value.</returns>
        public static DateTime CreateDateTime(this IObjectFactory factory, Distribution distribution)
        {
            Argument.NotNull(factory, nameof(factory));
            Argument.NotNull(distribution, nameof(distribution));

            return factory.CreateDateTime(DateTime.MinValue, DateTime.MaxValue, distribution);
        }

        /// <summary>
        /// Creates a random <see langword="DateTime"/> value within the specified range using the specified
        /// distribution algorithm.
        /// </summary>
        /// <param name="factory">The factory instance.</param>
        /// <param name="minimum">The minimum value.</param>
        /// <param name="maximum">The maximum value.</param>
        /// <param name="distribution">The distribution algorithm to use.</param>
        /// <returns>A random <see langword="DateTime"/> value.</returns>
        public static DateTime CreateDateTime(this IObjectFactory factory, DateTime minimum, DateTime maximum, Distribution distribution)
        {
            Argument.NotNull(factory, nameof(factory));
            Argument.InRange(maximum, minimum, DateTime.MaxValue, nameof(maximum), "The maximum value must be greater than the minimum value.");
            Argument.NotNull(distribution, nameof(distribution));

            long ticks = factory.CreateInt64(minimum.Ticks, maximum.Ticks, distribution);
            return new DateTime(ticks);
        }
    }
}