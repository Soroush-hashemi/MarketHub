using ApiMarketHub.Domain.CategoryAggregate.Repository;
using ApiMarketHub.Domain.CategoryAggregate.Service;

namespace ApiMarketHub.Application.Categories;
public class CategoryDomainService : ICategoryDomainService
{
    private readonly ICategoryRepository _repository;
    public CategoryDomainService(ICategoryRepository repository)
    {
        _repository = repository;
    }

    public bool IsSlugExist(string slug)
    {
        var Exists = _repository.Exists(s => s.Slug == slug); //  اگر در سیستم وجود نداشت 0 رو برگشت میده
        if (Exists == false)
            return true;
        return false;
    }
}