using System.Linq;
using BankOCR.Abstractions;
using FluentAssertions;
using Xunit;

namespace BankOCR.Tests {
    public class DigitSeparatorTest {
        private readonly IDigitSeparator separator = new DigitSeparator();

        [Fact]
        public void GetDigits_ReturnsSingleDigit() {
            var lines = separator.GetDigitsByLine(
                " _ " + "\n" +
                "I I" + "\n" +
                "I_I"
            ).ToList();

            lines.Should().HaveCount(1, "there's only a single line of digits in the string");

            var digits = lines[0].ToList();
            digits.Should().HaveCount(1, "There's only a single 3x3 cluster");
            digits.Single().Should().Be(" _ I II_I");
        }

        [Fact]
        public void GetDigits_ReturnsTwoSeparateDigits() {
            var lines = separator.GetDigitsByLine(
                " _     " + "\n" +
                "I I   I" + "\n" +
                "I_I   I"
            ).ToList();

            lines.Should().HaveCount(1, "there's only a single line of digits in the string");

            var digits = lines[0].ToList();
            digits.Should().HaveCount(2);
            digits[0].Should().Be(" _ I II_I");
            digits[1].Should().Be("     I  I");
        }

        [Fact]
        public void GetDigits_SeparatesByLines() {
            var lines = separator.GetDigitsByLine(
                " _ " + "\n" +
                "I I" + "\n" +
                "I_I" + "\n" +
                "\n" +
                "   " + "\n" +
                "  I" + "\n" +
                "  I"
            ).ToList();

            lines.Should().HaveCount(2, "empty lines delimit numbers");

            lines[0].Single().Should().Be(" _ I II_I");
            lines[1].Single().Should().Be("     I  I");
        }

        [Theory]
        [InlineData(
            " _     " + "\n" +
            "I I   I" + "\n" +
            "I_I   I" + "\n" +
            "\n" +
            " _ " + "\n" +
            " _I" + "\n" +
            "I_ ",
            2, 1
        )]
        [InlineData(
            " _ " + "\n" +
            " _I" + "\n" +
            "I_ " + "\n" +
            "\n" +
            " _     " + "\n" +
            "I I   I" + "\n" +
            "I_I   I",
            1, 2
        )]
        public void GetDigits_SupportsNumbersOfDifferentLength(
            string input,
            int expectedDigitsFirstLine,
            int expectedDigitsSecondLine
        ) {
            var lines = separator.GetDigitsByLine(input).ToList();

            lines[0].Should().HaveCount(expectedDigitsFirstLine);
            lines[1].Should().HaveCount(expectedDigitsSecondLine);
        }
    }
}
