using ApiMarketHub.Domain.ProductAggregate.Repository;
using ApiMarketHub.Domain.ProductAggregate.Service;

namespace ApiMarketHub.Application.Products;
public class ProductDomainService : IProductDomainService
{
    private readonly IProductRepository _repository;
    public ProductDomainService(IProductRepository repository)
    {
        _repository = repository;

    }
    public bool SlugIsExist(string slug)
    {
        return _repository.Exists(s =>  s.Slug == slug);
    }
}