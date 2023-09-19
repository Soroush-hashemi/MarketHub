using ApiMarketHub.Domain.OrderAggregate.Repository;
using Shared.Application;
using System;

namespace ApiMarketHub.Application.Orders.Finally;
public class FinallyOrderCommandHandler : IBaseCommandHandler<FinallyOrderCommand>
{
    private readonly IOrderRepository _orderRepository;
    public FinallyOrderCommandHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<OperationResult> Handle(FinallyOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await _orderRepository.GetTracking(request.orderId);
        if (order == null)
            return OperationResult.NotFound();

        order.Finally();
        await _orderRepository.Save();
        return OperationResult.Success();
    }
}