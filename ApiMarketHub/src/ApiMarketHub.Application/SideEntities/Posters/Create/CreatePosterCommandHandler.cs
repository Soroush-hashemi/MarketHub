using ApiMarketHub.Domain.SideEntities;
using ApiMarketHub.Domain.SideEntities.Repository;
using Shared.Application;
using Shared.Application.FileUtil;
using Shared.Application.FileUtil.Interfaces;

namespace ApiMarketHub.Application.SideEntities.Posters.Create;
public class CreatePosterCommandHandler : IBaseCommandHandler<CreatePosterCommand>
{
    private readonly IPosterRepository _repository;
    private readonly IFileService _fileService;
    public CreatePosterCommandHandler(IPosterRepository repository, IFileService fileService)
    {
        _repository = repository;
        _fileService = fileService;
    }
    public async Task<OperationResult> Handle(CreatePosterCommand request, CancellationToken cancellationToken)
    {
        var ImageName = await _fileService.SaveFileAndGenerateName(request.ImageFile, Directories.PosterImages);
        var poster = new Poster(request.Link, ImageName, request.Position);

        _repository.Add(poster);
        await _repository.Save();
        return OperationResult.Success();
    }
}