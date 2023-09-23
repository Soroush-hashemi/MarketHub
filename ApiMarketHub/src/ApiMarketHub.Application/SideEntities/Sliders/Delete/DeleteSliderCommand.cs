using Shared.Application;

namespace ApiMarketHub.Application.SideEntities.Sliders.Delete;
public record DeleteSliderCommand(long SliderId) : IBaseCommand;