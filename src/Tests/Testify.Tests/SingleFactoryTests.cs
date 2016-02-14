using Xunit;

namespace Testify
{
    public class SingleFactoryTests
    {
        [Fact]
        public void CreateSingle()
        {
            var factory = new ObjectFactory();
            var classifier = new Classifier<float>();
            classifier.AddClassification("GT", d => d > 0);
            classifier.AddClassification("LT", d => d < 0);

            classifier.Classify(() => factory.CreateSingle());

            Assert.True(classifier["GT"] > 0.4);
            Assert.True(classifier["LT"] > 0.4);
        }

        [Fact]
        public void CreateSingle_Distribution()
        {
            var factory = new ObjectFactory();
            var classifier = new Classifier<float>();
            classifier.AddClassification("GT", d => d > 0);
            classifier.AddClassification("LT", d => d < 0);

            classifier.Classify(() => factory.CreateSingle(Distribution.Uniform));

            Assert.True(classifier["GT"] > 0.4);
            Assert.True(classifier["LT"] > 0.4);
        }

        [Fact]
        public void CreateSingle_MinMax()
        {
            var factory = new ObjectFactory();
            var classifier = new Classifier<float>();
            classifier.AddClassification("GT", d => d > 0);
            classifier.AddClassification("LT", d => d < 0);

            classifier.Classify(() => factory.CreateSingle(float.MinValue, float.MaxValue));

            Assert.True(classifier["GT"] > 0.4);
            Assert.True(classifier["LT"] > 0.4);
        }

        [Fact]
        public void CreateSingle_MinMaxDistribution()
        {
            var factory = new ObjectFactory();
            var classifier = new Classifier<float>();
            classifier.AddClassification("GT", d => d > 0);
            classifier.AddClassification("LT", d => d < 0);

            classifier.Classify(() => factory.CreateSingle(float.MinValue, float.MaxValue, Distribution.Uniform));

            Assert.True(classifier["GT"] > 0.4);
            Assert.True(classifier["LT"] > 0.4);
        }
    }
}