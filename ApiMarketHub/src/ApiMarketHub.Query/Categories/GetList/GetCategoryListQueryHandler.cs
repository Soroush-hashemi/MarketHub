using ApiMarketHub.Infrastructure.Persistence.Command;
using ApiMarketHub.Query.Categories.DTOs;
using Microsoft.EntityFrameworkCore;
using Shared.Query;

namespace ApiMarketHub.Query.Categories.GetList;
public class GetCategoryListQueryHandler : IQueryHandler<GetCategoryListQuery, List<CategoryDto>>
{
    private readonly MarketHubContext _context;
    public GetCategoryListQueryHandler(MarketHubContext context)
    {
        _context = context;
    }

    public async Task<List<CategoryDto>> Handle(GetCategoryListQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Categories.Where(c => c.ParentId == null)
            .Include(c => c.Childs).ThenInclude(c => c.Childs).OrderByDescending(c => c.Id).ToListAsync(cancellationToken);

        return result.MapList();
    }
}