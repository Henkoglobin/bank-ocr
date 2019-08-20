using System.Collections.Generic;
using System.Linq;
using BankOCR.Abstractions;
using BankOCR.Extensions;

namespace BankOCR {
    public class BankOcrScanner : IBankOcrScanner {
        private readonly IDigitSeparator digitSeparator;
        private readonly IDigitScanner digitScanner;

        public BankOcrScanner(IDigitSeparator digitSeparator, IDigitScanner digitScanner) {
            this.digitSeparator = digitSeparator;
            this.digitScanner = digitScanner;
        }

        /// <inheritdoc />
        public List<string> Scan(string input)
            => digitSeparator.GetDigitsByLine(input)
                // Transform each line by...
                .Select(
                    line => {
                        // Parsing every 3x3 chunk into digits
                        var digitsInLine = line.Select(digit => digitScanner.Parse(digit)).ToList();

                        // If all digits are valid, concatenate them into a string, otherwise => null
                        return digitsInLine.All(digit => digit != null) 
                            ? digitsInLine.Cast<char>().JoinToString() 
                            : null;
                    })
                .ToList();
    }
}
