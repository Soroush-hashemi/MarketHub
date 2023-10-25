using ApiMarketHub.Application.Comments.ChangeStatus;
using ApiMarketHub.Application.Comments.Create;
using ApiMarketHub.Application.Comments.Delete;
using ApiMarketHub.Application.Comments.Edit;
using ApiMarketHub.PresentationFacade.Comments;
using ApiMarketHub.Query.Comments.DTOs;
using Microsoft.AspNetCore.Mvc;
using Shared.ApiResponse;
using System.Net;

namespace MarketHub.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CommentController : ApiController
{
    private readonly ICommentFacade _commentFacade;
    public CommentController(ICommentFacade commentFacade)
    {
        _commentFacade = commentFacade;
    }

    [HttpPost]
    public async Task<ApiResult<long>> Create(CreateCommentCommand command)
    {
        var result = await _commentFacade.Create(command);
        var Path = "Comment";
        return CommandResult(result, HttpStatusCode.Created, Path);
    }

    [HttpPut]
    public async Task<ApiResult> Edit(EditCommentCommand command)
    {
        var result = await _commentFacade.Edit(command);
        return CommandResult(result);
    }

    [HttpDelete]
    public async Task<ApiResult> Delete(DeleteCommentCommand command)
    {
        var result = await _commentFacade.Delete(command);
        return CommandResult(result);
    }

    [HttpPut("ChangeStatus")]
    public async Task<ApiResult> ChangeStatus(ChangeStatusCommentCommand command)
    {
        var result = await _commentFacade.ChangeStatus(command);
        return CommandResult(result);
    }

    [HttpGet("{commentId}")]
    public async Task<ApiResult<CommentDto?>> GetCommentById(long commentId)
    {
        var result = await _commentFacade.GetCommentById(commentId);
        return QueryResult(result);
    }

    [HttpGet("Filter")]
    public async Task<ApiResult<CommentFilterResult>> GetCommentByFilter(CommentFilterParams filterParams)
    {
        var result = await _commentFacade.GetCommentByFilter(filterParams);
        return QueryResult(result);
    }
}