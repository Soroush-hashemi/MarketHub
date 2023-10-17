using ApiMarketHub.Query.Users.DTOs;
using Shared.Query;

namespace ApiMarketHub.Query.Users.Addresses.GetList;
public record GetUserAddressesListQuery(long userId) : IQuery<List<AddressDto>>;