using ApiMarketHub.Query.Users.DTOs;
using Shared.Query;

namespace ApiMarketHub.Query.Users.GetByPhoneNumber;
public record GetUserByPhoneNumberQuery(string phoneNumber) : IQuery<UserDto?>;