using ApiMarketHub.Domain.SellerAggregate;
using ApiMarketHub.Domain.SellerAggregate.Repository;
using ApiMarketHub.Infrastructure.Persistence.Command;
using ApiMarketHub.Infrastructure.Persistence.Query;
using ApiMarketHub.Infrastructure.Repositories.Base;
using Dapper;

namespace ApiMarketHub.Infrastructure.Repositories;
public class SellerRepository : BaseRepository<Seller>, ISellerRepository
{
    private readonly DapperContext _dapperContext;
    public SellerRepository(Context context, DapperContext dapperContext) : base(context)
    {
        _dapperContext = dapperContext;
    }

    public async Task<InventoryInfo?> GetInventoryById(long id)
    {
        using var connection = _dapperContext.CreateConnection();
        var sql = $"SELECT * from {_dapperContext.Inventories} where Id=@InventoryId";

        return await connection.QueryFirstOrDefaultAsync<InventoryInfo>
            (sql, new { InventoryId = id });
    }
}
