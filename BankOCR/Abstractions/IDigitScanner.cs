namespace BankOCR.Abstractions {
    public interface IDigitScanner {
        /// <summary>
        /// Parses a single 3x3 cluster (flattened into a 9-character-string) into a single digit.
        /// </summary>
        /// <param name="input">A string of exactly nine characters.</param>
        /// <returns>The single digit that is represented by the 9-character flattened input cluster.</returns>
        char Parse(string input);
    }
}
