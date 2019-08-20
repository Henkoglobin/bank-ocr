using BankOCR.Abstractions;
using FluentAssertions;
using Xunit;

namespace BankOCR.IntegrationTests {
    public class BankOcrIntegrationTest {
        private readonly IBankOcrScanner scanner = new BankOcrScanner(
            new DigitSeparator(),
            new DigitScanner()
        );

        [Fact]
        public void SeparatorAndScannerWorkOnSingleLine() {
            var lines = scanner.Scan(
                " _       _   _     " + "\n" +
                "I I   I  _I  _I I_I" + "\n" +
                "I_I   I I_   _I   I"
            );

            lines.Should().HaveCount(1);
            lines[0].Should().Be("01234");
        }

        [Fact]
        public void ScannerReturnsNullOnInvalidData() {
            var lines = scanner.Scan(
                " _       _   _     " + "\n" +
                "I I   X  _I  _I I_I" + "\n" +
                "I_I   I I_   _I   I"
            );

            lines.Should().HaveCount(1);
            lines[0].Should().BeNull();
        }
    }
}
