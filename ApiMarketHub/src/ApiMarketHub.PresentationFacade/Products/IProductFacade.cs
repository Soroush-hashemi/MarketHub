using ApiMarketHub.Application.Products.AddImage;
using ApiMarketHub.Application.Products.Create;
using ApiMarketHub.Application.Products.Edit;
using ApiMarketHub.Application.Products.RemoveImage;
using ApiMarketHub.Query.Products.DTOs;
using Shared.Application;

namespace ApiMarketHub.PresentationFacade.Products;
public interface IProductFacade
{
    Task<OperationResult> AddImage(AddImageProductCommand command);
    Task<OperationResult> Create(CreateProductCommand command);
    Task<OperationResult> Edit(EditProductCommand command);
    Task<OperationResult> Delete(RemoveImageProductCommand command);

    Task<ProductFilterResult> GetProductsByFilter(ProductFilterParams filterParams);
    Task<ProductDto?> GetProductById(long ProductId);
    Task<ProductDto?> GetProductBySlug(string slug);
}