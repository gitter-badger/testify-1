using Xunit;

namespace Testify
{
    public class ByteFactoryTests
    {
        [Fact]
        public void CreateByte()
        {
            var factory = new ObjectFactory();
            var classifier = new Classifier<byte>();
            classifier.AddClassification("GT", d => d > (byte.MaxValue / 2));
            classifier.AddClassification("LT", d => d < (byte.MaxValue / 2));

            classifier.Classify(() => factory.CreateByte());

            Assert.True(classifier["GT"] > 0.4);
            Assert.True(classifier["LT"] > 0.4);
        }

        [Fact]
        public void CreateByte_Distribution()
        {
            var factory = new ObjectFactory();
            var classifier = new Classifier<byte>();
            classifier.AddClassification("GT", d => d > (byte.MaxValue / 2));
            classifier.AddClassification("LT", d => d < (byte.MaxValue / 2));

            classifier.Classify(() => factory.CreateByte(Distribution.Uniform));

            Assert.True(classifier["GT"] > 0.4);
            Assert.True(classifier["LT"] > 0.4);
        }

        [Fact]
        public void CreateByte_MinMax()
        {
            var factory = new ObjectFactory();
            var classifier = new Classifier<byte>();
            classifier.AddClassification("GT", d => d > (byte.MaxValue / 2));
            classifier.AddClassification("LT", d => d < (byte.MaxValue / 2));

            classifier.Classify(() => factory.CreateByte(byte.MinValue, byte.MaxValue));

            Assert.True(classifier["GT"] > 0.4);
            Assert.True(classifier["LT"] > 0.4);
        }

        [Fact]
        public void CreateByte_MinMaxDistribution()
        {
            var factory = new ObjectFactory();
            var classifier = new Classifier<byte>();
            classifier.AddClassification("GT", d => d > (byte.MaxValue / 2));
            classifier.AddClassification("LT", d => d < (byte.MaxValue / 2));

            classifier.Classify(() => factory.CreateByte(byte.MinValue, byte.MaxValue, Distribution.Uniform));

            Assert.True(classifier["GT"] > 0.4);
            Assert.True(classifier["LT"] > 0.4);
        }
    }
}