using ApiMarketHub.Application.SideEntities.Sliders.Create;
using ApiMarketHub.Application.SideEntities.Sliders.Delete;
using ApiMarketHub.Application.SideEntities.Sliders.Edit;
using ApiMarketHub.Query.SideEntities.DTOs;
using Shared.Application;

namespace ApiMarketHub.PresentationFacade.SideEntities.Slider;
public interface ISliderFacade
{
    Task<OperationResult> Create(CreateSliderCommand command);
    Task<OperationResult> Delete(DeleteSliderCommand command);
    Task<OperationResult> Edit(EditSliderCommand command);

    Task<SliderDto?> GetSliderById(long Id);
    Task<List<SliderDto>> GetSliderListQuery();
}