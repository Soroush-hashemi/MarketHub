using ApiMarketHub.Application.SideEntities.Posters.Create;
using ApiMarketHub.Application.SideEntities.Posters.Delete;
using ApiMarketHub.Application.SideEntities.Posters.Edit;
using ApiMarketHub.PresentationFacade.SideEntities.Poster;
using ApiMarketHub.Query.SideEntities.DTOs;
using FluentAssertions;
using MarketHub.Api.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using Shared.Application;
using Xunit;

namespace MarketHubApi.UnitTest.ControllersTests;

public class PosterControllerTest
{
    [Fact]
    public async Task Create_ValidCommand_ReturnsCreatedResult()
    {
        // Arrange
        var PosterFacade = Substitute.For<IPosterFacade>();
        var controller = new PosterController(PosterFacade);
        var command = new CreatePosterCommand();
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

        PosterFacade.Create(command).Returns(expectedResult);
        // Act
        var result = await controller.Create(command);

        // Assert
        result.IsSuccess.Should().BeTrue();
    }

    [Fact]
    public async Task Create_InValidCommand_ReturnsSuccessIsFalse()
    {
        // Arrange
        var PosterFacade = Substitute.For<IPosterFacade>();
        var controller = new PosterController(PosterFacade);
        var command = new CreatePosterCommand();
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

        PosterFacade.Create(command).Returns(expectedResult);
        // Act
        var result = await controller.Create(command);

        // Assert
        result.IsSuccess.Should().BeFalse();
    }

    [Fact]
    public async Task Edit_ValidCommand_ReturnsCreatedResult()
    {
        // Arrange
        var PosterFacade = Substitute.For<IPosterFacade>();
        var controller = new PosterController(PosterFacade);
        var command = new EditPosterCommand();
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

        PosterFacade.Edit(command).Returns(expectedResult);
        // Act
        var result = await controller.Edit(command);

        // Assert
        result.IsSuccess.Should().BeTrue();
    }

    [Fact]
    public async Task Edit_InValidCommand_ReturnsSuccessIsFalse()
    {
        // Arrange
        var PosterFacade = Substitute.For<IPosterFacade>();
        var controller = new PosterController(PosterFacade);
        var command = new EditPosterCommand();
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

        PosterFacade.Edit(command).Returns(expectedResult);
        // Act
        var result = await controller.Edit(command);

        // Assert
        result.IsSuccess.Should().BeFalse();
    }

    [Fact]
    public async Task Delete_ValidCommand_ReturnsCreatedResult()
    {
        // Arrange
        var PosterFacade = Substitute.For<IPosterFacade>();
        var controller = new PosterController(PosterFacade);
        var command = new DeletePosterCommand();
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

        PosterFacade.Delete(command).Returns(expectedResult);
        // Act
        var result = await controller.Delete(command);

        // Assert
        result.IsSuccess.Should().BeTrue();
    }

    [Fact]
    public async Task Delete_InValidCommand_ReturnsSuccessIsFalse()
    {
        // Arrange
        var PosterFacade = Substitute.For<IPosterFacade>();
        var controller = new PosterController(PosterFacade);
        var command = new DeletePosterCommand();
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

        PosterFacade.Delete(command).Returns(expectedResult);
        // Act
        var result = await controller.Delete(command);

        // Assert
        result.IsSuccess.Should().BeFalse();
    }

    [Fact]
    public async Task GetPosterById_ValidQuery_ReturnsPosterDto()
    {
        // Arrange
        var PosterFacade = Substitute.For<IPosterFacade>();
        var controller = new PosterController(PosterFacade);
        var PosterId = 1;

        var expectedPosterDto = new PosterDto();

        PosterFacade.GetPosterById(PosterId).Returns(expectedPosterDto);

        // Act
        var result = await controller.GetPosterById(PosterId);

        // Assert
        result.IsSuccess.Should().BeTrue();
        result.Data.Should().BeEquivalentTo(expectedPosterDto);
    }

    [Fact]
    public async Task GetPosterList_ValidQuery_ReturnsListPosterDto()
    {
        // Arrange
        var PosterFacade = Substitute.For<IPosterFacade>();
        var controller = new PosterController(PosterFacade);

        var expectedPosterDto = new List<PosterDto>();

        PosterFacade.GetPosterList().Returns(expectedPosterDto);

        // Act
        var result = await controller.GetPosterList();

        // Assert
        result.IsSuccess.Should().BeTrue();
        result.Data.Should().BeEquivalentTo(expectedPosterDto);
    }
}