using ApiMarketHub.Query.Sellers.DTOs;
using Shared.Query;

namespace ApiMarketHub.Query.Sellers.GetByFilter;
public class GetSellerByFilterQuery : QueryFilter<SellerFilterResult, SellerFilterParams>
{
    public GetSellerByFilterQuery(SellerFilterParams filterParams) : base(filterParams)
    {
        
    }
}