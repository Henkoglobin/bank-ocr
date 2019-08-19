using System.Collections.Generic;

namespace BankOCR.Abstractions {
    public interface IBankOcrScanner {
        /// <summary>
        /// Scans a string in 3x3 cluster format, returning the contained numbers line-by-line.
        /// </summary>
        /// <param name="input">
        /// The input string, comprised of 3x3 clusters.
        /// Each cluster is interpreted as a single digit,
        /// while each line of clusters is interpreted as a single number.
        /// </param>
        /// <returns>A list of interpreted numbers, each as a string to keep leading zeroes.</returns>
        List<string> Scan(string input);
    }
}
