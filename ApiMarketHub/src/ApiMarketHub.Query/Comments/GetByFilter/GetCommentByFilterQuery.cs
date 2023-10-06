using ApiMarketHub.Query.Comments.DTOs;
using Shared.Query;

namespace ApiMarketHub.Query.Comments.GetByFilter;
public class GetCommentByFilterQuery : QueryFilter<CommentFilterResult, CommentFilterParams>
{
    public GetCommentByFilterQuery(CommentFilterParams filterParams) : base(filterParams)
    {
        
    }
}