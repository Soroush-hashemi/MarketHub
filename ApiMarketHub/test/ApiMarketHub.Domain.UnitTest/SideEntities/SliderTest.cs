using ApiMarketHub.Domain.SideEntities;
using ApiMarketHub.Domain.SideEntities.Enum;
using ApiMarketHub.Domain.UnitTest.SideEntities.Builder;
using FluentAssertions;
using System;
using Xunit;

namespace ApiMarketHub.Domain.UnitTest.SideEntities;
public class SliderTest
{
    private readonly SliderBuilder _sliderBuilder;
    public SliderTest()
    {
        _sliderBuilder = new SliderBuilder();
    }

    [Fact]
    public void Constructor_Should_Create_Slider()
    {
        // Arrange & Act
        var slider = new Slider("DiscountProduct2", "https://localhost:7165/product/p1", "productImage.png", true);

        // Assert
        slider.Title.Should().Be("DiscountProduct2");
        slider.Link.Should().Be("https://localhost:7165/product/p1");
        slider.ImageName.Should().Be("productImage.png");
        slider.IsActive.Should().BeTrue();
    }

    [Fact]
    public void Guard_Should_Throw_NotImplementedException_When_ImageName_Was_Null()
    {
        // Arrange & Act
        Action act = () => new Slider("DiscountProduct2", "https://localhost:7165/product/p1", "", true);

        // Assert
        act.Should().ThrowExactly<NotImplementedException>().WithMessage("ImageName is null");
    }

    [Fact]
    public void Guard_Should_Throw_NotImplementedException_When_Link_Was_Null()
    {
        // Arrange & Act
        Action act = () => new Slider("DiscountProduct2", "", "productImage.png", true);

        // Assert
        act.Should().ThrowExactly<NotImplementedException>().WithMessage("Link is null");
    }

    [Fact]
    public void Guard_Should_Throw_NotImplementedException_When_Title_Was_Null()
    {
        // Arrange & Act
        Action act = () => new Slider("", "https://localhost:7165/product/p1", "productImage.png", true);

        // Assert
        act.Should().ThrowExactly<NotImplementedException>().WithMessage("Title is null");
    }

    public void Edit_Should_Edit_Poster()
    {
        // Arrange
        var slider = _sliderBuilder.CreateSlider();

        // Act
        slider.Edit("DiscountProduct2", "https://localhost:7165/product/p2", "productImage2.png", false);

        // Assert
        slider.Title.Should().Be("DiscountProduct2");
        slider.Link.Should().Be("https://localhost:7165/product/p2");
        slider.ImageName.Should().Be("productImage2.png");
        slider.IsActive.Should().BeFalse();
    }
}