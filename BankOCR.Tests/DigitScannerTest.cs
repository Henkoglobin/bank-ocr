using BankOCR.Abstractions;
using FluentAssertions;
using Xunit;

namespace BankOCR.Tests {
    public class OcrScannerTest {
        private readonly IDigitScanner scanner = new DigitScanner();

        [Theory]
        [InlineData(" _ I II_I", '0')]
        [InlineData("     I  I", '1')]
        [InlineData(" _  _II_ ", '2')]
        [InlineData(" _  _I _I", '3')]
        [InlineData("   I_I  I", '4')]
        [InlineData(" _ I_  _I", '5')]
        [InlineData(" _ I_ I_I", '6')]
        [InlineData(" _   I  I", '7')]
        [InlineData(" _ I_II_I", '8')]
        [InlineData(" _ I_I _I", '9')]
        public void Parse_ScansDigitCorrectly(string value, char expected)
            => scanner.Parse(value).Should().Be(expected);

        [Theory]
        [InlineData("         ")]
        [InlineData("_________")]
        [InlineData("     O  O")]
        public void Parse_HandlesInvalidDigitsGracefully(string value)
            => scanner.Parse(value).Should().BeNull();
    }
}
