using BrazilianDocuments.CPF;
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
}
