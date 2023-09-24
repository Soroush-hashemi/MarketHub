using ApiMarketHub.Domain.SideEntities;
using ApiMarketHub.Domain.SideEntities.Repository;
using Shared.Application;
using System;

namespace ApiMarketHub.Application.SideEntities.ShippingMethods.Create;
public class CreateShippingMethodCommandHandler : IBaseCommandHandler<CreateShippingMethodCommand>
{
    private readonly IShippingMethodRepository _repository;
    public CreateShippingMethodCommandHandler(IShippingMethodRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResult> Handle(CreateShippingMethodCommand request, CancellationToken cancellationToken)
    {
        var shippingMethod = new ShippingMethod(request.Cost, request.Title);
        _repository.Add(shippingMethod);
        await _repository.Save();
        return OperationResult.Success();
    }
}
