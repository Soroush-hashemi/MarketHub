using ApiMarketHub.Query.Sellers.DTOs;
using Shared.Query;

namespace ApiMarketHub.Query.Sellers.GetByUserId;
public record GetSellerByUserIdQuery(long userId) : IQuery<SellerDto?>;