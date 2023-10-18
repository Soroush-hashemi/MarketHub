using ApiMarketHub.Query.SideEntities.DTOs;
using Shared.Query;

namespace ApiMarketHub.Query.SideEntities.Sliders.GetById;
public record GetSliderByIdQuery(long Id) : IQuery<SliderDto?>;