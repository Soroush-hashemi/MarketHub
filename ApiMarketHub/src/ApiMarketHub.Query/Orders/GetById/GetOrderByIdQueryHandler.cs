using ApiMarketHub.Infrastructure.Persistence.Command;
using ApiMarketHub.Infrastructure.Persistence.Query;
using ApiMarketHub.Query.Orders.DTOs;
using Microsoft.EntityFrameworkCore;
using Shared.Query;

namespace ApiMarketHub.Query.Orders.GetById;
public class GetOrderByIdQueryHandler : IQueryHandler<GetOrderByIdQuery, OrderDto?>
{
    private readonly Context _context;
    private readonly DapperContext _dapperContext;

    public GetOrderByIdQueryHandler(Context context, DapperContext dapperContext)
    {
        _context = context;
        _dapperContext = dapperContext;
    }

    public async Task<OrderDto?> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
    {
        var order = await _context.Orders.FirstOrDefaultAsync(o => o.Id == request.orderId);
        if (order == null)
            throw new NullReferenceException();

        var orderDto = order.Map();

        orderDto.UserFullName = await _context.Users.Where(u => u.Id == orderDto.UserId)
            .Select(u => $"{u.Name} {u.Family}").FirstAsync(cancellationToken);

        orderDto.Items = await orderDto.GetOrderItems(_dapperContext);

        return orderDto;
    }
}