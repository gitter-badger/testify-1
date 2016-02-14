namespace Testify
{
    /// <summary>
    /// Defines factory methods for creating <see langword="double"/> values.
    /// </summary>
    public static class DoubleFactory
    {
        /// <summary>
        /// Creates a random <see langword="double"/> value using a uniform distribution algorithm.
        /// </summary>
        /// <param name="factory">The factory instance.</param>
        /// <returns>A random <see langword="double"/> value.</returns>
        public static double CreateDouble(this IObjectFactory factory)
        {
            Argument.NotNull(factory, nameof(factory));

            return factory.CreateDouble(double.MinValue, double.MaxValue, Distribution.Uniform);
        }

        /// <summary>
        /// Creates a random <see langword="double"/> value within the specified range using a uniform
        /// distribution algorithm.
        /// </summary>
        /// <param name="factory">The factory instance.</param>
        /// <param name="minimum">The minimum value.</param>
        /// <param name="maximum">The maximum value.</param>
        /// <returns>A random <see langword="double"/> value.</returns>
        public static double CreateDouble(this IObjectFactory factory, double minimum, double maximum)
        {
            Argument.NotNull(factory, nameof(factory));
            Argument.InRange(maximum, minimum, double.MaxValue, nameof(maximum), "The maximum value must be greater than the minimum value.");

            return factory.CreateDouble(minimum, maximum, Distribution.Uniform);
        }

        /// <summary>
        /// Creates a random <see langword="double"/> value using the specified distribution algorithm.
        /// </summary>
        /// <param name="factory">The factory instance.</param>
        /// <param name="distribution">The distribution algorithm to use.</param>
        /// <returns>A random <see langword="double"/> value.</returns>
        public static double CreateDouble(this IObjectFactory factory, Distribution distribution)
        {
            Argument.NotNull(factory, nameof(factory));
            Argument.NotNull(distribution, nameof(distribution));

            return factory.CreateDouble(double.MinValue, double.MaxValue, distribution);
        }
    }
}