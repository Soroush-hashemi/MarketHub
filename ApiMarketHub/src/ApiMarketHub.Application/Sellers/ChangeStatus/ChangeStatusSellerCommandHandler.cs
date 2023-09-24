using ApiMarketHub.Domain.SellerAggregate.Repository;
using Shared.Application;

namespace ApiMarketHub.Application.Sellers.ChangeStatus;
public class ChangeStatusSellerCommandHandler : IBaseCommandHandler<ChangeStatusSellerCommand>
{
    private readonly ISellerRepository _repository;
    public ChangeStatusSellerCommandHandler(ISellerRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResult> Handle(ChangeStatusSellerCommand request, CancellationToken cancellationToken)
    {
        var seller = await _repository.GetTracking(request.SellerId);
        if (seller == null)
            return OperationResult.NotFound();

        seller.ChangeStatus(request.Status);
        await _repository.Save();
        return OperationResult.Success();
    }
}