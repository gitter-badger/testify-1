using System;
using Xunit;

namespace Testify
{
    public class DateTimeFactoryTests
    {
        [Fact]
        public void CreateDateTime()
        {
            var factory = new ObjectFactory();
            var classifier = new Classifier<DateTime>();
            classifier.AddClassification("GT", d => d.Ticks > (DateTime.MaxValue.Ticks / 2));
            classifier.AddClassification("LT", d => d.Ticks < (DateTime.MaxValue.Ticks / 2));

            classifier.Classify(() => factory.CreateDateTime());

            Assert.True(classifier["GT"] > 0.4);
            Assert.True(classifier["LT"] > 0.4);
        }

        [Fact]
        public void CreateDateTime_Distribution()
        {
            var factory = new ObjectFactory();
            var classifier = new Classifier<DateTime>();
            classifier.AddClassification("GT", d => d.Ticks > (DateTime.MaxValue.Ticks / 2));
            classifier.AddClassification("LT", d => d.Ticks < (DateTime.MaxValue.Ticks / 2));

            classifier.Classify(() => factory.CreateDateTime(Distribution.Uniform));

            Assert.True(classifier["GT"] > 0.4);
            Assert.True(classifier["LT"] > 0.4);
        }

        [Fact]
        public void CreateDateTime_MinMax()
        {
            var factory = new ObjectFactory();
            var classifier = new Classifier<DateTime>();
            classifier.AddClassification("GT", d => d.Ticks > (DateTime.MaxValue.Ticks / 2));
            classifier.AddClassification("LT", d => d.Ticks < (DateTime.MaxValue.Ticks / 2));

            classifier.Classify(() => factory.CreateDateTime(DateTime.MinValue, DateTime.MaxValue));

            Assert.True(classifier["GT"] > 0.4);
            Assert.True(classifier["LT"] > 0.4);
        }

        [Fact]
        public void CreateDateTime_MinMaxDistribution()
        {
            var factory = new ObjectFactory();
            var classifier = new Classifier<DateTime>();
            classifier.AddClassification("GT", d => d.Ticks > (DateTime.MaxValue.Ticks / 2));
            classifier.AddClassification("LT", d => d.Ticks < (DateTime.MaxValue.Ticks / 2));

            classifier.Classify(() => factory.CreateDateTime(DateTime.MinValue, DateTime.MaxValue, Distribution.Uniform));

            Assert.True(classifier["GT"] > 0.4);
            Assert.True(classifier["LT"] > 0.4);
        }
    }
}