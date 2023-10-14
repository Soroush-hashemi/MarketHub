using ApiMarketHub.Infrastructure.Persistence.Command;
using ApiMarketHub.Query.Products.DTOs;
using Microsoft.EntityFrameworkCore;
using Shared.Domain.Exceptions;
using Shared.Query;

namespace ApiMarketHub.Query.Products.GetBySlug;
public class GetProductBySlugQueryHandler : IQueryHandler<GetProductBySlugQuery, ProductDto?>
{
    private readonly MarketHubContext _context;
    public GetProductBySlugQueryHandler(MarketHubContext context)
    {
        _context = context;
    }

    public async Task<ProductDto> Handle(GetProductBySlugQuery request, CancellationToken cancellationToken)
    {
        var product = await _context.Products
            .FirstOrDefaultAsync(f => f.Slug == request.Slug, cancellationToken);
        var productDto = product.Map();

        if (productDto == null)
            throw new NullOrEmptyException();

        await productDto.SetCategories(_context);
        return productDto;
    }
}