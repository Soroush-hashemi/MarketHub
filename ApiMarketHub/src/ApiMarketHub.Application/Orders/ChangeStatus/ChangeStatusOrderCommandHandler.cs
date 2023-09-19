using ApiMarketHub.Domain.OrderAggregate.Repository;
using Shared.Application;

namespace ApiMarketHub.Application.Orders.ChangeStatus;
public class ChangeStatusOrderCommandHandler : IBaseCommandHandler<ChangeStatusOrderCommand>
{
    private readonly IOrderRepository _orderRepository;
    public ChangeStatusOrderCommandHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<OperationResult> Handle(ChangeStatusOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await _orderRepository.GetTracking(request.orderId);
        if (order == null)
            return OperationResult.NotFound();

        order.ChangeStatus(request.changeStatus);
        await _orderRepository.Save();
        return OperationResult.Success();
    }
}