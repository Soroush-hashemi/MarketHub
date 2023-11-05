using ApiMarketHub.Domain.ProductAggregate.Repository;
using Shared.Application;
using Shared.Application.FileUtil;
using Shared.Application.FileUtil.Interfaces;

namespace ApiMarketHub.Application.Products.RemoveImage;
public class RemoveImageProductCommandHandler : IBaseCommandHandler<RemoveProductCommandImage>
{
    private readonly IProductRepository _productRepository;
    private readonly IFileService _fileService;
    public RemoveImageProductCommandHandler(IProductRepository productRepository, IFileService fileService)
    {
        _productRepository = productRepository;
        _fileService = fileService;
    }

    public async Task<OperationResult> Handle(RemoveProductCommandImage request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetTracking(request.ProductId);
        if (product == null)
            return OperationResult.NotFound();

        var imageName = product.RemoveImage(request.ImageId);
        await _productRepository.Save();
        _fileService.DeleteFile(Directories.ProductGalleryImage, imageName);
        return OperationResult.Success();
    }
}