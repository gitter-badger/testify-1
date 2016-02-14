using System;
using System.Reflection;

namespace Testify
{
    /// <summary>
    /// Extension methods for <see cref="ObjectFactory"/> use.
    /// </summary>
    public static class ObjectFactoryExtensions
    {
        /// <summary>
        /// Creates an object of the specified type.
        /// </summary>
        /// <typeparam name="T">The type of the object to create.</typeparam>
        /// <param name="self">The factory instance.</param>
        /// <returns>An instance of the specified type.</returns>
        public static T Create<T>(this IObjectFactory self)
        {
            if (self == null)
            {
                throw new ArgumentNullException(nameof(self));
            }

            return (T)self.Create(typeof(T));
        }

        /// <summary>
        /// Freezes the specified value as the result for any further calls to <see cref="Create"/>
        /// for the specified type.
        /// </summary>
        /// <param name="self">The factory instance.</param>
        /// <param name="type">The type to freeze.</param>
        /// <param name="value">The instance to freeze.</param>
        public static void Freeze(this IRegisterObjectFactory self, Type type, object value)
        {
            if (self == null)
            {
                throw new ArgumentNullException(nameof(self));
            }

            if (type == null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            if (type.IsValueType() && value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            self.Register(type, f => value);
        }

        /// <summary>
        /// Freezes the specified value as the result for any further calls to <see cref="Create"/>
        /// for the specified type.
        /// </summary>
        /// <typeparam name="T">The type to freeze.</typeparam>
        /// <param name="self">The factory instance.</param>
        /// <param name="value">The instance to freeze.</param>
        public static void Freeze<T>(this IRegisterObjectFactory self, T value)
        {
            if (self == null)
            {
                throw new ArgumentNullException(nameof(self));
            }

            self.Freeze(typeof(T), value);
        }

        /// <summary>
        /// Register a factory method for the specified type.
        /// </summary>
        /// <typeparam name="T">The type of object the factory method creates.</typeparam>
        /// <param name="self">The factory instance.</param>
        /// <param name="factory">The factory method.</param>
        public static void Register<T>(this IRegisterObjectFactory self, Func<IObjectFactory, T> factory)
        {
            if (self == null)
            {
                throw new ArgumentNullException(nameof(self));
            }

            if (factory == null)
            {
                throw new ArgumentNullException(nameof(factory));
            }

            self.Register(typeof(T), f => factory(f));
        }
    }
}