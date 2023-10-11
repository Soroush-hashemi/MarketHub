using ApiMarketHub.Domain.UserAggregate;
using ApiMarketHub.Domain.UserAggregate.Repository;
using ApiMarketHub.Infrastructure.Persistence.Command;
using ApiMarketHub.Infrastructure.Repositories.Base;

namespace ApiMarketHub.Infrastructure.Repositories;
public class UserRepository : BaseRepository<User> , IUserRepository
{
    public UserRepository(MarketHubContext context) : base(context)
    {
        
    }
}
