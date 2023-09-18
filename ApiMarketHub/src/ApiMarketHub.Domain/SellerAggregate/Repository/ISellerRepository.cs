using Common.Domain.Repository;

namespace ApiMarketHub.Domain.SellerAggregate.Repository;
public interface ISellerRepository : IBaseRepository<Seller>
{
    // نباید کلاسی که اگریگیت روت نیست رو برگردونیم به کاربر چون بهش دسترسی هایی که نباید رو پیدا میکنه
    Task<InventoryInfo?> GetInventoryById(long id);
}

public class InventoryInfo
{
    public long Id { get; set; }
    public long SellerId { get; set; }
    public long ProductId { get; set; }
    public int Count { get; set; }
    public int Price { get; set; }
}