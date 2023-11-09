using Shared.Application;

namespace ApiMarketHub.Application.Comments.ChangeStatus;
public record ChangeStatusCommentToAcceptedCommand(long commentId) : IBaseCommand;