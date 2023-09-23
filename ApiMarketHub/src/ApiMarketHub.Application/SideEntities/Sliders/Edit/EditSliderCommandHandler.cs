using ApiMarketHub.Domain.SideEntities;
using ApiMarketHub.Domain.SideEntities.Repository;
using Microsoft.AspNetCore.Http;
using Shared.Application;
using Shared.Application.FileUtil;
using Shared.Application.FileUtil.Interfaces;

namespace ApiMarketHub.Application.SideEntities.Sliders.Edit;
public class EditSliderCommandHandler : IBaseCommandHandler<EditSliderCommand>
{
    private readonly ISliderRepository _repository;
    private readonly IFileService _fileService;
    public EditSliderCommandHandler(ISliderRepository repository, IFileService fileService)
    {
        _repository = repository;
        _fileService = fileService;
    }

    public async Task<OperationResult> Handle(EditSliderCommand request, CancellationToken cancellationToken)
    {
        var Slider = await _repository.GetTracking(request.SilderId);
        if (Slider == null)
            return OperationResult.NotFound();

        var imageName = Slider.ImageName;
        var oldImage = Slider.ImageName;

        if (request.ImageFile != null)
            imageName = await _fileService.SaveFileAndGenerateName(request.ImageFile, Directories.SliderImages);

        Slider.Edit(request.Title, request.Link, imageName);

        await _repository.Save();
        DeleteOldImage(request.ImageFile, oldImage);
        return OperationResult.Success();
    }

    private void DeleteOldImage(IFormFile? imageFile, string oldImage)
    {
        if (imageFile != null)
            _fileService.DeleteFile(Directories.SliderImages, oldImage);
    }
}