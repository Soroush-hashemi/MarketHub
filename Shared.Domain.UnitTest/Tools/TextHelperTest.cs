using FluentAssertions;
using Shared.Domain.Tools;
using System;
using Xunit;

namespace Shared.Domain.UnitTest.Tools;
public class TextHelperTest
{
    [Fact]
    public void TextHelper_Should_Return_True()
    {
        // Arrange & Act 
        var isValid = TextHelper.IsText("سلام");

        // Assert
        isValid.Should().BeTrue();
    }

    [Fact]
    public void TextHelper_Should_Return_False()
    {
        // Arrange & Act
        var isValid = TextHelper.IsText("2175121");

        // Assert
        isValid.Should().BeFalse();
    }

    [Fact]
    public void ToSlug_Should_Return_With_ToLowerAndTrim()
    {
        // Arrange & Act 
        var slug = TextHelper.ToSlug("t$+%?^*@!#&~(=)/. t");

        // Assert
        slug.Should().Be("t-t");
    }
}