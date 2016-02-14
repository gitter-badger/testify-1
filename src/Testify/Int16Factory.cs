namespace Testify
{
    /// <summary>
    /// Defines factory methods for creating <see langword="short"/> values.
    /// </summary>
    public static class Int16Factory
    {
        /// <summary>
        /// Creates a random <see langword="short"/> value using a uniform distribution algorithm.
        /// </summary>
        /// <param name="factory">The factory instance.</param>
        /// <returns>A random <see langword="short"/> value.</returns>
        public static short CreateInt16(this IObjectFactory factory)
        {
            Argument.NotNull(factory, nameof(factory));

            return factory.CreateInt16(short.MinValue, short.MaxValue, Distribution.Uniform);
        }

        /// <summary>
        /// Creates a random <see langword="short"/> value within the specified range using a uniform
        /// distribution algorithm.
        /// </summary>
        /// <param name="factory">The factory instance.</param>
        /// <param name="minimum">The minimum value.</param>
        /// <param name="maximum">The maximum value.</param>
        /// <returns>A random <see langword="short"/> value.</returns>
        public static short CreateInt16(this IObjectFactory factory, short minimum, short maximum)
        {
            Argument.NotNull(factory, nameof(factory));
            Argument.InRange(maximum, minimum, short.MaxValue, nameof(maximum), "The maximum value must be greater than the minimum value.");

            return factory.CreateInt16(minimum, maximum, Distribution.Uniform);
        }

        /// <summary>
        /// Creates a random <see langword="short"/> value using the specified distribution algorithm.
        /// </summary>
        /// <param name="factory">The factory instance.</param>
        /// <param name="distribution">The distribution algorithm to use.</param>
        /// <returns>A random <see langword="short"/> value.</returns>
        public static short CreateInt16(this IObjectFactory factory, Distribution distribution)
        {
            Argument.NotNull(factory, nameof(factory));
            Argument.NotNull(distribution, nameof(distribution));

            return factory.CreateInt16(short.MinValue, short.MaxValue, distribution);
        }

        /// <summary>
        /// Creates a random <see langword="short"/> value within the specified range using the specified
        /// distribution algorithm.
        /// </summary>
        /// <param name="factory">The factory instance.</param>
        /// <param name="minimum">The minimum value.</param>
        /// <param name="maximum">The maximum value.</param>
        /// <param name="distribution">The distribution algorithm to use.</param>
        /// <returns>A random <see langword="short"/> value.</returns>
        public static short CreateInt16(this IObjectFactory factory, short minimum, short maximum, Distribution distribution)
        {
            Argument.NotNull(factory, nameof(factory));
            Argument.InRange(maximum, minimum, short.MaxValue, nameof(maximum), "The maximum value must be greater than the minimum value.");
            Argument.NotNull(distribution, nameof(distribution));

            return (short)factory.CreateInt64(minimum, maximum, distribution);
        }
    }
}