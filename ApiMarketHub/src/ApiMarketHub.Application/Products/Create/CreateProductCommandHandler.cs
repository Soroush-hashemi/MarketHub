using ApiMarketHub.Domain.ProductAggregate;
using ApiMarketHub.Domain.ProductAggregate.Repository;
using ApiMarketHub.Domain.ProductAggregate.Service;
using Shared.Application;
using Shared.Application.FileUtil;
using Shared.Application.FileUtil.Interfaces;

namespace ApiMarketHub.Application.Products.Create;
public class CreateProductCommandHandler : IBaseCommandHandler<CreateProductCommand>
{
    private IProductRepository _productRepository;
    private readonly IFileService _fileService;
    private readonly IProductDomainService _domainService;
    public CreateProductCommandHandler(IProductRepository productRepository, IFileService fileService,
        IProductDomainService domainService)
    {
        _productRepository = productRepository;
        _fileService = fileService;
        _domainService = domainService;
    }

    public async Task<OperationResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var imageName = await _fileService.SaveFileAndGenerateName(request.ImageName, Directories.ProductImages);
        var product = new Product(request.Title, imageName, request.Description, request.CategoryId,
                request.SubCategoryId, request.SecondarySubCategoryId, _domainService, request.Slug, request.SeoData);

        _productRepository.Add(product);

        var specifications = new List<ProductSpecification>();
        request.Specifications.ToList().ForEach(specification =>
        {
            specifications.Add(new ProductSpecification(specification.Key, specification.Value));
        });

        product.SetSpecification(specifications);
        await _productRepository.Save();
        return OperationResult.Success();
    }
}