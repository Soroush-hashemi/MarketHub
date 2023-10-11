using ApiMarketHub.Infrastructure.Persistence.Command;
using ApiMarketHub.Infrastructure.Persistence.Query;
using ApiMarketHub.Query.Orders.DTOs;
using Microsoft.EntityFrameworkCore;
using Shared.Query;

namespace ApiMarketHub.Query.Orders.GetCurrent;
public class GetCurrentUserOrderQueryHandler : IQueryHandler<GetCurrentUserOrderQuery, OrderDto?>
{
    private readonly MarketHubContext _context;
    private readonly DapperContext _dapperContext;
    public GetCurrentUserOrderQueryHandler(MarketHubContext context, DapperContext dapperContext)
    {
        _context = context;
        _dapperContext = dapperContext;
    }

    public async Task<OrderDto?> Handle(GetCurrentUserOrderQuery request, CancellationToken cancellationToken)
    {
        var order = await _context.Orders.FirstOrDefaultAsync(o => o.Id == request.orderId);
        if (order == null)
            throw new NullReferenceException();

        var orderDto = order.Map();
        orderDto.UserFullName = await _context.Users.Where(f => f.Id == orderDto.UserId)
            .Select(s => $"{s.Name} {s.Family}").FirstAsync(cancellationToken);

        orderDto.Items = await orderDto.GetOrderItems(_dapperContext);
        return orderDto;
    }
}