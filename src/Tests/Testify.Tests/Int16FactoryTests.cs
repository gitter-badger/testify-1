using Xunit;

namespace Testify
{
    public class Int16FactoryTests
    {
        [Fact]
        public void CreateInt16()
        {
            var factory = new ObjectFactory();
            var classifier = new Classifier<short>();
            classifier.AddClassification("GT", d => d > 0);
            classifier.AddClassification("LT", d => d < 0);

            classifier.Classify(() => factory.CreateInt16());

            Assert.True(classifier["GT"] > 0.4);
            Assert.True(classifier["LT"] > 0.4);
        }

        [Fact]
        public void CreateInt16_Distribution()
        {
            var factory = new ObjectFactory();
            var classifier = new Classifier<short>();
            classifier.AddClassification("GT", d => d > 0);
            classifier.AddClassification("LT", d => d < 0);

            classifier.Classify(() => factory.CreateInt16(Distribution.Uniform));

            Assert.True(classifier["GT"] > 0.4);
            Assert.True(classifier["LT"] > 0.4);
        }

        [Fact]
        public void CreateInt16_MinMax()
        {
            var factory = new ObjectFactory();
            var classifier = new Classifier<short>();
            classifier.AddClassification("GT", d => d > 0);
            classifier.AddClassification("LT", d => d < 0);

            classifier.Classify(() => factory.CreateInt16(short.MinValue, short.MaxValue));

            Assert.True(classifier["GT"] > 0.4);
            Assert.True(classifier["LT"] > 0.4);
        }

        [Fact]
        public void CreateInt16_MinMaxDistribution()
        {
            var factory = new ObjectFactory();
            var classifier = new Classifier<short>();
            classifier.AddClassification("GT", d => d > 0);
            classifier.AddClassification("LT", d => d < 0);

            classifier.Classify(() => factory.CreateInt16(short.MinValue, short.MaxValue, Distribution.Uniform));

            Assert.True(classifier["GT"] > 0.4);
            Assert.True(classifier["LT"] > 0.4);
        }
    }
}