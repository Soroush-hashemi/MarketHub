using ApiMarketHub.Application.Categories.AddChild;
using ApiMarketHub.Application.Categories.Create;
using ApiMarketHub.Application.Categories.Edit;
using ApiMarketHub.PresentationFacade.Categories;
using ApiMarketHub.Query.Categories.DTOs;
using Microsoft.AspNetCore.Mvc;
using Shared.ApiResponse;
using System.Net;

namespace MarketHub.Api.Controllers;
public class CategoryController : ApiController
{
    private readonly ICategoryFacade _categoryFacade;
    public CategoryController(ICategoryFacade categoryFacade)
    {
        _categoryFacade = categoryFacade;
    }

    [HttpPost]
    public async Task<ApiResult<long>> Create(CreateCategoryCommand command)
    {
        var result = await _categoryFacade.Create(command);
        var Path = "Category";
        return CommandResult(result, HttpStatusCode.Created, Path);
    }

    [HttpPost("Child")]
    public async Task<ApiResult<long>> AddChild(AddChildCategoryCommand command)
    {
        var result = await _categoryFacade.AddChild(command);
        var Path = "Category";
        return CommandResult(result, HttpStatusCode.Created, Path);
    }

    [HttpDelete("{CategoryId}")]
    public async Task<ApiResult> Delete(long CategoryId)
    {
        var result = await _categoryFacade.Delete(CategoryId);
        return CommandResult(result);
    }

    [HttpPut]
    public async Task<ApiResult> Edit(EditCategoryCommand command)
    {
        var result = await _categoryFacade.Edit(command);
        return CommandResult(result);
    }

    [HttpGet("{CategoryId}")]
    public async Task<ApiResult<CategoryDto>> GetCategoryById(long CategoryId)
    {
        var result = await _categoryFacade.GetCategoryById(CategoryId);
        return QueryResult(result);
    }

    [HttpGet("Child/{parentId}")]
    public async Task<ApiResult<List<SubCategoryDto>>> GetCategoryByParentId(long parentId)
    {
        var result = await _categoryFacade.GetCategoryByParentId(parentId);
        return QueryResult(result);
    }

    [HttpGet]
    public async Task<ApiResult<List<CategoryDto>>> GetCategoryList()
    {
        var result = await _categoryFacade.GetCategoryList();
        return QueryResult(result);
    }
}