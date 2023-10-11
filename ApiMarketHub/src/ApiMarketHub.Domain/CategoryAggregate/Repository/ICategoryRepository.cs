using Shared.Domain.Repository;

namespace ApiMarketHub.Domain.CategoryAggregate.Repository;
public interface ICategoryRepository : IBaseRepository<Category>
{
    Task<bool> DeleteCategory(long categoryId);
}