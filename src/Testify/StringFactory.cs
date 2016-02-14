using System.Text;

namespace Testify
{
    /// <summary>
    /// Defines factory methods for creating <see langword="string"/> values.
    /// </summary>
    public static class StringFactory
    {
        /// <summary>
        /// Creates a random <see langword="string"/> value with a length of 0 to 20 characters using
        /// a uniform distribution algorithm for generating alpha characters.
        /// </summary>
        /// <param name="factory">The factory instance.</param>
        /// <returns>A random <see langword="string"/> value.</returns>
        public static string CreateString(this IObjectFactory factory)
        {
            Argument.NotNull(factory, nameof(factory));

            return factory.CreateString(0, 20, Distribution.Uniform);
        }

        /// <summary>
        /// Creates a random <see langword="string"/> value with a length within the specified range using
        /// a uniform distribution algorithm for generating alpha characters.
        /// </summary>
        /// <param name="factory">The factory instance.</param>
        /// <param name="minimumLength">The minimum length.</param>
        /// <param name="maximumLength">The maximum length.</param>
        /// <returns>A random <see langword="string"/> value.</returns>
        public static string CreateString(this IObjectFactory factory, int minimumLength, int maximumLength)
        {
            Argument.NotNull(factory, nameof(factory));
            Argument.InRange(maximumLength, minimumLength, int.MaxValue, nameof(maximumLength), "The maximum length must be greater than the minimum length.");

            return factory.CreateString(minimumLength, maximumLength, Distribution.Uniform);
        }

        /// <summary>
        /// Creates a random <see langword="string"/> value with a length of 0 to 20 characters using
        /// the specified distribution algorithm for generating alpha characters.
        /// </summary>
        /// <param name="factory">The factory instance.</param>
        /// <param name="distribution">The distribution algorithm to use.</param>
        /// <returns>A random <see langword="string"/> value.</returns>
        public static string CreateString(this IObjectFactory factory, Distribution distribution)
        {
            Argument.NotNull(factory, nameof(factory));
            Argument.NotNull(distribution, nameof(distribution));

            return factory.CreateString(0, 20, distribution);
        }

        /// <summary>
        /// Creates a random <see langword="string"/> value with a length within the specified range using
        /// the specified distribution algorithm for generating alpha characters.
        /// </summary>
        /// <param name="factory">The factory instance.</param>
        /// <param name="minimumLength">The minimum length.</param>
        /// <param name="maximumLength">The maximum length.</param>
        /// <param name="distribution">The distribution algorithm to use.</param>
        /// <returns>A random <see langword="string"/> value.</returns>
        public static string CreateString(this IObjectFactory factory, int minimumLength, int maximumLength, Distribution distribution)
        {
            Argument.NotNull(factory, nameof(factory));
            Argument.InRange(maximumLength, minimumLength, int.MaxValue, nameof(maximumLength), "The maximum length must be greater than the minimum length.");
            Argument.NotNull(distribution, nameof(distribution));

            int length = factory.CreateInt32(minimumLength, maximumLength);
            StringBuilder builder = new StringBuilder(length);
            while (builder.Length < length)
            {
                builder.Append(factory.CreateAlphaChar(distribution));
            }

            return builder.ToString();
        }
    }
}