using System.Collections.Generic;
using BankOCR.Abstractions;

namespace BankOCR {
    public class DigitSeparator : IDigitSeparator {
        /// <inheritdoc />
        public IEnumerable<IEnumerable<string>> GetDigitsByLine(string input) {
            var lines = input.Split('\n');
            for (var y = 0; y < lines.Length; y += 4) {
                yield return GetDigits(lines, y);
            }
        }

        /// <summary>
        /// Returns 9-character flattened clusters from a single 'line'.
        /// </summary>
        /// <param name="lines">The input array of lines.</param>
        /// <param name="y">
        /// The y-coordinate to start scanning from.
        /// Must always be a multiple of 4.
        /// </param>
        /// <returns>
        /// An enumeration of flattened clusters read from the line specified
        /// by <paramref name="y"/> and the two following lines.
        /// </returns>
        private IEnumerable<string> GetDigits(string[] lines, int y) {
            for (var x = 0; x < lines[y].Length; x += 4) {
                yield return lines[y + 0].Substring(x, 3)
                    + lines[y + 1].Substring(x, 3)
                    + lines[y + 2].Substring(x, 3);
            }
        }
    }
}
