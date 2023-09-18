using Shared.Application;

namespace ApiMarketHub.Application.Comments.Delete;
public record DeleteCommentCommand(long CommentId, long UserId) : IBaseCommand;