using ApiMarketHub.Domain.CommentAggregate.Enum;
using Shared.Query.Bases;

namespace ApiMarketHub.Query.Comments.DTOs;
public class CommentDto : BaseDto
{
    public long ProductId { get; set; }
    public long UserId { get; set; }
    public string UserFullName { get; set; }
    public string ProductTitle { get; set; }
    public string Text { get; set; }
    public CommentStatus Status { get; set; }
}