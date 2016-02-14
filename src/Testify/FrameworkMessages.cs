using System;
using System.Globalization;
using Testify.Properties;

namespace Testify
{
    /// <summary>
    /// Formats framework messages.
    /// </summary>
    internal static class FrameworkMessages
    {
        /// <summary>
        /// Returns a formatted message for assertion failed messages.
        /// </summary>
        /// <param name="assertionName">The assertion name.</param>
        /// <param name="userMessage">The user message to include.</param>
        /// <returns>The formatted message.</returns>
        internal static string AssertionFailed(string assertionName, string userMessage) =>
            Format(Resources.FrameworkMessage_AssertionFailed, assertionName, userMessage.Trim());

        /// <summary>
        /// Formats a message for Contains failures.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="substring">The substring.</param>
        /// <param name="message">The user message.</param>
        /// <returns>The formatted message.</returns>
        internal static string ContainsFailMsg(string value, string substring, string message) =>
            Format(Resources.FrameworkMessage_ContainsFailMsg, value, substring, message);

        /// <summary>
        /// Formats a message for DoesNotMatch failures.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="pattern">The pattern.</param>
        /// <param name="userMessage">The user message.</param>
        /// <returns>The formatted message.</returns>
        internal static string DoesNotMatchFailMsg(string value, string pattern, string userMessage) =>
            Format(Resources.FrameworkMessage_DoesNotMatchFailMsg, value, pattern, userMessage);

        /// <summary>
        /// Formats a message for EndsWithFail failures.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="substring">The substring.</param>
        /// <param name="message">The message.</param>
        /// <returns>The formatted message.</returns>
        internal static string EndsWithFailMsg(string value, string substring, string message) =>
            Format(Resources.FrameworkMessage_EndsWithFailMsg, value, substring, message);

        /// <summary>
        /// Returns a formatted message for IsEqualTo failures due to greater difference than delta.
        /// </summary>
        /// <param name="userMessage">The user message to include.</param>
        /// <param name="expected">The expected value.</param>
        /// <param name="actual">The actual value.</param>
        /// <param name="delta">The expected delta.</param>
        /// <returns>The formatted message.</returns>
        internal static string IsEqualToDeltaFailMsg(string userMessage, double expected, double actual, double delta) =>
            Format(Resources.FrameworkMessage_IsEqualToDeltaFailMsg, delta, expected, actual, userMessage.Trim());

        /// <summary>
        /// Returns a formatted message for IsEqualTo failures due to greater difference than delta.
        /// </summary>
        /// <param name="userMessage">The user message to include.</param>
        /// <param name="expected">The expected value.</param>
        /// <param name="actual">The actual value.</param>
        /// <param name="delta">The expected delta.</param>
        /// <returns>The formatted message.</returns>
        internal static string IsEqualToDeltaFailMsg(string userMessage, float expected, float actual, float delta) =>
            Format(Resources.FrameworkMessage_IsEqualToDeltaFailMsg, delta, expected, actual, userMessage.Trim());

        /// <summary>
        /// Returns a formatted message for IsEqualTo failures due to different types.
        /// </summary>
        /// <param name="userMessage">The user message to include.</param>
        /// <param name="expected">The expected value.</param>
        /// <param name="expectedType">The expected value's type.</param>
        /// <param name="actual">The actual value.</param>
        /// <param name="actualType">The actual value's type.</param>
        /// <returns>The formatted message.</returns>
        internal static string IsEqualToDifferentTypesFailMsg(string userMessage, string expected, string expectedType, string actual, string actualType) =>
            Format(Resources.FrameworkMessage_IsEqualToFailTypesMsg, expected, expectedType, actual, actualType, userMessage.Trim());

        /// <summary>
        /// Returns a formatted message for IsEqualTo failures.
        /// </summary>
        /// <param name="userMessage">The user message to include.</param>
        /// <param name="expected">The expected value.</param>
        /// <param name="actual">The actual value.</param>
        /// <returns>The formatted message.</returns>
        internal static string IsEqualToFailMsg(string userMessage, string expected, string actual) =>
            Format(Resources.FrameworkMessage_IsEqualToFailMsg, expected, actual, userMessage.Trim());

        /// <summary>
        /// Returns a formatted message for IsInstanceOfType failures.
        /// </summary>
        /// <param name="userMessage">The user mesage to include.</param>
        /// <param name="expectedType">The expected type.</param>
        /// <param name="actualType">The actual type.</param>
        /// <returns>The formatted message</returns>
        internal static string IsInstanceOfTypeFailMsg(string userMessage, Type expectedType, string actualType) =>
            Format(Resources.FrameworkMessage_IsInstanceOfTypeFailMsg, expectedType, actualType, userMessage.Trim());

        /// <summary>
        /// Returns a formatted message for IsNotEqualTo failures due to difference less than delta.
        /// </summary>
        /// <param name="userMessage">The user message to include.</param>
        /// <param name="expected">The expected value.</param>
        /// <param name="actual">The actual value.</param>
        /// <param name="delta">The delta.</param>
        /// <returns>The formatted message.</returns>
        internal static string IsNotEqualToDeltaFailMsg(string userMessage, double expected, double actual, double delta) =>
            Format(Resources.FrameworkMessage_IsNotEqualToDeltaFailMsg, delta, expected, actual, userMessage.Trim());

        /// <summary>
        /// Returns a formatted message for IsNotEqualTo failures due to difference less than delta.
        /// </summary>
        /// <param name="userMessage">The user message to include.</param>
        /// <param name="expected">The expected value.</param>
        /// <param name="actual">The actual value.</param>
        /// <param name="delta">The delta.</param>
        /// <returns>The formatted message.</returns>
        internal static string IsNotEqualToDeltaFailMsg(string userMessage, float expected, float actual, float delta) =>
            Format(Resources.FrameworkMessage_IsNotEqualToDeltaFailMsg, delta, expected, actual, userMessage.Trim());

        /// <summary>
        /// Returns a formatted message for IsNotEqualTo failures.
        /// </summary>
        /// <param name="userMessage">The user message to include.</param>
        /// <param name="expected">The expected value.</param>
        /// <param name="actual">The actual value.</param>
        /// <returns>The formatted message.</returns>
        internal static string IsNotEqualToFailMsg(string userMessage, string expected, string actual) =>
            Format(Resources.FrameworkMessage_IsNotEqualToFailMsg, expected, actual, userMessage.Trim());

        /// <summary>
        /// Returns a formatted message for IsNotInstanceOfType failures.
        /// </summary>
        /// <param name="userMessage">The user message to include.</param>
        /// <param name="expected">The expected value.</param>
        /// <param name="actual">The actual value.</param>
        /// <returns>The formatted message.</returns>
        internal static string IsNotInstanceOfTypeFailMsg(string userMessage, string expected, string actual) =>
            Format(Resources.FrameworkMessage_IsNotInstanceOfTypeFailMsg, expected, actual, userMessage.Trim());

        /// <summary>
        /// Formats a message for Matches failures.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="pattern">The pattern.</param>
        /// <param name="message">The user message.</param>
        /// <returns>The formatted message.</returns>
        internal static string MatchesFailMsg(string value, string pattern, string message) =>
            Format(Resources.FrameworkMessage_MatchesFailMsg, value, pattern, message);

        /// <summary>
        /// Formats a message for StartsWith failures.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="substring">The substring.</param>
        /// <param name="message">The user message.</param>
        /// <returns>The formatted message.</returns>
        internal static string StartsWithFailMsg(string value, string substring, string message) =>
            Format(Resources.FrameworkMessage_StartsWithFailMsg, value, substring, message);

        private static string Format(string format, params object[] args) =>
            string.Format(CultureInfo.CurrentCulture, format, args).Trim();
    }
}