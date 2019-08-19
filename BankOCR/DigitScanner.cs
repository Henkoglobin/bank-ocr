using System.Collections.Generic;
using BankOCR.Abstractions;

namespace BankOCR {
    public class DigitScanner : IDigitScanner {
        /// <summary>
        /// Look-up Table of recognized characters (i.e. digits).
        /// </summary>
        private readonly IReadOnlyDictionary<string, char> patterns = new Dictionary<string, char> {
            [
                " _ " +
                "I I" +
                "I_I"
            ] = '0',
            [
                "   " +
                "  I" +
                "  I"
            ] = '1',
            [
                " _ " +
                " _I" +
                "I_ "
            ] = '2',
            [
                " _ " +
                " _I" +
                " _I"
            ] = '3',
            [
                "   " +
                "I_I" +
                "  I"
            ] = '4',
            [
                " _ " +
                "I_ " +
                " _I"
            ] = '5',
            [
                " _ " +
                "I_ " +
                "I_I"
            ] = '6',
            [
                " _ " +
                "  I" +
                "  I"
            ] = '7',
            [
                " _ " +
                "I_I" +
                "I_I"
            ] = '8',
            [
                " _ " +
                "I_I" +
                " _I"
            ] = '9'
        };

        /// <inheritdoc />
        public char Parse(string input)
            => patterns[input];
    }
}
