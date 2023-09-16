using Shared.Application;

namespace ApiMarketHub.Application.Comments.Edit;
public record EditCommentCommand(long commentId, long userId, string text) : IBaseCommand;