using ApiMarketHub.Domain.CategoryAggregate.Service;
using Shared.Domain.Bases;
using Shared.Domain.Exceptions;
using Shared.Domain.Tools;
using Shared.Domain.ValueObjects;

namespace ApiMarketHub.Domain.CategoryAggregate;
public class Category : AggregateRoot
{
    public string Title { get; private set; }
    public string Slug { get; private set; }
    public SeoData SeoData { get; private set; }
    public long? ParentId { get; private set; }
    public List<Category> Childs { get; private set; }

    private Category()
    {
        Childs = new List<Category>();
    }

    public Category(string title, string slug, SeoData seoData, ICategoryDomainService service)
    {
        slug?.ToSlug();
        Guard(title, slug, service);
        Title = title;
        Slug = slug;
        SeoData = seoData;
        Childs = new List<Category>();
    }

    public void Edit(string title, string slug, SeoData seoData, ICategoryDomainService service)
    {
        slug?.ToSlug();
        Guard(title, slug, service);
        Title = title;
        Slug = slug;
        SeoData = seoData;
    }

    public void AddChild(string title, string slug, SeoData seoData, ICategoryDomainService service)
    {
        Guard(title, slug, service);
        Childs.Add(new Category(title, slug, seoData, service)
        {
            ParentId = Id
        });
    }

    public void Guard(string title, string slug, ICategoryDomainService service)
    {
        NullOrEmptyException.CheckString(title, nameof(title));
        NullOrEmptyException.CheckString(slug, nameof(slug));

        if (slug != Slug)
            if (service.IsSlugExist(slug) == false)
                throw new SlugAlreadyExistsException();
    }
}