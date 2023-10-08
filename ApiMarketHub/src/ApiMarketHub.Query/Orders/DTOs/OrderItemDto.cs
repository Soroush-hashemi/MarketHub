using Shared.Query.Bases;

namespace ApiMarketHub.Query.Orders.DTO;
public class OrderItemDto : BaseDto
{
    public string ProductTitle { get; set; }
    public string ProductSlug { get; set; }
    public string ProductImageName { get; set; }
    public string StoreName { get; set; }
    public long OrderId { get; set; }
    public long InventoryId { get; set; }
    public int Count { get; set; }
    public int Price { get; set; }
    public int TotalPrice => Price * Count;
}