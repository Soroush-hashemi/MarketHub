using ApiMarketHub.Application.SideEntities.ShippingMethods.Create;
using ApiMarketHub.Application.SideEntities.ShippingMethods.Delete;
using ApiMarketHub.Application.SideEntities.ShippingMethods.Edit;
using ApiMarketHub.PresentationFacade.SideEntities.Poster;
using ApiMarketHub.PresentationFacade.SideEntities.ShippingMethods;
using ApiMarketHub.Query.SideEntities.DTOs;
using FluentAssertions;
using MarketHub.Api.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using Shared.Application;
using Xunit;

namespace MarketHubApi.UnitTest.ControllersTests;
public class ShippingMethodControllerTest
{
    [Fact]
    public async Task Create_ValidCommand_ReturnsCreatedResult()
    {
        // Arrange
        var ShippingMethodFacade = Substitute.For<IShippingMethodFacade>();
        var controller = new ShippingMethodController(ShippingMethodFacade);
        var command = new CreateShippingMethodCommand();
        var expectedResult = new OperationResult
        {
            Status = OperationResultStatus.Success,
            Message = "test",
        };

        var httpContext = Substitute.For<HttpContext>();
        httpContext.Response.StatusCode.Returns(200);

        controller.ControllerContext = new ControllerContext
        {
            HttpContext = httpContext
        };

        ShippingMethodFacade.Create(command).Returns(expectedResult);
        // Act
        var result = await controller.Create(command);

        // Assert
        result.IsSuccess.Should().BeTrue();
    }

    [Fact]
    public async Task Create_InValidCommand_ReturnsSuccessIsFalse()
    {
        // Arrange
        var ShippingMethodFacade = Substitute.For<IShippingMethodFacade>();
        var controller = new ShippingMethodController(ShippingMethodFacade);
        var command = new CreateShippingMethodCommand();
        var expectedResult = new OperationResult
        {
            Status = OperationResultStatus.Error,
            Message = "test",
        };

        var httpContext = Substitute.For<HttpContext>();
        httpContext.Response.StatusCode.Returns(500);

        controller.ControllerContext = new ControllerContext
        {
            HttpContext = httpContext
        };

        ShippingMethodFacade.Create(command).Returns(expectedResult);
        // Act
        var result = await controller.Create(command);

        // Assert
        result.IsSuccess.Should().BeFalse();
    }

    [Fact]
    public async Task Edit_ValidCommand_ReturnsCreatedResult()
    {
        // Arrange
        var ShippingMethodFacade = Substitute.For<IShippingMethodFacade>();
        var controller = new ShippingMethodController(ShippingMethodFacade);
        var command = new EditShippingMethodCommand();
        var expectedResult = new OperationResult
        {
            Status = OperationResultStatus.Success,
            Message = "test",
        };

        var httpContext = Substitute.For<HttpContext>();
        httpContext.Response.StatusCode.Returns(200);

        controller.ControllerContext = new ControllerContext
        {
            HttpContext = httpContext
        };

        ShippingMethodFacade.Edit(command).Returns(expectedResult);
        // Act
        var result = await controller.Edit(command);

        // Assert
        result.IsSuccess.Should().BeTrue();
    }

    [Fact]
    public async Task Edit_InValidCommand_ReturnsSuccessIsFalse()
    {
        // Arrange
        var ShippingMethodFacade = Substitute.For<IShippingMethodFacade>();
        var controller = new ShippingMethodController(ShippingMethodFacade);
        var command = new EditShippingMethodCommand();
        var expectedResult = new OperationResult
        {
            Status = OperationResultStatus.Error,
            Message = "test",
        };

        var httpContext = Substitute.For<HttpContext>();
        httpContext.Response.StatusCode.Returns(500);

        controller.ControllerContext = new ControllerContext
        {
            HttpContext = httpContext
        };

        ShippingMethodFacade.Edit(command).Returns(expectedResult);
        // Act
        var result = await controller.Edit(command);

        // Assert
        result.IsSuccess.Should().BeFalse();
    }

    [Fact]
    public async Task Delete_ValidCommand_ReturnsCreatedResult()
    {
        // Arrange
        var ShippingMethodFacade = Substitute.For<IShippingMethodFacade>();
        var controller = new ShippingMethodController(ShippingMethodFacade);
        var command = new DeleteShippingMethodCommand();
        var expectedResult = new OperationResult
        {
            Status = OperationResultStatus.Success,
            Message = "test",
        };

        var httpContext = Substitute.For<HttpContext>();
        httpContext.Response.StatusCode.Returns(200);

        controller.ControllerContext = new ControllerContext
        {
            HttpContext = httpContext
        };

        ShippingMethodFacade.Delete(command).Returns(expectedResult);
        // Act
        var result = await controller.Delete(command);

        // Assert
        result.IsSuccess.Should().BeTrue();
    }

    [Fact]
    public async Task Delete_InValidCommand_ReturnsSuccessIsFalse()
    {
        // Arrange
        var ShippingMethodFacade = Substitute.For<IShippingMethodFacade>();
        var controller = new ShippingMethodController(ShippingMethodFacade);
        var command = new DeleteShippingMethodCommand();
        var expectedResult = new OperationResult
        {
            Status = OperationResultStatus.Error,
            Message = "test",
        };

        var httpContext = Substitute.For<HttpContext>();
        httpContext.Response.StatusCode.Returns(500);

        controller.ControllerContext = new ControllerContext
        {
            HttpContext = httpContext
        };

        ShippingMethodFacade.Delete(command).Returns(expectedResult);
        // Act
        var result = await controller.Delete(command);

        // Assert
        result.IsSuccess.Should().BeFalse();
    }

    [Fact]
    public async Task GetShippingMethodById_ValidQuery_ReturnsPosterDto()
    {
        // Arrange
        var ShippingMethodFacade = Substitute.For<IShippingMethodFacade>();
        var controller = new ShippingMethodController(ShippingMethodFacade);
        var PosterId = 1;

        var expectedPosterDto = new ShippingMethodDto();

        ShippingMethodFacade.GetShippingMethodById(PosterId).Returns(expectedPosterDto);

        // Act
        var result = await controller.GetShippingMethodById(PosterId);

        // Assert
        result.IsSuccess.Should().BeTrue();
        result.Data.Should().BeEquivalentTo(expectedPosterDto);
    }

    [Fact]
    public async Task GetShippingMethodDtoList_ValidQuery_ReturnsListPosterDto()
    {
        // Arrange
        var ShippingMethodFacade = Substitute.For<IShippingMethodFacade>();
        var controller = new ShippingMethodController(ShippingMethodFacade);

        var expectedPosterDto = new List<ShippingMethodDto>();

        ShippingMethodFacade.GetShippingMethodDtoList().Returns(expectedPosterDto);

        // Act
        var result = await controller.GetShippingMethodDtoList();

        // Assert
        result.IsSuccess.Should().BeTrue();
        result.Data.Should().BeEquivalentTo(expectedPosterDto);
    }
}