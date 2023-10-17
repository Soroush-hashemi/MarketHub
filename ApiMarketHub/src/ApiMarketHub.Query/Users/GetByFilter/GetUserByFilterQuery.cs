using ApiMarketHub.Query.Users.DTOs;
using Shared.Query;

namespace ApiMarketHub.Query.Users.GetByFilter;

public class GetUserByFilterQuery : QueryFilter<UserFilterResult, UserFilterParams>
{
    public GetUserByFilterQuery(UserFilterParams filterParams) : base(filterParams)
    {
    }
}