using ApiMarketHub.Domain.OrderAggregate;
using ApiMarketHub.Domain.OrderAggregate.Repository;
using ApiMarketHub.Infrastructure.Persistence.Command;
using ApiMarketHub.Infrastructure.Repositories.Base;

namespace ApiMarketHub.Infrastructure.Repositories;
public class OrderRepository : BaseRepository<Order>, IOrderRepository
{
    public OrderRepository(Context context) : base(context)
    {
    }

    public Task<Order> GetCurrentUserOrder(long userId)
    {
        throw new NotImplementedException();
    }
}