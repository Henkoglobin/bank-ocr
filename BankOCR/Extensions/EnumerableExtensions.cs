using System;
using System.Collections.Generic;

namespace BankOCR.Extensions {
    public static class EnumerableExtensions {
        /// <summary>
        /// Convenience method to invoke <c>String.Join()</c> on an <see cref="IEnumerable{T}"/>
        /// of <see cref="Char"/>.
        /// </summary>
        /// <param name="source">The characters to join into a string.</param>
        /// <param name="separator">Optional separator to put between characters.</param>
        /// <returns>
        /// All characters from <paramref name="source"/>, separated by <paramref name="separator"/>.
        /// </returns>
        public static string JoinToString(this IEnumerable<char> source, string separator = null)
            => String.Join(separator ?? "", source);
    }
}
