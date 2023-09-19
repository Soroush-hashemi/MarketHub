using Shared.Application;

namespace ApiMarketHub.Application.Products.RemoveImage;
public record RemoveImageProductCommand(long ProductId, long ImageId) : IBaseCommand;