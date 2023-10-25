using Shared.Application;

namespace ApiMarketHub.Application.Comments.Create;
public record CreateCommentCommand(long userId, long productId, string text) : IBaseCommand<long>;