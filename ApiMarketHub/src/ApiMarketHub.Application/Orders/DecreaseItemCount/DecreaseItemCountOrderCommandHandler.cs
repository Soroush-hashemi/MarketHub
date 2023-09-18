using ApiMarketHub.Domain.OrderAggregate.Repository;
using Shared.Application;

namespace ApiMarketHub.Application.Orders.DecreaseItemCount;
public class DecreaseItemCountOrderCommandHandler : IBaseCommandHandler<DecreaseItemCountOrderCommand>
{
    private readonly IOrderRepository _orderRepository;
    public DecreaseItemCountOrderCommandHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<OperationResult> Handle(DecreaseItemCountOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await _orderRepository.GetCurrentUserOrder(request.userId);
        if (order == null)
            return OperationResult.NotFound();

        order.DecreaseItemCount(request.itemId, request.count);
        await _orderRepository.Save();
        return OperationResult.Success();
    }
}