using BrazilianDocuments.CPF;
using System;
using Xunit;

namespace BrazilianDocuments.Tests.Unit.CPF;

public class CpfCalculatorTests
{
    [Fact]
    public void GetFirstVerificationDigit_ShouldCalculateFirstVerificationDigit_WhenGivenACpf()
    {
        // Arrange
        var a = new byte[] { 8, 7, 0, 3, 7, 6, 3, 4, 0 };
        byte expected = 4;

        // Act
        var digit = CpfCalculator.GetFirstVerificationDigit(a);

        // Assert
        Assert.Equal(expected, digit);
    }

    [Fact]
    public void GetFirstVerificationDigit_ShouldThrowArgumentException_WhenGivenAnEmptyCpf()
    {
        // Arrange

        // Act

        // Assert
        Assert.Throws<ArgumentException>(() => CpfCalculator.GetFirstVerificationDigit(Array.Empty<byte>()));
    }

    [Fact]
    public void GetSecondVerificationDigit_ShouldCalculateSecondVerificationDigit_WhenGivenACpf()
    {
        // Arrange
        var a = new byte[] { 8, 7, 0, 3, 7, 6, 3, 4, 0, 4 };
        byte expected = 2;

        // Act
        var digit = CpfCalculator.GetSecondVerificationDigit(a);

        // Assert
        Assert.Equal(expected, digit);
    }
}