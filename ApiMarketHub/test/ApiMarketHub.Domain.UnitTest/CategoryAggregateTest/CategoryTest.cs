using ApiMarketHub.Domain.CategoryAggregate.Service;
using ApiMarketHub.Domain.UnitTest.CategoryAggregateTest.Builder;
using ApiMarketHub.Domain.UserAggregate.Service;
using ApiMarketHub.Domain.UserAggregate;
using FluentAssertions;
using NSubstitute;
using Shared.Domain.Exceptions;
using Xunit;
using ApiMarketHub.Domain.CategoryAggregate;
using Shared.Domain.ValueObjects;
using System;

namespace ApiMarketHub.Domain.UnitTest.CategoryAggregateTest;
public class CategoryTest
{
    private readonly CategoryBuilder _categoryBuilder;
    public CategoryTest()
    {
        _categoryBuilder = new CategoryBuilder();
    }


    // IsSlugExist False

    [Fact]
    public void AddChild_Should_AddChild()
    {
        // Arrange
        var category = _categoryBuilder.CreateCategory();
        var categoryDomainService = Substitute.For<ICategoryDomainService>();
        categoryDomainService.IsSlugExist(Arg.Any<string>()).Returns(true);

        // Act
        category.AddChild("test2", "test2", category.SeoData, categoryDomainService);

        // Assert
        category.Childs.Should().HaveCount(1);
    }

    [Fact]
    public void IsSlugExist_Should_Throw_SlugAlreadyExistsException_When_DataWas_Null()
    {
        // Arrange
        var seoDate = new SeoData("test", "test", "test", true, "test", "test");
        var categoryDomainService = Substitute.For<ICategoryDomainService>();
        categoryDomainService.IsSlugExist(Arg.Any<string>()).Returns(false);

        // Act
        Action act = () => new Category("test", "tes%$#t", seoDate, categoryDomainService);
        // Assert
        act.Should().ThrowExactly<SlugAlreadyExistsException>();
    }
}