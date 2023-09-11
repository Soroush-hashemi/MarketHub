using ApiMarketHub.Domain.SideEntities;
using ApiMarketHub.Domain.SideEntities.Enum;
using ApiMarketHub.Domain.UnitTest.SideEntities.Builder;
using FluentAssertions;
using Xunit;

namespace ApiMarketHub.Domain.UnitTest.SideEntities;
public class PosterTest
{
    private readonly PosterBuilder _posterBuilder;
    public PosterTest()
    {
        _posterBuilder = new PosterBuilder();
    }

    [Fact]
    public void Constructor_Should_Create_Poster()
    {
        // Arrange & Act
        var poster = _posterBuilder.CreateFullPoster();

        // Assert
        poster.Link.Should().Be("https://localhost:7165/product");
        poster.ImageName.Should().Be("productnum123.png");
        poster.Position.Should().Be(PosterPosition.above_slider);
    }

    [Fact]
    public void Guard_Should_Throw_NotImplementedException_When_ImageName_Was_Null()
    {
        // Arrange & Act
        Action act = () => new Poster("https://localhost:7165/product", "", PosterPosition.above_slider); ;

        // Assert
        act.Should().ThrowExactly<NotImplementedException>();
    }

    [Fact]
    public void Guard_Should_Throw_NotImplementedException_When_Link_Was_Null()
    {
        // Arrange & Act
        Action act = () => new Poster("", "productnum123.png", PosterPosition.above_slider); ;

        // Assert
        act.Should().ThrowExactly<NotImplementedException>();
    }

    [Fact]
    public void Edit_Should_Edit_Poster()
    {
        // Arrange
        var poster = _posterBuilder.CreateFullPoster();

        // Act
        poster.Edit("https://localhost:7165/product/p1", "productImage.png", PosterPosition.right_side);

        // Assert
        poster.Link.Should().Be("https://localhost:7165/product/p1");
        poster.ImageName.Should().Be("productImage.png");
        poster.Position.Should().Be(PosterPosition.right_side);
    }
}