using ApiMarketHub.Application.Products.AddImage;
using ApiMarketHub.Application.Products.Create;
using ApiMarketHub.Application.Products.Edit;
using ApiMarketHub.Application.Products.RemoveImage;
using ApiMarketHub.Application.SideEntities.Posters.Create;
using ApiMarketHub.PresentationFacade.Products;
using ApiMarketHub.PresentationFacade.SideEntities.Poster;
using ApiMarketHub.Query.Products.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.ApiResponse;

namespace MarketHub.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ApiController
    {
        private readonly IProductFacade _productFacade;
        public ProductController(IProductFacade productFacade)
        {
            _productFacade = productFacade;
        }

        [HttpPost]
        public async Task<ApiResult> Create(CreateProductCommand command)
        {
            var result = await _productFacade.Create(command);
            return CommandResult(result);
        }

        [HttpPut]
        public async Task<ApiResult> Edit(EditProductCommand command)
        {
            var result = await _productFacade.Edit(command);
            return CommandResult(result);
        }

        [HttpPost("Images")]
        public async Task<ApiResult> AddImage(AddProductImageCommand command)
        {
            var result = await _productFacade.AddImage(command);
            return CommandResult(result);
        }

        [HttpDelete("Images")]
        public async Task<ApiResult> RemoveImage(RemoveProductCommandImage command)
        {
            var result = await _productFacade.RemoveImage(command);
            return CommandResult(result);
        }

        [HttpGet("{productId}")]
        public async Task<ApiResult<ProductDto?>> GetProductById(long productId)
        {
            var product = await _productFacade.GetProductById(productId);
            return QueryResult(product);
        }

        [HttpGet("{slug}")]
        public async Task<ApiResult<ProductDto?>> GetProductBySlug(string slug)
        {
            var product = await _productFacade.GetProductBySlug(slug);
            return QueryResult(product);
        }

        [HttpGet("Filter")]
        public async Task<ApiResult<ProductFilterResult>> GetProductsByFilter(ProductFilterParams filterParams)
        {
            return QueryResult(await _productFacade.GetProductsByFilter(filterParams));
        }
    }
}