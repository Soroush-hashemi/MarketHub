using ApiMarketHub.Domain.CommentAggregate.Repository;
using Shared.Application;

namespace ApiMarketHub.Application.Comments.Edit;
public class EditCommentCommandHandler : IBaseCommandHandler<EditCommentCommand>
{
    private readonly ICommentRepository _commentRepository;
    public EditCommentCommandHandler(ICommentRepository commentRepository)
    {
        _commentRepository = commentRepository;
    }

    public async Task<OperationResult> Handle(EditCommentCommand request, CancellationToken cancellationToken)
    {
        var comment = await _commentRepository.GetTracking(request.commentId);
        if (comment == null || comment.UserId != request.userId)
            return OperationResult.NotFound();

        comment.Edit(request.text);
        _commentRepository.Update(comment);
        await _commentRepository.Save();
        return OperationResult.Success();
    }
}