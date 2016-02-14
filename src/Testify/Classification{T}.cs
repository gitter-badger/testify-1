using System;

namespace Testify
{
    /// <summary>
    /// Provides data about a classification.
    /// </summary>
    /// <typeparam name="T">The type of values to be classified.</typeparam>
    public sealed class Classification<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Classification{T}"/> class.
        /// </summary>
        /// <param name="name">The classification name.</param>
        /// <param name="predicate">The predicate values must pass to be classified in this classification.</param>
        public Classification(string name, Predicate<T> predicate)
        {
            this.Name = name;
            this.Predicate = predicate;
        }

        /// <summary>
        /// Gets or sets the number of values that have been classified in this classification.
        /// </summary>
        public int Count
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the classification name.
        /// </summary>
        public string Name
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the predicate values must pass to be classified in this classification.
        /// </summary>
        public Predicate<T> Predicate
        {
            get;
            private set;
        }
    }
}