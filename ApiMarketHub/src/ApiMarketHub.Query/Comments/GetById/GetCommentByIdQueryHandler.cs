using ApiMarketHub.Infrastructure.Persistence.Command;
using ApiMarketHub.Query.Comments.DTOs;
using Microsoft.EntityFrameworkCore;
using Shared.Query;

namespace ApiMarketHub.Query.Comments.GetById;
public class GetCommentByIdQueryHandler : IQueryHandler<GetCommentByIdQuery, CommentDto?>
{
    private readonly MarketHubContext _context;
    public GetCommentByIdQueryHandler(MarketHubContext context)
    {
        _context = context;
    }

    public async Task<CommentDto?> Handle(GetCommentByIdQuery request, CancellationToken cancellationToken)
    {
        var comment = await _context.Comments.FirstOrDefaultAsync(c => c.Id == request.CommentId, cancellationToken: cancellationToken);

        return comment.Map();
    }
}