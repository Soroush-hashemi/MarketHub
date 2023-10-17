using ApiMarketHub.Query.Users.DTOs;
using Shared.Query;

namespace ApiMarketHub.Query.Users.GetById;
public class GetUserByIdQuery : IQuery<UserDto?>
{
    public long UserId { get; private set; }
    public GetUserByIdQuery(long userId)
    {
        UserId = userId;
    }
}