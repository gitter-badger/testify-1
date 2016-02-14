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

        private static string Format(string format, params object[] args) =>
            string.Format(CultureInfo.CurrentCulture, format, args).Trim();
    }
}