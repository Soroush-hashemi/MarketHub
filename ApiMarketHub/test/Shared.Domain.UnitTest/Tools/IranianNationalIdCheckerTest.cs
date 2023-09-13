using Shared.Domain.Tools;
using Xunit;
using FluentAssertions;

namespace Shared.Domain.UnitTest.Tools;
public class IranianNationalIdCheckerTest
{
    [Fact]
    public void IranianNationalIdChecker_Should_Return_True()
    {
        // Arrange & Act
        var isValid = IranianNationalIdChecker.IsValid("2175607488");

        // Assert
        isValid.Should().BeTrue();
    }

    [Fact]
    public void IranianNationalIdChecker_Should_Return_False()
    {
        // Arrange & Act
        var isValid = IranianNationalIdChecker.IsValid("1234567890");

        // Assert
        isValid.Should().BeFalse();
    }
}