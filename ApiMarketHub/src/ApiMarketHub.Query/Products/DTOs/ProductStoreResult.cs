
using ApiMarketHub.Query.Categories.DTOs;
using Shared.Query.Bases;

namespace ApiMarketHub.Query.Products.DTOs;
public class ProductStoreResult : BaseFilter<ProductStoreDto, ProductStoreFilterParam>
{
    public CategoryDto? CategoryDto { get; set; }
}

public class ProductStoreDto : BaseDto
{
    public string Title { get; set; }
    public string Slug { get; set; }
    public long InventoryId { get; set; }
    public int Price { get; set; }
    public int DiscountPercentage { get; set; }
    public string ImageName { get; set; }
    public int TotalPrice
    {
        get
        {
            var discount = Price * DiscountPercentage / 100;
            return Price - discount;
        }
    }
}

public class ProductStoreFilterParam : BaseFilterParam
{
    public string? CategorySlug { get; set; } = "";
    public string? Search { get; set; } = "";
    public bool OnlyAvailableProducts { get; set; } = false;
    public bool JustHasDiscount { get; set; } = false;
    public ProductSearchOrderBy SearchOrderBy { get; set; } = ProductSearchOrderBy.Cheapest;
}

public enum ProductSearchOrderBy
{
    Latest,
    Expensive,
    Cheapest,
}