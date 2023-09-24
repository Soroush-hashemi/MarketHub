using ApiMarketHub.Domain.SellerAggregate.Repository;
using Shared.Application;

namespace ApiMarketHub.Application.Sellers.EditInventory;
public class EditSellerInventoryCommandHandler : IBaseCommandHandler<EditSellerInventoryCommand>
{
    private readonly ISellerRepository _repository;
    public EditSellerInventoryCommandHandler(ISellerRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResult> Handle(EditSellerInventoryCommand request, CancellationToken cancellationToken)
    {
        var seller = await _repository.GetTracking(request.SellerId);
        if (seller == null)
            return OperationResult.NotFound();

        seller.EditInventory(request.InventoryId, request.Count, request.Price, request.DiscountPercentage);
        await _repository.Save();
        return OperationResult.Success();
    }
}