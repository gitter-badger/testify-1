using Xunit;

namespace Testify
{
    public class BoolFactoryTests
    {
        [Fact]
        public void TestCreateBool()
        {
            var factory = new ObjectFactory();
            var classifier = new Classifier<bool>();
            classifier.AddClassification("true", b => b);
            classifier.AddClassification("false", b => !b);

            classifier.Classify(() => factory.CreateBool());

            Assert.True(classifier["true"] > 0.4);
            Assert.True(classifier["false"] > 0.4);
        }

        [Fact]
        public void TestCreateBool_Distribution()
        {
            var factory = new ObjectFactory();
            var classifier = new Classifier<bool>();
            classifier.AddClassification("true", b => b);
            classifier.AddClassification("false", b => !b);

            classifier.Classify(() => factory.CreateBool(Distribution.Uniform));

            Assert.True(classifier["true"] > 0.4);
            Assert.True(classifier["false"] > 0.4);
        }
    }
}