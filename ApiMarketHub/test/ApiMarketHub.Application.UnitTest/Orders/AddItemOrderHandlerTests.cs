using Xunit;
using FluentAssertions;
using NSubstitute;
using ApiMarketHub.Application.Orders.AddItem;
using ApiMarketHub.Domain.OrderAggregate.Repository;
using ApiMarketHub.Domain.OrderAggregate;
using ApiMarketHub.Domain.SellerAggregate.Repository;
using Shared.Application;

public class AddItemOrderHandlerTests
{
    [Fact]
    public async Task Handle_WithValidRequest_ShouldAddItemToOrderAndSave()
    {
        // Arrange
        var orderRepository = Substitute.For<IOrderRepository>();
        var sellerRepository = Substitute.For<ISellerRepository>();

        var handler = new AddItemOrderCommandHandler(orderRepository, sellerRepository);

        var request = new AddItemOrderCommand(101 , 2 ,3);

        var inventory = new InventoryInfo
        {
            Id = 101,
            Count = 5,
            Price = 10
        };

        var order = new Order(1);

        sellerRepository.GetInventoryById(request.inventoryId).Returns(inventory);
        orderRepository.GetCurrentUserOrder(request.userId).Returns(order);

        // Act
        var result = await handler.Handle(request, CancellationToken.None);

        // Assert
        order.Items.Should().HaveCount(1)
            .And.ContainSingle(item =>
                item.InventoryId == request.inventoryId &&
                item.Count == request.count &&
                item.Price == inventory.Price);

        await orderRepository.Received(1).Save();

        result.Status.Should().Be(OperationResultStatus.Success);
    }
}