using ApiMarketHub.Application.Orders.AddItem;
using ApiMarketHub.Application.Orders.ChangeStatus;
using ApiMarketHub.Application.Orders.Checkout;
using ApiMarketHub.Application.Orders.DecreaseItemCount;
using ApiMarketHub.Application.Orders.Finally;
using ApiMarketHub.Application.Orders.IncreaseItemCount;
using ApiMarketHub.Application.Orders.RemoveItem;
using ApiMarketHub.Domain.OrderAggregate.Enum;
using ApiMarketHub.PresentationFacade.Orders;
using ApiMarketHub.Query.Orders.DTOs;
using FluentAssertions;
using MarketHub.Api.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using Shared.Application;
using Xunit;

namespace MarketHubApi.UnitTest.ControllersTests;
public class OrderControllerTest
{
    [Fact]
    public async Task AddItem_ValidCommand_ReturnsCreatedResult()
    {
        // Arrange
        var orderFacade = Substitute.For<IOrderFacade>();
        var controller = new OrderController(orderFacade);
        var command = new AddItemOrderCommand(1, 1, 1);
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
        orderFacade.AddItem(command).Returns(expectedResult);

        // Act
        var result = await controller.AddItem(command);

        // Assert
        result.IsSuccess.Should().BeTrue();
    }

    [Fact]
    public async Task AddItem_InValidCommand_ReturnsSuccessIsFalse()
    {
        // Arrange
        var orderFacade = Substitute.For<IOrderFacade>();
        var controller = new OrderController(orderFacade);
        var command = new AddItemOrderCommand(1, 1, 1);
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
        orderFacade.AddItem(command).Returns(expectedResult);

        // Act
        var result = await controller.AddItem(command);

        // Assert
        result.IsSuccess.Should().BeFalse();
    }

    [Fact]
    public async Task ChangeStatus_ValidCommand_ReturnsCreatedResult()
    {
        // Arrange
        var orderFacade = Substitute.For<IOrderFacade>();
        var controller = new OrderController(orderFacade);
        var command = new ChangeStatusOrderCommand(1, OrderStatus.Shipping);
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
        orderFacade.ChangeStatus(command).Returns(expectedResult);

        // Act
        var result = await controller.ChangeStatus(command);

        // Assert
        result.IsSuccess.Should().BeTrue();
    }

    [Fact]
    public async Task ChangeStatus_InValidCommand_ReturnsSuccessIsFalse()
    {
        // Arrange
        var orderFacade = Substitute.For<IOrderFacade>();
        var controller = new OrderController(orderFacade);
        var command = new ChangeStatusOrderCommand(1, OrderStatus.Shipping);
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
        orderFacade.ChangeStatus(command).Returns(expectedResult);

        // Act
        var result = await controller.ChangeStatus(command);

        // Assert
        result.IsSuccess.Should().BeFalse();
    }

    [Fact]
    public async Task Checkout_ValidCommand_ReturnsCreatedResult()
    {
        // Arrange
        var orderFacade = Substitute.For<IOrderFacade>();
        var controller = new OrderController(orderFacade);
        var command = new CheckoutOrderCommand(1, "test", "test", "test", "test",
            "test", "test", "test", "test", 1);
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
        orderFacade.Checkout(command).Returns(expectedResult);

        // Act
        var result = await controller.Checkout(command);

        // Assert
        result.IsSuccess.Should().BeTrue();
    }

    [Fact]
    public async Task Checkout_InValidCommand_ReturnsSuccessIsFalse()
    {
        // Arrange
        var orderFacade = Substitute.For<IOrderFacade>();
        var controller = new OrderController(orderFacade);
        var command = new CheckoutOrderCommand(1, "test", "test", "test", "test",
            "test", "test", "test", "test", 1);
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
        orderFacade.Checkout(command).Returns(expectedResult);

        // Act
        var result = await controller.Checkout(command);

        // Assert
        result.IsSuccess.Should().BeFalse();
    }

    [Fact]
    public async Task DecreaseItemCount_ValidCommand_ReturnsCreatedResult()
    {
        // Arrange
        var orderFacade = Substitute.For<IOrderFacade>();
        var controller = new OrderController(orderFacade);
        var command = new DecreaseItemCountOrderCommand(1, 1, 1);
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
        orderFacade.DecreaseItemCount(command).Returns(expectedResult);

        // Act
        var result = await controller.DecreaseItemCount(command);

        // Assert
        result.IsSuccess.Should().BeTrue();
    }

    [Fact]
    public async Task DecreaseItemCount_InValidCommand_ReturnsSuccessIsFalse()
    {
        // Arrange
        var orderFacade = Substitute.For<IOrderFacade>();
        var controller = new OrderController(orderFacade);
        var command = new DecreaseItemCountOrderCommand(1, 1, 1);
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
        orderFacade.DecreaseItemCount(command).Returns(expectedResult);

        // Act
        var result = await controller.DecreaseItemCount(command);

        // Assert
        result.IsSuccess.Should().BeFalse();
    }

    [Fact]
    public async Task IncreaseItemCount_ValidCommand_ReturnsCreatedResult()
    {
        // Arrange
        var orderFacade = Substitute.For<IOrderFacade>();
        var controller = new OrderController(orderFacade);
        var command = new IncreaseItemCountOrderCommand(1, 1, 1);
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
        orderFacade.IncreaseItemCount(command).Returns(expectedResult);

        // Act
        var result = await controller.IncreaseItemCount(command);

        // Assert
        result.IsSuccess.Should().BeTrue();
    }

    [Fact]
    public async Task IncreaseItemCount_InValidCommand_ReturnsSuccessIsFalse()
    {
        // Arrange
        var orderFacade = Substitute.For<IOrderFacade>();
        var controller = new OrderController(orderFacade);
        var command = new IncreaseItemCountOrderCommand(1, 1, 1);
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
        orderFacade.IncreaseItemCount(command).Returns(expectedResult);

        // Act
        var result = await controller.IncreaseItemCount(command);

        // Assert
        result.IsSuccess.Should().BeFalse();
    }

    [Fact]
    public async Task Finally_ValidCommand_ReturnsCreatedResult()
    {
        // Arrange
        var orderFacade = Substitute.For<IOrderFacade>();
        var controller = new OrderController(orderFacade);
        var command = new FinallyOrderCommand(1);
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
        orderFacade.Finally(command).Returns(expectedResult);

        // Act
        var result = await controller.Finally(command);

        // Assert
        result.IsSuccess.Should().BeTrue();
    }

    [Fact]
    public async Task Finally_InValidCommand_ReturnsSuccessIsFalse()
    {
        // Arrange
        var orderFacade = Substitute.For<IOrderFacade>();
        var controller = new OrderController(orderFacade);
        var command = new FinallyOrderCommand(1);
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
        orderFacade.Finally(command).Returns(expectedResult);

        // Act
        var result = await controller.Finally(command);

        // Assert
        result.IsSuccess.Should().BeFalse();
    }

    [Fact]
    public async Task RemoveItemOrder_ValidCommand_ReturnsCreatedResult()
    {
        // Arrange
        var orderFacade = Substitute.For<IOrderFacade>();
        var controller = new OrderController(orderFacade);
        var command = new RemoveItemOrderCommand(1, 1);
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
        orderFacade.RemoveItemOrder(command).Returns(expectedResult);

        // Act
        var result = await controller.RemoveItemOrder(command);

        // Assert
        result.IsSuccess.Should().BeTrue();
    }

    [Fact]
    public async Task RemoveItemOrder_InValidCommand_ReturnsSuccessIsFalse()
    {
        // Arrange
        var orderFacade = Substitute.For<IOrderFacade>();
        var controller = new OrderController(orderFacade);
        var command = new RemoveItemOrderCommand(1, 1);
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
        orderFacade.RemoveItemOrder(command).Returns(expectedResult);

        // Act
        var result = await controller.RemoveItemOrder(command);

        // Assert
        result.IsSuccess.Should().BeFalse();
    }

    [Fact]
    public async Task GetOrderById_ValidQuery_ReturnsOrderDto()
    {
        // Arrange
        var OrderFacade = Substitute.For<IOrderFacade>();
        var controller = new OrderController(OrderFacade);
        var orderId = 1;
        var expectedOrderDto = new OrderDto();

        OrderFacade.GetOrderById(orderId).Returns(expectedOrderDto);

        // Act
        var result = await controller.GetOrderById(orderId);

        // Assert
        result.IsSuccess.Should().BeTrue();
        result.Data.Should().BeEquivalentTo(expectedOrderDto);
    }

    [Fact]
    public async Task GetCurrentUserOrder_ValidQuery_ReturnsOrderDto()
    {
        // Arrange
        var OrderFacade = Substitute.For<IOrderFacade>();
        var controller = new OrderController(OrderFacade);
        var userId = 1;
        var expectedOrderDto = new OrderDto();

        OrderFacade.GetCurrentUserOrder(userId).Returns(expectedOrderDto);

        // Act
        var result = await controller.GetCurrentUserOrder(userId);

        // Assert
        result.IsSuccess.Should().BeTrue();
        result.Data.Should().BeEquivalentTo(expectedOrderDto);
    }

    [Fact]
    public async Task GetOrdersByFilter_ValidQuery_ReturnsOrderFilterResult()
    {
        // Arrange
        var OrderFacade = Substitute.For<IOrderFacade>();
        var controller = new OrderController(OrderFacade);
        var filterParams = new OrderFilterParams();
        var expectedCommentFilterResult = new OrderFilterResult();
        OrderFacade.GetOrdersByFilter(filterParams).Returns(expectedCommentFilterResult);

        // Act
        var result = await controller.GetOrdersByFilter(filterParams);

        // Assert
        result.IsSuccess.Should().BeTrue();
    }
}