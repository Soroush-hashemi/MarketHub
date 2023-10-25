using ApiMarketHub.Application.Orders.AddItem;
using ApiMarketHub.Application.Orders.ChangeStatus;
using ApiMarketHub.Application.Orders.Checkout;
using ApiMarketHub.Application.Orders.DecreaseItemCount;
using ApiMarketHub.Application.Orders.Finally;
using ApiMarketHub.Application.Orders.IncreaseItemCount;
using ApiMarketHub.Application.Orders.RemoveItem;
using ApiMarketHub.Query.Orders.DTOs;
using Shared.Application;

namespace ApiMarketHub.PresentationFacade.Orders;
public interface IOrderFacade
{
    Task<OperationResult> AddItem(AddItemOrderCommand command);
    Task<OperationResult> ChangeStatus(ChangeStatusOrderCommand command);
    Task<OperationResult> Checkout(CheckoutOrderCommand command);
    Task<OperationResult> DecreaseItemCount(DecreaseItemCountOrderCommand command);
    Task<OperationResult> IncreaseItemCount(IncreaseItemCountOrderCommand command);
    Task<OperationResult> FinallyOrderCommand(FinallyOrderCommand command);
    Task<OperationResult> RemoveItemOrder(RemoveItemOrderCommand command);

    Task<OrderDto?> GetCurrentUserOrder(long userId);
    Task<OrderDto?> GetOrderById(long orderId);
    Task<OrderFilterResult> GetOrdersByFilter(OrderFilterParams filterParams);
}