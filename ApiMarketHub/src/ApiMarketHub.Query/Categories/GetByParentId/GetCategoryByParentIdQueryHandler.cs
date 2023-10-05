using ApiMarketHub.Infrastructure.Persistence.Command;
using ApiMarketHub.Query.Categories.DTOs;
using Microsoft.EntityFrameworkCore;
using Shared.Query;

namespace ApiMarketHub.Query.Categories.GetByParentId;
public class GetCategoryByParentIdQueryHandler : IQueryHandler<GetCategoryByParentIdQuery, List<SubCategoryDto>>
{
    private readonly Context _context;
    public GetCategoryByParentIdQueryHandler(Context context)
    {
        _context = context;
    }

    public async Task<List<SubCategoryDto>> Handle(GetCategoryByParentIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Categories.Include(c => c.Childs).Where(c => c.ParentId == request.ParentId).ToListAsync();
        return result.MapSubCategory();
    }
}