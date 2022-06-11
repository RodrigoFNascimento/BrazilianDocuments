using BrazilianDocuments.Extensions;
using System;
using Xunit;

namespace BrazilianDocuments.Tests.Unit.Extensions;

public class StringExtensionsTests
{
    [Theory]
    [InlineData("1", true)]
    [InlineData("", false)]
    [InlineData("r", false)]
    [InlineData("r2d2", false)]
    [InlineData("#1", false)]
    public void IsANumber_ShouldCheckWhetherStringIsNumber_WhenGivenString(
        string s,
        bool expected)
    {
        // Arrange

        // Act
        var result = s.IsANumber();

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("08", "^([0-9]{2})$", "", "")]
    [InlineData("08", "^([0-9]{2})$", "${1}00", "0800")]
    [InlineData("11122233344", "^([0-9]{3})([0-9]{3})([0-9]{3})([0-9]{2})$", "$1$2${3}0000$4", "111222333000044")]
    [InlineData("00000000000", "^([0-9]{3})([0-9]{3})([0-9]{3})([0-9]{2})$", "$1.$2.$3-$4", "000.000.000-00")]
    public void FormatString_ShouldReturnFormattedString_GivenPatternAndReplacement(
        string str,
        string pattern,
        string replacement,
        string expected)
    {
        var result = str.FormatString(pattern, replacement);

        Assert.Equal(expected, result);
    }

    [Fact]
    public void FormatString_ShouldReturnEmptyString_GivenEmptyString()
    {
        string s = "";
        string pattern = "^([0-9]{2})$";
        string replacement = "${1}00";

        var result = s.FormatString(pattern, replacement);

        Assert.Equal(s, result);
    }

    [Fact]
    public void FormatString_ShouldReturnString_GivenEmptyPattern()
    {
        string s = "5";
        string pattern = "";
        string replacement = "${1}00";

        var result = s.FormatString(pattern, replacement);

        Assert.Equal(s, result);
    }

    [Fact]
    public void RemoveNonDigits_ShouldRemoveNonDigitCharacters_WhenGivenString()
    {
        // Arrange
        string s = "!1#2qw3$";
        string expected = "123";

        // Act
        var result = s.RemoveNonDigits();

        // Assert
        Assert.Equal(expected, result);
    }
    
    [Fact]
    public void RemoveNonDigits_ShouldReturnNull_WhenGivenNull()
    {
        // Arrange
        string? s = null;
        string? expected = null;

        // Act
        var result = s.RemoveNonDigits();

        // Assert
        Assert.Equal(expected, result);
    }
    
    [Fact]
    public void RemoveNonDigits_ShouldReturnEmptyString_WhenGivenEmptyString()
    {
        // Arrange
        string s = "";
        string expected = "";

        // Act
        var result = s.RemoveNonDigits();

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void ToByteArray_ShouldConvertString_WhenGivenString()
    {
        // Arrange
        string s = "123";
        byte[] expected = { 1, 2, 3 };

        // Act
        var result = s.ToByteArray();

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void ToByteArray_ShouldThrowInvalidCastException_WhenGivenNonNumericString()
    {
        // Arrange
        string s = "abc";

        // Act

        // Assert
        Assert.Throws<InvalidCastException>(() => s.ToByteArray());
    }
}
