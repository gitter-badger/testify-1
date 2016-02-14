using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testify
{
    /// <summary>
    /// Defines factory methods for creating <see langword="TimeZoneInfo"/> values.
    /// </summary>
    public static class TimeZoneInfoFactory
    {
        /// <summary>
        /// Creates a random <see langword="TimeZoneInfo"/> value using a uniform distribution algorithm.
        /// </summary>
        /// <param name="factory">The factory instance.</param>
        /// <returns>A random <see langword="TimeZoneInfo"/> value.</returns>
        public static TimeZoneInfo CreateTimeZoneInfo(this IObjectFactory factory)
        {
            Argument.NotNull(factory, nameof(factory));

            return factory.CreateTimeZoneInfo(Distribution.Uniform);
        }

        /// <summary>
        /// Creates a random <see langword="TimeZoneInfo"/> value using the specified distribution algorithm.
        /// </summary>
        /// <param name="factory">The factory instance.</param>
        /// <param name="distribution">The distribution algorithm to use.</param>
        /// <returns>A random <see langword="TimeZoneInfo"/> value.</returns>
        public static TimeZoneInfo CreateTimeZoneInfo(this IObjectFactory factory, Distribution distribution)
        {
            Argument.NotNull(factory, nameof(factory));
            Argument.NotNull(distribution, nameof(distribution));

            // Figure out a better way to randomize a result in a PCL.
            return factory.CreateBool() ? TimeZoneInfo.Utc : TimeZoneInfo.Local;
        }
    }
}
