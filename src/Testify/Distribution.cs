using System;

namespace Testify
{
    /// <summary>
    /// Provides random number generation using a specified distribution algorithm.
    /// </summary>
    public abstract class Distribution
    {
        private const double MEAN = 0.0;
        private const int NSIGMA = 3;
        private const double STDDEV = 1.0;

        /// <summary>
        /// Gets a <see cref="Distribution"/> that uses an inverted normal distribution algorithm.
        /// </summary>
        public static Distribution InvertedNormal { get; } = new InvertedNormalDistribution();

        /// <summary>
        /// Gets a <see cref="Distribution"/> that uses a negative normal distribution algorithm.
        /// </summary>
        public static Distribution NegativeNormal { get; } = new NegativeNormalDistribution();

        /// <summary>
        /// Gets a <see cref="Distribution"/> that uses a positive normal distribution algorithm.
        /// </summary>
        public static Distribution PositiveNormal { get; } = new PositiveNormalDistribution();

        /// <summary>
        /// Gets a <see cref="Distribution"/> that uses an uniform distribution algorithm.
        /// </summary>
        public static Distribution Uniform { get; } = new UniformDistribution();

        /// <summary>
        /// Get the next double in the random distribution.
        /// </summary>
        /// <param name="random">The random number generator to use.</param>
        /// <returns>The next double in the random distribution.</returns>
        public abstract double NextDouble(Random random);

        /// <summary>
        /// Get the next double in the Gaussian distribution.
        /// </summary>
        /// <param name="random">The random number generator to use.</param>
        /// <returns>The next double in the Gaussian distribution.</returns>
        protected double NextGausian(Random random) => this.NextGausian(random, NSIGMA);

        /// <summary>
        /// Get the next double in the Gaussian distribution.
        /// </summary>
        /// <param name="random">The random number generator to use.</param>
        /// <param name="sigma">The sigma to use.</param>
        /// <returns>The next double in the Gaussian distribution.</returns>
        protected double NextGausian(Random random, int sigma)
        {
            double u1 = random.NextDouble();
            double u2 = random.NextDouble();
            double stdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Sin(2.0 * Math.PI * u2);
            double gausian = MEAN + (STDDEV * stdNormal);
            return (gausian % sigma) / sigma;
        }

        /// <summary>
        /// Provides random number generation using an inverted normal distribution algorithm.
        /// </summary>
        private sealed class InvertedNormalDistribution : Distribution
        {
            /// <summary>
            /// Get the next double in the random distribution.
            /// </summary>
            /// <param name="random">The random number generator to use.</param>
            /// <returns>The next double in the random distribution.</returns>
            public override double NextDouble(Random random)
            {
                double next = this.NextGausian(random, NSIGMA * 2);
                return (next < 0) ? 1 + next : next;
            }
        }

        /// <summary>
        /// Provides random number generation using a negative normal distribution algorithm.
        /// </summary>
        private sealed class NegativeNormalDistribution : Distribution
        {
            /// <summary>
            /// Get the next double in the random distribution.
            /// </summary>
            /// <param name="random">The random number generator to use.</param>
            /// <returns>The next double in the random distribution.</returns>
            public override double NextDouble(Random random) =>
                Math.Abs(-1 + Math.Abs(this.NextGausian(random)));
        }

        /// <summary>
        /// Provides random number generation using a positive normal distribution algorithm.
        /// </summary>
        private sealed class PositiveNormalDistribution : Distribution
        {
            /// <summary>
            /// Get the next double in the random distribution.
            /// </summary>
            /// <param name="random">The random number generator to use.</param>
            /// <returns>The next double in the random distribution.</returns>
            public override double NextDouble(Random random) => Math.Abs(this.NextGausian(random));
        }

        /// <summary>
        /// Provides random number generation using an uniform distribution algorithm.
        /// </summary>
        private sealed class UniformDistribution : Distribution
        {
            /// <summary>
            /// Get the next double in the random distribution.
            /// </summary>
            /// <param name="random">The random number generator to use.</param>
            /// <returns>The next double in the random distribution.</returns>
            public override double NextDouble(Random random) => random.NextDouble();
        }
    }
}