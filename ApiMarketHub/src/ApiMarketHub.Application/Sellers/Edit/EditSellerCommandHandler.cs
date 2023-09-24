using ApiMarketHub.Domain.SellerAggregate.Repository;
using ApiMarketHub.Domain.SellerAggregate.Service;
using Shared.Application;

namespace ApiMarketHub.Application.Sellers.Edit;
public class EditSellerCommandHandler : IBaseCommandHandler<EditSellerCommand>
{
    private readonly ISellerRepository _repository;
    private readonly ISellerDomainService _domainService;
    public EditSellerCommandHandler(ISellerRepository repository, ISellerDomainService domainService)
    {
        _repository = repository;
        _domainService = domainService;
    }

    public async Task<OperationResult> Handle(EditSellerCommand request, CancellationToken cancellationToken)
    {
        var Seller = await _repository.GetTracking(request.SellerId);
        if (Seller == null)
            return OperationResult.NotFound();

        Seller.Edit(request.ShopName, request.NationalCode, request.Status, _domainService);
        await _repository.Save();
        return OperationResult.Success();
    }
}