using ApiMarketHub.Domain.CategoryAggregate.Repository;
using ApiMarketHub.Domain.CategoryAggregate.Service;
using Shared.Application;
using System;

namespace ApiMarketHub.Application.Categories.Edit;
public class EditCategoryCommandHandler : IBaseCommandHandler<EditCategoryCommand>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly ICategoryDomainService _domainService;
    public EditCategoryCommandHandler(ICategoryRepository categoryRepository, ICategoryDomainService domainService)
    {
        _categoryRepository = categoryRepository;
        _domainService = domainService;
    }

    public async Task<OperationResult> Handle(EditCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetTracking(request.Id);
        if (category == null)
            return OperationResult.NotFound();

        category.Edit(request.title, request.slug, request.seoData, _domainService);
        await _categoryRepository.Save();
        return OperationResult.Success();
    }
}