using ApiMarketHub.Domain.OrderAggregate.Repository;
using Shared.Application;

namespace ApiMarketHub.Application.Orders.RemoveItem;
public class RemoveItemOrderCommandHandler : IBaseCommandHandler<RemoveItemOrderCommand>
{
    private readonly IOrderRepository _orderRepository;
    public RemoveItemOrderCommandHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<OperationResult> Handle(RemoveItemOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await _orderRepository.GetCurrentUserOrder(request.userId);
        if (order == null)
            return OperationResult.NotFound();

        order.RemoveItem(request.ItemId);
        await _orderRepository.Save();
        return OperationResult.Success();
    }
}