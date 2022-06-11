using BrazilianDocuments.CPF;
using System;
using Xunit;

namespace BrazilianDocuments.Tests.Unit.CPF;

public class CpfCalculatorTests
{
    [Theory]
    [InlineData(new byte[] { 0, 4, 5, 5, 1, 5, 3, 8, 5 }, 0)]
    [InlineData(new byte[] { 8, 7, 0, 3, 7, 6, 3, 4, 0 }, 4)]
    [InlineData(new byte[] { 8, 3, 5, 4, 0, 4, 0, 6, 0 }, 7)]
    [InlineData(new byte[] { 6, 1, 3, 1, 3, 4, 8, 7, 0 }, 7)]
    [InlineData(new byte[] { 1, 1, 1, 4, 4, 4, 7, 7, 7 }, 3)]
    public void GetFirstVerificationDigit_ShouldCalculateFirstVerificationDigit_WhenGivenACpf(byte[] a, byte expected)
    {
        // Arrange

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

    [Theory]
    [InlineData(new byte[] { 0, 4, 5, 5, 1, 5, 3, 8, 5, 0 }, 7)]
    [InlineData(new byte[] { 8, 7, 0, 3, 7, 6, 3, 4, 0, 4 }, 2)]
    [InlineData(new byte[] { 8, 3, 5, 4, 0, 4, 0, 6, 0, 7 }, 7)]
    [InlineData(new byte[] { 6, 1, 3, 1, 3, 4, 8, 7, 0, 7 }, 4)]
    [InlineData(new byte[] { 1, 1, 1, 4, 4, 4, 7, 7, 7, 3 }, 5)]
    public void GetSecondVerificationDigit_ShouldCalculateSecondVerificationDigit_WhenGivenACpf(byte[] a, byte expected)
    {
        // Arrange

        // Act
        var digit = CpfCalculator.GetSecondVerificationDigit(a);

        // Assert
        Assert.Equal(expected, digit);
    }
}