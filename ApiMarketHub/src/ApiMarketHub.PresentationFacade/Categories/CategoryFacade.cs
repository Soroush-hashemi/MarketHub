using ApiMarketHub.Application.Categories.AddChild;
using ApiMarketHub.Application.Categories.Create;
using ApiMarketHub.Application.Categories.Delete;
using ApiMarketHub.Application.Categories.Edit;
using ApiMarketHub.Query.Categories.DTOs;
using ApiMarketHub.Query.Categories.GetById;
using ApiMarketHub.Query.Categories.GetByParentId;
using ApiMarketHub.Query.Categories.GetList;
using MediatR;
using Shared.Application;

namespace ApiMarketHub.PresentationFacade.Categories;
internal class CategoryFacade : ICategoryFacade
{
    private readonly IMediator _mediator;
    public CategoryFacade(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<OperationResult<long>> Create(CreateCategoryCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult<long>> AddChild(AddChildCategoryCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> Delete(long CategoryId)
    {
        return await _mediator.Send(new DeleteCategoryCommand(CategoryId));
    }

    public async Task<OperationResult> Edit(EditCategoryCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<CategoryDto> GetCategoryById(long CategoryId)
    {
        return await _mediator.Send(new GetCategoryByIdQuery(CategoryId));
    }

    public async Task<List<SubCategoryDto>> GetCategoryByParentId(long ParentId)
    {
        return await _mediator.Send(new GetCategoryByParentIdQuery(ParentId));
    }

    public async Task<List<CategoryDto>> GetCategoryList()
    {
        return await _mediator.Send(new GetCategoryListQuery());
    }
}