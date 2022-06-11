using BrazilianDocuments.Extensions;
using System;
using System.Linq;

namespace BrazilianDocuments.CPF
{
    /// <summary>
    /// CPF number validator.
    /// </summary>
    public static class CpfValidator
    {
        /// <summary>
        /// Checks whether a CPF number is valid.
        /// </summary>
        /// <param name="number">Document number.</param>
        /// <returns>true when the number is valid, false otherwise.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="number"/> is null or whitespace.</exception>
        public static bool IsValid(string number)
        {
            if (string.IsNullOrWhiteSpace(number))
                throw new ArgumentNullException(nameof(number));

            if (IsRepeatedDigitCpf(number))
                return false;

            var numberArray = number.ToByteArray();

            int firstVerificationDigit = CpfCalculator.GetFirstVerificationDigit(numberArray.Take(numberArray.Length - 2).ToArray());
            int secondVerificationDigit = CpfCalculator.GetSecondVerificationDigit(numberArray.Take(numberArray.Length - 2).ToArray());

            var firstDigitIsCorrect = firstVerificationDigit == numberArray[numberArray.Length - 2];
            var secondDigitIsCorrect = secondVerificationDigit == numberArray[numberArray.Length - 1];

            return firstDigitIsCorrect && secondDigitIsCorrect;
        }

        /// <summary>
        /// Checks whether a CPF number is composed of only
        /// the same digit repeated.
        /// </summary>
        /// <param name="number">Document number.</param>
        /// <returns>true when <paramref name="number"/> is composed of only repeated digits, false otherwise.</returns>
        private static bool IsRepeatedDigitCpf(string number) =>
            number.All(x => x == '0') ||
            number.All(x => x == '1') ||
            number.All(x => x == '2') ||
            number.All(x => x == '3') ||
            number.All(x => x == '4') ||
            number.All(x => x == '5') ||
            number.All(x => x == '6') ||
            number.All(x => x == '7') ||
            number.All(x => x == '8') ||
            number.All(x => x == '9');
    }
}
