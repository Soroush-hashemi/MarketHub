using ApiMarketHub.Domain.SideEntities.Repository;
using Shared.Application;

namespace ApiMarketHub.Application.SideEntities.ShippingMethods.Edit;
public class EditShippingMethodCommandHandler : IBaseCommandHandler<EditShippingMethodCommand>
{
    private readonly IShippingMethodRepository _repository;
    public EditShippingMethodCommandHandler(IShippingMethodRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResult> Handle(EditShippingMethodCommand request, CancellationToken cancellationToken)
    {
        var shippingMethod = await _repository.GetTracking(request.Id);
        if (shippingMethod == null)
            return OperationResult.NotFound();

        shippingMethod.Edit(request.Cost, request.Title);
        await _repository.Save();
        return OperationResult.Success();
    }
}