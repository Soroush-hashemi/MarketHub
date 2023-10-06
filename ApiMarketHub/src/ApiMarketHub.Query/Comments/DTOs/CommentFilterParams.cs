using ApiMarketHub.Domain.CommentAggregate.Enum;
using Shared.Query.Bases;

namespace ApiMarketHub.Query.Comments.DTOs;
public class CommentFilterParams : BaseFilterParam
{
    public long? UserId { get; set; }
    public long? ProductId { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public CommentStatus? CommentStatus { get; set; }
}

public class CommentFilterResult : BaseFilter<CommentDto, CommentFilterParams>
{

}