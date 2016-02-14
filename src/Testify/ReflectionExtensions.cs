using System;
using System.Reflection;

namespace Testify
{
    /// <summary>
    /// Provides extension methods for performing reflection based operations.
    /// </summary>
    internal static class ReflectionExtensions
    {
        /// <summary>
        /// Determines whether the specified object is an instance of the specified type.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="obj">The object.</param>
        /// <returns><see langword="true"/> if the object is an instance of the specified type;
        /// otherwise <see langword="false"/>.</returns>
        internal static bool IsInstanceOfType(this Type type, object obj)
        {
            var typeInfo = type.GetTypeInfo();
            return obj == null
                ? typeInfo.IsClass
                : typeInfo.IsAssignableFrom(obj.GetType().GetTypeInfo());
        }
    }
}