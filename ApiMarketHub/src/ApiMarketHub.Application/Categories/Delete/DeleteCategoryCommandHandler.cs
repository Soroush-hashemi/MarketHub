using ApiMarketHub.Domain.CategoryAggregate.Repository;
using Shared.Application;

namespace ApiMarketHub.Application.Categories.Delete;
public class DeleteCategoryCommandHandler : IBaseCommandHandler<DeleteCategoryCommand>
{
    private readonly ICategoryRepository _categoryRepository;
    public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<OperationResult> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var result = await _categoryRepository.DeleteCategory(request.CategoryId);
        if (result is true)
        {
            await _categoryRepository.Save();
            return OperationResult.Success();
        }
        return OperationResult.Error("امکان حذف این دسته بندی وجود ندارد");
    }
}