using ApiMarketHub.Domain.SellerAggregate.Enum;
using ApiMarketHub.Domain.SellerAggregate.Repository;
using Shared.Application;

namespace ApiMarketHub.Application.Sellers.ChangeStatus;
public class ChangeStatusSellerToAcceptedCommandHandler : IBaseCommandHandler<ChangeStatusSellerToAcceptedCommand>
{
    private readonly ISellerRepository _repository;
    public ChangeStatusSellerToAcceptedCommandHandler(ISellerRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResult> Handle(ChangeStatusSellerToAcceptedCommand request, CancellationToken cancellationToken)
    {
        var seller = await _repository.GetTracking(request.SellerId);
        if (seller == null)
            return OperationResult.NotFound();

        seller.ChangeStatus(SellerStatus.Accepted);
        await _repository.Save();
        return OperationResult.Success();
    }
}