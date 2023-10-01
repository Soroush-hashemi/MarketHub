using Microsoft.AspNetCore.Http;
using Shared.Application;
using Shared.Domain.ValueObjects;

namespace ApiMarketHub.Application.Products.Create;
public class CreateProductCommand : IBaseCommand
{
    public string Title { get; private set; }
    public IFormFile ImageName { get; private set; }
    public string Description { get; private set; }
    public long CategoryId { get; private set; }
    public long SubCategoryId { get; private set; }
    public long? SecondarySubCategoryId { get; private set; }
    public string Slug { get; private set; }
    public SeoData SeoData { get; private set; }
    public Dictionary<string, string> Specifications { get; private set; }

    public CreateProductCommand(string title, IFormFile imageName, string description, long categoryId, long subCategoryId,
    long? secondarySubCategoryId, string slug, SeoData seoData, Dictionary<string, string> specifications)
    {
        Title = title;
        ImageName = imageName;
        Description = description;
        CategoryId = categoryId;
        SubCategoryId = subCategoryId;
        SecondarySubCategoryId = secondarySubCategoryId;
        Slug = slug;
        SeoData = seoData;
        Specifications = specifications;
    }
}