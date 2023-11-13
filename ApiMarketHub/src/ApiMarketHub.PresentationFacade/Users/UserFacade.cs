using ApiMarketHub.Application.Users.Create;
using ApiMarketHub.Application.Users.Edit;
using ApiMarketHub.Domain.UserAggregate;
using ApiMarketHub.Query.Users.DTOs;
using ApiMarketHub.Query.Users.GetByFilter;
using ApiMarketHub.Query.Users.GetById;
using ApiMarketHub.Query.Users.GetByPhoneNumber;
using MediatR;
using Shared.Application;

namespace ApiMarketHub.PresentationFacade.Users;
internal class UserFacade : IUserFacade
{
    private readonly IMediator _mediator;

    public UserFacade(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<OperationResult> Create(CreateUserCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> Edit(EditUserCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<UserFilterResult> GetUserByFilter(UserFilterParams filterParams)
    {
        return await _mediator.Send(new GetUserByFilterQuery(filterParams));
    }

    public async Task<UserDto?> GetUserById(long userId)
    {
        return await _mediator.Send(new GetUserByIdQuery(userId));
    }

    public async Task<UserDto?> GetUserByPhoneNumber(string phoneNumber)
    {
        return await _mediator.Send(new GetUserByPhoneNumberQuery(phoneNumber));
    }
}