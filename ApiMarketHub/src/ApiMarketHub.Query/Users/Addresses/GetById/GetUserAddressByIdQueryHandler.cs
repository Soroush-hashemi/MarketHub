using ApiMarketHub.Infrastructure.Persistence.Query;
using ApiMarketHub.Query.Users.DTOs;
using Dapper;
using Shared.Query;

namespace ApiMarketHub.Query.Users.Addresses.GetById;
public class GetUserAddressByIdQueryHandler : IQueryHandler<GetUserAddressByIdQuery, AddressDto?>
{
    private readonly DapperContext _dapperContext;
    public GetUserAddressByIdQueryHandler(DapperContext dapperContext)
    {
        _dapperContext = dapperContext;
    }

    public async Task<AddressDto?> Handle(GetUserAddressByIdQuery request, CancellationToken cancellationToken)
    {
        var sql = $"SELECT top 1 * from {_dapperContext.UserAddresses} where Id=@Id";
        var connection = _dapperContext.CreateConnection();

        return await connection.QueryFirstAsync<AddressDto>(sql, new { Id = request.Id });
    }
}