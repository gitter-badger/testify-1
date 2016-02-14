namespace Testify
{
    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public static class CharFactory
    {
        private static readonly Range BasicLatinCharRange = new Range(0x20, 0x7f);
        private static readonly Range LatinSupplementRange = new Range(0xa0, 0xff);
        private static readonly Range LowerCaseAlphaRange = new Range('a', 'z');
        private static readonly Range NumericRange = new Range('0', '9');
        private static readonly Range UpperCaseAlphaRange = new Range('A', 'Z');

        /// <summary>
        /// Creates a random <see langword="char"/> value within the range of alpha characters using
        /// a uniform distribution algorithm.
        /// </summary>
        /// <param name="factory">The factory instance.</param>
        /// <returns>A random alpha character.</returns>
        public static char CreateAlphaChar(this IObjectFactory factory)
        {
            Argument.NotNull(factory, nameof(factory));

            return factory.CreateAlphaChar(Distribution.Uniform);
        }

        /// <summary>
        /// Creates a random <see langword="char"/> value within the range of alpha characters using
        /// the specified distribution algorithm.
        /// </summary>
        /// <param name="factory">The factory instance.</param>
        /// <param name="distribution">The distribution algorithm to use.</param>
        /// <returns>A random alpha character.</returns>
        public static char CreateAlphaChar(this IObjectFactory factory, Distribution distribution)
        {
            Argument.NotNull(factory, nameof(factory));
            Argument.NotNull(distribution, nameof(distribution));

            return (char)Range.CreateLongFromRanges(factory, distribution, LowerCaseAlphaRange, UpperCaseAlphaRange);
        }

        /// <summary>
        /// Creates a random <see langword="char"/> value within the range of alpha/numeric characters
        /// using a uniform distribution algorithm.
        /// </summary>
        /// <param name="factory">The factory instance.</param>
        /// <returns>A random <see langword="char"/> value.</returns>
        public static char CreateAlphaNumericChar(this IObjectFactory factory)
        {
            Argument.NotNull(factory, nameof(factory));

            return factory.CreateAlphaNumericChar(Distribution.Uniform);
        }

        /// <summary>
        /// Creates a random <see langword="char"/> value within the range of alpha/numeric characters
        /// using the specified distribution algorithm.
        /// </summary>
        /// <param name="factory">The factory instance.</param>
        /// <param name="distribution">The distribution algorithm to use.</param>
        /// <returns>A random alpha/numeric character.</returns>
        public static char CreateAlphaNumericChar(this IObjectFactory factory, Distribution distribution)
        {
            Argument.NotNull(factory, nameof(factory));
            Argument.NotNull(distribution, nameof(distribution));

            return (char)Range.CreateLongFromRanges(factory, distribution, LowerCaseAlphaRange, UpperCaseAlphaRange, NumericRange);
        }

        /// <summary>
        /// Creates a random <see langword="char"/> value within the range of basic Latin characters using
        /// a uniform distribution algorithm.
        /// </summary>
        /// <param name="factory">The factory instance.</param>
        /// <returns>A random basic Latin character.</returns>
        public static char CreateBasicLatinChar(this IObjectFactory factory)
        {
            Argument.NotNull(factory, nameof(factory));

            return factory.CreateBasicLatinChar(Distribution.Uniform);
        }

        /// <summary>
        /// Creates a random <see langword="char"/> value within the range of basic Latin characters using
        /// the specified distribution algorithm.
        /// </summary>
        /// <param name="factory">The factory instance.</param>
        /// <param name="distribution">The distribution algorithm to use.</param>
        /// <returns>A random basic Latin character.</returns>
        public static char CreateBasicLatinChar(this IObjectFactory factory, Distribution distribution)
        {
            Argument.NotNull(factory, nameof(factory));
            Argument.NotNull(distribution, nameof(distribution));

            return factory.CreateChar((char)BasicLatinCharRange.Minimum, (char)BasicLatinCharRange.Maximum, distribution);
        }

        /// <summary>
        /// Creates a random <see langword="char"/> value using a uniform distribution algorithm.
        /// </summary>
        /// <param name="factory">The factory instance.</param>
        /// <returns>A random <see langword="char"/> value.</returns>
        public static char CreateChar(this IObjectFactory factory)
        {
            Argument.NotNull(factory, nameof(factory));

            return factory.CreateChar(char.MinValue, char.MaxValue, Distribution.Uniform);
        }

        /// <summary>
        /// Creates a random <see langword="char"/> value within the specified range using a uniform
        /// distribution algorithm.
        /// </summary>
        /// <param name="factory">The factory instance.</param>
        /// <param name="minimum">The minimum value.</param>
        /// <param name="maximum">The maximum value.</param>
        /// <returns>A random <see langword="char"/> value.</returns>
        public static char CreateChar(this IObjectFactory factory, char minimum, char maximum)
        {
            Argument.NotNull(factory, nameof(factory));
            Argument.InRange(maximum, minimum, double.MaxValue, nameof(maximum), "The maximum value must be greater than the minimum value.");

            return factory.CreateChar(minimum, maximum, Distribution.Uniform);
        }

        /// <summary>
        /// Creates a random <see langword="char"/> value using the specified distribution algorithm.
        /// </summary>
        /// <param name="factory">The factory instance.</param>
        /// <param name="distribution">The distribution algorithm to use.</param>
        /// <returns>A random <see langword="char"/> value.</returns>
        public static char CreateChar(this IObjectFactory factory, Distribution distribution)
        {
            Argument.NotNull(factory, nameof(factory));
            Argument.NotNull(distribution, nameof(distribution));

            return factory.CreateChar(char.MinValue, char.MaxValue, distribution);
        }

        /// <summary>
        /// Creates a random <see langword="char"/> value within the specified range using the specified
        /// distribution algorithm.
        /// </summary>
        /// <param name="factory">The factory instance.</param>
        /// <param name="minimum">The minimum value.</param>
        /// <param name="maximum">The maximum value.</param>
        /// <param name="distribution">The distribution algorithm to use.</param>
        /// <returns>A random <see langword="char"/> value.</returns>
        public static char CreateChar(this IObjectFactory factory, char minimum, char maximum, Distribution distribution)
        {
            Argument.NotNull(factory, nameof(factory));
            Argument.InRange(maximum, minimum, char.MaxValue, nameof(maximum), "The maximum value must be greater than the minimum value.");
            Argument.NotNull(distribution, nameof(distribution));

            return (char)factory.CreateInt64(minimum, maximum, distribution);
        }

        /// <summary>
        /// Creates a random <see langword="char"/> value within the range of Latin supplement characters
        /// using a uniform distribution algorithm.
        /// </summary>
        /// <param name="factory">The factory instance.</param>
        /// <returns>A random Latin supplement character.</returns>
        public static char CreateLatinSupplementChar(this IObjectFactory factory)
        {
            Argument.NotNull(factory, nameof(factory));

            return factory.CreateLatinSupplementChar(Distribution.Uniform);
        }

        /// <summary>
        /// Creates a random <see langword="char"/> value within the range of Latin supplement characters
        /// using the specified distribution algorithm.
        /// </summary>
        /// <param name="factory">The factory instance.</param>
        /// <param name="distribution">The distribution algorithm to use.</param>
        /// <returns>A random Latin supplement character.</returns>
        public static char CreateLatinSupplementChar(this IObjectFactory factory, Distribution distribution)
        {
            Argument.NotNull(factory, nameof(factory));
            Argument.NotNull(distribution, nameof(distribution));

            return factory.CreateChar((char)LatinSupplementRange.Minimum, (char)LatinSupplementRange.Maximum, distribution);
        }

        /// <summary>
        /// Creates a random <see langword="char"/> value within the range of numeric characters using
        /// a uniform distribution algorithm.
        /// </summary>
        /// <param name="factory">The factory instance.</param>
        /// <returns>A random numeric character.</returns>
        public static char CreateNumericChar(this IObjectFactory factory)
        {
            Argument.NotNull(factory, nameof(factory));

            return factory.CreateNumericChar(Distribution.Uniform);
        }

        /// <summary>
        /// Creates a random <see langword="char"/> value within the range of numeric characters using
        /// the specified distribution algorithm.
        /// </summary>
        /// <param name="factory">The factory instance.</param>
        /// <param name="distribution">The distribution algorithm to use.</param>
        /// <returns>A random numeric character.</returns>
        public static char CreateNumericChar(this IObjectFactory factory, Distribution distribution)
        {
            Argument.NotNull(factory, nameof(factory));
            Argument.NotNull(distribution, nameof(distribution));

            return factory.CreateChar((char)NumericRange.Minimum, (char)NumericRange.Maximum, distribution);
        }

        /// <summary>
        /// Creates a random <see langword="char"/> value within the range of printable characters
        /// using a uniform distribution algorithm.
        /// </summary>
        /// <param name="factory">The factory instance.</param>
        /// <returns>A random printable character.</returns>
        public static char CreatePrintableChar(this IObjectFactory factory)
        {
            Argument.NotNull(factory, nameof(factory));

            return factory.CreatePrintableChar(Distribution.Uniform);
        }

        /// <summary>
        /// Creates a random <see langword="char"/> value within the range of printable characters
        /// using the specified distribution algorithm.
        /// </summary>
        /// <param name="factory">The factory instance.</param>
        /// <param name="distribution">The distribution algorithm to use.</param>
        /// <returns>A random printable character.</returns>
        public static char CreatePrintableChar(this IObjectFactory factory, Distribution distribution)
        {
            Argument.NotNull(factory, nameof(factory));
            Argument.NotNull(distribution, nameof(distribution));

            return (char)Range.CreateLongFromRanges(factory, distribution, BasicLatinCharRange, LatinSupplementRange);
        }
    }
}