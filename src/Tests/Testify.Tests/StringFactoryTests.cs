using System.Linq;
using Xunit;

namespace Testify
{
    public class StringFactoryTests
    {
        [Fact]
        public void CreateString()
        {
            var factory = new ObjectFactory();

            var result = factory.CreateString();

            Assert.NotNull(result);
            Assert.True(result.All(c => char.IsLetter(c)));
        }

        [Fact]
        public void CreateString_Distribution()
        {
            var factory = new ObjectFactory();

            var result = factory.CreateString(Distribution.Uniform);

            Assert.NotNull(result);
            Assert.True(result.All(c => char.IsLetter(c)));
        }

        [Fact]
        public void CreateString_MinMaxLength()
        {
            var factory = new ObjectFactory();

            var result = factory.CreateString(4, 10);

            Assert.NotNull(result);
            Assert.True(result.All(c => char.IsLetter(c)));
            Assert.True(result.Length >= 4 && result.Length <= 10);
        }

        [Fact]
        public void CreateString_MinMaxLengthDistribution()
        {
            var factory = new ObjectFactory();

            var result = factory.CreateString(4, 10, Distribution.Uniform);

            Assert.NotNull(result);
            Assert.True(result.All(c => char.IsLetter(c)));
            Assert.True(result.Length >= 4 && result.Length <= 10);
        }
    }
}