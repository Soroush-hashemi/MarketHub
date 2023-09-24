using ApiMarketHub.Domain.SideEntities.Repository;
using Shared.Application;

namespace ApiMarketHub.Application.SideEntities.ShippingMethods.Delete;
public class DeleteShippingMethodCommandHandler : IBaseCommandHandler<DeleteShippingMethodCommand>
{
    private readonly IShippingMethodRepository _repository;
    public DeleteShippingMethodCommandHandler(IShippingMethodRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResult> Handle(DeleteShippingMethodCommand request, CancellationToken cancellationToken)
    {
        var shippingMethod = await _repository.GetTracking(request.Id);
        if (shippingMethod == null)
            return OperationResult.NotFound();

        _repository.Delete(shippingMethod);
        await _repository.Save();
        return OperationResult.Success();
    }
}