using System;
using Xunit;

namespace Testify
{
    public class DateTimeOffsetFactoryTests
    {
        [Fact]
        public void CreateDateTimeOffset()
        {
            var factory = new ObjectFactory();
            var classifier = new Classifier<DateTimeOffset>();
            classifier.AddClassification("GT", d => d.Ticks > (DateTimeOffset.MaxValue.Ticks / 2));
            classifier.AddClassification("LT", d => d.Ticks < (DateTimeOffset.MaxValue.Ticks / 2));

            classifier.Classify(() => factory.CreateDateTimeOffset());

            Assert.True(classifier["GT"] > 0.4);
            Assert.True(classifier["LT"] > 0.4);
        }

        [Fact]
        public void CreateDateTimeOffset_Distribution()
        {
            var factory = new ObjectFactory();
            var classifier = new Classifier<DateTimeOffset>();
            classifier.AddClassification("GT", d => d.Ticks > (DateTimeOffset.MaxValue.Ticks / 2));
            classifier.AddClassification("LT", d => d.Ticks < (DateTimeOffset.MaxValue.Ticks / 2));

            classifier.Classify(() => factory.CreateDateTimeOffset(Distribution.Uniform));

            Assert.True(classifier["GT"] > 0.4);
            Assert.True(classifier["LT"] > 0.4);
        }

        [Fact]
        public void CreateDateTimeOffset_MinMax()
        {
            var factory = new ObjectFactory();
            var classifier = new Classifier<DateTimeOffset>();
            classifier.AddClassification("GT", d => d.Ticks > (DateTimeOffset.MaxValue.Ticks / 2));
            classifier.AddClassification("LT", d => d.Ticks < (DateTimeOffset.MaxValue.Ticks / 2));

            classifier.Classify(() => factory.CreateDateTimeOffset(DateTimeOffset.MinValue, DateTimeOffset.MaxValue));

            Assert.True(classifier["GT"] > 0.4);
            Assert.True(classifier["LT"] > 0.4);
        }

        [Fact]
        public void CreateDateTimeOffset_MinMaxDistribution()
        {
            var factory = new ObjectFactory();
            var classifier = new Classifier<DateTimeOffset>();
            classifier.AddClassification("GT", d => d.Ticks > (DateTimeOffset.MaxValue.Ticks / 2));
            classifier.AddClassification("LT", d => d.Ticks < (DateTimeOffset.MaxValue.Ticks / 2));

            classifier.Classify(() => factory.CreateDateTimeOffset(DateTimeOffset.MinValue, DateTimeOffset.MaxValue, Distribution.Uniform));

            Assert.True(classifier["GT"] > 0.4);
            Assert.True(classifier["LT"] > 0.4);
        }
    }
}