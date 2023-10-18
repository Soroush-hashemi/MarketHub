using ApiMarketHub.Application.Sellers.Create;
using ApiMarketHub.Application.Sellers.Edit;
using ApiMarketHub.Query.Sellers.DTOs;
using Shared.Application;

namespace ApiMarketHub.PresentationFacade.Sellers;
public interface ISellerFacade
{
    Task<OperationResult> CreateSeller(CreateSellerCommand command);
    Task<OperationResult> EditSeller(EditSellerCommand command);

    Task<SellerDto?> GetSellerById(long sellerId);
    Task<SellerDto?> GetSellerByUserId(long userId);
    Task<SellerFilterResult> GetSellersByFilter(SellerFilterParams filterParams);
}