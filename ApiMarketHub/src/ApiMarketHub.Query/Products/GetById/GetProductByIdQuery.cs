using ApiMarketHub.Query.Products.DTOs;
using Shared.Query;

namespace ApiMarketHub.Query.Products.GetById;
public record GetProductByIdQuery(long ProductId) : IQuery<ProductDto?>;