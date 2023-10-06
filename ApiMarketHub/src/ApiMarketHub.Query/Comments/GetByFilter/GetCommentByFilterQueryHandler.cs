using ApiMarketHub.Infrastructure.Persistence.Command;
using ApiMarketHub.Query.Comments.DTOs;
using Microsoft.EntityFrameworkCore;
using Shared.Query;

namespace ApiMarketHub.Query.Comments.GetByFilter;
public class GetCommentByFilterQueryHandler : IQueryHandler<GetCommentByFilterQuery, CommentFilterResult>
{
    private readonly Context _context;
    public GetCommentByFilterQueryHandler(Context context)
    {
        _context = context;
    }

    public async Task<CommentFilterResult> Handle(GetCommentByFilterQuery request, CancellationToken cancellationToken)
    {
        var @params = request.FilterParams;
        var result = _context.Comments.OrderByDescending(c => c.CreationDate).AsQueryable();

        if (@params.ProductId != null)
            result = result.Where(r => r.ProductId == @params.ProductId);

        if (@params.CommentStatus != null)
            result = result.Where(r => r.Status == @params.CommentStatus);

        if (@params.UserId != null)
            result = result.Where(r => r.UserId == @params.UserId);

        if (@params.StartDate != null)
            result = result.Where(r => r.CreationDate.Date >= @params.StartDate.Value.Date);

        if (@params.EndDate != null)
            result = result.Where(r => r.CreationDate.Date <= @params.EndDate.Value.Date);

        var skip = (@params.PageId - 1) * @params.Take;
        var model = new CommentFilterResult()
        {
            Data = await result.Skip(skip).Take(@params.Take)
                .Select(comment => comment.MapFilterComment())
                .ToListAsync(cancellationToken),
            FilterParams = @params
        };
        model.GeneratePaging(result, @params.Take, @params.PageId);
        return model;
    }
}