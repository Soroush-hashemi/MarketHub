﻿using ApiMarketHub.Application.Sellers.ChangeStatus;
using ApiMarketHub.Application.Sellers.Create;
using ApiMarketHub.Application.Sellers.Edit;
using ApiMarketHub.Query.Sellers.DTOs;
using ApiMarketHub.Query.Sellers.GetByFilter;
using ApiMarketHub.Query.Sellers.GetById;
using ApiMarketHub.Query.Sellers.GetByUserId;
using MediatR;
using Shared.Application;

namespace ApiMarketHub.PresentationFacade.Sellers;
internal class SellerFacade : ISellerFacade
{
    private readonly IMediator _mediator;
    public SellerFacade(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<OperationResult> ChangeStatusSellerToAccepted(ChangeStatusSellerToAcceptedCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> ChangeStatusSellerToRejected(ChangeStatusSellerToRejectedCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> Create(CreateSellerCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> Edit(EditSellerCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<SellerDto?> GetSellerById(long sellerId)
    {
        return await _mediator.Send(new GetSellerByIdQuery(sellerId));
    }

    public async Task<SellerDto?> GetSellerByUserId(long userId)
    {
        return await _mediator.Send(new GetSellerByUserIdQuery(userId));
    }

    public async Task<SellerFilterResult> GetSellersByFilter(SellerFilterParams filterParams)
    {
        return await _mediator.Send(new GetSellerByFilterQuery(filterParams));
    }
}