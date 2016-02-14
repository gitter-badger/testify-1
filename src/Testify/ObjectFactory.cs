using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Factory = System.Func<Testify.IObjectFactory, object>;

namespace Testify
{
    /// <summary>
    /// Provides an object factory that can be used to create objects for use in unit tests.
    /// </summary>
    public sealed class ObjectFactory : IObjectFactory, IRegisterObjectFactory
    {
        private readonly List<IObjectFactoryCustomization> customizations = new List<IObjectFactoryCustomization>();
        private readonly Dictionary<Type, Factory> factories = new Dictionary<Type, Factory>();
        private readonly Random random;

        /// <summary>
        /// Initializes a new instance of the <see cref="ObjectFactory"/> class.
        /// </summary>
        public ObjectFactory()
            : this(0x07357FAC)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ObjectFactory"/> class.
        /// </summary>
        /// <param name="seed">The seed to provide to the random number generator.</param>
        public ObjectFactory(int seed)
        {
            this.random = new Random(seed);
            this.Register();
        }

        /// <summary>
        /// Creates an instance of the specified type of object.
        /// </summary>
        /// <param name="type">The type to create.</param>
        /// <returns>An instance of the specified type.</returns>
        public object Create(Type type)
        {
            Argument.NotNull(type, nameof(type));

            if (type.Is<ObjectFactory>() || type.Is<IObjectFactory>())
            {
                return this;
            }

            Factory factory;
            if (this.factories.TryGetValue(type, out factory))
            {
                return factory(this);
            }

            var context = new ObjectFactoryContext(this, type);
            object result;
            if (context.CallNextCustomization(out result))
            {
                return result;
            }

            throw new InvalidOperationException($"Unable to create instance of specified type {type}.");
        }

        /// <summary>
        /// Creates a random double value within a specified range using the specified distribution algorithm.
        /// </summary>
        /// <param name="minimum">The minimum value.</param>
        /// <param name="maximum">The maximum value.</param>
        /// <param name="distribution">The distribution algorithm to use.</param>
        /// <returns>A random double value.</returns>
        public double CreateDouble(double minimum, double maximum, Distribution distribution)
        {
            Argument.InRange(maximum, minimum, double.MaxValue, nameof(maximum), "The maximum value must be greater than the minimum value.");
            Argument.NotNull(distribution, nameof(distribution));

            return (distribution.NextDouble(this.random) * (maximum - minimum)) + minimum;
        }

        /// <summary>
        /// Customizes how the <see cref="ObjectFactory"/> creates objects.
        /// </summary>
        /// <param name="customization">The customization to apply.</param>
        /// <returns>The current <see cref="ObjectFactory"/> to allow for method call chaining.</returns>
        public ObjectFactory Customize(IObjectFactoryCustomization customization)
        {
            Argument.NotNull(customization, nameof(customization));

            this.customizations.Add(customization);
            return this;
        }

        /// <summary>
        /// Register a factory method for the specified type.
        /// </summary>
        /// <param name="type">The type of object the factory method creates.</param>
        /// <param name="factory">The factory method.</param>
        public void Register(Type type, Factory factory)
        {
            Argument.NotNull(type, nameof(type));
            Argument.NotNull(factory, nameof(factory));

            this.factories[type] = factory;
        }

        private object BuildArray(Type type)
        {
            var genericFactoryType = typeof(ArrayFactory<>);
            var factoryType = genericFactoryType.MakeGenericType(type);
            var factory = factoryType.GetMethodFunc<IObjectFactory, object>(nameof(ArrayFactory<int>.CreateArray));
            return factory(this);
        }

        /// <summary>
        /// Attempts to build a collection.
        /// </summary>
        /// <param name="type">The type of collection to build.</param>
        /// <param name="result">Returns the collection created.</param>
        /// <returns><see langword="true"/> if a collection was successfully created; otherwise <see langword="false"/>.</returns>
        private bool BuildCollection(Type type, out object result)
        {
            Argument.NotNull(type, nameof(type));

            if (type.IsArray)
            {
                var itemType = type.GetElementType();
                result = this.BuildArray(itemType);
                return true;
            }

            if (type.Is(typeof(IEnumerable<>)))
            {
                var itemType = type.GetGenericTypeArgument(0);
                result = this.BuildEnumerable(itemType);
                return true;
            }

            var ctor = type.GetConstructor(typeof(IEnumerable<>));
            if (ctor != null)
            {
                var items = this.Create(ctor.GetParameter(0).ParameterType);
                result = ctor.Invoke(new[] { items });
                return true;
            }

            ctor = type.GetConstructor();
            if (ctor != null)
            {
                result = ctor.Invoke(new object[0]);
                var method = type.GetMethods("Add").FirstOrDefault(m => m.GetParameters().Length == 1);
                if (method != null)
                {
                    foreach (var item in this.CreateEnumerable(method.GetParameters()[0].ParameterType))
                    {
                        method.Invoke(result, new[] { item });
                    }
                }

                return true;
            }

            result = null;
            return false;
        }

        private object BuildEnumerable(Type type)
        {
            var genericFactoryType = typeof(ArrayFactory<>);
            var factoryType = genericFactoryType.MakeGenericType(type);
            var factory = factoryType.GetMethodFunc<IObjectFactory, object>(nameof(ArrayFactory<int>.CreateItems));
            return factory(this);
        }

        /// <summary>
        /// Attempt to create an instance of the specified type of object when no factory for the
        /// type is registered.
        /// </summary>
        /// <param name="type">The type to create.</param>
        /// <param name="result">Returns an instance of the type created.</param>
        /// <returns><see langword="true"/> if an object was successfully created; otherwise <see langword="false"/>.</returns>
        private bool Create(Type type, out object result)
        {
            Argument.NotNull(type, nameof(type));

            if (typeof(IEnumerable).IsAssignableFrom(type) && this.BuildCollection(type, out result))
            {
                return true;
            }

            if (type.IsEnum())
            {
                result = this.CreateEnumValue(type);
                return true;
            }

            var constructors =
                from constructor in type.GetConstructors()
                let parameters = constructor.GetParameters()
                orderby parameters.Length ascending
                select new { Constructor = constructor, Parameters = parameters };
            var info = constructors.FirstOrDefault();
            if (info == null)
            {
                throw new InvalidOperationException($"Unable to find constructor for type '{type}'.");
            }

            var args = info.Parameters.Select(a => this.Create(a.ParameterType)).ToArray();
            try
            {
                result = info.Constructor.Invoke(args);
            }
            catch (Exception e)
            {
                throw new InvalidOperationException($"Unable to create type '{type}'.", e);
            }

            return true;
        }

        /// <summary>
        /// Registers several common types with the specified <see cref="IRegisterObjectFactory"/>.
        /// </summary>
        private void Register()
        {
            this.Register(f => f.CreateBool());
            this.Register(f => f.CreateByte());
            this.Register(f => f.CreateChar());
            this.Register(f => f.CreateDateTime());
            this.Register(f => f.CreateDateTimeOffset());
            this.Register(f => f.CreateDouble());
            this.Register(f => f.CreateSingle());
            this.Register(f => f.CreateInt32());
            this.Register(f => f.CreateInt64());
            this.Register(f => f.CreateInt16());
            this.Register(f => f.CreateString());
            this.Register(f => f.CreateTimeSpan());
            this.Register(f => f.CreateTimeZoneInfo());
        }

        private class ObjectFactoryContext : IObjectFactoryContext
        {
            private readonly ObjectFactory factory;
            private int current;

            /// <summary>
            /// Initializes a new instance of the <see cref="ObjectFactoryContext"/> class.
            /// </summary>
            /// <param name="factory">The factory associated with this context.</param>
            /// <param name="resultType">The type of object being created in this context.</param>
            public ObjectFactoryContext(ObjectFactory factory, Type resultType)
            {
                Argument.NotNull(factory, nameof(factory));
                Argument.NotNull(resultType, nameof(resultType));

                this.factory = factory;
                this.ResultType = resultType;
                this.current = this.factory.customizations.Count;
            }

            /// <summary>
            /// Gets the type being created.
            /// </summary>
            public Type ResultType { get; }

            /// <summary>
            /// Calls the next customization in the chain.
            /// </summary>
            /// <param name="result">The result.</param>
            /// <returns><see langword="true"/> if an object was created, otherwise <see langword="false"/>.</returns>
            public bool CallNextCustomization(out object result)
            {
                if (this.current != 0)
                {
                    return this.factory.customizations[--this.current].Create(this, out result);
                }

                if (this.ResultType.IsType(typeof(IEnumerable)))
                {
                    return this.factory.BuildCollection(this.ResultType, out result);
                }

                if (this.ResultType.IsInterface() || this.ResultType.IsAbstract())
                {
                    result = null;
                    return false;
                }

                return this.factory.Create(this.ResultType, out result);
            }

            /// <summary>
            /// Creates an object of the specified type.
            /// </summary>
            /// <param name="type">The type of object to create.</param>
            /// <returns>An instance of the specified type.</returns>
            public object Create(Type type)
            {
                Argument.NotNull(type, nameof(type));

                return this.factory.Create(type);
            }

            /// <summary>
            /// Creates a random <see langword="double"/> value within the specified range using the specified
            /// distribution algorithm.
            /// </summary>
            /// <param name="minimum">The minimum value.</param>
            /// <param name="maximum">The maximum value.</param>
            /// <param name="distribution">The distribution algorithm to use.</param>
            /// <returns>A random <see langword="int"/> value.</returns>
            public double CreateDouble(double minimum, double maximum, Distribution distribution)
            {
                Argument.InRange(maximum, minimum, double.MaxValue, nameof(maximum), "The maximum value must be greater than the minimum value.");
                Argument.NotNull(distribution, nameof(distribution));

                return this.factory.CreateDouble(minimum, maximum, distribution);
            }
        }
    }
}