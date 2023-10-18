﻿using ApiMarketHub.Application.Comments.ChangeStatus;
using ApiMarketHub.Application.Comments.Create;
using ApiMarketHub.Application.Comments.Delete;
using ApiMarketHub.Application.Comments.Edit;
using ApiMarketHub.Query.Comments.DTOs;
using ApiMarketHub.Query.Comments.GetByFilter;
using ApiMarketHub.Query.Comments.GetById;
using MediatR;
using Shared.Application;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ApiMarketHub.PresentationFacade.Comments;
internal class CommentFacade : ICommentFacade
{
    private readonly Mediator _mediator;
    public CommentFacade(Mediator mediator)
    {
        _mediator = mediator;
    }
    public async Task<OperationResult> ChangeStatus(ChangeStatusCommentCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> Create(CreateCommentCommand command)
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