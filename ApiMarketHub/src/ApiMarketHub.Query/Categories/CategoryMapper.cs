using ApiMarketHub.Domain.CategoryAggregate;
using ApiMarketHub.Query.Categories.DTOs;

namespace ApiMarketHub.Query.Categories;
internal static class CategoryMapper
{
    public static CategoryDto Map(this Category? category)
    {
        return new CategoryDto()
        {
            Title = category.Title,
            Slug = category.Slug,
            Id = category.Id,
            SeoData = category.SeoData,
            CreationDate = category.CreationDate,
            Childs = category.Childs.MapSubCategory()
        };
    }

    public static List<CategoryDto> MapList(this List<Category> categories)
    {
        var model = new List<CategoryDto>();

        categories.ForEach(category =>
        {
            model.Add(new CategoryDto()
            {
                Title = category.Title,
                Slug = category.Slug,
                Id = category.Id,
                SeoData = category.SeoData,
                CreationDate = category.CreationDate,
                Childs = category.Childs.MapSubCategory()
            });
        });
        return model;
    }

    public static List<SubCategoryDto> MapSubCategory(this List<Category> child)
    {
        var model = new List<SubCategoryDto>();

        child.ForEach(c =>
        {
            model.Add(new SubCategoryDto()
            {
                Title = c.Title,
                Slug = c.Slug,
                Id = c.Id,
                SeoData = c.SeoData,
                CreationDate = c.CreationDate,
                ParentId = (long)c.ParentId,
                Childs = c.Childs.SecondarySubCategory()
            });
        });
        return model;
    }

    private static List<SecondarySubCategoryDto> SecondarySubCategory(this List<Category> child)
    {
        var model = new List<SecondarySubCategoryDto>();
        child.ForEach(c =>
        {
            model.Add(new SecondarySubCategoryDto()
            {
                Title = c.Title,
                Slug = c.Slug,
                Id = c.Id,
                SeoData = c.SeoData,
                CreationDate = c.CreationDate,
                ParentId = (long)c.ParentId,
            });
        });
        return model;
    }
}