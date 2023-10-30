using ApiMarketHub.Application.Categories.Create;
using ApiMarketHub.PresentationFacade.Categories;
using MarketHub.Api.Controllers;
using Shared.Domain.ValueObjects;
using NSubstitute;
using Xunit;
using Shared.Application;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApiMarketHub.Application.Categories.AddChild;
using ApiMarketHub.Application.Categories.Edit;
using ApiMarketHub.Query.Categories.DTOs;

namespace MarketHubApi.UnitTest.ControllersTests;

public class CategoryControllerTest
{
    [Fact]
    public async Task Create_ValidCommand_ReturnsCreatedResult()
    {
        // Arrange
        var categoryFacade = Substitute.For<ICategoryFacade>();
        var controller = new CategoryController(categoryFacade);
        var seoDate = new SeoData("test", "test", "test", true, "test", "test");
        var command = new CreateCategoryCommand("TestTitle", "TestSlug", seoDate);
        var expectedResult = new OperationResult<long>
        {
            Status = OperationResultStatus.Success,
            Data = 1,
            Message = "test",
        };

        var httpContext = Substitute.For<HttpContext>();
        httpContext.Response.StatusCode.Returns(200);

        controller.ControllerContext = new ControllerContext
        {
            HttpContext = httpContext
        };

        categoryFacade.Create(command).Returns(expectedResult);
        // Act
        var result = await controller.Create(command);

        // Assert
        result.IsSuccess.Should().BeTrue();
        result.Data.Should().Be(expectedResult.Data);
    }

    [Fact]
    public async Task Create_InValidCommand_ReturnsSuccessIsFalse()
    {
        // Arrange
        var categoryFacade = Substitute.For<ICategoryFacade>();
        var controller = new CategoryController(categoryFacade);
        var seoDate = new SeoData("test", "test", "test", true, "test", "test");
        var command = new CreateCategoryCommand("TestTitle", "", seoDate);
        var expectedResult = new OperationResult<long>
        {
            Status = OperationResultStatus.Error,
        };

        var httpContext = Substitute.For<HttpContext>();
        httpContext.Response.StatusCode.Returns(500);

        controller.ControllerContext = new ControllerContext
        {
            HttpContext = httpContext
        };

        categoryFacade.Create(command).Returns(expectedResult);
        // Act
        var result = await controller.Create(command);

        // Assert
        result.IsSuccess.Should().BeFalse();
        result.Data.Should().Be(expectedResult.Data);
    }

    [Fact]
    public async Task AddChild_ValidCommand_ReturnsCreatedResult()
    {
        // Arrange
        var categoryFacade = Substitute.For<ICategoryFacade>();
        var controller = new CategoryController(categoryFacade);
        var seoDate = new SeoData("test", "test", "test", true, "test", "test");
        var command = new AddChildCategoryCommand(1, "TestTitle", "TestSlug", seoDate);
        var expectedResult = new OperationResult<long>
        {
            Status = OperationResultStatus.Success,
            Data = 1,
            Message = "test",
        };

        var httpContext = Substitute.For<HttpContext>();
        httpContext.Response.StatusCode.Returns(200);

        controller.ControllerContext = new ControllerContext
        {
            HttpContext = httpContext
        };

        categoryFacade.AddChild(command).Returns(expectedResult);
        // Act
        var result = await controller.AddChild(command);

        // Assert
        result.IsSuccess.Should().BeTrue();
        result.Data.Should().Be(expectedResult.Data);
    }

    [Fact]
    public async Task AddChild_InValidCommand_ReturnsSuccessIsFalse()
    {
        // Arrange
        var categoryFacade = Substitute.For<ICategoryFacade>();
        var controller = new CategoryController(categoryFacade);
        var seoDate = new SeoData("test", "test", "test", true, "test", "test");
        var command = new AddChildCategoryCommand(0, "TestTitle", "", seoDate);
        var expectedResult = new OperationResult<long>
        {
            Status = OperationResultStatus.Error,
        };

        var httpContext = Substitute.For<HttpContext>();
        httpContext.Response.StatusCode.Returns(500);

        controller.ControllerContext = new ControllerContext
        {
            HttpContext = httpContext
        };

        categoryFacade.AddChild(command).Returns(expectedResult);
        // Act
        var result = await controller.AddChild(command);

        // Assert
        result.IsSuccess.Should().BeFalse();
        result.Data.Should().Be(expectedResult.Data);
    }

    [Fact]
    public async Task Delete_ValidCommand_ReturnsCreatedResult()
    {
        // Arrange
        var categoryFacade = Substitute.For<ICategoryFacade>();
        var controller = new CategoryController(categoryFacade);
        long CategoryId = 10;
        var expectedResult = new OperationResult
        {
            Status = OperationResultStatus.Success,
            Message = "test",
        };

        categoryFacade.Delete(CategoryId).Returns(expectedResult);
        // Act
        var result = await controller.Delete(CategoryId);

        // Assert
        result.IsSuccess.Should().BeTrue();
    }

    [Fact]
    public async Task Delete_ValidCommand_ReturnsSuccessIsFalse()
    {
        // Arrange
        var categoryFacade = Substitute.For<ICategoryFacade>();
        var controller = new CategoryController(categoryFacade);
        long CategoryId = 0;
        var expectedResult = new OperationResult
        {
            Status = OperationResultStatus.Error,
            Message = "test",
        };

        categoryFacade.Delete(CategoryId).Returns(expectedResult);
        // Act
        var result = await controller.Delete(CategoryId);

        // Assert
        result.IsSuccess.Should().BeFalse();
    }

    [Fact]
    public async Task Edit_ValidCommand_ReturnsCreatedResult()
    {
        // Arrange
        var categoryFacade = Substitute.For<ICategoryFacade>();
        var controller = new CategoryController(categoryFacade);
        var seoDate = new SeoData("test", "test", "test", true, "test", "test");
        var command = new EditCategoryCommand(1, "TestTitle", "TestSlug", seoDate);
        var expectedResult = new OperationResult
        {
            Status = OperationResultStatus.Success,
            Message = "test",
        };

        categoryFacade.Edit(command).Returns(expectedResult);
        // Act
        var result = await controller.Edit(command);

        // Assert
        result.IsSuccess.Should().BeTrue();
    }

    [Fact]
    public async Task Edit_InValidCommand_ReturnsSuccessIsFalse()
    {
        // Arrange
        var categoryFacade = Substitute.For<ICategoryFacade>();
        var controller = new CategoryController(categoryFacade);
        var seoDate = new SeoData("test", "test", "test", true, "test", "test");
        var command = new EditCategoryCommand(1, "TestTitle", "", seoDate);
        var expectedResult = new OperationResult
        {
            Status = OperationResultStatus.Error,
            Message = "test",
        };

        categoryFacade.Edit(command).Returns(expectedResult);
        // Act
        var result = await controller.Edit(command);

        // Assert
        result.IsSuccess.Should().BeFalse();
    }

    [Fact]
    public async Task GetCategoryById_ValidQuery_ReturnsCategoryDto()
    {
        // Arrange
        var categoryFacade = Substitute.For<ICategoryFacade>();
        var controller = new CategoryController(categoryFacade);
        var categoryId = 1;

        var expectedCategoryDto = new CategoryDto
        {
            Id = categoryId,
            Slug = "SlugTest",
            SeoData = new SeoData("test", "test", "test", true, "test", "test"),
            Title = "TitleTest",
            Childs = null,
        };

        categoryFacade.GetCategoryById(categoryId).Returns(expectedCategoryDto);

        // Act
        var result = await controller.GetCategoryById(categoryId);

        // Assert
        result.IsSuccess.Should().BeTrue();
        result.Data.Should().BeEquivalentTo(expectedCategoryDto);
    }

    [Fact]
    public async Task GetCategoryByParentId_ValidQuery_ReturnsListSubCategoryDto()
    {
        // Arrange
        var categoryFacade = Substitute.For<ICategoryFacade>();
        var controller = new CategoryController(categoryFacade);
        var ParentId = 1;

        var expectedResult = new List<SubCategoryDto>();

        categoryFacade.GetCategoryByParentId(ParentId).Returns(expectedResult);

        // Act
        var result = await controller.GetCategoryByParentId(ParentId);

        // Assert
        result.IsSuccess.Should().BeTrue();
        result.Data.Should().BeEquivalentTo(expectedResult);
    }

    [Fact]
    public async Task GetCategoryList_ValidQuery_ReturnsListCategoryDto()
    {
        // Arrange
        var categoryFacade = Substitute.For<ICategoryFacade>();
        var controller = new CategoryController(categoryFacade);

        var expectedCategoryDto = new List<CategoryDto>();


        categoryFacade.GetCategoryList().Returns(expectedCategoryDto);

        // Act
        var result = await controller.GetCategoryList();

        // Assert
        result.IsSuccess.Should().BeTrue();
        result.Data.Should().BeEquivalentTo(expectedCategoryDto);
    }
}