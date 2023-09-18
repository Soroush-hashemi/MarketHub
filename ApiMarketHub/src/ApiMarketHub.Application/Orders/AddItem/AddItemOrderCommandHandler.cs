using ApiMarketHub.Domain.OrderAggregate;
using ApiMarketHub.Domain.OrderAggregate.Repository;
using ApiMarketHub.Domain.SellerAggregate.Repository;
using Shared.Application;

namespace ApiMarketHub.Application.Orders.AddItem;
public class AddItemOrderCommandHandler : IBaseCommandHandler<AddItemOrderCommand>
{
    private readonly IOrderRepository _orderRepository;
    private readonly ISellerRepository _sellerRepository;
    public AddItemOrderCommandHandler(IOrderRepository orderRepository, ISellerRepository sellerRepository)
    {
        _orderRepository = orderRepository;
        _sellerRepository = sellerRepository;
    }

    public async Task<OperationResult> Handle(AddItemOrderCommand request, CancellationToken cancellationToken)
    {
        var inventory = await _sellerRepository.GetInventoryById(request.inventoryId);

        if (inventory == null)
            return OperationResult.NotFound();
        if (inventory.Count < request.count)
            return OperationResult.Error("تعداد درخواستی کمتر از تعداد انبار است");

        var order = await _orderRepository.GetCurrentUserOrder(request.userId);

        if (order == null)
        {
            order = new Order(request.userId);
            order.AddItem(new OrderItem(request.inventoryId, request.count, inventory.Price));
            _orderRepository.Add(order);
        }
        else
        {
            order.AddItem(new OrderItem(request.inventoryId, request.count, inventory.Price));
        }

        if (ItemCountBeggerThanInventoryCount(inventory, order) == true)
            return OperationResult.Error("تعداد درخواستی کمتر از تعداد انبار است");

        await _orderRepository.Save();
        return OperationResult.Success();
    }

    private bool ItemCountBeggerThanInventoryCount(InventoryInfo inventory, Order order)
    {
        var orderItem = order.Items.First(f => f.InventoryId == inventory.Id);
        if (orderItem.Count > inventory.Count)
            return true;

        return false;
    }
}