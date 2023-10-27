using ApiMarketHub.Application.Comments.ChangeStatus;
using ApiMarketHub.Application.Comments.Create;
using ApiMarketHub.Application.Comments.Delete;
using ApiMarketHub.Application.Comments.Edit;
using ApiMarketHub.Domain.CommentAggregate.Enum;
using ApiMarketHub.PresentationFacade.Comments;
using ApiMarketHub.Query.Comments.DTOs;
using FluentAssertions;
using MarketHub.Api.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using Shared.Application;
using Xunit;

namespace MarketHubApi.UnitTest.ControllersTests;

public class CommentControllerTest
{
    [Fact]
    public async Task Create_ValidCommand_ReturnsCreatedResult()
    {
        // Arrange
        var CommentFacade = Substitute.For<ICommentFacade>();
        var controller = new CommentController(CommentFacade);
        var command = new CreateCommentCommand(1, 1, "test Message 123");
        var expectedResult = new OperationResult<long>
        {
            Status = OperationResultStatus.Success,
            Data = 1,
            Message = "test",
        };

        var httpContext = Substitute.For<HttpContext>();
        httpContext.Response.StatusCode.Returns(200);

        controller.ControllerContext = new ControllerContext
        {
            HttpContext = httpContext
        };
        CommentFacade.Create(command).Returns(expectedResult);

        // Act
        var result = await controller.Create(command);

        // Assert
        result.IsSuccess.Should().BeTrue();
        result.Data.Should().Be(expectedResult.Data);
    }

    [Fact]
    public async Task Create_InValidCommand_ReturnsSuccessIsFalse()
    {
        // Arrange
        var CommentFacade = Substitute.For<ICommentFacade>();
        var controller = new CommentController(CommentFacade);
        var command = new CreateCommentCommand(1, 1, "");
        var expectedResult = new OperationResult<long>
        {
            Status = OperationResultStatus.Error,
        };

        var httpContext = Substitute.For<HttpContext>();
        httpContext.Response.StatusCode.Returns(500);

        controller.ControllerContext = new ControllerContext
        {
            HttpContext = httpContext
        };

        CommentFacade.Create(command).Returns(expectedResult);
        // Act
        var result = await controller.Create(command);

        // Assert
        result.IsSuccess.Should().BeFalse();
        result.Data.Should().Be(expectedResult.Data);
    }

    [Fact]
    public async Task Edit_ValidCommand_ReturnsCreatedResult()
    {
        // Arrange
        var CommentFacade = Substitute.For<ICommentFacade>();
        var controller = new CommentController(CommentFacade);
        var command = new EditCommentCommand(1, 1, "test Message 123");
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

        CommentFacade.Edit(command).Returns(expectedResult);
        // Act
        var result = await controller.Edit(command);

        // Assert
        result.IsSuccess.Should().BeTrue();
    }

    [Fact]
    public async Task Edit_InValidCommand_ReturnsSuccessIsFalse()
    {
        // Arrange
        var CommentFacade = Substitute.For<ICommentFacade>();
        var controller = new CommentController(CommentFacade);
        var command = new EditCommentCommand(1, 1, "test Message 123");
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

        CommentFacade.Edit(command).Returns(expectedResult);
        // Act
        var result = await controller.Edit(command);

        // Assert
        result.IsSuccess.Should().BeFalse();
    }

    [Fact]
    public async Task Delete_ValidCommand_ReturnsCreatedResult()
    {
        // Arrange
        var CommentFacade = Substitute.For<ICommentFacade>();
        var controller = new CommentController(CommentFacade);
        var command = new DeleteCommentCommand(1, 1);
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

        CommentFacade.Delete(command).Returns(expectedResult);
        // Act
        var result = await controller.Delete(command);

        // Assert
        result.IsSuccess.Should().BeTrue();
    }

    [Fact]
    public async Task Delete_InValidCommand_ReturnsSuccessIsFalse()
    {
        // Arrange
        var CommentFacade = Substitute.For<ICommentFacade>();
        var controller = new CommentController(CommentFacade);
        var command = new DeleteCommentCommand(1, 1);
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

        CommentFacade.Delete(command).Returns(expectedResult);
        // Act
        var result = await controller.Delete(command);

        // Assert
        result.IsSuccess.Should().BeFalse();
    }

    [Fact]
    public async Task ChangeStatus_ValidCommand_ReturnsCreatedResult()
    {
        // Arrange
        var CommentFacade = Substitute.For<ICommentFacade>();
        var controller = new CommentController(CommentFacade);
        var command = new ChangeStatusCommentCommand(1, CommentStatus.Accepted);
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

        CommentFacade.ChangeStatus(command).Returns(expectedResult);
        // Act
        var result = await controller.ChangeStatus(command);

        // Assert
        result.IsSuccess.Should().BeTrue();
    }

    [Fact]
    public async Task ChangeStatus_InValidCommand_ReturnsSuccessIsFalse()
    {
        // Arrange
        var CommentFacade = Substitute.For<ICommentFacade>();
        var controller = new CommentController(CommentFacade);
        var command = new ChangeStatusCommentCommand(1, CommentStatus.Accepted);
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

        CommentFacade.ChangeStatus(command).Returns(expectedResult);

        // Act
        var result = await controller.ChangeStatus(command);

        // Assert
        result.IsSuccess.Should().BeFalse();
    }

    [Fact]
    public async Task GetCommentById_ValidQuery_ReturnsCommentDto()
    {
        // Arrange
        var CommentFacade = Substitute.For<ICommentFacade>();
        var controller = new CommentController(CommentFacade);
        var commentId = 1;

        var expectedCommentDto = new CommentDto();

        CommentFacade.GetCommentById(commentId).Returns(expectedCommentDto);

        // Act
        var result = await controller.GetCommentById(commentId);

        // Assert
        result.IsSuccess.Should().BeTrue();
        result.Data.Should().BeEquivalentTo(expectedCommentDto);
    }

    [Fact]
    public async Task GetCommentByFilter_ValidQuery_ReturnsCommentFilterResult()
    {
        // Arrange
        var CommentFacade = Substitute.For<ICommentFacade>();
        var controller = new CommentController(CommentFacade);
        var filterParams = new CommentFilterParams();

        var expectedCommentFilterResult = new CommentFilterResult();

        CommentFacade.GetCommentByFilter(filterParams).Returns(expectedCommentFilterResult);

        // Act
        var result = await controller.GetCommentByFilter(filterParams);

        // Assert
        result.IsSuccess.Should().BeTrue();
    }
}