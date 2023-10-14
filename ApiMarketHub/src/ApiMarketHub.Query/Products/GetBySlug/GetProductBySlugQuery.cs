using ApiMarketHub.Query.Products.DTOs;
using Shared.Query;

namespace ApiMarketHub.Query.Products.GetBySlug;
public class GetProductBySlugQuery : IQuery<ProductDto?>
{
    public GetProductBySlugQuery(string slug)
    {
        Slug = slug;
    }

    public string Slug { get; private set; }

}