using ApiMarketHub.Domain.ProductAggregate;
using ApiMarketHub.Domain.ProductAggregate.Repository;
using ApiMarketHub.Infrastructure.Persistence.Command;
using ApiMarketHub.Infrastructure.Repositories.Base;

namespace ApiMarketHub.Infrastructure.Repositories;
public class ProductRepository : BaseRepository<Product>, IProductRepository
{
    public ProductRepository(Context context) : base(context)
    {

    }
}