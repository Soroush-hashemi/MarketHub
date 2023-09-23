using ApiMarketHub.Domain.SideEntities.Repository;
using Shared.Application;
using Shared.Application.FileUtil;
using Shared.Application.FileUtil.Interfaces;

namespace ApiMarketHub.Application.SideEntities.Sliders.Delete;
public class DeleteSliderCommandHandler : IBaseCommandHandler<DeleteSliderCommand>
{
    private readonly ISliderRepository _repository;
    private readonly IFileService _fileService;
    public DeleteSliderCommandHandler(IPosterRepository repository, IFileService fileService)
    {
        _repository = repository;
        _fileService = fileService;
    }

    public async Task<OperationResult> Handle(DeleteSliderCommand request, CancellationToken cancellationToken)
    {
        var slider = await _repository.GetTracking(request.SliderId);
        if (slider == null)
            return OperationResult.NotFound();

        _repository.Delete(slider);
        await _repository.Save();

        _fileService.DeleteFile(Directories.SliderImages, slider.ImageName);
        return OperationResult.Success();
    }
}