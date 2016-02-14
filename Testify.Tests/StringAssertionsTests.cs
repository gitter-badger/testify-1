using System.Linq;
using System.Text.RegularExpressions;
using Xunit;
using static Testify.Assertions;

namespace Testify
{
    public class StringAssertionsTests
    {
        [Fact]
        public void Contains_Substring_ShouldNotThrow()
        {
            Assert("foobar").Contains("foo");
        }

        [Fact]
        public void Contains_NonSubstring_ShouldThrow()
        {
            try
            {
                Assert("foobar").Contains("baz");
            }
            catch (AssertionException e)
            {
                ExpectMessage(e, "Contains failed. String 'foobar' does not contain string 'baz'.");
                return;
            }

            Fail("Contains did not throw.");
        }

        [Fact]
        public void Contains_GivenMessage_ShouldDisplayMessage()
        {
            try
            {
                Assert("foobar").Contains("baz", "Some message.");
            }
            catch (AssertionException e)
            {
                ExpectMessage(e, "Contains failed. String 'foobar' does not contain string 'baz'. Some message.");
                return;
            }

            Fail("Contains did not throw.");
        }

        [Fact]
        public void Contains_GivenMessageParameters_ShouldDisplayMessage()
        {
            try
            {
                Assert("foobar").Contains("baz", "Some {0}.", "message");
            }
            catch (AssertionException e)
            {
                ExpectMessage(e, "Contains failed. String 'foobar' does not contain string 'baz'. Some message.");
                return;
            }

            Fail("Contains did not throw.");
        }

        [Fact]
        public void DoesNotMatch_Mismatch_ShouldNotThrow()
        {
            Assert("foo").DoesNotMatch(new Regex("bar"));
        }

        [Fact]
        public void DoesNotMatch_Match_ShouldThrow()
        {
            try
            {
                Assert("foo").DoesNotMatch(new Regex("foo"));
            }
            catch (AssertionException e)
            {
                ExpectMessage(e, "DoesNotMatch failed. String 'foo' matches pattern 'foo'.");
                return;
            }

            Fail("DoesNotMatch did not throw.");
        }

        [Fact]
        public void DoesNotMatch_GivenMessage_ShouldDisplayMessage()
        {
            try
            {
                Assert("foo").DoesNotMatch(new Regex("foo"), "Some message.");
            }
            catch (AssertionException e)
            {
                ExpectMessage(e, "DoesNotMatch failed. String 'foo' matches pattern 'foo'. Some message.");
                return;
            }

            Fail("DoesNotMatch did not throw.");
        }

        [Fact]
        public void DoesNotMatch_GivenMessageParameters_ShouldDisplayFormattedMessage()
        {
            try
            {
                Assert("foo").DoesNotMatch(new Regex("foo"), "Some {0}.", "message");
            }
            catch (AssertionException e)
            {
                ExpectMessage(e, "DoesNotMatch failed. String 'foo' matches pattern 'foo'. Some message.");
                return;
            }

            Fail("DoesNotMatch did not throw.");
        }

        [Fact]
        public void EndsWith_Suffix_ShouldNotThrow()
        {
            Assert("foo").EndsWith("o");
        }

        [Fact]
        public void EndsWith_NonSuffix_ShouldThrow()
        {
            try
            {
                Assert("foo").EndsWith("bar");
            }
            catch (AssertionException e)
            {
                ExpectMessage(e, "EndsWith failed. String 'foo' does not end with string 'bar'.");
                return;
            }

            Fail("EndsWith did not throw.");
        }

        [Fact]
        public void EndsWith_GivenMessage_ShouldDisplayMessage()
        {
            try
            {
                Assert("foo").EndsWith("bar", "Some message.");
            }
            catch (AssertionException e)
            {
                ExpectMessage(e, "EndsWith failed. String 'foo' does not end with string 'bar'. Some message.");
                return;
            }

            Fail("EndsWith did not throw.");
        }

        [Fact]
        public void EndsWith_GivenMessageParameters_ShouldDisplayFormattedMessage()
        {
            try
            {
                Assert("foo").EndsWith("bar", "Some {0}.", "message");
            }
            catch (AssertionException e)
            {
                ExpectMessage(e, "EndsWith failed. String 'foo' does not end with string 'bar'. Some message.");
                return;
            }

            Fail("EndsWith did not throw.");
        }

        [Fact]
        public void Matches_Match_ShouldNotThrow()
        {
            Assert("foo").Matches(new Regex("foo"));
        }

        [Fact]
        public void Matches_Mismatch_ShouldThrow()
        {
            try
            {
                Assert("foo").Matches(new Regex("bar"));
            }
            catch (AssertionException e)
            {
                ExpectMessage(e, "Matches failed. String 'foo' does not match pattern 'bar'.");
                return;
            }

            Fail("Matches did not throw.");
        }

        [Fact]
        public void Matches_GivenMessage_ShouldDisplayMessage()
        {
            try
            {
                Assert("foo").Matches(new Regex("bar"), "Some message.");
            }
            catch (AssertionException e)
            {
                ExpectMessage(e, "Matches failed. String 'foo' does not match pattern 'bar'. Some message.");
                return;
            }

            Fail("Matches did not throw.");
        }

        [Fact]
        public void Matches_GivenMessageParameters_ShouldDisplayFormattedMessage()
        {
            try
            {
                Assert("foo").Matches(new Regex("bar"), "Some {0}.", "message");
            }
            catch (AssertionException e)
            {
                ExpectMessage(e, "Matches failed. String 'foo' does not match pattern 'bar'. Some message.");
                return;
            }

            Fail("Matches did not throw.");
        }

        [Fact]
        public void StartsWith_Prefix_ShouldNotThrow()
        {
            Assert("foo").StartsWith("f");
        }

        [Fact]
        public void StartsWith_NonPrefix_ShouldThrow()
        {
            try
            {
                Assert("foo").StartsWith("bar");
            }
            catch (AssertionException e)
            {
                ExpectMessage(e, "StartsWith failed. String 'foo' does not start with string 'bar'.");
                return;
            }

            Fail("StartsWith did not throw.");
        }

        [Fact]
        public void StartsWith_GivenMessage_ShouldDisplayMessage()
        {
            try
            {
                Assert("foo").StartsWith("bar", "Some message.");
            }
            catch (AssertionException e)
            {
                ExpectMessage(e, "StartsWith failed. String 'foo' does not start with string 'bar'. Some message.");
                return;
            }

            Fail("StartsWith did not throw.");
        }

        [Fact]
        public void StartsWith_GivenMessageParameters_ShouldDisplayFormattedMessage()
        {
            try
            {
                Assert("foo").StartsWith("bar", "Some {0}.", "message");
            }
            catch (AssertionException e)
            {
                ExpectMessage(e, "StartsWith failed. String 'foo' does not start with string 'bar'. Some message.");
                return;
            }

            Fail("StartsWith did not throw.");
        }

        private static void ExpectMessage(AssertionException exception, string message)
        {
            ExpectMessage(exception, message, null);
        }

        private static void ExpectMessage(AssertionException exception, string message, params object[] parameters)
        {
            if (parameters != null && parameters.Any())
            {
                message = string.Format(message, parameters);
            }

            if (exception.Message != message)
            {
                Fail("Unexpected message: '{0}'. Expected message: '{1}'.", exception.Message, message);
            }
        }
    }
}
