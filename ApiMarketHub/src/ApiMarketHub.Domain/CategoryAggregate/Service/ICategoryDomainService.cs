namespace ApiMarketHub.Domain.CategoryAggregate.Service;
public interface ICategoryDomainService
{
    public bool IsSlugExist(string slug);
}