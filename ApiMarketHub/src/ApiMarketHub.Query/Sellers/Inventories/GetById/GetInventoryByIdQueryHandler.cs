using ApiMarketHub.Infrastructure.Persistence.Query;
using ApiMarketHub.Query.Sellers.DTOs;
using Dapper;
using Shared.Query;

namespace ApiMarketHub.Query.Sellers.Inventories.GetById;
internal class GetInventoryByIdQueryHandler : IQueryHandler<GetInventoryByIdQuery, InventoryDto?>
{
    private readonly DapperContext _context;
    public GetInventoryByIdQueryHandler(DapperContext context)
    {
        _context = context;
    }

    public async Task<InventoryDto?> Handle(GetInventoryByIdQuery request, CancellationToken cancellationToken)
    {
        var connection = _context.CreateConnection();

        var sql = @$"SELECT Top(1) i.Id, SellerId , ProductId ,Count , Price,i.CreationDate , DiscountPercentage , s.ShopName,
                        p.Title as ProductTitle,p.ImageName as ProductImage
            FROM {_context.Inventories} i inner join {_context.Sellers} s on i.SellerId=s.Id  
            inner join {_context.Products} p on i.ProductId=p.Id WHERE i.Id=@id";

        var inventory = await connection.QueryFirstOrDefaultAsync<InventoryDto>(sql, new { id = request.Id });
        if (inventory == null)
            throw new ArgumentNullException();

        return inventory;
    }
}