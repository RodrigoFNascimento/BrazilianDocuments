using BrazilianDocuments.CPF;
using Xunit;

namespace BrazilianDocuments.Tests.Unit.CPF;

public class CpfValidatorTests
{
    [Theory]
    [InlineData("85034251060", true)]
    [InlineData("30548688001", true)]
    [InlineData("59688316008", true)]
    [InlineData("54487306105", false)]
    [InlineData("00000000000", false)]
    [InlineData("11111111111", false)]
    [InlineData("22222222222", false)]
    public void IsValid_ShouldReturnTrue_WhenGivenAValidCpf(
        string a,
        bool expected)
    {
        Assert.Equal(CpfValidator.IsValid(a), expected);
    }
}
