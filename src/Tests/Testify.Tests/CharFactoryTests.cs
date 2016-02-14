using Xunit;

namespace Testify
{
    public class CharFactoryTests
    {
        [Fact]
        public void CreateAlphaChar()
        {
            var factory = new ObjectFactory();
            var classifier = new Classifier<char>();
            classifier.AddClassification("Alpha", d => char.IsLetter(d));

            classifier.Classify(() => factory.CreateAlphaChar());

            Assert.True(classifier["Alpha"] == 1.0);
        }

        [Fact]
        public void CreateAlphaChar_Distribution()
        {
            var factory = new ObjectFactory();
            var classifier = new Classifier<char>();
            classifier.AddClassification("Alpha", d => char.IsLetter(d));

            classifier.Classify(() => factory.CreateAlphaChar(Distribution.Uniform));

            Assert.True(classifier["Alpha"] == 1.0);
        }

        [Fact]
        public void CreateAlphaNumericChar()
        {
            var factory = new ObjectFactory();
            var classifier = new Classifier<char>();
            classifier.AddClassification("Alpha", d => char.IsLetterOrDigit(d));

            classifier.Classify(() => factory.CreateAlphaNumericChar());

            Assert.True(classifier["Alpha"] == 1.0);
        }

        [Fact]
        public void CreateAlphaNumericChar_Distribution()
        {
            var factory = new ObjectFactory();
            var classifier = new Classifier<char>();
            classifier.AddClassification("Alpha", d => char.IsLetterOrDigit(d));

            classifier.Classify(() => factory.CreateAlphaNumericChar(Distribution.Uniform));

            Assert.True(classifier["Alpha"] == 1.0);
        }

        [Fact]
        public void CreateBasicLatinChar()
        {
            var factory = new ObjectFactory();
            var classifier = new Classifier<char>();
            classifier.AddClassification("Alpha", d => d >= 0x20 && d <= 0x7f);

            classifier.Classify(() => factory.CreateBasicLatinChar());

            Assert.True(classifier["Alpha"] == 1.0);
        }

        [Fact]
        public void CreateBasicLatinChar_Distribution()
        {
            var factory = new ObjectFactory();
            var classifier = new Classifier<char>();
            classifier.AddClassification("Alpha", d => d >= 0x20 && d <= 0x7f);

            classifier.Classify(() => factory.CreateBasicLatinChar(Distribution.Uniform));

            Assert.True(classifier["Alpha"] == 1.0);
        }

        [Fact]
        public void CreateChar()
        {
            var factory = new ObjectFactory();
            var classifier = new Classifier<char>();
            classifier.AddClassification("GT", d => d > (char.MaxValue / 2));
            classifier.AddClassification("LT", d => d < (char.MaxValue / 2));

            classifier.Classify(() => factory.CreateChar());

            Assert.True(classifier["GT"] > 0.4);
            Assert.True(classifier["LT"] > 0.4);
        }

        [Fact]
        public void CreateChar_Distribution()
        {
            var factory = new ObjectFactory();
            var classifier = new Classifier<char>();
            classifier.AddClassification("GT", d => d > (char.MaxValue / 2));
            classifier.AddClassification("LT", d => d < (char.MaxValue / 2));

            classifier.Classify(() => factory.CreateChar(Distribution.Uniform));

            Assert.True(classifier["GT"] > 0.4);
            Assert.True(classifier["LT"] > 0.4);
        }

        [Fact]
        public void CreateChar_MinMax()
        {
            var factory = new ObjectFactory();
            var classifier = new Classifier<char>();
            classifier.AddClassification("GT", d => d > (char.MaxValue / 2));
            classifier.AddClassification("LT", d => d < (char.MaxValue / 2));

            classifier.Classify(() => factory.CreateChar(char.MinValue, char.MaxValue));

            Assert.True(classifier["GT"] > 0.4);
            Assert.True(classifier["LT"] > 0.4);
        }

        [Fact]
        public void CreateChar_MinMaxDistribution()
        {
            var factory = new ObjectFactory();
            var classifier = new Classifier<char>();
            classifier.AddClassification("GT", d => d > (char.MaxValue / 2));
            classifier.AddClassification("LT", d => d < (char.MaxValue / 2));

            classifier.Classify(() => factory.CreateChar(char.MinValue, char.MaxValue, Distribution.Uniform));

            Assert.True(classifier["GT"] > 0.4);
            Assert.True(classifier["LT"] > 0.4);
        }

        [Fact]
        public void CreateLatinSupplementChar()
        {
            var factory = new ObjectFactory();
            var classifier = new Classifier<char>();
            classifier.AddClassification("Alpha", d => d >= 0xa0 && d <= 0xff);

            classifier.Classify(() => factory.CreateLatinSupplementChar());

            Assert.True(classifier["Alpha"] == 1.0);
        }

        [Fact]
        public void CreateLatinSupplementChar_Distribution()
        {
            var factory = new ObjectFactory();
            var classifier = new Classifier<char>();
            classifier.AddClassification("Alpha", d => d >= 0xa0 && d <= 0xff);

            classifier.Classify(() => factory.CreateLatinSupplementChar(Distribution.Uniform));

            Assert.True(classifier["Alpha"] == 1.0);
        }

        [Fact]
        public void CreateNumericChar()
        {
            var factory = new ObjectFactory();
            var classifier = new Classifier<char>();
            classifier.AddClassification("Alpha", d => char.IsDigit(d));

            classifier.Classify(() => factory.CreateNumericChar());

            Assert.True(classifier["Alpha"] == 1.0);
        }

        [Fact]
        public void CreateNumericChar_Distribution()
        {
            var factory = new ObjectFactory();
            var classifier = new Classifier<char>();
            classifier.AddClassification("Alpha", d => char.IsDigit(d));

            classifier.Classify(() => factory.CreateNumericChar(Distribution.Uniform));

            Assert.True(classifier["Alpha"] == 1.0);
        }

        [Fact]
        public void CreatePrintableChar()
        {
            var factory = new ObjectFactory();
            var classifier = new Classifier<char>();
            classifier.AddClassification("Alpha", d => (d >= 0x20 && d <= 0x7f) || (d >= 0xa0 && d <= 0xff));

            classifier.Classify(() => factory.CreatePrintableChar());

            Assert.True(classifier["Alpha"] == 1.0);
        }

        [Fact]
        public void CreatePrintableChar_Distribution()
        {
            var factory = new ObjectFactory();
            var classifier = new Classifier<char>();
            classifier.AddClassification("Alpha", d => (d >= 0x20 && d <= 0x7f) || (d >= 0xa0 && d <= 0xff));

            classifier.Classify(() => factory.CreatePrintableChar(Distribution.Uniform));

            Assert.True(classifier["Alpha"] == 1.0);
        }
    }
}