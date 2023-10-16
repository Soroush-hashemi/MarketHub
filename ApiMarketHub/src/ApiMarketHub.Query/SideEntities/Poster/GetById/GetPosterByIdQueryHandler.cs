using ApiMarketHub.Infrastructure.Persistence.Command;
using ApiMarketHub.Query.SideEntities.DTOs;
using Microsoft.EntityFrameworkCore;
using Shared.Query;

namespace ApiMarketHub.Query.SideEntities.Poster.GetById;
public class GetPosterByIdQueryHandler : IQueryHandler<GetPosterByIdQuery, PosterDto>
{
    private readonly MarketHubContext _context;
    public GetPosterByIdQueryHandler(MarketHubContext context)
    {
        _context = context;   
    }

    public async Task<PosterDto> Handle(GetPosterByIdQuery request, CancellationToken cancellationToken)
    {
        var poster = await _context.Poster.FirstOrDefaultAsync(f => f.Id == request.Id, cancellationToken);
        if (poster == null)
            return null;

        return new PosterDto()
        {
            Id = poster.Id,
            CreationDate = poster.CreationDate,
            ImageName = poster.ImageName,
            Link = poster.Link,
            Position = poster.Position
        };
    }
}