using ApiMarketHub.Domain.SellerAggregate;
using FluentAssertions;
using Shared.Domain.Exceptions;
using System;
using Xunit;

namespace ApiMarketHub.Domain.UnitTest.SellerAggregateTest;
public class SellerInventoryTest
{
    [Fact]
    public void Guard_InvalidPrice_ThrowsInvalidDomainDataException()
    {
        // Arrange & Act
        Action act = () => new SellerInventory(10, 10, 0, 10);

        // Assert
        act.Should().Throw<InvalidDomainDataException>();
    }

    [Fact]
    public void Guard_InvalidCount_ThrowsInvalidDomainDataException()
    {
        // Arrange & Act
        Action act = () => new SellerInventory(10, -1, 10, 10);

        // Assert
        act.Should().Throw<InvalidDomainDataException>();
    }
}