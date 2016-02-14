using System;
using Xunit;

namespace Testify
{
    public class EnumFactoryTests
    {
        [Flags]
        private enum FlagsEnum
        {
            None = 0x0,
            First = 0x1,
            Second = 0x2,
            Third = 0x4
        }

        private enum SimpleEnum
        {
            One,
            Two,
            Three
        }

        [Fact]
        public void CreateEnumValue_FlagsEnumType()
        {
            var factory = new ObjectFactory();

            var result = (FlagsEnum)factory.CreateEnumValue(typeof(FlagsEnum));
        }

        [Fact]
        public void CreateEnumValue_FlagsEnumTypeDistribution()
        {
            var factory = new ObjectFactory();

            var result = (FlagsEnum)factory.CreateEnumValue(typeof(FlagsEnum), Distribution.Uniform);
        }

        [Fact]
        public void CreateEnumValue_SimpleEnumType()
        {
            var factory = new ObjectFactory();

            var result = (SimpleEnum)factory.CreateEnumValue(typeof(SimpleEnum));
        }

        [Fact]
        public void CreateEnumValue_SimpleEnumTypeDistribution()
        {
            var factory = new ObjectFactory();

            var result = (SimpleEnum)factory.CreateEnumValue(typeof(SimpleEnum), Distribution.Uniform);
        }

        [Fact]
        public void CreateEnumValueOfFlagsEnum()
        {
            var factory = new ObjectFactory();

            var result = factory.CreateEnumValue<FlagsEnum>();
        }

        [Fact]
        public void CreateEnumValueOfFlagsEnum_Distribution()
        {
            var factory = new ObjectFactory();

            var result = factory.CreateEnumValue<FlagsEnum>(Distribution.Uniform);
        }

        [Fact]
        public void CreateEnumValueOfSimpleEnum()
        {
            var factory = new ObjectFactory();

            var result = factory.CreateEnumValue<SimpleEnum>();
        }

        [Fact]
        public void CreateEnumValueOfSimpleEnum_Distribution()
        {
            var factory = new ObjectFactory();

            var result = factory.CreateEnumValue<SimpleEnum>(Distribution.Uniform);
        }
    }
}