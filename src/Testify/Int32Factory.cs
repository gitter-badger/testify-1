namespace Testify
{
    /// <summary>
    /// Defines factory methods for creating <see langword="int"/> values.
    /// </summary>
    public static class Int32Factory
    {
        /// <summary>
        /// Creates a random <see langword="int"/> value using a uniform distribution algorithm.
        /// </summary>
        /// <param name="factory">The factory instance.</param>
        /// <returns>A random <see langword="int"/> value.</returns>
        public static int CreateInt32(this IObjectFactory factory)
        {
            Argument.NotNull(factory, nameof(factory));

            return factory.CreateInt32(int.MinValue, int.MaxValue, Distribution.Uniform);
        }

        /// <summary>
        /// Creates a random <see langword="int"/> value within the specified range using a uniform distribution algorithm.
        /// </summary>
        /// <param name="factory">The factory instance.</param>
        /// <param name="minimum">The minimum value.</param>
        /// <param name="maximum">The maximum value.</param>
        /// <returns>A random <see langword="int"/> value.</returns>
        public static int CreateInt32(this IObjectFactory factory, int minimum, int maximum)
        {
            Argument.NotNull(factory, nameof(factory));
            Argument.InRange(maximum, minimum, int.MaxValue, nameof(maximum), "The maximum value must be greater than the minimum value.");

            return factory.CreateInt32(minimum, maximum, Distribution.Uniform);
        }

        /// <summary>
        /// Creates a random <see langword="int"/> value using the specified distribution algorithm.
        /// </summary>
        /// <param name="factory">The factory instance.</param>
        /// <param name="distribution">The distribution algorithm to use.</param>
        /// <returns>A random <see langword="int"/> value.</returns>
        public static int CreateInt32(this IObjectFactory factory, Distribution distribution)
        {
            Argument.NotNull(factory, nameof(factory));
            Argument.NotNull(distribution, nameof(distribution));

            return factory.CreateInt32(int.MinValue, int.MaxValue, distribution);
        }

        /// <summary>
        /// Creates a random <see langword="int"/> value within the specified range using the specified
        /// distribution algorithm.
        /// </summary>
        /// <param name="factory">The factory instance.</param>
        /// <param name="minimum">The minimum value.</param>
        /// <param name="maximum">The maximum value.</param>
        /// <param name="distribution">The distribution algorithm to use.</param>
        /// <returns>A random <see langword="int"/> value.</returns>
        public static int CreateInt32(this IObjectFactory factory, int minimum, int maximum, Distribution distribution)
        {
            Argument.NotNull(factory, nameof(factory));
            Argument.InRange(maximum, minimum, int.MaxValue, nameof(maximum), "The maximum value must be greater than the minimum value.");
            Argument.NotNull(distribution, nameof(distribution));

            return (int)factory.CreateInt64(minimum, maximum, distribution);
        }
    }
}