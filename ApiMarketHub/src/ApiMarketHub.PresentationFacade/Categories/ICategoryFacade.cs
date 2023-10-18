﻿using ApiMarketHub.Application.Categories.AddChild;
using ApiMarketHub.Application.Categories.Create;
using ApiMarketHub.Application.Categories.Delete;
using ApiMarketHub.Application.Categories.Edit;
using ApiMarketHub.Query.Categories.DTOs;
using Shared.Application;

namespace ApiMarketHub.PresentationFacade.Categories;
public interface ICategoryFacade
{
    Task<OperationResult<long>> AddChild(AddChildCategoryCommand command);
    Task<OperationResult<long>> Create(CreateCategoryCommand command);
    Task<OperationResult> Edit(EditCategoryCommand command);
    Task<OperationResult> Delete(long CategoryId);

    Task<CategoryDto> GetCategoryById(long CategoryId);
    Task<List<SubCategoryDto>> GetCategoryByParentId(long ParentId);
    Task<List<CategoryDto>> GetCategoryList();
}