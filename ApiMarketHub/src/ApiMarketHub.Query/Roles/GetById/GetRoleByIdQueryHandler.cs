using ApiMarketHub.Infrastructure.Persistence.Command;
using ApiMarketHub.Query.Roles.DTOs;
using Microsoft.EntityFrameworkCore;
using Shared.Domain.Exceptions;
using Shared.Query;

namespace ApiMarketHub.Query.Roles.GetById;
public class GetRoleByIdQueryHandler : IQueryHandler<GetRoleByIdQuery, RoleDto?>
{
    private readonly MarketHubContext _context;
    public GetRoleByIdQueryHandler(MarketHubContext context)
    {
        _context = context;
    }

    public async Task<RoleDto?> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
    {
        var role = await _context.Roles.FirstOrDefaultAsync(r => r.Id == request.RoleId, cancellationToken);
        if (role == null)
            throw new NullOrEmptyException();

        return new RoleDto()
        {
            Id = role.Id,
            CreationDate = role.CreationDate,
            Permissions = role.Permissions.Select(s => s.Permission).ToList(),
            Title = role.Title
        };
    }
}