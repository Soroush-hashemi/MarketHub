using ApiMarketHub.Domain.ProductAggregate.Service;
using Shared.Domain.Bases;
using Shared.Domain.Exceptions;
using Shared.Domain.Tools;
using Shared.Domain.ValueObjects;

namespace ApiMarketHub.Domain.ProductAggregate;
public class Product : AggregateRoot
{
    public string Title { get; private set; }
    public string ImageName { get; private set; }
    public string Description { get; private set; }
    public long CategoryId { get; private set; }
    public long SubCategoryId { get; private set; }
    public long? SecondarySubCategoryId { get; private set; }
    public string Slug { get; private set; }
    public SeoData SeoData { get; private set; }
    public List<ProductImage> Images { get; private set; }
    public List<ProductSpecification> Specifications { get; private set; }

    private Product()
    {

    }

    public Product(string title, string imageName, string description, long categoryId, long subCategoryId,
        long? secondarySubCategoryId, IProductDomainService domainService, string slug, SeoData seoData)
    {
        NullOrEmptyException.CheckString(imageName, nameof(imageName));
        Guard(title, slug, description, domainService);

        Title = title;
        ImageName = imageName;
        Description = description;
        CategoryId = categoryId;
        SubCategoryId = subCategoryId;
        SecondarySubCategoryId = secondarySubCategoryId;
        Slug = slug.ToSlug();
        SeoData = seoData;
    }

    public void Edit(string title, string description, long categoryId, long subCategoryId, long secondarySubCategoryId,
        string slug, IProductDomainService domainService, SeoData seoData)
    {
        Guard(title, slug, description, domainService);
        Title = title;
        Description = description;
        CategoryId = categoryId;
        SubCategoryId = subCategoryId;
        SecondarySubCategoryId = secondarySubCategoryId;
        Slug = slug.ToSlug();
        SeoData = seoData;
    }

    public void SetProductImage(string imageName)
    {
        NullOrEmptyException.CheckString(imageName, nameof(imageName));
        ImageName = imageName;
    }

    public void AddImage(ProductImage image)
    {
        image.ProductId = Id;
        Images.Add(image);
    }

    public string RemoveImage(long id)
    {
        var image = Images.FirstOrDefault(f => f.Id == id);
        if (image == null)
            throw new NullOrEmptyException("Image is null");

        Images.Remove(image);
        return image.ImageName;
    }

    public void SetSpecification(List<ProductSpecification> specifications)
    {
        specifications.ForEach(s => s.ProductId = Id); // تمام مقادیری که ایدی اونا با پروداکت ما یکی هست رو پیدا میکنه 
        Specifications = specifications; // و در اینجا ستش میکنه 
    }

    private void Guard(string title, string slug, string description, IProductDomainService domainService)
    {
        NullOrEmptyException.CheckString(title, nameof(title));
        NullOrEmptyException.CheckString(description, nameof(description));
        NullOrEmptyException.CheckString(slug, nameof(slug));

        if (slug != Slug)
            if (domainService.SlugIsExist(slug.ToSlug()))
                throw new SlugAlreadyExistsException();
    }
}