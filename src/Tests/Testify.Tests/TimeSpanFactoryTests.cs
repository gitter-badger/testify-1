using System;
using Xunit;
using static Testify.Assertions;

namespace Testify
{
    public class TimeSpanFactoryTests
    {
        [Fact]
        public void CreateTimeSpan()
        {
            var factory = new ObjectFactory();
            var mid = new TimeSpan(0);
            var classifier = new Classifier<TimeSpan>();
            classifier.AddClassification("GT", d => d > mid);
            classifier.AddClassification("LT", d => d < mid);

            classifier.Classify(() => factory.CreateTimeSpan());

            AssertAll(
                "Distribution of values was not uniform.",
                () => Assert(classifier["GT"] > 0.4).IsTrue($"Roughly half the generated values should be greater than {mid}. Actual: {classifier["GT"]}."),
                () => Assert(classifier["LT"] > 0.4).IsTrue($"Roughly half the generated values should be less than {mid}. Actual: {classifier["LT"]}."));
        }

        [Fact]
        public void CreateTimeSpan_Distribution()
        {
            var factory = new ObjectFactory();
            var mid = new TimeSpan(0);
            var classifier = new Classifier<TimeSpan>();
            classifier.AddClassification("GT", d => d > mid);
            classifier.AddClassification("LT", d => d < mid);

            classifier.Classify(() => factory.CreateTimeSpan(Distribution.Uniform));

            AssertAll(
                "Distribution of values was not uniform.",
                () => Assert(classifier["GT"] > 0.4).IsTrue($"Roughly half the generated values should be greater than {mid}. Actual: {classifier["GT"]}."),
                () => Assert(classifier["LT"] > 0.4).IsTrue($"Roughly half the generated values should be less than {mid}. Actual: {classifier["LT"]}."));
        }

        [Fact]
        public void CreateTimeSpan_MinMax()
        {
            var factory = new ObjectFactory();
            var mid = new TimeSpan(0);
            var classifier = new Classifier<TimeSpan>();
            classifier.AddClassification("GT", d => d > mid);
            classifier.AddClassification("LT", d => d < mid);

            classifier.Classify(() => factory.CreateTimeSpan(TimeSpan.MinValue, TimeSpan.MaxValue));

            AssertAll(
                "Distribution of values was not uniform.",
                () => Assert(classifier["GT"] > 0.4).IsTrue($"Roughly half the generated values should be greater than {mid}. Actual: {classifier["GT"]}."),
                () => Assert(classifier["LT"] > 0.4).IsTrue($"Roughly half the generated values should be less than {mid}. Actual: {classifier["LT"]}."));
        }

        [Fact]
        public void CreateTimeSpan_MinMaxDistribution()
        {
            var factory = new ObjectFactory();
            var mid = new TimeSpan(0);
            var classifier = new Classifier<TimeSpan>();
            classifier.AddClassification("GT", d => d > mid);
            classifier.AddClassification("LT", d => d < mid);

            classifier.Classify(() => factory.CreateTimeSpan(TimeSpan.MinValue, TimeSpan.MaxValue, Distribution.Uniform));

            AssertAll(
                "Distribution of values was not uniform.",
                () => Assert(classifier["GT"] > 0.4).IsTrue($"Roughly half the generated values should be greater than {mid}. Actual: {classifier["GT"]}."),
                () => Assert(classifier["LT"] > 0.4).IsTrue($"Roughly half the generated values should be less than {mid}. Actual: {classifier["LT"]}."));
        }
    }
}