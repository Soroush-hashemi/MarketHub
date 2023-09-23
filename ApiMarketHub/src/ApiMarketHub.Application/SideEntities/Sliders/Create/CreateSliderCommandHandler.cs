using ApiMarketHub.Domain.SideEntities;
using ApiMarketHub.Domain.SideEntities.Repository;
using Shared.Application;
using Shared.Application.FileUtil;
using Shared.Application.FileUtil.Interfaces;

namespace ApiMarketHub.Application.SideEntities.Sliders.Create;
public class CreateSliderCommandHandler : IBaseCommandHandler<CreateSliderCommand>
{
    private readonly ISliderRepository _repository;
    private readonly IFileService _fileService;
    public CreateSliderCommandHandler(ISliderRepository repository, IFileService fileService)
    {
        _repository = repository;
        _fileService = fileService;
    }

    public async Task<OperationResult> Handle(CreateSliderCommand request, CancellationToken cancellationToken)
    {
        var ImageName = await _fileService.SaveFileAndGenerateName(request.ImageFile, Directories.SliderImages);
        var slider = new Slider(request.Title, request.Link, ImageName, request.IsActive);

        _repository.Add(slider);
        await _repository.Save();
        return OperationResult.Success();
    }
}