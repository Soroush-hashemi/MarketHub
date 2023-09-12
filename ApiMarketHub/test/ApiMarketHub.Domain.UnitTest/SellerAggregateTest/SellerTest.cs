using ApiMarketHub.Domain.SellerAggregate;
using ApiMarketHub.Domain.SellerAggregate.Service;
using FluentAssertions;
using NSubstitute;
using Shared.Domain.Exceptions;
using Xunit;

namespace ApiMarketHub.Domain.UnitTest.SellerAggregateTest;
public class SellerTest
{
    [Fact]
    public void IsValidSellerInformation_Should_NotDoAnything_When_IsTrue()
    {
        // Arrange & Act
        var DomainService = Substitute.For<ISellerDomainService>();
        DomainService.IsValidSellerInformation(Arg.Any<Seller>()).Returns(true);
        DomainService.NationalCodeExistInDataBase(Arg.Any<string>()).Returns(true);
        var seller = new Seller(10, "Testshop", "8918177161", DomainService);

        // Assert
        seller.NationalCode.Should().Be("8918177161");
    }

    [Fact]
    public void IsValidSellerInformation_Should_Throw_InvalidDomainDataException_When_IsFalse()
    {
        // Arrange
        var DomainService = Substitute.For<ISellerDomainService>();
        DomainService.IsValidSellerInformation(Arg.Any<Seller>()).Returns(false);

        // Act 
        Action act = () => new Seller(10, "Testshop", "8918177161", DomainService);

        // Assert
        act.Should().Throw<InvalidDomainDataException>();
    }

    [Fact]
    public void NationalCodeExistInDataBase_Should_NotDoAnything_When_IsTrue()
    {
        // Arrange & Act
        var DomainService = Substitute.For<ISellerDomainService>();
        DomainService.IsValidSellerInformation(Arg.Any<Seller>()).Returns(true);
        DomainService.NationalCodeExistInDataBase(Arg.Any<string>()).Returns(true);
        var seller = new Seller(10, "Testshop", "8918177161", DomainService);

        // Assert
        seller.NationalCode.Should().Be("8918177161");
    }

    [Fact]
    public void NationalCodeExistInDataBase_Should_Throw_InvalidDomainDataException_When_IsFalse()
    {
        // Arrange
        var DomainService = Substitute.For<ISellerDomainService>();
        DomainService.NationalCodeExistInDataBase(Arg.Any<string>()).Returns(false);

        // Act 
        Action act = () => new Seller(10, "Testshop", "8918177161", DomainService);

        // Assert
        act.Should().Throw<InvalidDomainDataException>();
    }
}