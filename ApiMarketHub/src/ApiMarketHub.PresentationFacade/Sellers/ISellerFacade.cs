﻿using ApiMarketHub.Application.Sellers.ChangeStatus;
using ApiMarketHub.Application.Sellers.Create;
using ApiMarketHub.Application.Sellers.Edit;
using ApiMarketHub.Query.Sellers.DTOs;
using Shared.Application;

namespace ApiMarketHub.PresentationFacade.Sellers;
public interface ISellerFacade
{
    Task<OperationResult> Create(CreateSellerCommand command);
    Task<OperationResult> Edit(EditSellerCommand command);
    Task<OperationResult> ChangeStatusSellerToRejected(ChangeStatusSellerToRejectedCommand command);
    Task<OperationResult> ChangeStatusSellerToAccepted(ChangeStatusSellerToAcceptedCommand command);


    Task<SellerDto?> GetSellerById(long sellerId);
    Task<SellerDto?> GetSellerByUserId(long userId);
    Task<SellerFilterResult> GetSellersByFilter(SellerFilterParams filterParams);
}