using System;

namespace BrazilianDocuments.CPF
{
    /// <summary>
    /// Verification digits calculator.
    /// </summary>
    public static class CpfCalculator
    {
        /// <summary>
        /// Calculates the first digit used to validate the document number.
        /// </summary>
        /// <param name="documentNumber">Document number.</param>
        /// <returns>First verification digit.</returns>
        /// <exception cref="ArgumentException">Thrown when the document number length is invalid.</exception>
        public static byte GetFirstVerificationDigit(byte[] documentNumber)
        {
            if (documentNumber.Length == 0)
                throw new ArgumentException("O tamanho do CPF não pode ser 0.", nameof(documentNumber));

            byte multiplier = 10;
            int sum = 0;
            byte moduleValue = 11;

            for (int i = 0; i < documentNumber.Length; i++)
            {
                if (documentNumber[i] > 9)
                    throw new ArgumentException($"Dígito inválido: {documentNumber[i]}.", nameof(documentNumber));

                sum += multiplier * documentNumber[i];
                multiplier--;
            }

            var remainder = sum % moduleValue;

            if (remainder < 2)
                return 0;

            return (byte)(moduleValue - remainder);
        }

        /// <summary>
        /// Calculates the second digit used to validate the document number.
        /// </summary>
        /// <param name="documentNumber">Document number.</param>
        /// <returns>Second verification digit.</returns>
        /// <exception cref="ArgumentException">Thrown when the document number length is invalid.</exception>
        public static byte GetSecondVerificationDigit(byte[] documentNumber)
        {
            if (documentNumber.Length == 0)
                throw new ArgumentException("O tamanho do CPF não pode ser 0.", nameof(documentNumber));

            byte multiplier = 11;
            int sum = 0;
            byte moduleValue = 11;

            for (int i = 0; i < documentNumber.Length; i++)
            {
                if (documentNumber[i] > 9)
                    throw new ArgumentException($"Dígito inválido: {documentNumber[i]}.", nameof(documentNumber));

                sum += multiplier * documentNumber[i];
                multiplier--;
            }

            var remainder = sum % moduleValue;

            if (remainder < 2)
                return 0;

            return (byte)(moduleValue - remainder);
        }
    }
}
