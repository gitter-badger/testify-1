using Xunit;

namespace Testify
{
    public class Int32FactoryTests
    {
        [Fact]
        public void CreateInt32()
        {
            var factory = new ObjectFactory();
            var classifier = new Classifier<int>();
            classifier.AddClassification("GT", d => d > 0);
            classifier.AddClassification("LT", d => d < 0);

            classifier.Classify(() => factory.CreateInt32());

            Assert.True(classifier["GT"] > 0.4);
            Assert.True(classifier["LT"] > 0.4);
        }

        [Fact]
        public void CreateInt32_Distribution()
        {
            var factory = new ObjectFactory();
            var classifier = new Classifier<int>();
            classifier.AddClassification("GT", d => d > 0);
            classifier.AddClassification("LT", d => d < 0);

            classifier.Classify(() => factory.CreateInt32(Distribution.Uniform));

            Assert.True(classifier["GT"] > 0.4);
            Assert.True(classifier["LT"] > 0.4);
        }

        [Fact]
        public void CreateInt32_MinMax()
        {
            var factory = new ObjectFactory();
            var classifier = new Classifier<int>();
            classifier.AddClassification("GT", d => d > 0);
            classifier.AddClassification("LT", d => d < 0);

            classifier.Classify(() => factory.CreateInt32(int.MinValue, int.MaxValue));

            Assert.True(classifier["GT"] > 0.4);
            Assert.True(classifier["LT"] > 0.4);
        }

        [Fact]
        public void CreateInt32_MinMaxDistribution()
        {
            var factory = new ObjectFactory();
            var classifier = new Classifier<int>();
            classifier.AddClassification("GT", d => d > 0);
            classifier.AddClassification("LT", d => d < 0);

            classifier.Classify(() => factory.CreateInt32(int.MinValue, int.MaxValue, Distribution.Uniform));

            Assert.True(classifier["GT"] > 0.4);
            Assert.True(classifier["LT"] > 0.4);
        }
    }
}