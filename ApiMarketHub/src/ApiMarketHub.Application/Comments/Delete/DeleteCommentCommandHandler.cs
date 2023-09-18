using ApiMarketHub.Domain.CommentAggregate.Repository;
using Shared.Application;

namespace ApiMarketHub.Application.Comments.Delete;
public class DeleteCommentCommandHandler : IBaseCommandHandler<DeleteCommentCommand>
{
    private readonly ICommentRepository _commentRepository;
    public DeleteCommentCommandHandler(ICommentRepository commentRepository)
    {
        _commentRepository = commentRepository;
    }
    public async Task<OperationResult> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
    {
        var comment = await _commentRepository.GetTracking(request.CommentId);
        if (comment == null || comment.UserId != request.UserId)
            return OperationResult.NotFound();

        await _commentRepository.DeleteAndSave(comment);
        return OperationResult.Success();
    }
}