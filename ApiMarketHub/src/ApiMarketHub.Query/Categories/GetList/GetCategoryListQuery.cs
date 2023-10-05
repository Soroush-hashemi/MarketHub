using ApiMarketHub.Query.Categories.DTOs;
using Shared.Query;

namespace ApiMarketHub.Query.Categories.GetList;
public record GetCategoryListQuery : IQuery<List<CategoryDto>>;