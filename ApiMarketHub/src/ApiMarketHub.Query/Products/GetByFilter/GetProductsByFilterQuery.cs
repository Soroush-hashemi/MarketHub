using ApiMarketHub.Query.Products.DTOs;
using Shared.Query;

namespace ApiMarketHub.Query.Products.GetByFilter;
public class GetProductsByFilterQuery : QueryFilter<ProductFilterResult, ProductFilterParams>
{
    public GetProductsByFilterQuery(ProductFilterParams productFilterParams) : base(productFilterParams)
    {
        
    }
}