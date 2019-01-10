using System;
using System.Collections.Generic;
using System.Linq;

namespace Strate.Demo.Common
{
    /// <summary>
    ///     Provides a set of common validation methods.
    /// </summary>
    public static class ValidationExtensions
    {
        /// <summary>
        ///     Ensures that the provided string value is not null, empty, or whitespace.
        /// </summary>
        /// <param name="value">The value to validate.</param>
        /// <param name="parameterName">The parameter name to use in the resulting exception if validation fails.</param>
        public static void ShouldNotBeNullEmptyOrWhiteSpace(this string value, string parameterName)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(FormattableString.Invariant($"The parameter {parameterName} cannot be null, empty or whitespace."));
            }
        }

        /// <summary>
        ///     Ensures that the provided object is not null.
        /// </summary>
        /// <typeparam name="T">The type of the provided object.</typeparam>
        /// <param name="value">The value to validate.</param>
        /// <param name="parameterName">The parameter name to use in the resulting exception if validation fails.</param>
        public static void ShouldNotBeNull<T>(this T value, string parameterName)
        {
            if (value == null)
            {
                throw new ArgumentException(FormattableString.Invariant($"The parameter {parameterName} cannot be null."));
            }
        }

        /// <summary>
        ///     Ensures that the provide enumeration is not null or empty.
        /// </summary>
        /// <typeparam name="T">The type of the provided object.</typeparam>
        /// <param name="value">The value to validate.</param>
        /// <param name="parameterName">The parameter name to use in the resulting exception if validation fails.</param>
        public static void ShouldNotBeNullOrEmpty<T>(this IEnumerable<T> values, string parameterName)
        {
            if (values == null || !values.Any())
            {
                throw new ArgumentException(FormattableString.Invariant($"The parameter {parameterName} cannot be null or empty."));
            }
        }
    }
}
