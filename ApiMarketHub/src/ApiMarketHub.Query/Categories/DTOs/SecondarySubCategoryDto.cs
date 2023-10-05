using Shared.Domain.ValueObjects;
using Shared.Query.Bases;

namespace ApiMarketHub.Query.Categories.DTOs;
public class SecondarySubCategoryDto : BaseDto
{
    public string Title { get; set; }
    public string Slug { get; set; }
    public SeoData SeoData { get; set; }
    public long ParentId { get; set; }
}