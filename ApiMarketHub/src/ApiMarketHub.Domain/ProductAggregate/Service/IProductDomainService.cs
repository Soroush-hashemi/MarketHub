namespace ApiMarketHub.Domain.ProductAggregate.Service;
public interface IProductDomainService
{
    bool SlugIsExist(string slug);
}