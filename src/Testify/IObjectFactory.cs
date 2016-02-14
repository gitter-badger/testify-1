using System;

namespace Testify
{
    /// <summary>
    /// Defines an interface for a factory object that can be used to create other objects.
    /// </summary>
    public interface IObjectFactory
    {
        /// <summary>
        /// Creates an object of the specified type.
        /// </summary>
        /// <param name="type">The type of object to create.</param>
        /// <returns>An instance of the specified type.</returns>
        object Create(Type type);

        /// <summary>
        /// Creates a random <see langword="double"/> value within the specified range using the specified
        /// distribution algorithm.
        /// </summary>
        /// <param name="minimum">The minimum value.</param>
        /// <param name="maximum">The maximum value.</param>
        /// <param name="distribution">The distribution algorithm to use.</param>
        /// <returns>A random <see langword="int"/> value.</returns>
        double CreateDouble(double minimum, double maximum, Distribution distribution);
    }
}