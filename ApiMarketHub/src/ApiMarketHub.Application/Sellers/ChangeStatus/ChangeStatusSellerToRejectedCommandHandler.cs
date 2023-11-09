using ApiMarketHub.Domain.SellerAggregate.Enum;
using ApiMarketHub.Domain.SellerAggregate.Repository;
using Shared.Application;

namespace ApiMarketHub.Application.Sellers.ChangeStatus;
public class ChangeStatusSellerToRejectedCommandHandler : IBaseCommandHandler<ChangeStatusSellerToRejectedCommand>
{
    private readonly ISellerRepository _repository;
    public ChangeStatusSellerToRejectedCommandHandler(ISellerRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResult> Handle(ChangeStatusSellerToRejectedCommand request, CancellationToken cancellationToken)
    {
        var seller = await _repository.GetTracking(request.SellerId);
        if (seller == null)
            return OperationResult.NotFound();

        seller.ChangeStatus(SellerStatus.Rejected);
        await _repository.Save();
        return OperationResult.Success();
    }
}