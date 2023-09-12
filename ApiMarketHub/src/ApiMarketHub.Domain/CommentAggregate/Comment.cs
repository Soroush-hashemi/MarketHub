using ApiMarketHub.Domain.CommentAggregate.Enum;
using Shared.Domain.Bases;
using Shared.Domain.Exceptions;

namespace ApiMarketHub.Domain.CommentAggregate;
public class Comment : AggregateRoot
{
    public long UserId { get; private set; }
    public long ProductId { get; private set; }
    public string Text { get; private set; }
    public CommentStatus Status { get; private set; }
    public DateTime UpdateDate { get; private set; }

    public Comment(long userId, long productId, string text)
    {
        NullOrEmptyException.CheckString(text, nameof(text));
        UserId = userId;
        ProductId = productId;
        Text = text;
        Status = CommentStatus.Pending;
    }

    public void Edit(string text)
    {
        NullOrEmptyException.CheckString(text, nameof(text));
        Text = text;
        UpdateDate = DateTime.Now;
    }

    public void ChangeStatus(CommentStatus status)
    {
        Status = status;
        UpdateDate = DateTime.Now;
    }
}