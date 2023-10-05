using Shared.Domain.ValueObjects;
using Shared.Query.Bases;

namespace ApiMarketHub.Query.Categories.DTOs;
public class SubCategoryDto : BaseDto
{
    public long ParentId { get; set; }
    public string Title { get; set; }
    public string Slug { get; set; }
    public SeoData SeoData { get; set; }
    public List<SecondarySubCategoryDto> Childs { get; set; }
}