using System;

namespace Testify
{
    /// <summary>
    /// Defines factory methods for creating <see langword="DateTimeOffset"/> values.
    /// </summary>
    public static class DateTimeOffsetFactory
    {
        /// <summary>
        /// Creates a random <see langword="DateTimeOffset"/> value using a uniform distribution algorithm.
        /// </summary>
        /// <param name="self">The factory instance.</param>
        /// <returns>A random <see langword="DateTimeOffset"/> value.</returns>
        public static DateTimeOffset CreateDateTimeOffset(this IObjectFactory self)
        {
            if (self == null)
            {
                throw new ArgumentNullException(nameof(self));
            }

            return self.CreateDateTimeOffset(DateTimeOffset.MinValue, DateTimeOffset.MaxValue, Distribution.Uniform);
        }

        /// <summary>
        /// Creates a random <see langword="DateTimeOffset"/> value within the specified range using a uniform
        /// distribution algorithm.
        /// </summary>
        /// <param name="self">The factory instance.</param>
        /// <param name="minimum">The minimum value.</param>
        /// <param name="maximum">The maximum value.</param>
        /// <returns>A random <see langword="DateTimeOffset"/> value.</returns>
        public static DateTimeOffset CreateDateTimeOffset(this IObjectFactory self, DateTimeOffset minimum, DateTimeOffset maximum)
        {
            if (self == null)
            {
                throw new ArgumentNullException(nameof(self));
            }

            if (minimum > maximum)
            {
                throw new ArgumentOutOfRangeException(nameof(maximum), "The maximum value must be greater than the minimum value.");
            }

            return self.CreateDateTimeOffset(minimum, maximum, Distribution.Uniform);
        }

        /// <summary>
        /// Creates a random <see langword="DateTimeOffset"/> value using the specified distribution algorithm.
        /// </summary>
        /// <param name="self">The factory instance.</param>
        /// <param name="distribution">The distribution algorithm to use.</param>
        /// <returns>A random <see langword="DateTimeOffset"/> value.</returns>
        public static DateTimeOffset CreateDateTimeOffset(this IObjectFactory self, Distribution distribution)
        {
            if (self == null)
            {
                throw new ArgumentNullException(nameof(self));
            }

            if (distribution == null)
            {
                throw new ArgumentNullException(nameof(distribution));
            }

            return self.CreateDateTimeOffset(DateTimeOffset.MinValue, DateTimeOffset.MaxValue, distribution);
        }

        /// <summary>
        /// Creates a random <see langword="DateTimeOffset"/> value within the specified range using the specified
        /// distribution algorithm.
        /// </summary>
        /// <param name="self">The factory instance.</param>
        /// <param name="minimum">The minimum value.</param>
        /// <param name="maximum">The maximum value.</param>
        /// <param name="distribution">The distribution algorithm to use.</param>
        /// <returns>A random <see langword="DateTimeOffset"/> value.</returns>
        public static DateTimeOffset CreateDateTimeOffset(this IObjectFactory self, DateTimeOffset minimum, DateTimeOffset maximum, Distribution distribution)
        {
            if (self == null)
            {
                throw new ArgumentNullException(nameof(self));
            }

            if (minimum > maximum)
            {
                throw new ArgumentOutOfRangeException(nameof(maximum), "The maximum value must be greater than the minimum value.");
            }

            if (distribution == null)
            {
                throw new ArgumentNullException(nameof(distribution));
            }

            TimeZoneInfo timeZone = self.CreateTimeZoneInfo(distribution);
            long ticks = self.CreateInt64(minimum.Ticks, maximum.Ticks, distribution);
            return new DateTimeOffset(ticks, timeZone.BaseUtcOffset);
        }
    }
}