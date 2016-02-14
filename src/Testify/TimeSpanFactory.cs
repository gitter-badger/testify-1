using System;

namespace Testify
{
    /// <summary>
    /// Defines factory methods for creating <see langword="TimeSpan"/> values.
    /// </summary>
    public static class TimeSpanFactory
    {
        /// <summary>
        /// Creates a random <see langword="TimeSpan"/> value using a uniform distribution algorithm.
        /// </summary>
        /// <param name="factory">The factory instance.</param>
        /// <returns>A random <see langword="TimeSpan"/> value.</returns>
        public static TimeSpan CreateTimeSpan(this IObjectFactory factory)
        {
            Argument.NotNull(factory, nameof(factory));

            return factory.CreateTimeSpan(TimeSpan.MinValue, TimeSpan.MaxValue, Distribution.Uniform);
        }

        /// <summary>
        /// Creates a random <see langword="TimeSpan"/> value within the specified range using a uniform
        /// distribution algorithm.
        /// </summary>
        /// <param name="factory">The factory instance.</param>
        /// <param name="minimum">The minimum value.</param>
        /// <param name="maximum">The maximum value.</param>
        /// <returns>A random <see langword="TimeSpan"/> value.</returns>
        public static TimeSpan CreateTimeSpan(this IObjectFactory factory, TimeSpan minimum, TimeSpan maximum)
        {
            Argument.NotNull(factory, nameof(factory));
            Argument.InRange(maximum, minimum, TimeSpan.MaxValue, nameof(maximum), "The maximum value must be greater than the minimum value.");

            return factory.CreateTimeSpan(minimum, maximum, Distribution.Uniform);
        }

        /// <summary>
        /// Creates a random <see langword="TimeSpan"/> value using the specified distribution algorithm.
        /// </summary>
        /// <param name="factory">The factory instance.</param>
        /// <param name="distribution">The distribution algorithm to use.</param>
        /// <returns>A random <see langword="TimeSpan"/> value.</returns>
        public static TimeSpan CreateTimeSpan(this IObjectFactory factory, Distribution distribution)
        {
            Argument.NotNull(factory, nameof(factory));
            Argument.NotNull(distribution, nameof(distribution));

            return factory.CreateTimeSpan(TimeSpan.MinValue, TimeSpan.MaxValue, distribution);
        }

        /// <summary>
        /// Creates a random <see langword="TimeSpan"/> value within the specified range using the specified
        /// distribution algorithm.
        /// </summary>
        /// <param name="factory">The factory instance.</param>
        /// <param name="minimum">The minimum value.</param>
        /// <param name="maximum">The maximum value.</param>
        /// <param name="distribution">The distribution algorithm to use.</param>
        /// <returns>A random <see langword="TimeSpan"/> value.</returns>
        public static TimeSpan CreateTimeSpan(this IObjectFactory factory, TimeSpan minimum, TimeSpan maximum, Distribution distribution)
        {
            Argument.NotNull(factory, nameof(factory));
            Argument.InRange(maximum, minimum, TimeSpan.MaxValue, nameof(maximum), "The maximum value must be greater than the minimum value.");
            Argument.NotNull(distribution, nameof(distribution));

            long ticks = factory.CreateInt64(minimum.Ticks, maximum.Ticks, distribution);
            return new TimeSpan(ticks);
        }
    }
}