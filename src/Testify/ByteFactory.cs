namespace Testify
{
    /// <summary>
    /// Defines factory methods for creating <see langword="int"/> values.
    /// </summary>
    public static class ByteFactory
    {
        /// <summary>
        /// Creates a random <see langword="byte"/> value using a uniform distribution algorithm.
        /// </summary>
        /// <param name="factory">The factory instance.</param>
        /// <returns>A random <see langword="byte"/> value.</returns>
        public static byte CreateByte(this IObjectFactory factory)
        {
            Argument.NotNull(factory, nameof(factory));

            return factory.CreateByte(byte.MinValue, byte.MaxValue, Distribution.Uniform);
        }

        /// <summary>
        /// Creates a random <see langword="byte"/> value within the specified range using a uniform
        /// distribution algorithm.
        /// </summary>
        /// <param name="factory">The factory instance.</param>
        /// <param name="minimum">The minimum value.</param>
        /// <param name="maximum">The maximum value.</param>
        /// <returns>A random <see langword="byte"/> value.</returns>
        public static byte CreateByte(this IObjectFactory factory, byte minimum, byte maximum)
        {
            Argument.NotNull(factory, nameof(factory));
            Argument.InRange(maximum, minimum, double.MaxValue, nameof(maximum), "The maximum value must be greater than the minimum value.");

            return factory.CreateByte(minimum, maximum, Distribution.Uniform);
        }

        /// <summary>
        /// Creates a random <see langword="byte"/> value using the specified distribution algorithm.
        /// </summary>
        /// <param name="factory">The factory instance.</param>
        /// <param name="distribution">The distribution algorithm to use.</param>
        /// <returns>A random <see langword="byte"/> value.</returns>
        public static byte CreateByte(this IObjectFactory factory, Distribution distribution)
        {
            Argument.NotNull(factory, nameof(factory));
            Argument.NotNull(distribution, nameof(distribution));

            return factory.CreateByte(byte.MinValue, byte.MaxValue, distribution);
        }

        /// <summary>
        /// Creates a random <see langword="byte"/> value within the specified range using the specified
        /// distribution algorithm.
        /// </summary>
        /// <param name="factory">The factory instance.</param>
        /// <param name="minimum">The minimum value.</param>
        /// <param name="maximum">The maximum value.</param>
        /// <param name="distribution">The distribution algorithm to use.</param>
        /// <returns>A random <see langword="byte"/> value.</returns>
        public static byte CreateByte(this IObjectFactory factory, byte minimum, byte maximum, Distribution distribution)
        {
            Argument.NotNull(factory, nameof(factory));
            Argument.InRange(maximum, minimum, double.MaxValue, nameof(maximum), "The maximum value must be greater than the minimum value.");
            Argument.NotNull(distribution, nameof(distribution));

            return (byte)factory.CreateInt64(minimum, maximum, distribution);
        }
    }
}