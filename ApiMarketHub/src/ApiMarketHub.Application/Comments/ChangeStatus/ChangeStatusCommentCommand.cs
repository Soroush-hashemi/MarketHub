using Shared.Application;
using ApiMarketHub.Domain.CommentAggregate.Enum;

namespace ApiMarketHub.Application.Comments.ChangeStatus;
public record ChangeStatusCommentCommand(long commentId, CommentStatus changeStatus) : IBaseCommand;