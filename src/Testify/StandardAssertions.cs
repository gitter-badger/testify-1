using System;
using System.ComponentModel;
using System.Globalization;
using Testify.Properties;

namespace Testify
{
    /// <summary>
    /// Defines standard assertion methods used with the fluent <see cref="Assertions.Assert{T}(T)"/> method.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class StandardAssertions
    {
        /// <summary>
        /// Verifies that two specified doubles are equal or within the specified accuracy of each other.
        /// </summary>
        /// <param name="actualValue">The actual value.</param>
        /// <param name="expected">The expected value.</param>
        /// <param name="delta">The required accuracy. The assertion will fail only if <paramref name="expected"/>
        /// is different from <paramref name="actualValue"/> by more than <paramref name="delta"/>.</param>
        public static void IsEqualTo(this ActualValue<double> actualValue, double expected, double delta)
        {
            actualValue.IsEqualTo(expected, delta, null, null);
        }

        /// <summary>
        /// Verifies that two specified doubles are equal or within the specified accuracy of each other.
        /// Displays a message if the assertion fails.
        /// </summary>
        /// <param name="actualValue">The actual value.</param>
        /// <param name="expected">The expected value.</param>
        /// <param name="delta">The required accuracy. The assertion will fail only if <paramref name="expected"/>
        /// is different from <paramref name="actualValue"/> by more than <paramref name="delta"/>.</param>
        /// <param name="message">A message to display if the assertion fails. This message can
        /// be seen in the unit test results.</param>
        public static void IsEqualTo(this ActualValue<double> actualValue, double expected, double delta, string message)
        {
            actualValue.IsEqualTo(expected, delta, message, null);
        }

        /// <summary>
        /// Verifies that two specified doubles are equal or within the specified accuracy of each other.
        /// Displays a message if the assertion fails, and applies the specified formatting to it.
        /// </summary>
        /// <param name="actualValue">The actual value.</param>
        /// <param name="expected">The expected value.</param>
        /// <param name="delta">The required accuracy. The assertion will fail only if <paramref name="expected"/>
        /// is different from <paramref name="actualValue"/> by more than <paramref name="delta"/>.</param>
        /// <param name="message">A message to display if the assertion fails. This message can
        /// be seen in the unit test results.</param>
        /// <param name="parameters">An array of parameters to use when formatting <paramref name="message"/>.</param>
        public static void IsEqualTo(this ActualValue<double> actualValue, double expected, double delta, string message, params object[] parameters)
        {
            string formattedMessage;
            if (double.IsNaN(expected) || double.IsNaN(actualValue.Value) || double.IsNaN(delta))
            {
                formattedMessage = FrameworkMessages.IsEqualToDeltaFailMsg(
                        message == null
                            ? string.Empty
                            : Assertions.ReplaceNullChars(message),
                        expected.ToString(CultureInfo.CurrentCulture.NumberFormat),
                        actualValue.Value.ToString(CultureInfo.CurrentCulture.NumberFormat),
                        delta.ToString(CultureInfo.CurrentCulture.NumberFormat));
                Assertions.HandleFail("IsEqualTo", formattedMessage, parameters);
            }

            if (Math.Abs(expected - actualValue.Value) <= delta)
            {
                return;
            }

            var finalMessage = FrameworkMessages.IsEqualToDeltaFailMsg(
                Assertions.ReplaceNullChars(message) ?? string.Empty,
                expected.ToString(CultureInfo.CurrentCulture.NumberFormat),
                actualValue.Value.ToString(CultureInfo.CurrentCulture.NumberFormat),
                delta.ToString(CultureInfo.CurrentCulture.NumberFormat));
            Assertions.HandleFail("IsEqualTo", finalMessage, parameters);
        }

        /// <summary>
        /// Verifies that two specified singles are equal or within the specified accuracy of each other.
        /// </summary>
        /// <param name="actualValue">The actual value.</param>
        /// <param name="expected">The expected value.</param>
        /// <param name="delta">The required accuracy. The assertion will fail only if <paramref name="expected"/>
        /// is different from <paramref name="actualValue"/> by more than <paramref name="delta"/>.</param>
        public static void IsEqualTo(this ActualValue<float> actualValue, float expected, float delta)
        {
            actualValue.IsEqualTo(expected, delta, null, null);
        }

        /// <summary>
        /// Verifies that two specified singles are equal or within the specified accuracy of each other.
        /// Displays a message if the assertion fails.
        /// </summary>
        /// <param name="actualValue">The actual value.</param>
        /// <param name="expected">The expected value.</param>
        /// <param name="delta">The required accuracy. The assertion will fail only if <paramref name="expected"/>
        /// is different from <paramref name="actualValue"/> by more than <paramref name="delta"/>.</param>
        /// <param name="message">A message to display if the assertion fails. This message can
        /// be seen in the unit test results.</param>
        public static void IsEqualTo(this ActualValue<float> actualValue, float expected, float delta, string message)
        {
            actualValue.IsEqualTo(expected, delta, message, null);
        }

        /// <summary>
        /// Verifies that two specified singles are equal or within the specified accuracy of each other.
        /// Displays a message if the assertion fails, and applies the specified formatting to it.
        /// </summary>
        /// <param name="actualValue">The actual value.</param>
        /// <param name="expected">The expected value.</param>
        /// <param name="delta">The required accuracy. The assertion will fail only if <paramref name="expected"/>
        /// is different from <paramref name="actualValue"/> by more than <paramref name="delta"/>.</param>
        /// <param name="message">A message to display if the assertion fails. This message can
        /// be seen in the unit test results.</param>
        /// <param name="parameters">An array of parameters to use when formatting <paramref name="message"/>.</param>
        public static void IsEqualTo(this ActualValue<float> actualValue, float expected, float delta, string message, params object[] parameters)
        {
            if (float.IsNaN(expected) || float.IsNaN(actualValue.Value) || float.IsNaN(delta))
            {
                var finalMessage1 = FrameworkMessages.IsEqualToDeltaFailMsg(
                    Assertions.ReplaceNullChars(message) ?? string.Empty,
                    expected.ToString(CultureInfo.CurrentCulture.NumberFormat),
                    actualValue.Value.ToString(CultureInfo.CurrentCulture.NumberFormat),
                    delta.ToString(CultureInfo.CurrentCulture.NumberFormat));
                Assertions.HandleFail("IsEqualTo", finalMessage1, parameters);
            }

            if (Math.Abs(expected - actualValue.Value) <= delta)
            {
                return;
            }

            var finalMessage2 = FrameworkMessages.IsEqualToDeltaFailMsg(
                Assertions.ReplaceNullChars(message) ?? string.Empty,
                expected.ToString(CultureInfo.CurrentCulture.NumberFormat),
                actualValue.Value.ToString(CultureInfo.CurrentCulture.NumberFormat),
                delta.ToString(CultureInfo.CurrentCulture.NumberFormat));
            Assertions.HandleFail("IsEqualTo", finalMessage2, parameters);
        }

        /// <summary>
        /// Verifies that two specified objects are equal.
        /// </summary>
        /// <typeparam name="T">The actual value type.</typeparam>
        /// <param name="actualValue">The actual value.</param>
        /// <param name="expected">The expected value.</param>
        public static void IsEqualTo<T>(this ActualValue<T> actualValue, object expected)
        {
            actualValue.IsEqualTo(expected, null, null);
        }

        /// <summary>
        /// Verifies that two specified objects are equal. Displays a message if the assertion fails.
        /// </summary>
        /// <typeparam name="T">The actual value type.</typeparam>
        /// <param name="actualValue">The actual value.</param>
        /// <param name="expected">The expected value.</param>
        /// <param name="message">A message to display if the assertion fails. This message can
        /// be seen in the unit test results.</param>
        public static void IsEqualTo<T>(this ActualValue<T> actualValue, object expected, string message)
        {
            actualValue.IsEqualTo(expected, message, null);
        }

        /// <summary>
        /// Verifies that two specified objects are equal. Displays a message if the assertion fails,
        /// and applies the specified formatting to it.
        /// </summary>
        /// <typeparam name="T">The actual value type.</typeparam>
        /// <param name="actualValue">The actual value.</param>
        /// <param name="expected">The expected value.</param>
        /// <param name="message">A message to display if the assertion fails. This message can
        /// be seen in the unit test results.</param>
        /// <param name="parameters">An array of parameters to use when formatting <paramref name="message"/>.</param>
        public static void IsEqualTo<T>(this ActualValue<T> actualValue, object expected, string message, params object[] parameters)
        {
            if (object.Equals(expected, actualValue.Value))
            {
                return;
            }

            var finalMessage = (object)actualValue.Value == null || expected == null || actualValue.Value.GetType().Equals(expected.GetType())
                    ? FrameworkMessages.IsEqualToFailMsg(Assertions.ReplaceNullChars(message) ?? string.Empty, Assertions.ReplaceNulls(expected), Assertions.ReplaceNulls(actualValue.Value))
                    : FrameworkMessages.IsEqualToDifferentTypesFailMsg(Assertions.ReplaceNullChars(message) ?? string.Empty, Assertions.ReplaceNulls(expected), expected.GetType().FullName, Assertions.ReplaceNulls(actualValue.Value), actualValue.Value.GetType().FullName);
            Assertions.HandleFail("IsEqualTo", finalMessage, parameters);
        }

        /// <summary>
        /// Verifies that two specified objects are equal.
        /// </summary>
        /// <typeparam name="T">The actual value type.</typeparam>
        /// <param name="actualValue">The actual value.</param>
        /// <param name="expected">The expected value.</param>
        public static void IsEqualTo<T>(this ActualValue<T> actualValue, T expected)
        {
            actualValue.IsEqualTo(expected, null, null);
        }

        /// <summary>
        /// Verifies that two specified objects are equal. Displays a message if the assertion fails.
        /// </summary>
        /// <typeparam name="T">The actual value type.</typeparam>
        /// <param name="actualValue">The actual value.</param>
        /// <param name="expected">The expected value.</param>
        /// <param name="message">A message to display if the assertion fails. This message can
        /// be seen in the unit test results.</param>
        public static void IsEqualTo<T>(this ActualValue<T> actualValue, T expected, string message)
        {
            actualValue.IsEqualTo(expected, message, null);
        }

        /// <summary>
        /// Verifies that two specified objects are equal. Displays a message if the assertion fails,
        /// and applies the specified formatting to it.
        /// </summary>
        /// <typeparam name="T">The actual value type.</typeparam>
        /// <param name="actualValue">The actual value.</param>
        /// <param name="expected">The expected value.</param>
        /// <param name="message">A message to display if the assertion fails. This message can
        /// be seen in the unit test results.</param>
        /// <param name="parameters">An array of parameters to use when formatting <paramref name="message"/>.</param>
        public static void IsEqualTo<T>(this ActualValue<T> actualValue, T expected, string message, params object[] parameters)
        {
            if (object.Equals(expected, actualValue.Value))
            {
                return;
            }

            var finalMessage = (object)actualValue.Value == null || (object)expected == null || actualValue.Value.GetType().Equals(expected.GetType())
                    ? FrameworkMessages.IsEqualToFailMsg(Assertions.ReplaceNullChars(message) ?? string.Empty, Assertions.ReplaceNulls(expected), Assertions.ReplaceNulls(actualValue.Value))
                    : FrameworkMessages.IsEqualToDifferentTypesFailMsg(Assertions.ReplaceNullChars(message) ?? string.Empty, Assertions.ReplaceNulls(expected), expected.GetType().FullName, Assertions.ReplaceNulls(actualValue.Value), actualValue.Value.GetType().FullName);
            Assertions.HandleFail("IsEqualTo", finalMessage, parameters);
        }

        /// <summary>
        /// Asserts that the actual value is <see langword="false"/>.
        /// </summary>
        /// <param name="actualValue">The actual value.</param>
        public static void IsFalse(this ActualValue<bool> actualValue)
        {
            actualValue.IsFalse(null, null);
        }

        /// <summary>
        /// Asserts that the actual value is <see langword="false"/>. Displays a message if the assertion
        /// fails.
        /// </summary>
        /// <param name="actualValue">The actual value.</param>
        /// <param name="message">A message to display if the assertion fails. This message can
        /// be seen in the unit test results.</param>
        public static void IsFalse(this ActualValue<bool> actualValue, string message)
        {
            actualValue.IsFalse(message, null);
        }

        /// <summary>
        /// Asserts that the actual value is <see langword="false"/>. Displays a message if the assertion
        /// fails, and applies the specified formatting to it.
        /// </summary>
        /// <param name="actualValue">The actual value.</param>
        /// <param name="message">A message to display if the assertion fails. This message can
        /// be seen in the unit test results.</param>
        /// <param name="parameters">An array of parameters to use when formatting <paramref name="message"/>.</param>
        public static void IsFalse(this ActualValue<bool> actualValue, string message, params object[] parameters)
        {
            if (actualValue.Value)
            {
                Assertions.HandleFail("IsFalse", message, parameters);
            }
        }

        /// <summary>
        /// Verifies that the specified object is an instance of the specified type. Displays a message if the
        /// assertion fails, and applies the specified formatting to it.
        /// </summary>
        /// <typeparam name="T">The type of the actual value.</typeparam>
        /// <param name="actualValue">The actual value.</param>
        /// <param name="expectedType">The type expected to be found in the inheritance hierarchy of
        /// <paramref name="actualValue.Value"/>.</param>
        public static void IsInstanceOfType<T>(this ActualValue<T> actualValue, Type expectedType)
        {
            actualValue.IsInstanceOfType(expectedType, null, null);
        }

        /// <summary>
        /// Verifies that the specified object is an instance of the specified type. Displays a message if the
        /// assertion fails, and applies the specified formatting to it.
        /// </summary>
        /// <typeparam name="T">The type of the actual value.</typeparam>
        /// <param name="actualValue">The actual value.</param>
        /// <param name="expectedType">The type expected to be found in the inheritance hierarchy of
        /// <paramref name="actualValue.Value"/>.</param>
        /// <param name="message">A message to display if the assertion fails. This message can
        /// be seen in the unit test results.</param>
        public static void IsInstanceOfType<T>(this ActualValue<T> actualValue, Type expectedType, string message)
        {
            actualValue.IsInstanceOfType(expectedType, message, null);
        }

        /// <summary>
        /// Verifies that the specified object is an instance of the specified type. Displays a message if the
        /// assertion fails, and applies the specified formatting to it.
        /// </summary>
        /// <typeparam name="T">The type of the actual value.</typeparam>
        /// <param name="actualValue">The actual value.</param>
        /// <param name="expectedType">The type expected to be found in the inheritance hierarchy of
        /// <paramref name="actualValue.Value"/>.</param>
        /// <param name="message">A message to display if the assertion fails. This message can
        /// be seen in the unit test results.</param>
        /// <param name="parameters">An array of parameters to use when formatting <paramref name="message"/>.</param>
        public static void IsInstanceOfType<T>(this ActualValue<T> actualValue, Type expectedType, string message, params object[] parameters)
        {
            if (expectedType == null)
            {
                Assertions.HandleFail("IsInstanceOfType", message, parameters);
            }

            if (expectedType.IsInstanceOfType(actualValue.Value))
            {
                return;
            }

            var finalMessage = FrameworkMessages.IsInstanceOfTypeFailMsg(
                Assertions.ReplaceNullChars(message) ?? string.Empty,
                expectedType.ToString(),
                (object)actualValue.Value == null ? Resources.Common_NullInMessages : actualValue.Value.GetType().ToString());
            Assertions.HandleFail("IsInstanceOfType", finalMessage, parameters);
        }

        /// <summary>
        /// Verifies that two specified doubles are not equal or within the specified accuracy of each
        /// other.
        /// </summary>
        /// <param name="actualValue">The actual value.</param>
        /// <param name="expected">The expected value.</param>
        /// <param name="delta">The required accuracy. The assertion will fail only if <paramref name="expected"/>
        /// is different from <paramref name="actualValue"/> by more than <paramref name="delta"/>.</param>
        public static void IsNotEqualTo(this ActualValue<double> actualValue, double expected, double delta)
        {
            actualValue.IsNotEqualTo(expected, delta, null, null);
        }

        /// <summary>
        /// Verifies that two specified doubles are not equal or within the specified accuracy of each other.
        /// Displays a message if the assertion fails.
        /// </summary>
        /// <param name="actualValue">The actual value.</param>
        /// <param name="expected">The expected value.</param>
        /// <param name="delta">The required accuracy. The assertion will fail only if <paramref name="expected"/>
        /// is different from <paramref name="actualValue"/> by more than <paramref name="delta"/>.</param>
        /// <param name="message">A message to display if the assertion fails. This message can
        /// be seen in the unit test results.</param>
        public static void IsNotEqualTo(this ActualValue<double> actualValue, double expected, double delta, string message)
        {
            actualValue.IsNotEqualTo(expected, delta, message, null);
        }

        /// <summary>
        /// Verifies that two specified doubles are not equal or within the specified accuracy of each other.
        /// Displays a message if the assertion fails, and applies the specified formatting to it.
        /// </summary>
        /// <param name="actualValue">The actual value.</param>
        /// <param name="expected">The expected value.</param>
        /// <param name="delta">The required accuracy. The assertion will fail only if <paramref name="expected"/>
        /// is different from <paramref name="actualValue"/> by more than <paramref name="delta"/>.</param>
        /// <param name="message">A message to display if the assertion fails. This message can
        /// be seen in the unit test results.</param>
        /// <param name="parameters">An array of parameters to use when formatting <paramref name="message"/>.</param>
        public static void IsNotEqualTo(this ActualValue<double> actualValue, double expected, double delta, string message, params object[] parameters)
        {
            if (double.IsNaN(expected) || double.IsNaN(actualValue.Value) || double.IsNaN(delta))
            {
                var finalMessage1 = FrameworkMessages.IsNotEqualToDeltaFailMsg(
                    Assertions.ReplaceNullChars(message) ?? string.Empty,
                    expected.ToString(CultureInfo.CurrentCulture.NumberFormat),
                    actualValue.Value.ToString(CultureInfo.CurrentCulture.NumberFormat),
                    delta.ToString(CultureInfo.CurrentCulture.NumberFormat));
                Assertions.HandleFail("IsNotEqualTo", finalMessage1, parameters);
            }

            if (Math.Abs(expected - actualValue.Value) > delta)
            {
                return;
            }

            var finalMessage2 = FrameworkMessages.IsNotEqualToDeltaFailMsg(
                Assertions.ReplaceNullChars(message) ?? string.Empty,
                expected.ToString(CultureInfo.CurrentCulture.NumberFormat),
                actualValue.Value.ToString(CultureInfo.CurrentCulture.NumberFormat),
                delta.ToString(CultureInfo.CurrentCulture.NumberFormat));
            Assertions.HandleFail("IsNotEqualTo", finalMessage2, parameters);
        }

        /// <summary>
        /// Verifies that two specified singles are not equal or within the specified accuracy of each other.
        /// </summary>
        /// <param name="actualValue">The actual value.</param>
        /// <param name="expected">The expected value.</param>
        /// <param name="delta">The required accuracy. The assertion will fail only if <paramref name="expected"/>
        /// is different from <paramref name="actualValue"/> by more than <paramref name="delta"/>.</param>
        public static void IsNotEqualTo(this ActualValue<float> actualValue, float expected, float delta)
        {
            actualValue.IsNotEqualTo(expected, delta, null, null);
        }

        /// <summary>
        /// Verifies that two specified singles are not equal or within the specified accuracy of each other.
        /// Displays a message if the assertion fails.
        /// </summary>
        /// <param name="actualValue">The actual value.</param>
        /// <param name="expected">The expected value.</param>
        /// <param name="delta">The required accuracy. The assertion will fail only if <paramref name="expected"/>
        /// is different from <paramref name="actualValue"/> by more than <paramref name="delta"/>.</param>
        /// <param name="message">A message to display if the assertion fails. This message can
        /// be seen in the unit test results.</param>
        public static void IsNotEqualTo(this ActualValue<float> actualValue, float expected, float delta, string message)
        {
            actualValue.IsNotEqualTo(expected, delta, message, null);
        }

        /// <summary>
        /// Verifies that two specified singles are not equal or within the specified accuracy of each other.
        /// Displays a message if the assertion fails, and applies the specified formatting to it.
        /// </summary>
        /// <param name="actualValue">The actual value.</param>
        /// <param name="expected">The expected value.</param>
        /// <param name="delta">The required accuracy. The assertion will fail only if <paramref name="expected"/>
        /// is different from <paramref name="actualValue"/> by more than <paramref name="delta"/>.</param>
        /// <param name="message">A message to display if the assertion fails. This message can
        /// be seen in the unit test results.</param>
        /// <param name="parameters">An array of parameters to use when formatting <paramref name="message"/>.</param>
        public static void IsNotEqualTo(this ActualValue<float> actualValue, float expected, float delta, string message, params object[] parameters)
        {
            if (float.IsNaN(expected) || float.IsNaN(actualValue.Value) || float.IsNaN(delta))
            {
                var finalMessage1 = FrameworkMessages.IsNotEqualToDeltaFailMsg(
                    Assertions.ReplaceNullChars(message) ?? string.Empty,
                    expected.ToString(CultureInfo.CurrentCulture.NumberFormat),
                    actualValue.Value.ToString(CultureInfo.CurrentCulture.NumberFormat),
                    delta.ToString(CultureInfo.CurrentCulture.NumberFormat));
                Assertions.HandleFail("IsNotEqualTo", finalMessage1, parameters);
            }

            if (Math.Abs(expected - actualValue.Value) > delta)
            {
                return;
            }

            var finalMessage2 = FrameworkMessages.IsNotEqualToDeltaFailMsg(
                Assertions.ReplaceNullChars(message) ?? string.Empty,
                expected.ToString(CultureInfo.CurrentCulture.NumberFormat),
                actualValue.Value.ToString(CultureInfo.CurrentCulture.NumberFormat),
                delta.ToString(CultureInfo.CurrentCulture.NumberFormat));
            Assertions.HandleFail("IsNotEqualTo", finalMessage2, parameters);
        }

        /// <summary>
        /// Verifies that two specified objects are not equal.
        /// </summary>
        /// <typeparam name="T">The actual value type.</typeparam>
        /// <param name="actualValue">The actual value.</param>
        /// <param name="expected">The expected value.</param>
        public static void IsNotEqualTo<T>(this ActualValue<T> actualValue, object expected)
        {
            actualValue.IsNotEqualTo(expected, null, null);
        }

        /// <summary>
        /// Verifies that two specified objects are not equal. Displays a message if the assertion fails.
        /// </summary>
        /// <typeparam name="T">The actual value type.</typeparam>
        /// <param name="actualValue">The actual value.</param>
        /// <param name="expected">The expected value.</param>
        /// <param name="message">A message to display if the assertion fails. This message can
        /// be seen in the unit test results.</param>
        public static void IsNotEqualTo<T>(this ActualValue<T> actualValue, object expected, string message)
        {
            actualValue.IsNotEqualTo(expected, message, null);
        }

        /// <summary>
        /// Verifies that two specified objects are not equal. Displays a message if the assertion fails,
        /// and applies the specified formatting to it.
        /// </summary>
        /// <typeparam name="T">The actual value type.</typeparam>
        /// <param name="actualValue">The actual value.</param>
        /// <param name="expected">The expected value.</param>
        /// <param name="message">A message to display if the assertion fails. This message can
        /// be seen in the unit test results.</param>
        /// <param name="parameters">An array of parameters to use when formatting <paramref name="message"/>.</param>
        public static void IsNotEqualTo<T>(this ActualValue<T> actualValue, object expected, string message, params object[] parameters)
        {
            if (!object.Equals(expected, actualValue.Value))
            {
                return;
            }

            var finalMessage = FrameworkMessages.IsNotEqualToFailMsg(
                Assertions.ReplaceNullChars(message) ?? string.Empty,
                Assertions.ReplaceNulls(expected),
                Assertions.ReplaceNulls(actualValue.Value));
            Assertions.HandleFail("IsNotEqualTo", finalMessage, parameters);
        }

        /// <summary>
        /// Verifies that two specified objects are not equal.
        /// </summary>
        /// <typeparam name="T">The actual value type.</typeparam>
        /// <param name="actualValue">The actual value.</param>
        /// <param name="expected">The expected value.</param>
        public static void IsNotEqualTo<T>(this ActualValue<T> actualValue, T expected)
        {
            actualValue.IsNotEqualTo(expected, null, null);
        }

        /// <summary>
        /// Verifies that two specified objects are not equal.
        /// </summary>
        /// <typeparam name="T">The actual value type.</typeparam>
        /// <param name="actualValue">The actual value.</param>
        /// <param name="expected">The expected value.</param>
        /// <param name="message">A message to display if the assertion fails. This message can
        /// be seen in the unit test results.</param>
        public static void IsNotEqualTo<T>(this ActualValue<T> actualValue, T expected, string message)
        {
            actualValue.IsNotEqualTo(expected, message, null);
        }

        /// <summary>
        /// Verifies that two specified objects are not equal. Displays a message if the assertion fails,
        /// and applies the specified formatting to it.
        /// </summary>
        /// <typeparam name="T">The actual value type.</typeparam>
        /// <param name="actualValue">The actual value.</param>
        /// <param name="expected">The expected value.</param>
        /// <param name="message">A message to display if the assertion fails. This message can
        /// be seen in the unit test results.</param>
        /// <param name="parameters">An array of parameters to use when formatting <paramref name="message"/>.</param>
        public static void IsNotEqualTo<T>(this ActualValue<T> actualValue, T expected, string message, params object[] parameters)
        {
            if (!object.Equals(expected, actualValue.Value))
            {
                return;
            }

            var finalMessage = FrameworkMessages.IsNotEqualToFailMsg(
                Assertions.ReplaceNullChars(message) ?? string.Empty,
                Assertions.ReplaceNulls(expected),
                Assertions.ReplaceNulls(actualValue.Value));
            Assertions.HandleFail("IsNotEqualTo", finalMessage, parameters);
        }

        /// <summary>
        /// Verifies that the specified object is not an instance of the specified type. Displays a message if the
        /// assertion fails, and applies the specified formatting to it.
        /// </summary>
        /// <typeparam name="T">The type of the actual value.</typeparam>
        /// <param name="actualValue">The actual value.</param>
        /// <param name="expectedType">The type not expected to be found in the inheritance hierarchy of
        /// <paramref name="actualValue.Value"/>.</param>
        public static void IsNotInstanceOfType<T>(this ActualValue<T> actualValue, Type expectedType)
        {
            actualValue.IsNotInstanceOfType(expectedType, null, null);
        }

        /// <summary>
        /// Verifies that the specified object is not an instance of the specified type. Displays a message if the
        /// assertion fails, and applies the specified formatting to it.
        /// </summary>
        /// <typeparam name="T">The type of the actual value.</typeparam>
        /// <param name="actualValue">The actual value.</param>
        /// <param name="expectedType">The type not expected to be found in the inheritance hierarchy of
        /// <paramref name="actualValue.Value"/>.</param>
        /// <param name="message">A message to display if the assertion fails. This message can
        /// be seen in the unit test results.</param>
        public static void IsNotInstanceOfType<T>(this ActualValue<T> actualValue, Type expectedType, string message)
        {
            actualValue.IsNotInstanceOfType(expectedType, message, null);
        }

        /// <summary>
        /// Verifies that the specified object is not an instance of the specified type. Displays a message if the
        /// assertion fails, and applies the specified formatting to it.
        /// </summary>
        /// <typeparam name="T">The type of the actual value.</typeparam>
        /// <param name="actualValue">The actual value.</param>
        /// <param name="expectedType">The type not expected to be found in the inheritance hierarchy of
        /// <paramref name="actualValue.Value"/>.</param>
        /// <param name="message">A message to display if the assertion fails. This message can
        /// be seen in the unit test results.</param>
        /// <param name="parameters">An array of parameters to use when formatting <paramref name="message"/>.</param>
        public static void IsNotInstanceOfType<T>(this ActualValue<T> actualValue, Type expectedType, string message, params object[] parameters)
        {
            if (expectedType == null)
            {
                Assertions.HandleFail("IsNotInstanceOfType", message, parameters);
            }

            if (!expectedType.IsInstanceOfType(actualValue.Value))
            {
                return;
            }

            var finalMessage = FrameworkMessages.IsNotInstanceOfTypeFailMsg(
                Assertions.ReplaceNullChars(message) ?? string.Empty,
                expectedType.ToString(),
                (object)actualValue.Value == null ? Resources.Common_NullInMessages : actualValue.Value.GetType().ToString());
            Assertions.HandleFail("IsNotInstanceOfType", finalMessage, parameters);
        }

        /// <summary>
        /// Verifies that the specified object is not <see langword="null"/>. Displays a message if the
        /// assertion fails, and applies the specified formatting to it.
        /// </summary>
        /// <typeparam name="T">The type of the actual value.</typeparam>
        /// <param name="actualValue">The actual value.</param>
        public static void IsNotNull<T>(this ActualValue<T> actualValue)
            where T : class
        {
            actualValue.IsNotNull(null, null);
        }

        /// <summary>
        /// Verifies that the specified object is not <see langword="null"/>. Displays a message if the
        /// assertion fails, and applies the specified formatting to it.
        /// </summary>
        /// <typeparam name="T">The type of the actual value.</typeparam>
        /// <param name="actualValue">The actual value.</param>
        /// <param name="message">A message to display if the assertion fails. This message can
        /// be seen in the unit test results.</param>
        public static void IsNotNull<T>(this ActualValue<T> actualValue, string message)
            where T : class
        {
            actualValue.IsNotNull(message, null);
        }

        /// <summary>
        /// Verifies that the specified object is not <see langword="null"/>. Displays a message if the
        /// assertion fails, and applies the specified formatting to it.
        /// </summary>
        /// <typeparam name="T">The type of the actual value.</typeparam>
        /// <param name="actualValue">The actual value.</param>
        /// <param name="message">A message to display if the assertion fails. This message can
        /// be seen in the unit test results.</param>
        /// <param name="parameters">An array of parameters to use when formatting <paramref name="message"/>.</param>
        public static void IsNotNull<T>(this ActualValue<T> actualValue, string message, params object[] parameters)
            where T : class
        {
            if (actualValue.Value != null)
            {
                return;
            }

            Assertions.HandleFail("IsNotNull", message, parameters);
        }

        /// <summary>
        /// Verifies that two specified object variables refer to different objects. Displays a message if the
        /// assertion fails, and applies the specified formatting to it.
        /// </summary>
        /// <typeparam name="T">The type of the actual object.</typeparam>
        /// <param name="actualValue">The actual value.</param>
        /// <param name="expected">The expected value.</param>
        public static void IsNotSameAs<T>(this ActualValue<T> actualValue, T expected)
            where T : class
        {
            actualValue.IsNotSameAs(expected, null, null);
        }

        /// <summary>
        /// Verifies that two specified object variables refer to different objects. Displays a message if the
        /// assertion fails, and applies the specified formatting to it.
        /// </summary>
        /// <typeparam name="T">The type of the actual object.</typeparam>
        /// <param name="actualValue">The actual value.</param>
        /// <param name="expected">The expected value.</param>
        /// <param name="message">A message to display if the assertion fails. This message can
        /// be seen in the unit test results.</param>
        public static void IsNotSameAs<T>(this ActualValue<T> actualValue, T expected, string message)
            where T : class
        {
            actualValue.IsNotSameAs(expected, message, null);
        }

        /// <summary>
        /// Verifies that two specified object variables refer to different objects. Displays a message if the
        /// assertion fails, and applies the specified formatting to it.
        /// </summary>
        /// <typeparam name="T">The type of the actual object.</typeparam>
        /// <param name="actualValue">The actual value.</param>
        /// <param name="expected">The expected value.</param>
        /// <param name="message">A message to display if the assertion fails. This message can
        /// be seen in the unit test results.</param>
        /// <param name="parameters">An array of parameters to use when formatting <paramref name="message"/>.</param>
        public static void IsNotSameAs<T>(this ActualValue<T> actualValue, T expected, string message, params object[] parameters)
            where T : class
        {
            if (!object.ReferenceEquals(actualValue.Value, expected))
            {
                return;
            }

            Assertions.HandleFail("IsNotSameAs", message, parameters);
        }

        /// <summary>
        /// Verifies that the specified object is <see langword="null"/>. Displays a message if the
        /// assertion fails, and applies the specified formatting to it.
        /// </summary>
        /// <typeparam name="T">The type of the actual value.</typeparam>
        /// <param name="actualValue">The actual value.</param>
        public static void IsNull<T>(this ActualValue<T> actualValue)
            where T : class
        {
            actualValue.IsNull(null, null);
        }

        /// <summary>
        /// Verifies that the specified object is <see langword="null"/>. Displays a message if the
        /// assertion fails, and applies the specified formatting to it.
        /// </summary>
        /// <typeparam name="T">The type of the actual value.</typeparam>
        /// <param name="actualValue">The actual value.</param>
        /// <param name="message">A message to display if the assertion fails. This message can
        /// be seen in the unit test results.</param>
        public static void IsNull<T>(this ActualValue<T> actualValue, string message)
            where T : class
        {
            actualValue.IsNull(message, null);
        }

        /// <summary>
        /// Verifies that the specified object is <see langword="null"/>. Displays a message if the
        /// assertion fails, and applies the specified formatting to it.
        /// </summary>
        /// <typeparam name="T">The type of the actual value.</typeparam>
        /// <param name="actualValue">The actual value.</param>
        /// <param name="message">A message to display if the assertion fails. This message can
        /// be seen in the unit test results.</param>
        /// <param name="parameters">An array of parameters to use when formatting <paramref name="message"/>.</param>
        public static void IsNull<T>(this ActualValue<T> actualValue, string message, params object[] parameters)
            where T : class
        {
            if (actualValue.Value == null)
            {
                return;
            }

            Assertions.HandleFail("IsNull", message, parameters);
        }

        /// <summary>
        /// Verifies that two specified object variables refer to the same object.
        /// </summary>
        /// <typeparam name="T">The type of the actual object.</typeparam>
        /// <param name="actualValue">The actual value.</param>
        /// <param name="expected">The expected value.</param>
        public static void IsSameAs<T>(this ActualValue<T> actualValue, T expected)
            where T : class
        {
            actualValue.IsSameAs(expected, null, null);
        }

        /// <summary>
        /// Verifies that two specified object variables refer to the same object. Displays a message if the
        /// assertion fails.
        /// </summary>
        /// <typeparam name="T">The type of the actual object.</typeparam>
        /// <param name="actualValue">The actual value.</param>
        /// <param name="expected">The expected value.</param>
        /// <param name="message">A message to display if the assertion fails. This message can
        /// be seen in the unit test results.</param>
        public static void IsSameAs<T>(this ActualValue<T> actualValue, T expected, string message)
            where T : class
        {
            actualValue.IsSameAs(expected, message, null);
        }

        /// <summary>
        /// Verifies that two specified object variables refer to the same object. Displays a message if the
        /// assertion fails, and applies the specified formatting to it.
        /// </summary>
        /// <typeparam name="T">The type of the actual object.</typeparam>
        /// <param name="actualValue">The actual value.</param>
        /// <param name="expected">The expected value.</param>
        /// <param name="message">A message to display if the assertion fails. This message can
        /// be seen in the unit test results.</param>
        /// <param name="parameters">An array of parameters to use when formatting <paramref name="message"/>.</param>
        public static void IsSameAs<T>(this ActualValue<T> actualValue, T expected, string message, params object[] parameters)
            where T : class
        {
            if (object.ReferenceEquals(actualValue.Value, expected))
            {
                return;
            }

            Assertions.HandleFail("IsSameAs", message, parameters);
        }

        /// <summary>
        /// Asserts that the actual value is <see langword="true"/>.
        /// </summary>
        /// <param name="actualValue">The actual value.</param>
        public static void IsTrue(this ActualValue<bool> actualValue)
        {
            actualValue.IsTrue(null, null);
        }

        /// <summary>
        /// Asserts that the actual value is <see langword="true"/>. Displays a message if the assertion
        /// fails.
        /// </summary>
        /// <param name="actualValue">The actual value.</param>
        /// <param name="message">A message to display if the assertion fails. This message can
        /// be seen in the unit test results.</param>
        public static void IsTrue(this ActualValue<bool> actualValue, string message)
        {
            actualValue.IsTrue(message, null);
        }

        /// <summary>
        /// Asserts that the actual value is <see langword="true"/>. Displays a message if the assertion
        /// fails, and applies the specified formatting to it.
        /// </summary>
        /// <param name="actualValue">The actual value.</param>
        /// <param name="message">A message to display if the assertion fails. This message can
        /// be seen in the unit test results.</param>
        /// <param name="parameters">An array of parameters to use when formatting <paramref name="message"/>.</param>
        public static void IsTrue(this ActualValue<bool> actualValue, string message, params object[] parameters)
        {
            if (!actualValue.Value)
            {
                Assertions.HandleFail("IsTrue", message, parameters);
            }
        }
    }
}