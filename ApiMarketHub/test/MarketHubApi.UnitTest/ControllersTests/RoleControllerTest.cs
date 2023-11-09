using ApiMarketHub.Application.Roles.Create;
using ApiMarketHub.Application.Roles.Edit;
using ApiMarketHub.Domain.RoleAggregate.Enum;
using ApiMarketHub.PresentationFacade.Roles;
using ApiMarketHub.Query.Categories.DTOs;
using ApiMarketHub.Query.Roles.DTO;
using FluentAssertions;
using MarketHub.Api.Controllers;
using Microsoft.AspNetCore.Http;
using NSubstitute;
using Shared.Application;
using System.Collections.Generic;
using Xunit;

namespace MarketHubApi.UnitTest.ControllersTests;
public class RoleControllerTest
{
    [Fact]
    public async Task Create_ValidCommand_ReturnsCreatedResult()
    {
        // Arrange
        var RoleFacade = Substitute.For<IRoleFacade>();
        var controller = new RoleController(RoleFacade);
        List<Permission> permissions = new List<Permission>();
        var command = new CreateRoleCommand("test title", permissions);
        var expectedResult = new OperationResult
        {
            Status = OperationResultStatus.Success,
            Message = "test",
        };

        var httpContext = Substitute.For<HttpContext>();
        httpContext.Response.StatusCode.Returns(200);
        RoleFacade.Create(command).Returns(expectedResult);

        // Act
        var result = await controller.Create(command);

        // Assert
        result.IsSuccess.Should().BeTrue();
    }

    [Fact]
    public async Task Create_InValidCommand_ReturnsSuccessIsFalse()
    {
        // Arrange
        var RoleFacade = Substitute.For<IRoleFacade>();
        var controller = new RoleController(RoleFacade);
        List<Permission> permissions = new List<Permission>();
        var command = new CreateRoleCommand("test title", permissions);
        var expectedResult = new OperationResult
        {
            Status = OperationResultStatus.Error,
            Message = "test",
        };

        var httpContext = Substitute.For<HttpContext>();
        httpContext.Response.StatusCode.Returns(500);
        RoleFacade.Create(command).Returns(expectedResult);

        // Act
        var result = await controller.Create(command);

        // Assert
        result.IsSuccess.Should().BeFalse();
    }

    [Fact]
    public async Task Edit_ValidCommand_ReturnsCreatedResult()
    {
        // Arrange
        var RoleFacade = Substitute.For<IRoleFacade>();
        var controller = new RoleController(RoleFacade);
        List<Permission> permissions = new List<Permission>();
        var command = new EditRoleCommand(1 ,"title edited", permissions);
        var expectedResult = new OperationResult
        {
            Status = OperationResultStatus.Success,
            Message = "test",
        };

        var httpContext = Substitute.For<HttpContext>();
        httpContext.Response.StatusCode.Returns(200);
        RoleFacade.Edit(command).Returns(expectedResult);

        // Act
        var result = await controller.Edit(command);

        // Assert
        result.IsSuccess.Should().BeTrue();
    }

    [Fact]
    public async Task Edit_InValidCommand_ReturnsSuccessIsFalse()
    {
        // Arrange
        var RoleFacade = Substitute.For<IRoleFacade>();
        var controller = new RoleController(RoleFacade);
        List<Permission> permissions = new List<Permission>();
        var command = new EditRoleCommand(1, "title edited", permissions);
        var expectedResult = new OperationResult
        {
            Status = OperationResultStatus.Error,
            Message = "test",
        };

        var httpContext = Substitute.For<HttpContext>();
        httpContext.Response.StatusCode.Returns(500);
        RoleFacade.Edit(command).Returns(expectedResult);

        // Act
        var result = await controller.Edit(command);

        // Assert
        result.IsSuccess.Should().BeFalse();
    }

    [Fact]
    public async Task GetRoleById_ValidQuery_ReturnsRoleDto()
    {
        // Arrange
        var RoleFacade = Substitute.For<IRoleFacade>();
        var controller = new RoleController(RoleFacade);
        long roleId = 1;
        var expectedResult = new RoleDto();
        RoleFacade.GetRoleById(roleId).Returns(expectedResult);

        // Act
        var result = await controller.GetRoleById(roleId);

        // Assert
        result.IsSuccess.Should().BeTrue();
        result.Data.Should().BeEquivalentTo(expectedResult);
    }

    [Fact]
    public async Task GetRoleById_ValidQuery_ReturnsListRoleDto()
    {
        // Arrange
        var RoleFacade = Substitute.For<IRoleFacade>();
        var controller = new RoleController(RoleFacade);
        var expectedResult = new List<RoleDto>();
        RoleFacade.GetRoles().Returns(expectedResult);

        // Act
        var result = await controller.GetRoles();

        // Assert
        result.IsSuccess.Should().BeTrue();
        result.Data.Should().BeEquivalentTo(expectedResult);
    }
}