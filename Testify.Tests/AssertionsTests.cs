using Xunit;
using static Testify.Assertions;

namespace Testify
{
    public class AssertionsTests
    {
        [Fact]
        public void AssertReturnsActualValue()
        {
            var actualValue = new object();

            var result = Assert(actualValue);

            if (!object.ReferenceEquals(result.Value, actualValue))
            {
                Fail("Actual value not set correctly.");
            }
        }

        [Fact]
        public void CompoundAssertionNoErrorsShouldNotThrow()
        {
            try
            {
                CompoundAssertion(
                    "An error occurred.",
                    () => { },
                    () => { });
            }
            catch (AssertionException)
            {
                Fail("CompoundAssertion threw when it shouldn't have.");
            }
        }

        [Fact]
        public void CompoundAssertionErrorsShouldReportErrors()
        {
            try
            {
                CompoundAssertion(
                    "An error occurred.",
                    () => Fail("First"),
                    () => Fail("Second"));
            }
            catch (AssertionException e)
            {
                if (e.InnerExceptions.Count != 2)
                {
                    Fail("CompoundAssertion didn't report the correct number of errors.");
                }

                return;
            }

            Fail("CompoundAssert didn't report any errors.");
        }

        [Fact]
        public void FailShouldThrowException()
        {
            try
            {
                Fail("An error occurred.");
            }
            catch (AssertionException e)
            {
                if (e.Message != "An error occurred.")
                {
                    throw new AssertionException("Message not set correctly.");
                }

                return;
            }

            throw new AssertionException("Fail did not throw.");
        }

        [Fact]
        public void FailWithParametersShouldFormatMessage()
        {
            try
            {
                Fail("An {0} occurred.", "error");
            }
            catch (AssertionException e)
            {
                if (e.Message != "An error occurred.")
                {
                    throw new AssertionException("Message not set correctly.");
                }

                return;
            }

            throw new AssertionException("Fail did not throw.");
        }
    }
}
