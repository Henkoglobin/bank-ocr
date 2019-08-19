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
                    line => line
                        // ... parsing every digit of the line...
                        .Select(digit => digitScanner.Parse(digit))
                        // ... and then collecting all digits of a line into a string
                        .JoinToString()
                )
                .ToList();
    }
}
