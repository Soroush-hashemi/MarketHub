using ApiMarketHub.Application.Categories.AddChild;
using ApiMarketHub.Application.Categories.Create;
using ApiMarketHub.Application.Categories.Edit;
using ApiMarketHub.PresentationFacade.Categories;
using ApiMarketHub.Query.Categories.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace MarketHub.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly ICategoryFacade _categoryFacade;
    public CategoryController(ICategoryFacade categoryFacade)
    {
        _categoryFacade = categoryFacade;
    }

    [HttpPost]
    public async Task<ActionResult<long>> Create(CreateCategoryCommand command)
    {
        var result = await _categoryFacade.Create(command);
        return Ok(result);
    }

    [HttpPost("AddChild")]
    public async Task<ActionResult<long>> AddChild(AddChildCategoryCommand command)
    {
        var result = await _categoryFacade.AddChild(command);
        return Ok(result);
    }

    [HttpDelete("CategoryId")]
    public async Task<ActionResult> Delete(long CategoryId)
    {
        var result = await _categoryFacade.Delete(CategoryId);
        return Ok(result);
    }

    [HttpPut]
    public async Task<ActionResult> Edit(EditCategoryCommand command)
    {
        var result = await _categoryFacade.Edit(command);
        return Ok(result);
    }

    [HttpGet("CategoryId")]
    public async Task<ActionResult<CategoryDto>> GetCategoryById(long CategoryId)
    {
        var result = await _categoryFacade.GetCategoryById(CategoryId);
        return Ok(result);
    }

    [HttpGet("CategoryId")]
    public async Task<ActionResult<List<SubCategoryDto>>> GetCategoryByParentId(long ParentId)
    {
        var result = await _categoryFacade.GetCategoryByParentId(ParentId);
        return Ok(result);
    }

    [HttpGet]
    public async Task<ActionResult<List<CategoryDto>>> GetCategoryList()
    {
        var result = await _categoryFacade.GetCategoryList();
        return Ok(result);
    }
}