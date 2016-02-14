using System.Collections.Generic;
using System.Linq;

namespace Testify
{
    /// <summary>
    /// Array factory helper.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    internal static class ArrayFactory<T>
    {
        /// <summary>
        /// Creates the array.
        /// </summary>
        /// <param name="factory">The object factory.</param>
        /// <returns>The array.</returns>
        internal static T[] CreateArray(IObjectFactory factory) => CreateItems(factory).ToArray();

        /// <summary>
        /// Creates the items.
        /// </summary>
        /// <param name="factory">The factory.</param>
        /// <returns>The items.</returns>
        internal static IEnumerable<T> CreateItems(IObjectFactory factory) => factory.CreateEnumerable<T>();
    }
}