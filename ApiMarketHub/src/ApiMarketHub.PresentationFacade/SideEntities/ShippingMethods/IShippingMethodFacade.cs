using ApiMarketHub.Application.SideEntities.ShippingMethods.Create;
using ApiMarketHub.Application.SideEntities.ShippingMethods.Delete;
using ApiMarketHub.Application.SideEntities.ShippingMethods.Edit;
using ApiMarketHub.Query.SideEntities.DTOs;
using Shared.Application;

namespace ApiMarketHub.PresentationFacade.SideEntities.ShippingMethods;
public interface IShippingMethodFacade
{
    Task<OperationResult> Create(CreateShippingMethodCommand command);
    Task<OperationResult> Delete(DeleteShippingMethodCommand command);
    Task<OperationResult> Edit(EditShippingMethodCommand command);

    Task<ShippingMethodDto?> GetShippingMethodById(long Id);
    Task<List<ShippingMethodDto>> GetShippingMethodDtoList();
}