using ApiMarketHub.Application.Orders.AddItem;
using ApiMarketHub.Application.Orders.ChangeStatus;
using ApiMarketHub.Application.Orders.Checkout;
using ApiMarketHub.Application.Orders.DecreaseItemCount;
using ApiMarketHub.Application.Orders.Finally;
using ApiMarketHub.Application.Orders.IncreaseItemCount;
using ApiMarketHub.Application.Orders.RemoveItem;
using ApiMarketHub.Query.Orders.DTOs;
using ApiMarketHub.Query.Orders.GetByFilter;
using ApiMarketHub.Query.Orders.GetById;
using ApiMarketHub.Query.Orders.GetCurrent;
using MediatR;
using Shared.Application;

namespace ApiMarketHub.PresentationFacade.Orders;
internal class OrderFacade : IOrderFacade
{
    private readonly IMediator _mediator;
    public OrderFacade(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<OperationResult> AddItem(AddItemOrderCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> ChangeStatus(ChangeStatusOrderCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> Checkout(CheckoutOrderCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> DecreaseItemCount(DecreaseItemCountOrderCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> Finally(FinallyOrderCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> IncreaseItemCount(IncreaseItemCountOrderCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> RemoveItemOrder(RemoveItemOrderCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OrderDto?> GetCurrentUserOrder(long userId)
    {
        return await _mediator.Send(new GetCurrentUserOrderQuery(userId));
    }

    public async Task<OrderDto?> GetOrderById(long orderId)
    {
        return await _mediator.Send(new GetOrderByIdQuery(orderId));
    }

    public async Task<OrderFilterResult> GetOrdersByFilter(OrderFilterParams filterParams)
    {
        return await _mediator.Send(new GetOrdersByFilterQuery(filterParams));
    }
}