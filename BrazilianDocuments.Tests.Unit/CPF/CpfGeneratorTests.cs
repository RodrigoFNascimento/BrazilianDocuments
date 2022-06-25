using BrazilianDocuments.CPF;
using System.Text.RegularExpressions;
using Xunit;

namespace BrazilianDocuments.Tests.Unit.CPF;

public class CpfGeneratorTests
{
    [Fact]
    public void GenerateCpf_ShouldReturnAValidCpf()
    {
        // Arrange

        // Act
        var cpf = CpfGenerator.Generate();
        var result = CpfValidator.IsValid(cpf);

        // Assert
        Assert.True(result);
    }
    
    [Fact]
    public void GenerateInCustomFormat_ShouldReturnCpfInCustomFormat_WhenCustomFormatIsSpecified()
    {
        // Arrange
        var pattern = "^([0-9]{3})([0-9]{3})([0-9]{3})([0-9]{2})$";
        var replacement = "$1.$2.$3-$4";
        var newPattern = "^([0-9]{3}).([0-9]{3}).([0-9]{3})-([0-9]{2})$";

        // Act
        var cpf = CpfGenerator.GenerateInCustomFormat(pattern, replacement);
        var result = Regex.Match(cpf, newPattern).Success;

        // Assert
        Assert.True(result);
    }
}
