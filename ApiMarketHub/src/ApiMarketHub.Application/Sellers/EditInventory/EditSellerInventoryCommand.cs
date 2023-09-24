using Shared.Application;

namespace ApiMarketHub.Application.Sellers.EditInventory;
public class EditSellerInventoryCommand : IBaseCommand
{
    public long SellerId { get; private set; }
    public long InventoryId { get; private set; }
    public int Count { get; private set; }
    public int Price { get; private set; }
    public int? DiscountPercentage { get; private set; }

    public EditSellerInventoryCommand(long sellerId, long inventoryId, int count, int price, int? discountPercentage)
    {
        SellerId = sellerId;
        InventoryId = inventoryId;
        Count = count;
        Price = price;
        DiscountPercentage = discountPercentage;
    }
}