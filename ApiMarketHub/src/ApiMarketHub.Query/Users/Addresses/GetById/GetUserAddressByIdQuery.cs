
using ApiMarketHub.Query.Users.DTOs;
using Shared.Query;

namespace ApiMarketHub.Query.Users.Addresses.GetById;
public record GetUserAddressByIdQuery(long Id) : IQuery<AddressDto?>;