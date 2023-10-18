using ApiMarketHub.Application.Comments.ChangeStatus;
using ApiMarketHub.Application.Comments.Create;
using ApiMarketHub.Application.Comments.Delete;
using ApiMarketHub.Application.Comments.Edit;
using ApiMarketHub.Query.Comments.DTOs;
using Shared.Application;

namespace ApiMarketHub.PresentationFacade.Comments;
public interface ICommentFacade
{
    Task<OperationResult> ChangeStatus(ChangeStatusCommentCommand command);
    Task<OperationResult> Create(CreateCommentCommand command);
    Task<OperationResult> Delete(DeleteCommentCommand command);
    Task<OperationResult> Edit(EditCommentCommand command);

    Task<CommentDto?> GetCommentById(long CommentId);
    Task<CommentFilterResult> GetCommentByFilter(CommentFilterParams filterParams);
}