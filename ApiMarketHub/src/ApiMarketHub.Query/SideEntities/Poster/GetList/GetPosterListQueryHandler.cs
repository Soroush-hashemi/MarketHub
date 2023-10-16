using ApiMarketHub.Infrastructure.Persistence.Command;
using ApiMarketHub.Query.SideEntities.DTOs;
using Microsoft.EntityFrameworkCore;
using Shared.Query;

namespace ApiMarketHub.Query.SideEntities.Poster.GetList;
public class GetPosterListQueryHandler : IQueryHandler<GetPosterListQuery, List<PosterDto>>
{
    private readonly MarketHubContext _context;
    public GetPosterListQueryHandler(MarketHubContext context)
    {
        _context = context;
    }

    public async Task<List<PosterDto>> Handle(GetPosterListQuery request, CancellationToken cancellationToken)
    {
        return await _context.Poster.OrderByDescending(d => d.Id)
            .Select(banner => new PosterDto()
            {
                Id = banner.Id,
                CreationDate = banner.CreationDate,
                ImageName = banner.ImageName,
                Link = banner.Link,
                Position = banner.Position
            }).ToListAsync(cancellationToken);
    }
}