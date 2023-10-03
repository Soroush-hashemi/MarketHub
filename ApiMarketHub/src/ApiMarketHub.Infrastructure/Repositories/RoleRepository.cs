using ApiMarketHub.Domain.RoleAggregate;
using ApiMarketHub.Domain.RoleAggregate.Repository;
using ApiMarketHub.Infrastructure.Persistence.Command;
using ApiMarketHub.Infrastructure.Repositories.Base;

namespace ApiMarketHub.Infrastructure.Repositories;
public class RoleRepository : BaseRepository<Role> , IRoleRepository
{
    public RoleRepository(Context context) : base(context)
    {
        
    }
}