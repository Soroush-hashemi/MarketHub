using ApiMarketHub.Infrastructure.Persistence.Command;
using ApiMarketHub.Query.Sellers.DTOs;
using Microsoft.EntityFrameworkCore;
using Shared.Query;

namespace ApiMarketHub.Query.Sellers.GetByFilter;
public class SellerByFilterQueryHandler : IQueryHandler<GetSellerByFilterQuery, SellerFilterResult>
{
    private readonly MarketHubContext _context;
    public SellerByFilterQueryHandler(MarketHubContext context)
    {
        _context = context;
    }

    public async Task<SellerFilterResult> Handle(GetSellerByFilterQuery request, CancellationToken cancellationToken)
    {
        var @params = request.FilterParams;
        var result = _context.Sellers.OrderByDescending(d => d.Id).AsQueryable();

        if (!string.IsNullOrWhiteSpace(@params.NationalCode))
            result = result.Where(r => r.NationalCode.Contains(@params.NationalCode));

        if (!string.IsNullOrWhiteSpace(@params.StoreName))
            result = result.Where(r => r.StoreName.Contains(@params.StoreName));


        var skip = (@params.PageId - 1) * @params.Take;

        var sellerResult = new SellerFilterResult()
        {
            FilterParams = @params,
            Data = await result.Skip(skip).Take(@params.Take)
                .Select(seller => seller.Map())
                .ToListAsync(cancellationToken)
        };

        sellerResult.GeneratePaging(result, @params.Take, @params.PageId);
        return sellerResult;
    }
}