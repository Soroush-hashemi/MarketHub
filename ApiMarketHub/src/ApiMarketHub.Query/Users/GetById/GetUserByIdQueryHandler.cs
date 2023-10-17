using ApiMarketHub.Infrastructure.Persistence.Command;
using ApiMarketHub.Query.Users.DTOs;
using Microsoft.EntityFrameworkCore;
using Shared.Query;

namespace ApiMarketHub.Query.Users.GetById;
public class GetUserByIdQueryHandler : IQueryHandler<GetUserByIdQuery, UserDto?>
{
    private readonly MarketHubContext _context;
    public GetUserByIdQueryHandler(MarketHubContext context)
    {
        _context = context;
    }

    public async Task<UserDto?> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _context.Users.FirstOrDefaultAsync(f => f.Id == request.UserId, cancellationToken);
        if (user == null)
            throw new ArgumentNullException();

        var userDto = await user.Map().SetUserRoleTitles(_context);
        return userDto;
    }
}