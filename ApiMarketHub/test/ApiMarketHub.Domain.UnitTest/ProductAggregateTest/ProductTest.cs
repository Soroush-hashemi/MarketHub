using ApiMarketHub.Domain.ProductAggregate;
using ApiMarketHub.Domain.ProductAggregate.Service;
using FluentAssertions;
using NSubstitute;
using Shared.Domain.Exceptions;
using Shared.Domain.ValueObjects;
using Xunit;

namespace ApiMarketHub.Domain.UnitTest.ProductAggregateTest;
public class ProductTest
{
    [Fact]
    public void IsSlugExist_Should_Throw_SlugAlreadyExistsException_When_SlugIsExist_EqualTo_False()
    {
        // Arrange
        var domainService = Substitute.For<IProductDomainService>();
        domainService.SlugIsExist(Arg.Any<string>()).Returns(false);
        var seoDate = new SeoData("test", "test", "test", true, "test", "test");

        // Act
        Action act = () => new Product("test2", "test2", "test2", 12, 21, 5, domainService, "test2", seoDate);

        // Assert
        act.Should().Throw<SlugAlreadyExistsException>();
    }

    [Fact]
    public void IsSlugExist_Should_NotDoAnything_When_SlugIsExist_EqualTo_True()
    {
        // Arrange
        var domainService = Substitute.For<IProductDomainService>();
        domainService.SlugIsExist(Arg.Any<string>()).Returns(true);
        var seoDate = new SeoData("test", "test", "test", true, "test", "test");

        // Act
        var product = new Product("test2", "test2", "test2", 12, 21, 5, domainService, "test2", seoDate);

        // Assert
        product.Slug.Should().Be("test2");
    }

}