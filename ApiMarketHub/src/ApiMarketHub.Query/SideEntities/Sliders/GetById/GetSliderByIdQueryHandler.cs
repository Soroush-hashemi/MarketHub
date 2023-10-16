using ApiMarketHub.Infrastructure.Persistence.Command;
using ApiMarketHub.Query.SideEntities.DTOs;
using Microsoft.EntityFrameworkCore;
using Shared.Query;

namespace ApiMarketHub.Query.SideEntities.Sliders.GetById;
public class GetSliderByIdQueryHandler : IQueryHandler<GetSliderByIdQuery, SliderDto>
{
    private readonly MarketHubContext _context;
    public GetSliderByIdQueryHandler(MarketHubContext context)
    {
        _context = context;
    }

    public async Task<SliderDto> Handle(GetSliderByIdQuery request, CancellationToken cancellationToken)
    {
        var slider = await _context.Sliders
            .FirstOrDefaultAsync(f => f.Id == request.Id, cancellationToken);
        if (slider == null)
            return null;

        return new SliderDto()
        {
            Id = slider.Id,
            CreationDate = slider.CreationDate,
            ImageName = slider.ImageName,
            Link = slider.Link,
            Title = slider.Title
        };
    }
}