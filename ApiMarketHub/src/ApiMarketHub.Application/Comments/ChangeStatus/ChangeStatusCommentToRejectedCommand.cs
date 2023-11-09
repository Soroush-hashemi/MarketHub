using Shared.Application;

namespace ApiMarketHub.Application.Comments.ChangeStatus;
public record ChangeStatusCommentToRejectedCommand(long commentId) : IBaseCommand;