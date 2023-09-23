using Common.Domain.Repository;
using System.Reflection;

namespace ApiMarketHub.Domain.SideEntities.Repository;
public interface IPosterRepository : IBaseRepository<Poster>
{
    void Delete(Poster poster);
}