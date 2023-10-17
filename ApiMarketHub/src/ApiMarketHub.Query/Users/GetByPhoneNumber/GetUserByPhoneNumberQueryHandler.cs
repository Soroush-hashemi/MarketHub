using ApiMarketHub.Infrastructure.Persistence.Command;
using ApiMarketHub.Query.Users.DTOs;
using Microsoft.EntityFrameworkCore;
using Shared.Query;

namespace ApiMarketHub.Query.Users.GetByPhoneNumber;
public class GetUserByPhoneNumberQueryHandler : IQueryHandler<GetUserByPhoneNumberQuery, UserDto?>
{
    private readonly MarketHubContext _context;
    public GetUserByPhoneNumberQueryHandler(MarketHubContext context)
    {
        _context = context;
    }
    public async Task<UserDto?> Handle(GetUserByPhoneNumberQuery request, CancellationToken cancellationToken)
    {
        var user = await _context.Users.FirstOrDefaultAsync(f => f.PhoneNumber.Value == request.phoneNumber, cancellationToken);
        if (user == null)
            throw new ArgumentNullException();

        var userDto = await user.Map().SetUserRoleTitles(_context);
        return userDto;
    }
}