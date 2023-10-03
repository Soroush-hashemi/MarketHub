using ApiMarketHub.Domain.CommentAggregate;
using ApiMarketHub.Domain.CommentAggregate.Repository;
using ApiMarketHub.Infrastructure.Persistence.Command;
using ApiMarketHub.Infrastructure.Repositories.Base;

namespace ApiMarketHub.Infrastructure.Repositories;
public class CommentRepository : BaseRepository<Comment>, ICommentRepository
{
    public CommentRepository(Context context) : base(context)
    {
    }

    public Task DeleteAndSave(Comment comment)
    {
        throw new NotImplementedException();
    }
}