using ApiMarketHub.Application.SideEntities.Sliders.Create;
using ApiMarketHub.Application.SideEntities.Sliders.Delete;
using ApiMarketHub.Application.SideEntities.Sliders.Edit;
using ApiMarketHub.PresentationFacade.SideEntities.Slider;
using ApiMarketHub.Query.SideEntities.DTOs;
using Microsoft.AspNetCore.Mvc;
using Shared.ApiResponse;

namespace MarketHub.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SliderController : ApiController
    {
        private readonly ISliderFacade _sliderFacade;
        public SliderController(ISliderFacade sliderFacade)
        {
            _sliderFacade = sliderFacade;
        }

        [HttpPost]
        public async Task<ApiResult> Create(CreateSliderCommand command)
        {
            var result = await _sliderFacade.Create(command);
            return CommandResult(result);
        }

        [HttpPut]
        public async Task<ApiResult> Edit(EditSliderCommand command)
        {
            var result = await _sliderFacade.Edit(command);
            return CommandResult(result);
        }

        [HttpPut]
        public async Task<ApiResult> Delete(DeleteSliderCommand command)
        {
            var result = await _sliderFacade.Delete(command);
            return CommandResult(result);
        }

        [HttpGet("{Id}")]
        public async Task<ApiResult<SliderDto?>> GetSliderById(long Id)
        {
            var result = await _sliderFacade.GetSliderById(Id);
            return QueryResult(result);
        }

        [HttpGet]
        public async Task<ApiResult<List<SliderDto>>> GetSliderListQuery()
        {
            var result = await _sliderFacade.GetSliderListQuery();
            return QueryResult(result);
        }
    }
}
