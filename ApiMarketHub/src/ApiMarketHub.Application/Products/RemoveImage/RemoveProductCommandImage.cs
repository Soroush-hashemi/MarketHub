using Shared.Application;

namespace ApiMarketHub.Application.Products.RemoveImage;
public record RemoveProductCommandImage(long ProductId, long ImageId) : IBaseCommand;