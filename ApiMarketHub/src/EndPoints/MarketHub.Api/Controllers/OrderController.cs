using ApiMarketHub.Application.Orders.AddItem;
using ApiMarketHub.Application.Orders.ChangeStatus;
using ApiMarketHub.Application.Orders.Checkout;
using ApiMarketHub.Application.Orders.DecreaseItemCount;
using ApiMarketHub.Application.Orders.Finally;
using ApiMarketHub.Application.Orders.IncreaseItemCount;
using ApiMarketHub.Application.Orders.RemoveItem;
using ApiMarketHub.PresentationFacade.Orders;
using ApiMarketHub.Query.Orders.DTOs;
using Microsoft.AspNetCore.Mvc;
using Shared.ApiResponse;

namespace MarketHub.Api.Controllers;

public class OrderController : ApiController
{
    private readonly IOrderFacade _orderFacade;
    public OrderController(IOrderFacade orderFacade)
    {
        _orderFacade = orderFacade;
    }

    [HttpPost]
    public async Task<ApiResult> AddItem(AddItemOrderCommand command)
    {
        var result = await _orderFacade.AddItem(command);
        return CommandResult(result);
    }

    [HttpPut("ChangeStatus")]
    public async Task<ApiResult> ChangeStatus(ChangeStatusOrderCommand command)
    {
        var result = await _orderFacade.ChangeStatus(command);
        return CommandResult(result);
    }

    [HttpPost("Checkout")]
    public async Task<ApiResult> Checkout(CheckoutOrderCommand command)
    {
        var result = await _orderFacade.Checkout(command);
        return CommandResult(result);
    }

    [HttpPut("orderItem/DecreaseCount")]
    public async Task<ApiResult> DecreaseItemCount(DecreaseItemCountOrderCommand command)
    {
        var result = await _orderFacade.DecreaseItemCount(command);
        return CommandResult(result);
    }

    [HttpPut("orderItem/IncreaseCount")]
    public async Task<ApiResult> IncreaseItemCount(IncreaseItemCountOrderCommand command)
    {
        var result = await _orderFacade.IncreaseItemCount(command);
        return CommandResult(result);
    }

    [HttpPut("ChangeStatus/Finally")]
    public async Task<ApiResult> Finally(FinallyOrderCommand command)
    {
        var result = await _orderFacade.FinallyOrderCommand(command);
        return CommandResult(result);
    }

    [HttpDelete("orderItem")]
    public async Task<ApiResult> RemoveItemOrder(RemoveItemOrderCommand command)
    {
        var result = await _orderFacade.RemoveItemOrder(command);
        return CommandResult(result);
    }

    [HttpGet("{orderId}")]
    public async Task<ApiResult<OrderDto?>> GetOrderById(long orderId)
    {
        var result = await _orderFacade.GetOrderById(orderId);
        return QueryResult(result);
    }

    [HttpGet("{userId}")]
    public async Task<ApiResult<OrderDto?>> GetCurrentUserOrder(long userId)
    {
        var result = await _orderFacade.GetCurrentUserOrder(userId);
        return QueryResult(result);
    }

    [HttpGet("Filter")]
    public async Task<ApiResult<OrderFilterResult>> GetOrdersByFilter(OrderFilterParams filterParams)
    {
        var result = await _orderFacade.GetOrdersByFilter(filterParams);
        return QueryResult(result);
    }
}