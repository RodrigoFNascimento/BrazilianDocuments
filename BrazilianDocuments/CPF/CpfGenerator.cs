using BrazilianDocuments.Extensions;
using System;
using System.Linq;

namespace BrazilianDocuments.CPF
{
    /// <summary>
    /// CPF number generator.
    /// </summary>
    public static class CpfGenerator
    {
        /// <summary>
        /// Default CPF number length established by the government.
        /// </summary>
        private const byte CpfLength = 11;
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
        /// Randomly generates a CPF number.
        /// </summary>
        /// <returns>Random CPF number.</returns>
        public static string Generate(bool withSymbols = false)
        {
            byte[] number = new byte[CpfLength];

            var random = new Random();

            for (int i = 0; i < CpfLength - 2; i++)
                number[i] = (byte)random.Next(9);

            number[CpfLength - 2] = CpfCalculator.GetFirstVerificationDigit(number.Take(number.Length - 2).ToArray());
            number[CpfLength - 1] = CpfCalculator.GetSecondVerificationDigit(number.Take(number.Length - 2).ToArray());

            var cpf = string.Join("", number);

            if (withSymbols)
                cpf = cpf.FormatString(DefaultPattern, DefaultReplacement);

            return cpf;
        }

        /// <summary>
        /// Randomly generates a CPF number in a custom format.
        /// </summary>
        /// <param name="pattern">Pattern used to format the document number</param>
        /// <param name="replacement">Replacement used to format the document number</param>
        /// <returns>Random CPF number in specified format.</returns>
        public static string GenerateInCustomFormat(string pattern, string replacement) =>
            Generate().FormatString(pattern, replacement);
    }
}
