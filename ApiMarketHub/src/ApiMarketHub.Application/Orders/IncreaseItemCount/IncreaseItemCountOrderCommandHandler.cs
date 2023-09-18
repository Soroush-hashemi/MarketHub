using ApiMarketHub.Domain.OrderAggregate.Repository;
using Shared.Application;

namespace ApiMarketHub.Application.Orders.IncreaseItemCount;
public class IncreaseItemCountOrderCommandHandler : IBaseCommandHandler<IncreaseItemCountOrderCommand>
{
    private readonly IOrderRepository _orderRepository;
    public IncreaseItemCountOrderCommandHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<OperationResult> Handle(IncreaseItemCountOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await _orderRepository.GetCurrentUserOrder(request.userId);
        if (order == null)
            return OperationResult.NotFound();

        order.IncreaseItemCount(request.itemId, request.count);
        await _orderRepository.Save();
        return OperationResult.Success();
    }
}