using ApiMarketHub.Domain.SideEntities;
using ApiMarketHub.Domain.SideEntities.Repository;
using ApiMarketHub.Infrastructure.Persistence.Command;
using ApiMarketHub.Infrastructure.Repositories.Base;

namespace ApiMarketHub.Infrastructure.Repositories;
public class PosterRepository : BaseRepository<Poster>, IPosterRepository
{
    public PosterRepository(Context context) : base(context)
    {
        
    }

    public void Delete(Poster poster)
    {
        _context.Poster.Remove(poster);
    }
}