using System.Linq;
using Xunit;

namespace Testify
{
    public class EnumerableFactoryTests
    {
        [Fact]
        public void TestCreateEnumerable_Type()
        {
            var factory = new ObjectFactory();

            var result = factory.CreateEnumerable(typeof(int));

            Assert.NotNull(result);
        }

        [Fact]
        public void TestCreateEnumerable_TypeMinMaxLength()
        {
            var factory = new ObjectFactory();

            var result = factory.CreateEnumerable(typeof(int), 4, 10);
            var count = result.OfType<int>().Count();

            Assert.NotNull(result);
            Assert.True(count >= 4 && count <= 10);
        }

        [Fact]
        public void TestCreateEnumerableOfT()
        {
            var factory = new ObjectFactory();

            var result = factory.CreateEnumerable<int>();

            Assert.NotNull(result);
        }

        [Fact]
        public void TestCreateEnumerableT_MinMaxLength()
        {
            var factory = new ObjectFactory();

            var result = factory.CreateEnumerable<int>(4, 10);
            var count = result.Count();

            Assert.NotNull(result);
            Assert.True(count >= 4 && count <= 10);
        }
    }
}