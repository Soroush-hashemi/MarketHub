using ApiMarketHub.Domain.OrderAggregate;
using ApiMarketHub.Domain.OrderAggregate.Enum;
using ApiMarketHub.Domain.OrderAggregate.Repository;
using ApiMarketHub.Infrastructure.Persistence.Command;
using ApiMarketHub.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace ApiMarketHub.Infrastructure.Repositories;
public class OrderRepository : BaseRepository<Order>, IOrderRepository
{
    public OrderRepository(Context context) : base(context)
    {
    }

    public async Task<Order> GetCurrentUserOrder(long userId)
    {
        var UserOrder = await _context.Orders.AsTracking().FirstOrDefaultAsync(f => f.UserId == userId && f.Status == OrderStatus.Pending);
        if (UserOrder == null)
            return null;

        return UserOrder;
    }
}