using ApiMarketHub.Application.Comments.ChangeStatus;
using ApiMarketHub.Application.Comments.Create;
using ApiMarketHub.Application.Comments.Delete;
using ApiMarketHub.Application.Comments.Edit;
using ApiMarketHub.Query.Comments.DTOs;
using ApiMarketHub.Query.Comments.GetByFilter;
using ApiMarketHub.Query.Comments.GetById;
using MediatR;
using Shared.Application;

namespace ApiMarketHub.PresentationFacade.Comments;
internal class CommentFacade : ICommentFacade
{
    private readonly IMediator _mediator;
    public CommentFacade(IMediator mediator)
    {
        _mediator = mediator;
    }
    public async Task<OperationResult> ChangeStatus(ChangeStatusCommentCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult<long>> Create(CreateCommentCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> Delete(DeleteCommentCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> Edit(EditCommentCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<CommentFilterResult> GetCommentByFilter(CommentFilterParams filterParams)
    {
        return await _mediator.Send(new GetCommentByFilterQuery(filterParams));
    }

    public async Task<CommentDto?> GetCommentById(long CommentId)
    {
        return await _mediator.Send(new GetCommentByIdQuery(CommentId));
    }
}