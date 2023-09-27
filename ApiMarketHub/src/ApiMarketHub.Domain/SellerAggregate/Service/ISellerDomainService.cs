namespace ApiMarketHub.Domain.SellerAggregate.Service;
public interface ISellerDomainService
{
    bool IsValidSellerInformation(Seller seller);
    bool NationalCodeExistInDataBase(string nationalCode);
}