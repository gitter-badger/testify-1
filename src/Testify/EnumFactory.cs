using System;
using System.Reflection;

namespace Testify
{
    /// <summary>
    /// Defines factory methods for creating <see langword="Enum"/> values.
    /// </summary>
    public static class EnumFactory
    {
        /// <summary>
        /// Creates a random value of the specified <see cref="Enum"/> type using a uniform distribution
        /// algorithm.
        /// </summary>
        /// <param name="factory">The factory instance.</param>
        /// <param name="enumType">The <see cref="Enum"/> type.</param>
        /// <returns>A random value of the specified <see cref="Enum"/> type.</returns>
        public static object CreateEnumValue(this IObjectFactory factory, Type enumType)
        {
            Argument.NotNull(factory, nameof(factory));
            Argument.NotNull(enumType, nameof(enumType));
            Argument.IsEnumType(enumType, nameof(enumType));

            return factory.CreateEnumValue(enumType, Distribution.Uniform);
        }

        /// <summary>
        /// Creates a random value of the specified <see cref="Enum"/> type using the specified distribution
        /// algorithm.
        /// </summary>
        /// <param name="factory">The factory instance.</param>
        /// <param name="enumType">The <see cref="Enum"/> type.</param>
        /// <param name="distribution">The distribution algorithm to use.</param>
        /// <returns>A random value of the specified <see cref="Enum"/> type.</returns>
        public static object CreateEnumValue(this IObjectFactory factory, Type enumType, Distribution distribution)
        {
            Argument.NotNull(factory, nameof(factory));
            Argument.NotNull(enumType, nameof(enumType));
            Argument.NotNull(distribution, nameof(distribution));
            Argument.IsEnumType(enumType, nameof(enumType));

            var values = Enum.GetValues(enumType);
            var index = factory.CreateInt32(0, values.Length - 1, distribution);
            return values.GetValue(index);
        }

        /// <summary>
        /// Creates a random value of the specified <see cref="Enum"/> type using a uniform distribution
        /// algorithm.
        /// </summary>
        /// <typeparam name="T">The <see cref="Enum"/> type.</typeparam>
        /// <param name="factory">The factory instance.</param>
        /// <returns>A random value of the specified <see cref="Enum"/> type.</returns>
        public static T CreateEnumValue<T>(this IObjectFactory factory)
        {
            Argument.NotNull(factory, nameof(factory));

            var type = typeof(T);
            if (!type.IsEnum())
            {
                throw new InvalidOperationException("Generic parameter T must be an Enum type.");
            }

            return (T)factory.CreateEnumValue(type, Distribution.Uniform);
        }

        /// <summary>
        /// Creates a random value of the specified <see cref="Enum"/> type using the specified distribution
        /// algorithm.
        /// </summary>
        /// <typeparam name="T">The <see cref="Enum"/> type</typeparam>
        /// <param name="factory">The factory instance.</param>
        /// <param name="distribution">The distribution algorithm to use.</param>
        /// <returns>A random value of the specified <see cref="Enum"/> type.</returns>
        public static T CreateEnumValue<T>(this IObjectFactory factory, Distribution distribution)
        {
            Argument.NotNull(factory, nameof(factory));
            Argument.NotNull(distribution, nameof(distribution));

            var type = typeof(T);
            if (!type.IsEnum())
            {
                throw new InvalidOperationException("Generic parameter T must be an Enum type.");
            }

            return (T)factory.CreateEnumValue(type, distribution);
        }
    }
}