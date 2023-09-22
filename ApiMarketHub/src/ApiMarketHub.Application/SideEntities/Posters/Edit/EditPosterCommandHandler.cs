using ApiMarketHub.Domain.SideEntities.Repository;
using Microsoft.AspNetCore.Http;
using Shared.Application;
using Shared.Application.FileUtil;
using Shared.Application.FileUtil.Interfaces;
using Shared.Application.SecurityUtil;

namespace ApiMarketHub.Application.SideEntities.Posters.Edit;
public class EditPosterCommandHandler : IBaseCommandHandler<EditPosterCommand>
{
    private readonly IPosterRepository _repository;
    private readonly IFileService _fileService;
    public EditPosterCommandHandler(IPosterRepository repository, IFileService fileService)
    {
        _repository = repository;
        _fileService = fileService;
    }

    public async Task<OperationResult> Handle(EditPosterCommand request, CancellationToken cancellationToken)
    {
        var poster = await _repository.GetTracking(request.PosterId);
        if (poster == null)
            return OperationResult.NotFound();

        var OldImage = poster.ImageName;
        var ImageName = poster.ImageName;

        if (request.ImageFile.IsImage())
            ImageName = await _fileService.SaveFileAndGenerateName(request.ImageFile, Directories.PosterImages);

        poster.Edit(request.Link, ImageName, request.Position);

        DeleteOldImage(request.ImageFile, OldImage);
        await _repository.Save();
        return OperationResult.Success();

    }

    private void DeleteOldImage(IFormFile? imageFile, string oldImage)
    {
        if (imageFile.IsImage())
            _fileService.DeleteFile(Directories.PosterImages, oldImage);
    }
}