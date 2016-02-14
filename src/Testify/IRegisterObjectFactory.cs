﻿using System;

namespace Testify
{
    /// <summary>
    /// Defines the interface used to register factory methods on an <see cref="ObjectFactory"/>.
    /// </summary>
    public interface IRegisterObjectFactory
    {
        /// <summary>
        /// Register a factory method for the specified type.
        /// </summary>
        /// <param name="type">The type of object the factory method creates.</param>
        /// <param name="factory">The factory method.</param>
        void Register(Type type, Func<IObjectFactory, object> factory);
    }
}