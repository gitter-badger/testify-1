using Xunit;

namespace Testify
{
    public class Int64FactoryTests
    {
        [Fact]
        public void CreateInt64()
        {
            var factory = new ObjectFactory();
            var classifier = new Classifier<long>();
            classifier.AddClassification("GT", d => d > 0);
            classifier.AddClassification("LT", d => d < 0);

            classifier.Classify(() => factory.CreateInt64());

            Assert.True(classifier["GT"] > 0.4);
            Assert.True(classifier["LT"] > 0.4);
        }

        [Fact]
        public void CreateInt64_Distribution()
        {
            var factory = new ObjectFactory();
            var classifier = new Classifier<long>();
            classifier.AddClassification("GT", d => d > 0);
            classifier.AddClassification("LT", d => d < 0);

            classifier.Classify(() => factory.CreateInt64(Distribution.Uniform));

            Assert.True(classifier["GT"] > 0.4);
            Assert.True(classifier["LT"] > 0.4);
        }

        [Fact]
        public void CreateInt64_MinMax()
        {
            var factory = new ObjectFactory();
            var classifier = new Classifier<long>();
            classifier.AddClassification("GT", d => d > 0);
            classifier.AddClassification("LT", d => d < 0);

            classifier.Classify(() => factory.CreateInt64(long.MinValue, long.MaxValue));

            Assert.True(classifier["GT"] > 0.4);
            Assert.True(classifier["LT"] > 0.4);
        }

        [Fact]
        public void CreateInt64_MinMaxDistribution()
        {
            var factory = new ObjectFactory();
            var classifier = new Classifier<long>();
            classifier.AddClassification("GT", d => d > 0);
            classifier.AddClassification("LT", d => d < 0);

            classifier.Classify(() => factory.CreateInt64(long.MinValue, long.MaxValue, Distribution.Uniform));

            Assert.True(classifier["GT"] > 0.4);
            Assert.True(classifier["LT"] > 0.4);
        }
    }
}