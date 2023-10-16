using ApiMarketHub.Infrastructure.Persistence.Command;
using ApiMarketHub.Query.SideEntities.DTOs;
using Microsoft.EntityFrameworkCore;
using Shared.Query;

namespace ApiMarketHub.Query.SideEntities.Sliders.GetList;
public class GetSliderListQueryHandler : IQueryHandler<GetSliderListQuery, List<SliderDto>>
{
    private readonly MarketHubContext _context;
    public GetSliderListQueryHandler(MarketHubContext context)
    {
        _context = context;
    }

    public async Task<List<SliderDto>> Handle(GetSliderListQuery request, CancellationToken cancellationToken)
    {
        return await _context.Sliders.OrderByDescending(d => d.Id)
            .Select(slider => new SliderDto()
            {
                Id = slider.Id,
                CreationDate = slider.CreationDate,
                ImageName = slider.ImageName,
                Link = slider.Link,
                Title = slider.Title
            }).ToListAsync(cancellationToken);
    }
}