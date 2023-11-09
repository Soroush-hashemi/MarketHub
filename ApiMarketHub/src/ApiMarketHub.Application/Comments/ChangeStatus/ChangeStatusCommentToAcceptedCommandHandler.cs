using ApiMarketHub.Domain.CommentAggregate.Enum;
using ApiMarketHub.Domain.CommentAggregate.Repository;
using Shared.Application;

namespace ApiMarketHub.Application.Comments.ChangeStatus;
public class ChangeStatusCommentToAcceptedCommandHandler : IBaseCommandHandler<ChangeStatusCommentToAcceptedCommand>
{
    private readonly ICommentRepository _commentRepository;
    public ChangeStatusCommentToAcceptedCommandHandler(ICommentRepository commentRepository)
    {
        _commentRepository = commentRepository;
    }

    public async Task<OperationResult> Handle(ChangeStatusCommentToAcceptedCommand request, CancellationToken cancellationToken)
    {
        var comment = await _commentRepository.GetTracking(request.commentId);
        if (comment == null)
            return OperationResult.NotFound();

        comment.ChangeStatus(CommentStatus.Accepted);
        await _commentRepository.Save();
        return OperationResult.Success();
    }
}