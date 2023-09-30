using ApiMarketHub.Application.Users.Create;
using ApiMarketHub.Domain.UserAggregate;
using ApiMarketHub.Domain.UserAggregate.Enums;
using ApiMarketHub.Domain.UserAggregate.Repository;
using ApiMarketHub.Domain.UserAggregate.Service;
using FluentAssertions;
using NSubstitute;
using Shared.Application;
using Shared.Domain.ValueObjects;
using Xunit;

namespace ApiMarketHub.Application.UnitTest.Users;

public class CreateUserHandlerTest
{
    [Fact]
    public async Task CreateUserHandler_Should_CreateNewUser()
    {
        // Arrange
        var userRepository = Substitute.For<IUserRepository>();
        var userDomainService = Substitute.For<IUserDomainService>();

        var createUserCommand = new CreateUserCommand("test", "test",
            new PhoneNumber("09181112233"), "test@gmail.com", "!?12344321", Gender.MALE);

        var createUserHandler = new CreateUserCommandHandler(userRepository, userDomainService);

        // Act
        var result = await createUserHandler.Handle(createUserCommand, CancellationToken.None);

        // Assert
        userRepository.Received(1).Add(Arg.Any<User>());
        await userRepository.Received(1).Save();

        result.Status.Should().Be(OperationResultStatus.Success);
    }

    [Fact]
    public void Validate_InvalidEmail_ShouldHaveValidationError()
    {
        // Arrange
        var validator = new CreateUserCommandValidator();
        var command = new CreateUserCommand("test", "test",
            new PhoneNumber("09181112233"), "invalid_email", "!?12344321", Gender.MALE);

        // Act
        var validationResult = validator.Validate(command);

        // Assert
        validationResult.Errors.Should().Contain
            (e => e.PropertyName == nameof(command.Email) && e.ErrorMessage == "ایمیل نامعتبر است");

    }

    [Fact]
    public void NameNotNullOrEmpty_Should_HaveValidationFailure_WhenNameIsNull()
    {
        // Arrange
        var validator = new CreateUserCommandValidator();
        var command = new CreateUserCommand("", "test",
            new PhoneNumber("09181112233"), "test@gmail.com", "!?12344321", Gender.MALE);

        // Act
        var validationResult = validator.Validate(command);

        // Assert
        validationResult.IsValid.Should().BeFalse();
        validationResult.Errors.Should().ContainSingle();
        validationResult.Errors[0].ErrorMessage.Should().Be("اسم اجباری است ");
    }

    [Fact]
    public void FamilyNotNullOrEmpty_Should_HaveValidationFailure_WhenFamilyIsEmpty()
    {
        // Arrange
        var validator = new CreateUserCommandValidator();
        var command = new CreateUserCommand("test", "",
            new PhoneNumber("09181112233"), "test@gmail.com", "!?12344321", Gender.MALE);

        // Act
        var validationResult = validator.Validate(command);

        // Assert
        validationResult.IsValid.Should().BeFalse();
        validationResult.Errors.Should().ContainSingle();
        validationResult.Errors[0].ErrorMessage.Should().Be("نام خانوادگی اجباری است ");
    }

    [Fact]
    public void PasswordMinimumLength_Should_HaveValidationFailure_WhenPasswordIsTooShort()
    {
        // Arrange
        var validator = new CreateUserCommandValidator();
        var command = new CreateUserCommand("test", "test",
            new PhoneNumber("09181112233"), "test@gmail.com", "123", Gender.MALE);

        // Act
        var validationResult = validator.Validate(command);

        // Assert
        validationResult.IsValid.Should().BeFalse();
        validationResult.Errors.Should().ContainSingle();
        validationResult.Errors[0].ErrorMessage.Should().Be("کلمه عبور باید بیشتر از 4 کاراکتر باشد");
    }
}