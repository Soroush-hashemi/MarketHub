using ApiMarketHub.Application.Comments.ChangeStatus;
using ApiMarketHub.Application.Comments.Create;
using ApiMarketHub.Application.Comments.Delete;
using ApiMarketHub.Application.Comments.Edit;
using ApiMarketHub.PresentationFacade.Comments;
using ApiMarketHub.Query.Comments.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace MarketHub.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CommentController : ControllerBase
{
    private readonly ICommentFacade _commentFacade;
    public CommentController(ICommentFacade commentFacade)
    {
        _commentFacade = commentFacade;
    }

    [HttpPost]
    public async Task<ActionResult> Create(CreateCommentCommand command)
    {
        var result = await _commentFacade.Create(command);
        return Ok(result);
    }

    [HttpPut]
    public async Task<ActionResult> Edit(EditCommentCommand command)
    {
        var result = await _commentFacade.Edit(command);
        return Ok(result);
    }

    [HttpDelete]
    public async Task<ActionResult> Delete(DeleteCommentCommand command)
    {
        var result = await _commentFacade.Delete(command);
        return Ok(result);
    }

    [HttpPut("ChangeStatus")]
    public async Task<ActionResult> ChangeStatus(ChangeStatusCommentCommand command)
    {
        var result = await _commentFacade.ChangeStatus(command);
        return Ok(result);
    }

    [HttpGet("{commentId}")]
    public async Task<ActionResult<CommentDto?>> GetCommentById(long commentId)
    {
        var result = await _commentFacade.GetCommentById(commentId);
        return Ok(result);
    }

    [HttpGet]
    public async Task<ActionResult<CommentFilterResult>> GetCommentByFilter([FromQuery] CommentFilterParams filterParams)
    {
        var result = await _commentFacade.GetCommentByFilter(filterParams);
        return Ok(result);
    }
}