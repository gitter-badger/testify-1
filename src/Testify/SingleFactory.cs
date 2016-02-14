namespace Testify
{
    /// <summary>
    /// Defines factory methods for creating <see langword="float"/> values.
    /// </summary>
    public static class SingleFactory
    {
        /// <summary>
        /// Creates a random <see langword="float"/> value using a uniform distribution algorithm.
        /// </summary>
        /// <param name="factory">The factory instance.</param>
        /// <returns>A random <see langword="float"/> value.</returns>
        public static float CreateSingle(this IObjectFactory factory)
        {
            Argument.NotNull(factory, nameof(factory));

            return factory.CreateSingle(float.MinValue, float.MaxValue, Distribution.Uniform);
        }

        /// <summary>
        /// Creates a random <see langword="float"/> value within the specified range using a uniform
        /// distribution algorithm.
        /// </summary>
        /// <param name="factory">The factory instance.</param>
        /// <param name="minimum">The minimum value.</param>
        /// <param name="maximum">The maximum value.</param>
        /// <returns>A random <see langword="float"/> value.</returns>
        public static float CreateSingle(this IObjectFactory factory, float minimum, float maximum)
        {
            Argument.NotNull(factory, nameof(factory));
            Argument.InRange(maximum, minimum, float.MaxValue, nameof(maximum), "The maximum value must be greater than the minimum value.");

            return factory.CreateSingle(minimum, maximum, Distribution.Uniform);
        }

        /// <summary>
        /// Creates a random <see langword="float"/> value using the specified distribution algorithm.
        /// </summary>
        /// <param name="factory">The factory instance.</param>
        /// <param name="distribution">The distribution algorithm to use.</param>
        /// <returns>A random <see langword="float"/> value.</returns>
        public static float CreateSingle(this IObjectFactory factory, Distribution distribution)
        {
            Argument.NotNull(factory, nameof(factory));
            Argument.NotNull(distribution, nameof(distribution));

            return factory.CreateSingle(float.MinValue, float.MaxValue, distribution);
        }

        /// <summary>
        /// Creates a random <see langword="float"/> value within the specified range using the specified
        /// distribution algorithm.
        /// </summary>
        /// <param name="factory">The factory instance.</param>
        /// <param name="minimum">The minimum value.</param>
        /// <param name="maximum">The maximum value.</param>
        /// <param name="distribution">The distribution algorithm to use.</param>
        /// <returns>A random <see langword="float"/> value.</returns>
        public static float CreateSingle(this IObjectFactory factory, float minimum, float maximum, Distribution distribution)
        {
            Argument.NotNull(factory, nameof(factory));
            Argument.InRange(maximum, minimum, float.MaxValue, nameof(maximum), "The maximum value must be greater than the minimum value.");
            Argument.NotNull(distribution, nameof(distribution));

            return (float)factory.CreateDouble(minimum, maximum, distribution);
        }
    }
}