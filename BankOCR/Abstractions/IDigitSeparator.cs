using System.Collections.Generic;

namespace BankOCR.Abstractions {
    public interface IDigitSeparator {
        /// <summary>
        /// Separates a string into a number of lines of 3x3 clusters. Each cluster is flattened into
        /// a string with exactly nine characters without any line breaks.
        /// </summary>
        /// <param name="input">The input string to separate.</param>
        /// <returns>
        /// An enumeration of lines, each of which is an enumeration of 9-character flattend clusters.
        /// </returns>
        IEnumerable<IEnumerable<string>> GetDigitsByLine(string input);
    }
}
