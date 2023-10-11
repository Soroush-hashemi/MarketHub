using Shared.Domain.Repository;

namespace ApiMarketHub.Domain.OrderAggregate.Repository;
public interface IOrderRepository : IBaseRepository<Order>
{
    Task<Order> GetCurrentUserOrder(long userId);
}