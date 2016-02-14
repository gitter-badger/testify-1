using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Testify
{
    /// <summary>
    /// Provides argument validation methods.
    /// </summary>
    internal static class Argument
    {
        /// <summary>
        /// Ensures the argument is in the specified range..
        /// </summary>
        /// <typeparam name="T">The value type.</typeparam>
        /// <param name="value">The value.</param>
        /// <param name="minimum">The minimum allowable value.</param>
        /// <param name="maximum">The maximum allowable value.</param>
        /// <param name="paramName">The name of the parameter.</param>
        /// <exception cref="ArgumentOutOfRangeException">The argument was not in the specified range.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void InRange<T>(T value, T minimum, T maximum, string paramName)
            where T : IComparable<T>
        {
            var comparer = Comparer<T>.Default;
            if (comparer.Compare(value, minimum) < 0 || comparer.Compare(value, maximum) > 0)
            {
                throw new ArgumentOutOfRangeException(paramName);
            }
        }

        /// <summary>
        /// Ensures the argument is in the specified range..
        /// </summary>
        /// <typeparam name="T">The value type.</typeparam>
        /// <param name="value">The value.</param>
        /// <param name="minimum">The minimum allowable value.</param>
        /// <param name="maximum">The maximum allowable value.</param>
        /// <param name="paramName">The name of the parameter.</param>
        /// <param name="message">The message to include in the exception.</param>
        /// <exception cref="ArgumentOutOfRangeException">The argument was not in the specified range.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void InRange<T>(T value, T minimum, T maximum, string paramName, string message)
            where T : IComparable<T>
        {
            var comparer = Comparer<T>.Default;
            if (comparer.Compare(value, minimum) < 0 || comparer.Compare(value, maximum) > 0)
            {
                throw new ArgumentOutOfRangeException(paramName, message);
            }
        }

        /// <summary>
        /// Ensures the argument is not <see langword="null"/>.
        /// </summary>
        /// <typeparam name="T">The argument type.</typeparam>
        /// <param name="value">The value of the argument.</param>
        /// <param name="paramName">The name of the parameter.</param>
        /// <exception cref="ArgumentNullException">The argument was <see langword="null"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void NotNull<T>(T value, string paramName)
            where T : class
        {
            if (value == null)
            {
                throw new ArgumentNullException(paramName);
            }
        }

        /// <summary>
        /// Ensures the argument is not <see langword="null"/> or <see cref="string.Empty"/>.
        /// </summary>
        /// <param name="value">The value of the argument.</param>
        /// <param name="paramName">The name of the parameter.</param>
        /// <exception cref="ArgumentNullException">The argument was <see langword="null"/>.</exception>
        /// <exception cref="ArgumentException">The argument was <see cref="string.Empty"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void NotNullOrEmpty(string value, string paramName)
        {
            if (value == null)
            {
                throw new ArgumentNullException(paramName);
            }

            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("The string may not be empty.", paramName);
            }
        }

        /// <summary>
        /// Ensures the argument is an <see cref="Enum"/> type.
        /// </summary>
        /// <param name="value">The value of the argument.</param>
        /// <param name="paramName">The name of the parameter.</param>
        /// <exception cref="ArgumentException">The <paramref name="value"/> was not an <see cref="Enum"/>
        /// type.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void IsEnumType(Type value, string paramName)
        {
            if (!value.IsEnum())
            {
                throw new ArgumentException(paramName, "Type must be an Enum type.");
            }
        }
    }
}