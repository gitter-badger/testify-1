using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Testify
{
    /// <summary>
    /// Defines factory methods for creating <see langword="IEnumerable"/> values.
    /// </summary>
    public static class EnumerableFactory
    {
        /// <summary>
        /// Creates a random <see langword="IEnumerable"/> sequence of 0 to 20 objects of the specified type.
        /// </summary>
        /// <param name="factory">The factory instance.</param>
        /// <param name="type">The type of objects to create.</param>
        /// <returns>A random <see langword="IEnumerable"/> sequence of the specified type of objects.</returns>
        public static IEnumerable CreateEnumerable(this IObjectFactory factory, Type type)
        {
            Argument.NotNull(factory, nameof(factory));
            Argument.NotNull(type, nameof(type));

            return factory.CreateEnumerable(type, 0, 20);
        }

        /// <summary>
        /// Creates a random <see langword="IEnumerable"/> sequence of objects of the specified type.
        /// </summary>
        /// <param name="factory">The factory instance.</param>
        /// <param name="type">The type of objects to create.</param>
        /// <param name="minimumLength">The minimum length of the sequence.</param>
        /// <param name="maximumLength">The maximum length of the sequence.</param>
        /// <returns>A random <see langword="IEnumerable"/> sequence of the specified type of objects.</returns>
        public static IEnumerable CreateEnumerable(this IObjectFactory factory, Type type, int minimumLength, int maximumLength)
        {
            Argument.NotNull(factory, nameof(factory));
            Argument.NotNull(type, nameof(type));
            Argument.InRange(maximumLength, minimumLength, int.MaxValue, nameof(maximumLength), "The maximum length must be greater than the minimum length.");

            int length = factory.CreateInt32(minimumLength, maximumLength);
            return CreateEnumerable(factory, type, length);
        }

        /// <summary>
        /// Creates a random <see langword="IEnumerable{T}"/> sequence of 0 to 20 objects of the specified type.
        /// </summary>
        /// <typeparam name="T">The type of objects to create.</typeparam>
        /// <param name="factory">The factory instance.</param>
        /// <returns>A random <see langword="IEnumerable{T}"/> sequence of the specified type of objects.</returns>
        public static IEnumerable<T> CreateEnumerable<T>(this IObjectFactory factory)
        {
            Argument.NotNull(factory, nameof(factory));

            return factory.CreateEnumerable(typeof(T), 0, 20).Cast<T>();
        }

        /// <summary>
        /// Creates a random <see langword="IEnumerable{T}"/> sequence of objects of the specified type.
        /// </summary>
        /// <typeparam name="T">The type of objects to create.</typeparam>
        /// <param name="factory">The factory instance.</param>
        /// <param name="minimumLength">The minimum length of the sequence.</param>
        /// <param name="maximumLength">The maximum length of the sequence.</param>
        /// <returns>A random <see langword="IEnumerable{T}"/> sequence of the specified type of objects.</returns>
        public static IEnumerable<T> CreateEnumerable<T>(this IObjectFactory factory, int minimumLength, int maximumLength)
        {
            Argument.NotNull(factory, nameof(factory));
            Argument.InRange(maximumLength, minimumLength, int.MaxValue, nameof(maximumLength), "The maximum length must be greater than the minimum length.");

            return factory.CreateEnumerable(typeof(T), minimumLength, maximumLength).Cast<T>();
        }

        /// <summary>
        /// Creates an enumerable sequence.
        /// </summary>
        /// <param name="factory">The factory to use for creating objects in the sequence.</param>
        /// <param name="type">The type of objects to create in the sequence.</param>
        /// <param name="length">The length of the sequence.</param>
        /// <returns>A sequence of the specified length of the specified type of objects.</returns>
        private static IEnumerable CreateEnumerable(IObjectFactory factory, Type type, int length)
        {
            for (int i = 0; i < length; ++i)
            {
                yield return factory.Create(type);
            }
        }
    }
}