using ApiMarketHub.Domain.SellerAggregate;
using ApiMarketHub.Domain.SellerAggregate.Repository;
using ApiMarketHub.Infrastructure.Persistence.Command;
using ApiMarketHub.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace ApiMarketHub.Infrastructure.Repositories;
public class SellerRepository : BaseRepository<Seller>, ISellerRepository
{
    public SellerRepository(Context context) : base(context)
    {
    }

    public async Task<InventoryInfo?> GetInventoryById(long id)
    {
        return await _context.Inventories.Where(I => I.Id == id)
            .Select(i => new InventoryInfo()
            {
                Count = i.Count,
                Id = i.Id,
                Price = i.Price,
                ProductId = i.ProductId,
                SellerId = i.SellerId
            }).FirstOrDefaultAsync();
    }
}
