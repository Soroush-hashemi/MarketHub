using ApiMarketHub.Domain.SellerAggregate.Enum;
using Shared.Query.Bases;

namespace ApiMarketHub.Query.Sellers.DTOs;
public class SellerDto : BaseDto
{
    public long UserId { get; set; }
    public string StoreName { get; set; }
    public string NationalCode { get; set; }
    public SellerStatus Status { get; set; }
}

public class SellerFilterResult : BaseFilter<SellerDto, SellerFilterParams>
{

}

public class SellerFilterParams : BaseFilterParam
{
    public string StoreName { get; set; }
    public string NationalCode { get; set; }
}