using ApiMarketHub.Application.Products.AddImage;
using ApiMarketHub.Application.Products.Create;
using ApiMarketHub.Application.Products.Edit;
using ApiMarketHub.Application.Products.RemoveImage;
using ApiMarketHub.Query.Products.DTOs;
using ApiMarketHub.Query.Products.GetByFilter;
using ApiMarketHub.Query.Products.GetById;
using ApiMarketHub.Query.Products.GetBySlug;
using MediatR;
using Shared.Application;

namespace ApiMarketHub.PresentationFacade.Products;
internal class ProductFacade : IProductFacade
{
    private readonly IMediator _mediator;
    public ProductFacade(IMediator mediator)
    {
        _mediator = mediator;
    }
    public async Task<OperationResult> AddImage(AddImageProductCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> Create(CreateProductCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> Delete(RemoveImageProductCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> Edit(EditProductCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<ProductDto?> GetProductById(long ProductId)
    {
        return await _mediator.Send(new GetProductByIdQuery(ProductId));
    }

    public async Task<ProductDto?> GetProductBySlug(string slug)
    {
        return await _mediator.Send(new GetProductBySlugQuery(slug));
    }

    public async Task<ProductFilterResult> GetProductsByFilter(ProductFilterParams filterParams)
    {
        return await _mediator.Send(new GetProductsByFilterQuery(filterParams));
    }
}