using ApiMarketHub.Infrastructure.Persistence.Command;
using ApiMarketHub.Query.Categories.DTOs;
using Microsoft.EntityFrameworkCore;
using Shared.Query;

namespace ApiMarketHub.Query.Categories.GetById;
public class GetCategoryByIdQueryHandler : IQueryHandler<GetCategoryByIdQuery, CategoryDto>
{
    private readonly MarketHubContext _context;
    public GetCategoryByIdQueryHandler(MarketHubContext context)
    {
        _context = context;
    }

    public async Task<CategoryDto> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == request.CategoryId, cancellationToken);
        if (category == null)
            throw new ArgumentNullException();

        return category.Map();
    }
}