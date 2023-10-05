using ApiMarketHub.Query.Categories.DTOs;
using Shared.Query;

namespace ApiMarketHub.Query.Categories.GetById;
public record GetCategoryByIdQuery(long CategoryId) : IQuery<CategoryDto>;