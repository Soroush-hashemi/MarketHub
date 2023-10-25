using ApiMarketHub.Domain.CommentAggregate;
using ApiMarketHub.Domain.CommentAggregate.Repository;
using Shared.Application;
using System;

namespace ApiMarketHub.Application.Comments.Create;
public class CreateCommentCommandHandler : IBaseCommandHandler<CreateCommentCommand, long>
{
    private readonly ICommentRepository _commentRepository;
    public CreateCommentCommandHandler(ICommentRepository commentRepository)
    {
        _commentRepository = commentRepository;
    }

    public async Task<OperationResult<long>> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
    {
        var comment = new Comment(request.userId, request.productId, request.text);
        _commentRepository.Add(comment);
        await _commentRepository.Save();
        return OperationResult<long>.Success(comment.Id);
    }
}