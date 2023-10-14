using ApiMarketHub.Infrastructure.Persistence.Command;
using ApiMarketHub.Query.Products.DTOs;
using Microsoft.EntityFrameworkCore;
using Shared.Domain.Exceptions;
using Shared.Query;

namespace ApiMarketHub.Query.Products.GetById;
public class GetProductByIdQueryHandler : IQueryHandler<GetProductByIdQuery, ProductDto?>
{
    private readonly MarketHubContext _context;
    public GetProductByIdQueryHandler(MarketHubContext context)
    {
        _context = context;
    }

    public async Task<ProductDto?> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await _context.Products
            .FirstOrDefaultAsync(f => f.Id == request.ProductId, cancellationToken);

        var productDto = product.Map();
        if (productDto == null)
            throw new NullOrEmptyException();

        await productDto.SetCategories(_context);
        return productDto;

    }
}