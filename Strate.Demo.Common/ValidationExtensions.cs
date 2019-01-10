using System;
using System.Collections.Generic;
using System.Linq;

namespace Strate.Demo.Common
{
    public static class ValidationExtensions
    {
        public static void ShouldNotBeNullEmptyOrWhiteSpace(this string value, string parameterName)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(FormattableString.Invariant($"The parameter {parameterName} cannot be null, empty or whitespace."));
            }
        }

        public static void ShouldNotBeNull<T>(this T value, string parameterName)
        {
            if (value == null)
            {
                throw new ArgumentException(FormattableString.Invariant($"The parameter {parameterName} cannot be null."));
            }
        }

        public static void ShouldNotBeNullOrEmpty<T>(this IEnumerable<T> values, string parameterName)
        {
            if (values == null || !values.Any())
            {
                throw new ArgumentException(FormattableString.Invariant($"The parameter {parameterName} cannot be null or empty."));
            }
        }
    }
}
