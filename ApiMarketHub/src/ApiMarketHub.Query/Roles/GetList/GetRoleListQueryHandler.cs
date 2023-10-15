using ApiMarketHub.Infrastructure.Persistence.Command;
using ApiMarketHub.Query.Roles.DTOs;
using Microsoft.EntityFrameworkCore;
using Shared.Query;

namespace ApiMarketHub.Query.Roles.GetList;
public class GetRoleListQueryHandler : IQueryHandler<GetRoleListQuery, List<RoleDto>>
{
    private readonly MarketHubContext _context;
    public GetRoleListQueryHandler(MarketHubContext context)
    {
        _context = context;
    }

    public async Task<List<RoleDto>> Handle(GetRoleListQuery request, CancellationToken cancellationToken)
    {
        return await _context.Roles.Select(role => new RoleDto()
        {
            Id = role.Id,
            CreationDate = role.CreationDate,
            Permissions = role.Permissions.Select(s => s.Permission).ToList(),
            Title = role.Title
        }).ToListAsync(cancellationToken);
    }
}