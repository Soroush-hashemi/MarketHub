using ApiMarketHub.Domain.SellerAggregate;
using ApiMarketHub.Query.Sellers.DTOs;

namespace ApiMarketHub.Query.Sellers;
public static class SellerMapper
{
    public static SellerDto Map(this Seller seller)
    {
        if (seller == null)
            throw new ArgumentNullException();

        return new SellerDto()
        {
            Id = seller.Id,
            CreationDate = seller.CreationDate,
            Status = seller.Status,
            NationalCode = seller.NationalCode,
            StoreName = seller.StoreName,
            UserId = seller.UserId
        };
    }
}