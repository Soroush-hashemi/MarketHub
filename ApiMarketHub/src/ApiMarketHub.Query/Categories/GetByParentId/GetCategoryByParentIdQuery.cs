using ApiMarketHub.Query.Categories.DTOs;
using Shared.Query;

namespace ApiMarketHub.Query.Categories.GetByParentId;
public record GetCategoryByParentIdQuery(long ParentId) : IQuery<List<SubCategoryDto>>;