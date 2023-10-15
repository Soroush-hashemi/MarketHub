using ApiMarketHub.Query.Sellers.DTOs;
using Shared.Query;

namespace ApiMarketHub.Query.Sellers.GetById;
public class GetSellerByIdQuery : IQuery<SellerDto>
{
    public GetSellerByIdQuery(long id)
    {
        Id = id;
    }

    public long Id { get; private set; }
}