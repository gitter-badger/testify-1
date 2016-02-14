namespace Testify
{
    /// <summary>
    /// Defines factory methods for creating <see langword="bool"/> values.
    /// </summary>
    public static class BoolFactory
    {
        /// <summary>
        /// Creates a random <see langword="bool"/> value using a uniform distribution algorithm.
        /// </summary>
        /// <param name="factory">The factory instance.</param>
        /// <returns>A random <see langword="bool"/> value.</returns>
        public static bool CreateBool(this IObjectFactory factory)
        {
            Argument.NotNull(factory, nameof(factory));

            return factory.CreateBool(Distribution.Uniform);
        }

        /// <summary>
        /// Creates a random <see langword="bool"/> value using the specified distribution algorithm.
        /// </summary>
        /// <param name="factory">The factory instance.</param>
        /// <param name="distribution">The distribution algorithm to use.</param>
        /// <returns>A random <see langword="bool"/> value.</returns>
        public static bool CreateBool(this IObjectFactory factory, Distribution distribution)
        {
            Argument.NotNull(factory, nameof(factory));
            Argument.NotNull(distribution, nameof(distribution));

            return factory.CreateDouble(0, 1, distribution) >= 0.5;
        }
    }
}