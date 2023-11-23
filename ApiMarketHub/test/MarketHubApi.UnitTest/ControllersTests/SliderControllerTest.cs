using ApiMarketHub.Application.SideEntities.Sliders.Create;
using ApiMarketHub.Application.SideEntities.Sliders.Delete;
using ApiMarketHub.Application.SideEntities.Sliders.Edit;
using ApiMarketHub.PresentationFacade.SideEntities.ShippingMethods;
using ApiMarketHub.PresentationFacade.SideEntities.Slider;
using ApiMarketHub.Query.SideEntities.DTOs;
using ApiMarketHub.Query.SideEntities.Sliders.GetList;
using FluentAssertions;
using MarketHub.Api.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using Shared.Application;
using Xunit;

namespace MarketHubApi.UnitTest.ControllersTests;
public class SliderControllerTest
{
    [Fact]
    public async Task Create_ValidCommand_ReturnsCreatedResult()
    {
        // Arrange
        var sliderFacade = Substitute.For<ISliderFacade>();
        var controller = new SliderController(sliderFacade);
        var command = new CreateSliderCommand();
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

        sliderFacade.Create(command).Returns(expectedResult);
        // Act
        var result = await controller.Create(command);

        // Assert
        result.IsSuccess.Should().BeTrue();
    }

    [Fact]
    public async Task Create_InValidCommand_ReturnsSuccessIsFalse()
    {
        // Arrange
        var sliderFacade = Substitute.For<ISliderFacade>();
        var controller = new SliderController(sliderFacade);
        var command = new CreateSliderCommand();
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

        sliderFacade.Create(command).Returns(expectedResult);
        // Act
        var result = await controller.Create(command);

        // Assert
        result.IsSuccess.Should().BeFalse();
    }

    [Fact]
    public async Task Edit_ValidCommand_ReturnsCreatedResult()
    {
        // Arrange
        var sliderFacade = Substitute.For<ISliderFacade>();
        var controller = new SliderController(sliderFacade);
        var command = new EditSliderCommand();
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

        sliderFacade.Edit(command).Returns(expectedResult);
        // Act
        var result = await controller.Edit(command);

        // Assert
        result.IsSuccess.Should().BeTrue();
    }

    [Fact]
    public async Task Edit_InValidCommand_ReturnsSuccessIsFalse()
    {
        // Arrange
        var sliderFacade = Substitute.For<ISliderFacade>();
        var controller = new SliderController(sliderFacade);
        var command = new EditSliderCommand();
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

        sliderFacade.Edit(command).Returns(expectedResult);
        // Act
        var result = await controller.Edit(command);

        // Assert
        result.IsSuccess.Should().BeFalse();
    }

    [Fact]
    public async Task Delete_ValidCommand_ReturnsCreatedResult()
    {
        // Arrange
        var sliderFacade = Substitute.For<ISliderFacade>();
        var controller = new SliderController(sliderFacade);
        var command = new DeleteSliderCommand(2);
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

        sliderFacade.Delete(command).Returns(expectedResult);
        // Act
        var result = await controller.Delete(command);

        // Assert
        result.IsSuccess.Should().BeTrue();
    }

    [Fact]
    public async Task Delete_InValidCommand_ReturnsSuccessIsFalse()
    {
        // Arrange
        var sliderFacade = Substitute.For<ISliderFacade>();
        var controller = new SliderController(sliderFacade);
        var command = new DeleteSliderCommand(2);
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

        sliderFacade.Delete(command).Returns(expectedResult);
        // Act
        var result = await controller.Delete(command);

        // Assert
        result.IsSuccess.Should().BeFalse();
    }

    [Fact]
    public async Task GetSliderById_ValidQuery_ReturnsSliderDto()
    {
        // Arrange
        var sliderFacade = Substitute.For<ISliderFacade>();
        var controller = new SliderController(sliderFacade);
        var SliderId = 1;

        var expectedSlider = new SliderDto();

        sliderFacade.GetSliderById(SliderId).Returns(expectedSlider);

        // Act
        var result = await controller.GetSliderById(SliderId);

        // Assert
        result.IsSuccess.Should().BeTrue();
        result.Data.Should().BeEquivalentTo(expectedSlider);
    }

    [Fact]
    public async Task GetSliderListQuery_ValidQuery_ReturnsListSliderDto()
    {
        // Arrange
        var sliderFacade = Substitute.For<ISliderFacade>();
        var controller = new SliderController(sliderFacade);

        var expectedSlider = new List<SliderDto>();

        sliderFacade.GetSliderListQuery().Returns(expectedSlider);

        // Act
        var result = await controller.GetSliderListQuery();

        // Assert
        result.IsSuccess.Should().BeTrue();
        result.Data.Should().BeEquivalentTo(expectedSlider);
    }
}