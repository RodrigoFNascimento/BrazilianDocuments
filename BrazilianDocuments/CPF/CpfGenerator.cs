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
        /// Randomly generates a CPF number.
        /// </summary>
        /// <returns>Random CPF number.</returns>
        public static string Generate()
        {
            byte[] cpf = new byte[CpfLength];

            var random = new Random();

            for (int i = 0; i < CpfLength - 2; i++)
                cpf[i] = (byte)random.Next(9);

            cpf[CpfLength - 2] = CpfCalculator.GetFirstVerificationDigit(cpf.Take(cpf.Length - 2).ToArray());
            cpf[CpfLength - 1] = CpfCalculator.GetSecondVerificationDigit(cpf.Take(cpf.Length - 2).ToArray());

            return string.Join("", cpf);
        }
    }
}
