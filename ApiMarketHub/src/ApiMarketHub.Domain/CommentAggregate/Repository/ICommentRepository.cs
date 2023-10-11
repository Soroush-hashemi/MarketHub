using Shared.Domain.Repository;

namespace ApiMarketHub.Domain.CommentAggregate.Repository;
public interface ICommentRepository : IBaseRepository<Comment>
{
    Task DeleteAndSave(Comment comment);
}