using ApiMarketHub.Infrastructure.Persistence.Command;
using ApiMarketHub.Query.Sellers.DTOs;
using Microsoft.EntityFrameworkCore;
using Shared.Query;

namespace ApiMarketHub.Query.Sellers.GetByUserId;
public class GetSellerByUserIdQueryHandler : IQueryHandler<GetSellerByUserIdQuery, SellerDto?>
{
    private readonly MarketHubContext _context;
    public GetSellerByUserIdQueryHandler(MarketHubContext context)
    {
        _context = context;
    }

    public async Task<SellerDto?> Handle(GetSellerByUserIdQuery request, CancellationToken cancellationToken)
    {
        var seller = await _context.Sellers.FirstOrDefaultAsync(u => u.UserId == request.userId, cancellationToken);
        if (seller == null)
            throw new ArgumentNullException();

        var sellerDto = seller.Map();
        return sellerDto;
    }
}