using ApiMarketHub.Domain.CommentAggregate.Enum;
using ApiMarketHub.Domain.CommentAggregate.Repository;
using Shared.Application;

namespace ApiMarketHub.Application.Comments.ChangeStatus;
public class ChangeStatusCommentToRejectedCommandHandler : IBaseCommandHandler<ChangeStatusCommentToRejectedCommand>
{
    private readonly ICommentRepository _commentRepository;
    public ChangeStatusCommentToRejectedCommandHandler(ICommentRepository commentRepository)
    {
        _commentRepository = commentRepository;
    }

    public async Task<OperationResult> Handle(ChangeStatusCommentToRejectedCommand request, CancellationToken cancellationToken)
    {
        var comment = await _commentRepository.GetTracking(request.commentId);
        if (comment == null)
            return OperationResult.NotFound();

        comment.ChangeStatus(CommentStatus.Rejected);
        await _commentRepository.Save();
        return OperationResult.Success();
    }
}