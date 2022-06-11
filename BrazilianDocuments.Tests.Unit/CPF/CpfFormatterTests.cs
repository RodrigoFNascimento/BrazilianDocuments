using BrazilianDocuments.CPF;
using System;
using Xunit;

namespace BrazilianDocuments.Tests.Unit.CPF;

public class CpfFormatterTests
{
    [Fact]
    public void GetInCustomFormat_ShouldFormatNumber_WhenGivenNumber()
    {
        // Arrange
        string number = "12345678900";
        string pattern = "^([0-9]{3})([0-9]{3})([0-9]{3})([0-9]{2})$";
        string replacement = "$1.$2.$3-$4";
        char padCharacter = '0';
        string expected = "123.456.789-00";

        // Act
        var result = CpfFormatter.GetInCustomFormat(number, pattern, replacement, padCharacter);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void GetInCustomFormat_ShouldThrowException_WhenGivenEmptyNumber()
    {
        // Arrange
        string number = "";
        string pattern = "^([0-9]{3})([0-9]{3})([0-9]{3})([0-9]{2})$";
        string replacement = "$1.$2.$3-$4";
        char padCharacter = '0';

        // Act

        // Assert
        Assert.Throws<ArgumentNullException>(
            () => CpfFormatter.GetInCustomFormat(number, pattern, replacement, padCharacter));
    }

    [Fact]
    public void GetInCustomFormat_ShouldThrowException_WhenGivenNumberTooLong()
    {
        // Arrange
        string number = "123456789123";
        string pattern = "^([0-9]{3})([0-9]{3})([0-9]{3})([0-9]{2})$";
        string replacement = "$1.$2.$3-$4";
        char padCharacter = '0';

        // Act

        // Assert
        Assert.Throws<ArgumentException>(
            () => CpfFormatter.GetInCustomFormat(number, pattern, replacement, padCharacter));
    }

    [Theory]
    [InlineData("2345678912", 7, 0, 'X', '0', "XXXXXXX8912")]
    [InlineData("2345678912", 3, 4, 'o', '0', "0234ooo8912")]
    public void GetMasked_ShouldMaskNumber_WhenGivenNumber(
        string number,
        int numberOfCharacters,
        int offSet,
        char maskCharacter,
        char padCharacter,
        string expected)
    {
        // Arrange

        // Act
        var result = CpfFormatter.GetMasked(number, numberOfCharacters, offSet, maskCharacter, padCharacter);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void GetMasked_ShouldThrowException_WhenGivenEmptyNumber()
    {
        // Arrange
        string number = "";
        int numberOfCharacters = number.Length;
        int offSet = 0;
        char character = 'X';

        // Act

        // Assert
        Assert.Throws<ArgumentNullException>(
            () => CpfFormatter.GetMasked(number, numberOfCharacters, offSet, character));
    }

    [Fact]
    public void GetMasked_ShouldThrowException_WhenGivenANumberOfCharactersBiggerThanTheNumbersLength()
    {
        // Arrange
        string number = "12312312312";
        int numberOfCharacters = number.Length + 1;
        int offSet = 0;
        char character = 'X';

        // Act

        // Assert
        Assert.Throws<ArgumentOutOfRangeException>(
            () => CpfFormatter.GetMasked(number, numberOfCharacters, offSet, character));
    }

    [Fact]
    public void GetMasked_ShouldThrowException_WhenTheSumOfOffSetAndNumberOfCharactersIsBiggerThanTheNumbersLength()
    {
        // Arrange
        string number = "12312312312";
        int numberOfCharacters = number.Length;
        int offSet = number.Length;
        char character = 'X';

        // Act

        // Assert
        Assert.Throws<ArgumentOutOfRangeException>(
            () => CpfFormatter.GetMasked(number, numberOfCharacters, offSet, character));
    }
}
