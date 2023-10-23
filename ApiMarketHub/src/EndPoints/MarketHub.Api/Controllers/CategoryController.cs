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
        var url = Url.Action(nameof(GetCategoryById), "Category", new { id = result.Data }, Request.Scheme);
        return CommandResult(result, HttpStatusCode.Created, url);
    }

    [HttpPost("AddChild")]
    public async Task<ApiResult<long>> AddChild(AddChildCategoryCommand command)
    {
        var result = await _categoryFacade.AddChild(command);
        var url = Url.Action(nameof(GetCategoryById), "Category", new { id = result.Data }, Request.Scheme);
        return CommandResult(result, HttpStatusCode.Created, url);
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

    [HttpGet("{parentId}")]
    public async Task<ApiResult<List<SubCategoryDto>>> GetCategoryByParentId(long ParentId)
    {
        var result = await _categoryFacade.GetCategoryByParentId(ParentId);
        return QueryResult(result);
    }

    [HttpGet]
    public async Task<ApiResult<List<CategoryDto>>> GetCategoryList()
    {
        var result = await _categoryFacade.GetCategoryList();
        return QueryResult(result);
    }
}