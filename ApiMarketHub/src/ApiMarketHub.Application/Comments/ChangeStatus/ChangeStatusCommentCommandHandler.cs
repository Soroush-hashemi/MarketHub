using ApiMarketHub.Domain.CommentAggregate.Repository;
using Shared.Application;
using System;

namespace ApiMarketHub.Application.Comments.ChangeStatus;
public class ChangeStatusCommentCommandHandler : IBaseCommandHandler<ChangeStatusCommentCommand>
{
    private readonly ICommentRepository _commentRepository;
    public ChangeStatusCommentCommandHandler(ICommentRepository commentRepository)
    {
        _commentRepository = commentRepository;
    }

    public async Task<OperationResult> Handle(ChangeStatusCommentCommand request, CancellationToken cancellationToken)
    {
        var comment = await _commentRepository.GetTracking(request.commentId);
        if (comment == null)
            return OperationResult.NotFound();

        comment.ChangeStatus(request.changeStatus);
        await _commentRepository.Save();
        return OperationResult.Success();
    }
}