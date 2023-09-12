using FluentAssertions;
using Shared.Domain.Tools;
using Xunit;

namespace Shared.Domain.UnitTest.Tools;
public class EmailValidationTest
{
    [Fact]
    public void EmailValidation_Should_Return_True()
    {
        // Arrange & Act
        var isValid = EmailValidation.IsValidEmail("soro.ush84sh@gmail.com");

        // Assert
        isValid.Should().BeTrue();
    }

    [Fact]
    public void EmailValidation_Should_Return_False()
    {
        // Arrange & Act
        var isValid = EmailValidation.IsValidEmail("TestEmail");

        // Assert
        isValid.Should().BeFalse();
    }
}