using ApiMarketHub.Domain.SellerAggregate;
using ApiMarketHub.Domain.SellerAggregate.Repository;
using ApiMarketHub.Domain.SellerAggregate.Service;

namespace ApiMarketHub.Application.Sellers;
internal class SellerDomainService : ISellerDomainService
{
    private readonly ISellerRepository _repository;
    public SellerDomainService(ISellerRepository repository)
    {
        _repository = repository;
    }

    public bool IsValidSellerInformation(Seller seller) // اگر در سیستم موجود باشند مقدار فالس را برمیگردانیم
    {
        var sellerIsExit = _repository.Exists(s => s.NationalCode == seller.NationalCode || s.UserId == seller.UserId);
        return !sellerIsExit; // اگر مقادیر در سیستم وحود داشت واریبل ما ترو میشود و ما اون را فالس میکنیم و سپس برمیگردانیم
    }

    public bool NationalCodeExistInDataBase(string nationalCode)
    {
        return _repository.Exists(n => n.NationalCode == nationalCode);
    }
}