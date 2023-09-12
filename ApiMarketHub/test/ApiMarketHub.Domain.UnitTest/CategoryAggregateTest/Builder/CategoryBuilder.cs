using ApiMarketHub.Domain.CategoryAggregate;
using ApiMarketHub.Domain.CategoryAggregate.Service;
using NSubstitute;
using Shared.Domain.ValueObjects;

namespace ApiMarketHub.Domain.UnitTest.CategoryAggregateTest.Builder;
public class CategoryBuilder
{
    public Category CreateCategory()
    {
        var seoDate = new SeoData("test", "test", "test", true, "test", "test");

        var categoryDomainService = Substitute.For<ICategoryDomainService>();
        categoryDomainService.IsSlugExist(Arg.Any<string>()).Returns(true);

        var category = new Category("test", "tes%$#t", seoDate, categoryDomainService);

        return category;
    }
}