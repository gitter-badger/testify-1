using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Testify.Properties;

namespace Testify
{
    /// <summary>
    /// Provides methods for starting fluent assertions.
    /// </summary>
    public static class Assertions
    {
        /// <summary>
        /// Begins a fluent assertion by providing the actual value.
        /// </summary>
        /// <typeparam name="T">The type of the actual value.</typeparam>
        /// <param name="actualValue">The actual value.</param>
        /// <returns>An <see cref="ActualValue{T}"/> instance that can be used to declare
        /// fluent assertions.</returns>
        public static ActualValue<T> Assert<T>(T actualValue) => new ActualValue<T>(actualValue);

        /// <summary>
        /// Declares a compound assertion.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="assertions">The assertions.</param>
        public static void CompoundAssertion(string message, params Action[] assertions)
        {
            var errors = new Lazy<List<Exception>>(false);
            foreach (var action in assertions)
            {
                try
                {
                    action();
                }
                catch (Exception e)
                {
                    errors.Value.Add(e);
                }
            }

            if (errors.IsValueCreated)
            {
                throw new AssertionException(message, errors.Value);
            }
        }

        /// <summary>
        /// Fails with an <see cref="AssertionException"/> without checking any conditions. Displays
        /// a message.
        /// </summary>
        /// <param name="message">A message to display. This message can be seen in the unit test results.</param>
        public static void Fail(string message)
        {
            throw new AssertionException(message);
        }

        /// <summary>
        /// Fails with an <see cref="AssertionException"/> without checking any conditions. Displays
        /// a message, and applies the specified formatting to it.
        /// </summary>
        /// <param name="message">A message to display. This message can be seen in the unit test results.</param>
        /// <param name="parameters">An array of parameters to use when formatting <paramref name="message"/>.</param>
        public static void Fail(string message, params object[] parameters)
        {
            string completeMessage = Assertions.CreateCompleteMessage(message, parameters);
            throw new AssertionException(completeMessage);
        }

        /// <summary>
        /// In a string, replaces null characters ("\0") with "\\0".
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>The result.</returns>
        public static string ReplaceNullChars(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            var list = new List<int>();
            for (int index = 0; index < input.Length; ++index)
            {
                if (input[index] == 0)
                {
                    list.Add(index);
                }
            }

            if (!list.Any())
            {
                return input;
            }

            var stringBuilder = new StringBuilder(input.Length + list.Count);
            int startIndex = 0;
            foreach (int num in list)
            {
                stringBuilder.Append(input.Substring(startIndex, num - startIndex));
                stringBuilder.Append("\\0");
                startIndex = num + 1;
            }

            stringBuilder.Append(input.Substring(startIndex));
            return stringBuilder.ToString();
        }

        /// <summary>
        /// Creates the complete message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>The formatted message.</returns>
        internal static string CreateCompleteMessage(string message, object[] parameters)
        {
            string str = string.Empty;
            if (!string.IsNullOrEmpty(message))
            {
                str = parameters != null && parameters.Any() ? string.Format(CultureInfo.CurrentCulture, ReplaceNulls(message), parameters) : ReplaceNulls(message);
            }

            return str;
        }

        /// <summary>
        /// Raises failure exceptions.
        /// </summary>
        /// <param name="assertionName">Name of the assertion.</param>
        /// <param name="message">The message.</param>
        /// <param name="parameters">The parameters.</param>
        internal static void HandleFail(string assertionName, string message, params object[] parameters)
        {
            string completeMessage = Assertions.CreateCompleteMessage(message, parameters);
            throw new AssertionException(FrameworkMessages.AssertionFailed(assertionName, completeMessage));
        }

        /// <summary>
        /// Replaces the nulls.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>Text formatted without nulls.</returns>
        internal static string ReplaceNulls(object input)
        {
            if (input == null)
            {
                return Resources.Common_NullInMessages;
            }

            string result = input.ToString();
            if (result == null)
            {
                return Resources.Common_ObjectString;
            }

            return Assertions.ReplaceNullChars(result);
        }
    }
}