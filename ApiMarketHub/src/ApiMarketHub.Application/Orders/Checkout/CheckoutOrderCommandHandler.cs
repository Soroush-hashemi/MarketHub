using ApiMarketHub.Domain.OrderAggregate;
using ApiMarketHub.Domain.OrderAggregate.Repository;
using ApiMarketHub.Domain.OrderAggregate.ValueObjects;
using ApiMarketHub.Domain.SideEntities.Repository;
using Shared.Application;

namespace ApiMarketHub.Application.Orders.Checkout;
public class CheckoutOrderCommandHandler : IBaseCommandHandler<CheckoutOrderCommand>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IShippingMethodRepository _shippingMethodRepository;
    public CheckoutOrderCommandHandler(IOrderRepository orderRepository, IShippingMethodRepository shippingMethodRepository)
    {
        _orderRepository = orderRepository;
        _shippingMethodRepository = shippingMethodRepository;
    }

    public async Task<OperationResult> Handle(CheckoutOrderCommand request, CancellationToken cancellationToken)
    {
        var currentOrder = await _orderRepository.GetCurrentUserOrder(request.UserId);
        if (currentOrder == null)
            return OperationResult.NotFound();

        var address = new OrderAddress(request.State, request.City, request.PostalCode,
                request.AddressDetail, request.PhoneNumber, request.Name, request.Family, request.NationalCode);

        var shippingMethod = await _shippingMethodRepository.GetAsync(request.ShippingMethodId);
        if (shippingMethod == null)
            return OperationResult.Error();

        currentOrder.Checkout(address, new OrderShippingMethod(shippingMethod.Title, shippingMethod.Cost));
        await _orderRepository.Save();
        return OperationResult.Success();
    }
}