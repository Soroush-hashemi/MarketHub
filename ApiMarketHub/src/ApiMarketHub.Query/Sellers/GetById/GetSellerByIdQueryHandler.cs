using ApiMarketHub.Infrastructure.Persistence.Command;
using ApiMarketHub.Query.Sellers.DTOs;
using Microsoft.EntityFrameworkCore;
using Shared.Query;

namespace ApiMarketHub.Query.Sellers.GetById;
public class GetSellerByIdQueryHandler : IQueryHandler<GetSellerByIdQuery, SellerDto?>
{
    private readonly MarketHubContext _context;
    public GetSellerByIdQueryHandler(MarketHubContext context)
    {
        _context = context;
    }

    public async Task<SellerDto?> Handle(GetSellerByIdQuery request, CancellationToken cancellationToken)
    {
        var seller = await _context.Sellers.FirstOrDefaultAsync(s => s.Id == request.Id, cancellationToken);
        if (seller == null)
            throw new ArgumentNullException();

        var sellerDto = seller.Map();
        return sellerDto;
    }
}