using ApiMarketHub.Domain.SideEntities.Repository;
using Shared.Application;
using Shared.Application.FileUtil;
using Shared.Application.FileUtil.Interfaces;

namespace ApiMarketHub.Application.SideEntities.Posters.Delete;
public class DeletePosterCommandHandler : IBaseCommandHandler<DeletePosterCommand>
{
    private readonly IPosterRepository _repository;
    private readonly IFileService _fileService;
    public DeletePosterCommandHandler(IPosterRepository repository, IFileService fileService)
    {
        _repository = repository;
        _fileService = fileService;
    }

    public async Task<OperationResult> Handle(DeletePosterCommand request, CancellationToken cancellationToken)
    {
        var poster = await _repository.GetTracking(request.Poster);
        if (poster == null)
            return OperationResult.Success();

        _repository.Delete(poster);
        await _repository.Save();

        var ImageName = poster.ImageName;
        _fileService.DeleteFile(Directories.PosterImages, ImageName);

        return OperationResult.Success();
    }
}