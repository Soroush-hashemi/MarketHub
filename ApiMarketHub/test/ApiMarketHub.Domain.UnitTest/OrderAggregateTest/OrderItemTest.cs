using ApiMarketHub.Domain.OrderAggregate;
using FluentAssertions;
using NSubstitute.ExceptionExtensions;
using Shared.Domain.Exceptions;
using Xunit;

namespace ApiMarketHub.Domain.UnitTest.OrderAggregateTest;
public class OrderItemTest
{
    [Fact]
    public void DecreaseCount_Should_DecreaseCount_When_CountIs_MoreThere_Then_One()
    {
        // Arrange
        var orderItem = new OrderItem(3321, 2, 10000);

        // Act
        orderItem.DecreaseCount(1);

        // Assert
        orderItem.Count.Should().Be(1);
    }

    [Fact]
    public void CountGuard_Should_Throw_InvalidDomainDataException_When_CountIs_EqualTo_Zero()
    {
        // Arrange
        var orderItem = new OrderItem(3321, 2, 10000);

        // Act
        Action act = () => orderItem.DecreaseCount(0);

        // Assert
        act.Should().ThrowExactly<InvalidDomainDataException>();
    }

    [Fact]
    public void DecreaseCount_Should_NotDoAnything_When_CountIs_EqualTo_One()
    {
        // Arrange
        var orderItem = new OrderItem(3321, 2, 10000);

        // Act
        orderItem.DecreaseCount(1);

        // Assert
        orderItem.Count.Should().Be(1);
    }

    [Fact]
    public void PriceGuard_Should_Throw_InvalidDomainDataException_When_PriceIs_Lesser_ThenOne()
    {
        // Arrange & Act
        Action act = () => new OrderItem(3321, 2, 0);

        // Assert
        act.Should().ThrowExactly<InvalidDomainDataException>();
    }
}