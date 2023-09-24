using ApiMarketHub.Domain.SellerAggregate;
using ApiMarketHub.Domain.SellerAggregate.Repository;
using Shared.Application;

namespace ApiMarketHub.Application.Sellers.AddInventory;
public class AddSellerInventoryCommandHandler : IBaseCommandHandler<AddSellerInventoryCommand>
{
    private readonly ISellerRepository _Repository;
    public AddSellerInventoryCommandHandler(ISellerRepository Repository)
    {
        _Repository = Repository;
    }

    public async Task<OperationResult> Handle(AddSellerInventoryCommand request, CancellationToken cancellationToken)
    {
        var Seller = await _Repository.GetTracking(request.SellerId);
        if (Seller == null)
            return OperationResult.NotFound();

        var inventory = new SellerInventory(request.ProductId, request.Count, request.Price, request.DiscountPercentage);

        Seller.AddInventory(inventory);
        await _Repository.Save();
        return OperationResult.Success();
    }
}