using System;
using System.Collections.Generic;
using Xunit;

namespace Testify
{
    public class ObjectFactoryTests
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

        private interface IModel
        {
            string Value { get; }
        }

        [Fact]
        public void Create_ArrayOfType()
        {
            var factory = new ObjectFactory();

            var result = (Model[])factory.Create(typeof(Model[]));

            Assert.NotNull(result);
        }

        [Fact]
        public void Create_ConcreteTypeNotRegistered()
        {
            var factory = new ObjectFactory();

            var result = (Model)factory.Create(typeof(Model));

            Assert.NotNull(result);
        }

        [Fact]
        public void Create_Double()
        {
            var factory = new ObjectFactory();
            var classifier = new Classifier<double>();
            classifier.AddClassification("GT", d => d > 0);
            classifier.AddClassification("LT", d => d < 0);

            classifier.Classify(() => (double)factory.Create(typeof(double)));

            Assert.True(classifier["GT"] > 0.4);
            Assert.True(classifier["LT"] > 0.4);
        }

        [Fact]
        public void Create_EnumerableOfType()
        {
            var factory = new ObjectFactory();

            var result = (IEnumerable<Model>)factory.Create(typeof(IEnumerable<Model>));

            Assert.NotNull(result);
        }

        [Fact]
        public void Create_FlagsEnum()
        {
            var factory = new ObjectFactory();

            var result = (FlagsEnum)factory.Create(typeof(FlagsEnum));
        }

        [Fact]
        public void Create_ListOfType()
        {
            var factory = new ObjectFactory();

            var result = (List<Model>)factory.Create(typeof(List<Model>));

            Assert.NotNull(result);
        }

        [Fact]
        public void Create_ModelList()
        {
            var factory = new ObjectFactory();

            var result = (ModelList)factory.Create(typeof(ModelList));

            Assert.NotNull(result);
        }

        [Fact]
        public void Create_SimpleEnum()
        {
            var factory = new ObjectFactory();

            var result = (SimpleEnum)factory.Create(typeof(SimpleEnum));
        }

        [Fact]
        public void Create_TupleIntString()
        {
            var factory = new ObjectFactory();

            var result = (Tuple<int, string>)factory.Create(typeof(Tuple<int, string>));

            Assert.NotNull(result);
        }

        [Fact]
        public void CreateDouble_MinMaxDistribution()
        {
            var factory = new ObjectFactory();
            var classifier = new Classifier<double>();
            classifier.AddClassification("GT", d => d > 0);
            classifier.AddClassification("LT", d => d < 0);

            classifier.Classify(() => factory.CreateDouble(double.MinValue, double.MaxValue, Distribution.Uniform));

            Assert.True(classifier["GT"] > 0.4);
            Assert.True(classifier["LT"] > 0.4);
        }

        [Fact]
        public void Customize()
        {
            var factory = new ObjectFactory();
            factory.Customize(new Customization());

            var result = (IModel)factory.Create(typeof(IModel));

            Assert.NotNull(result);
        }

        [Fact]
        public void Register()
        {
            var factory = new ObjectFactory();
            factory.Register<IModel>(f => new Model());

            var result = (IModel)factory.Create(typeof(IModel));

            Assert.NotNull(result);
        }

        private class Customization : IObjectFactoryCustomization
        {
            public bool Create(IObjectFactoryContext context, out object result)
            {
                if (context.ResultType == typeof(IModel))
                {
                    result = new Model();
                    return true;
                }

                return context.CallNextCustomization(out result);
            }
        }

        private class Model : IModel
        {
            public string Value { get; } = nameof(Model);
        }

        private class ModelList : List<Model>
        {
        }
    }
}