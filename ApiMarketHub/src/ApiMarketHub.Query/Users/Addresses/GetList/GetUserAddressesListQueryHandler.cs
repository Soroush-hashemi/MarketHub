using ApiMarketHub.Infrastructure.Persistence.Query;
using ApiMarketHub.Query.Users.DTOs;
using Dapper;
using Shared.Query;

namespace ApiMarketHub.Query.Users.Addresses.GetList;
public class GetUserAddressesListQueryHandler : IQueryHandler<GetUserAddressesListQuery, List<AddressDto>>
{
    private readonly DapperContext _dappercontext;
    public GetUserAddressesListQueryHandler(DapperContext dappercontext)
    {
        _dappercontext = dappercontext;
    }

    public async Task<List<AddressDto>> Handle(GetUserAddressesListQuery request, CancellationToken cancellationToken)
    {
        var sql = $"SELECT * from {_dappercontext.UserAddresses} where UserId=@userId";
        var connection = _dappercontext.CreateConnection();

        var result = await connection.QueryAsync<AddressDto>(sql, new { userId = request.userId });
        return result.ToList();
    }
}