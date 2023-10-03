using ApiMarketHub.Domain.CategoryAggregate;
using ApiMarketHub.Domain.CategoryAggregate.Repository;
using ApiMarketHub.Infrastructure.Persistence.Command;
using ApiMarketHub.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace ApiMarketHub.Infrastructure.Repositories;
public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
{
    public CategoryRepository(Context context) : base(context)
    {
    }

    public async Task<bool> DeleteCategory(long categoryId)
    {
        var category = await _context.Categories.Include(c => c.Childs).Include(c => c.Childs)
            .FirstOrDefaultAsync(c => c.Id.Equals(categoryId));

        if (category == null)
            return false;

        var hasProductsInCategory = await _context.Products
            .AnyAsync(c => c.CategoryId == categoryId || c.SubCategoryId == categoryId || c.SecondarySubCategoryId == categoryId);


        if (hasProductsInCategory)
            return false;

        if (category.Childs.Any(c => c.Childs.Any()))
        {
            _context.RemoveRange(category.Childs.SelectMany(s => s.Childs));
        }
        _context.RemoveRange(category.Childs);
        _context.RemoveRange(category);

        return true;
    }
}