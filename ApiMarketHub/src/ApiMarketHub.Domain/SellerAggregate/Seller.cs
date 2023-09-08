using ApiMarketHub.Domain.SellerAggregate.Enum;
using ApiMarketHub.Domain.SellerAggregate.Service;
using Shared.Domain.Bases;
using Shared.Domain.Exceptions;
using Shared.Domain.Tools;

namespace ApiMarketHub.Domain.SellerAggregate;
public class Seller : AggregateRoot
{
    public long UserId { get; private set; }
    public string StoreName { get; private set; }
    public string NationalCode { get; private set; }
    public SellerStatus Status { get; private set; }
    public DateTime? LastUpdate { get; private set; }
    public List<SellerInventory> Inventories { get; private set; }

    private Seller()
    {

    }

    public Seller(long userId, string shopName, string nationalCode, ISellerDomainService domainService)
    {
        Guard(shopName, nationalCode);
        UserId = userId;
        StoreName = shopName;
        NationalCode = nationalCode;
        Inventories = new List<SellerInventory>();

        if (domainService.IsValidSellerInformation(this) == false)
            throw new InvalidDomainDataException("the information is invalid");
    }

    public void ChangeStatus(SellerStatus status)
    {
        Status = status;
        LastUpdate = DateTime.Now;
    }

    public void Edit(string shopName, string nationalCode, SellerStatus status, ISellerDomainService domainService)
    {
        Guard(shopName, nationalCode);
        if (nationalCode != NationalCode)
            if (domainService.NationalCodeExistInDataBase(nationalCode))
                throw new InvalidDomainDataException("the code belongs to someone else");

        StoreName = shopName;
        NationalCode = nationalCode;
        Status = status;
    }

    public void AddInventory(SellerInventory inventory)
    {
        if (Inventories.Any(f => f.ProductId == inventory.ProductId))
            throw new InvalidDomainDataException("this product has already been registered");

        Inventories.Add(inventory);
    }

    public void EditInventory(long inventoryId, int count, int price, int? discountPercentage)
    {
        var currentInventory = Inventories.FirstOrDefault(f => f.Id == inventoryId);
        if (currentInventory == null)
            throw new NullOrEmptyException("product not found");

        currentInventory.Edit(count, price, discountPercentage);
    }

    public void Guard(string shopName, string nationalCode)
    {
        NullOrEmptyException.CheckString(shopName, nameof(shopName));
        NullOrEmptyException.CheckString(nationalCode, nameof(nationalCode));
        if (IranianNationalIdChecker.IsValid(nationalCode) == false)
            throw new InvalidDomainDataException("national code is invalid");
    }
}