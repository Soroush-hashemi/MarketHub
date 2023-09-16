using ApiMarketHub.Domain.CategoryAggregate.Repository;
using ApiMarketHub.Domain.CategoryAggregate.Service;
using Shared.Application;

namespace ApiMarketHub.Application.Categories.AddChild;
public class AddChildCategoryCommandHandler : IBaseCommandHandler<AddChildCategoryCommand, long>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly ICategoryDomainService _domainService;
    public AddChildCategoryCommandHandler(ICategoryRepository categoryRepository, ICategoryDomainService domainService)
    {
        _categoryRepository = categoryRepository;
        _domainService = domainService;
    }

    public async Task<OperationResult<long>> Handle(AddChildCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetTracking(request.parentId);
        if (category == null)
            return OperationResult<long>.NotFound();

        category.AddChild(request.title, request.slug, request.SeoData, _domainService);
        await _categoryRepository.Save();
        return OperationResult<long>.Success(request.parentId);
    }
}