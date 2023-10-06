using ApiMarketHub.Query.Comments.DTOs;
using Shared.Query;

namespace ApiMarketHub.Query.Comments.GetById;
public record GetCommentByIdQuery(long CommentId) : IQuery<CommentDto?>;