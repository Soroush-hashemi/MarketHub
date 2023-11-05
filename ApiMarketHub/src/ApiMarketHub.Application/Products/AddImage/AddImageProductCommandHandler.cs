using ApiMarketHub.Domain.ProductAggregate;
using ApiMarketHub.Domain.ProductAggregate.Repository;
using Shared.Application;
using Shared.Application.FileUtil;
using Shared.Application.FileUtil.Interfaces;

namespace ApiMarketHub.Application.Products.AddImage;
public class AddImageProductCommandHandler : IBaseCommandHandler<AddProductImageCommand>
{
    private readonly IProductRepository _productRepository;
    private readonly IFileService _fileService;
    public AddImageProductCommandHandler(IProductRepository productRepository, IFileService fileService)
    {
        _productRepository = productRepository;
        _fileService = fileService;
    }

    public async Task<OperationResult> Handle(AddProductImageCommand request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetTracking(request.ProductId);
        if (product == null)
            return OperationResult.NotFound();

        var imageName = await _fileService.SaveFileAndGenerateName(request.ImageFile, Directories.ProductGalleryImage);
        var productImage = new ProductImage(imageName, request.Sequence);

        product.AddImage(productImage);
        await _productRepository.Save();
        return OperationResult.Success();
    }
}