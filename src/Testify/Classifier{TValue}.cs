using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Testify
{
    /// <summary>
    /// Classifies values.
    /// </summary>
    /// <typeparam name="TValue">The type of values to be classified.</typeparam>
    public sealed class Classifier<TValue> : IEnumerable<Classification<TValue>>
    {
        /// <summary>
        /// The classifications.
        /// </summary>
        private readonly List<Classification<TValue>> classifications = new List<Classification<TValue>>();

        /// <summary>
        /// Gets the number of values that have been classified.
        /// </summary>
        public int Count
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the number of values that have been classified in the specified category.
        /// </summary>
        /// <param name="category">The classification category.</param>
        /// <returns>The number of values that were classified in the specified category.</returns>
        public double this[string category]
        {
            get
            {
                return (double)this.classifications.First(c => c.Name == category).Count / (double)this.Count;
            }
        }

        /// <summary>
        /// Adds a classification category.
        /// </summary>
        /// <param name="name">The name of the classification category.</param>
        /// <param name="predicate">The predicate values must pass in order to be classified in this category.</param>
        public void AddClassification(string name, Predicate<TValue> predicate)
        {
            if (this.classifications.Any(c => c.Count > 0))
            {
                throw new InvalidOperationException();
            }

            this.classifications.Add(new Classification<TValue>(name, predicate));
        }

        /// <summary>
        /// Adds the value to every valid classification category.
        /// </summary>
        /// <param name="value">The value to classify.</param>
        public void Classify(TValue value)
        {
            foreach (var classification in this.classifications)
            {
                if (classification.Predicate(value))
                {
                    classification.Count++;
                }
            }

            this.Count++;
        }

        /// <summary>
        /// Produces and classifies 1000 values.
        /// </summary>
        /// <param name="producer">The delegate used to produce values.</param>
        public void Classify(Func<TValue> producer)
        {
            Argument.NotNull(producer, nameof(producer));

            this.Classify(1000, producer);
        }

        /// <summary>
        /// Produces and classifies values.
        /// </summary>
        /// <param name="runs">The number of values to produce.</param>
        /// <param name="producer">The delegate used to produce values.</param>
        public void Classify(int runs, Func<TValue> producer)
        {
            Argument.NotNull(producer, nameof(producer));

            for (int i = 0; i < runs; ++i)
            {
                this.Classify(producer());
            }
        }

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>An IEnumerator object that can be used to iterate through the collection.</returns>
        public IEnumerator<Classification<TValue>> GetEnumerator()
        {
            return this.classifications.GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>An IEnumerator object that can be used to iterate through the collection.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}