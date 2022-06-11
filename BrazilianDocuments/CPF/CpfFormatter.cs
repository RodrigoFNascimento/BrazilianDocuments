using BrazilianDocuments.Extensions;
using System;
using System.Text;

namespace BrazilianDocuments.CPF
{
    /// <summary>
    /// CPF Formatter.
    /// </summary>
    public static class CpfFormatter
    {
        /// <summary>
        /// Default character used to mask the document number's digits.
        /// </summary>
        private const char DefaultMaskChar = 'X';
        /// <summary>
        /// Default character used to pad the document number when it's length is shorter than expected.
        /// </summary>
        private const char DefaultPadCharacter = '0';
        /// <summary>
        /// Default pattern used to format the document number
        /// according to the official format established by the government.
        /// </summary>
        private const string DefaultPattern = "^([0-9]{3})([0-9]{3})([0-9]{3})([0-9]{2})$";
        /// <summary>
        /// Default replacement used to format the document number
        /// according to the official format established by the government.
        /// </summary>
        private const string DefaultReplacement = "$1.$2.$3-$4";
        /// <summary>
        /// Default document number length established by the government.
        /// </summary>
        private const int DocumentNumberLength = 11;

        /// <summary>
        /// Formats a document number using a custom format.
        /// </summary>
        /// <param name="number">Document number.</param>
        /// <param name="pattern">Pattern.</param>
        /// <param name="replacement">Replacement.</param>
        /// <returns>Formatted number.</returns>
        public static string GetInCustomFormat(string number, string pattern, string replacement) =>
            GetInCustomFormat(number, pattern, replacement, DefaultPadCharacter);

        /// <summary>
        /// Formats a document number using a custom format.
        /// </summary>
        /// <param name="number">Document number.</param>
        /// <param name="pattern">Pattern.</param>
        /// <param name="replacement">Replacement.</param>
        /// <param name="padCharacter">Character used to left pad the document number to default length before formatting.</param>
        /// <returns>Formatted number.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the document number is null or whitespace.</exception>
        /// <exception cref="ArgumentException">Thrown when the document number is longer than the default.</exception>
        public static string GetInCustomFormat(string number, string pattern, string replacement, char padCharacter)
        {
            if (string.IsNullOrWhiteSpace(number))
                throw new ArgumentNullException(nameof(number));

            if (number.Length > DocumentNumberLength)
                throw new ArgumentException($"Number can't be longer than {DocumentNumberLength} digits", nameof(number));

            number = number.Trim().PadLeft(DocumentNumberLength, padCharacter);

            return number.FormatString(pattern, replacement);
        }

        /// <summary>
        /// Masks a document number.
        /// </summary>
        /// <param name="number">Document number.</param>
        /// <param name="numberOfCharacters">Number of characters the should be masked.</param>
        /// <returns>Masked document number.</returns>
        public static string GetMasked(string number, int numberOfCharacters) =>
            GetMasked(number, numberOfCharacters, 0, DefaultMaskChar);

        /// <summary>
        /// Masks a document number.
        /// </summary>
        /// <param name="number">Document number.</param>
        /// <param name="numberOfCharacters">Number of characters the should be masked.</param>
        /// <param name="offSet">Number of digits from the left that should not be masked.</param>
        /// <returns>Masked document number.</returns>
        public static string GetMasked(string number, int numberOfCharacters, int offSet) =>
            GetMasked(number, numberOfCharacters, offSet, DefaultMaskChar);

        /// <summary>
        /// Masks a document number.
        /// </summary>
        /// <param name="number">Document number.</param>
        /// <param name="numberOfCharacters">Number of characters the should be masked.</param>
        /// <param name="offSet">Number of digits from the left that should not be masked.</param>
        /// <param name="maskCharacter">Character used to mask the digits.</param>
        /// <returns>Masked document number.</returns>
        public static string GetMasked(string number, int numberOfCharacters, int offSet, char maskCharacter) =>
            GetMasked(number, numberOfCharacters, offSet, maskCharacter, DefaultPadCharacter);
        
        /// <summary>
        /// Masks a document number.
        /// </summary>
        /// <param name="number">Document number.</param>
        /// <param name="numberOfCharacters">Number of characters the should be masked.</param>
        /// <param name="offSet">Number of digits from the left that should not be masked.</param>
        /// <param name="maskCharacter">Character used to mask the digits.</param>
        /// <param name="padCharacter">Character used to left pad the document number before applying the mask.</param>
        /// <returns>Masked document number.</returns>
        public static string GetMasked(string number, int numberOfCharacters, int offSet, char maskCharacter, char padCharacter)
        {
            if (string.IsNullOrWhiteSpace(number))
                throw new ArgumentNullException(nameof(number));
            if (numberOfCharacters > number.Length)
                throw new ArgumentOutOfRangeException(nameof(numberOfCharacters));
            if (offSet + numberOfCharacters > number.Length)
                throw new ArgumentOutOfRangeException(nameof(offSet));

            number = number.PadLeft(DocumentNumberLength, padCharacter);

            var maskedNumber = new StringBuilder();
            maskedNumber.Append(number.Substring(0, offSet));

            for (int i = 0; i < numberOfCharacters; i++)
                maskedNumber.Append(maskCharacter);

            maskedNumber.Append(number.Substring(offSet + numberOfCharacters));
            return maskedNumber.ToString();
        }

        /// <summary>
        /// Applies the format established by the government
        /// to the document number.
        /// </summary>
        /// <param name="number">Document number.</param>
        /// <returns>Formatted document number.</returns>
        public static string GetWithSymbols(string number) =>
            GetInCustomFormat(number, DefaultPattern, DefaultReplacement);
    }
}
