using ApiMarketHub.Domain.CategoryAggregate;
using ApiMarketHub.Domain.CategoryAggregate.Repository;
using ApiMarketHub.Infrastructure.Persistence.Command;
using ApiMarketHub.Infrastructure.Repositories.Base;

namespace ApiMarketHub.Infrastructure.Repositories;
public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
{
    public CategoryRepository(Context context) : base(context)
    {
    }

    public Task<bool> DeleteCategory(long categoryId)
    {
        throw new NotImplementedException();
    }
}