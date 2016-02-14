using Xunit;

namespace Testify
{
    public class DoubleFactoryTests
    {
        [Fact]
        public void CreateDouble()
        {
            var factory = new ObjectFactory();
            var classifier = new Classifier<double>();
            classifier.AddClassification("GT", d => d > 0);
            classifier.AddClassification("LT", d => d < 0);

            classifier.Classify(() => factory.CreateDouble());

            Assert.True(classifier["GT"] > 0.4);
            Assert.True(classifier["LT"] > 0.4);
        }

        [Fact]
        public void CreateDouble_Distribution()
        {
            var factory = new ObjectFactory();
            var classifier = new Classifier<double>();
            classifier.AddClassification("GT", d => d > 0);
            classifier.AddClassification("LT", d => d < 0);

            classifier.Classify(() => factory.CreateDouble(Distribution.Uniform));

            Assert.True(classifier["GT"] > 0.4);
            Assert.True(classifier["LT"] > 0.4);
        }

        [Fact]
        public void CreateDouble_MinMax()
        {
            var factory = new ObjectFactory();
            var classifier = new Classifier<double>();
            classifier.AddClassification("GT", d => d > 0);
            classifier.AddClassification("LT", d => d < 0);

            classifier.Classify(() => factory.CreateDouble(double.MinValue, double.MaxValue));

            Assert.True(classifier["GT"] > 0.4);
            Assert.True(classifier["LT"] > 0.4);
        }
    }
}