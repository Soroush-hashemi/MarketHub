using ApiMarketHub.Domain.UserAggregate.Repository;
using ApiMarketHub.Domain.UserAggregate.Service;
using Microsoft.AspNetCore.Http;
using Shared.Application;
using Shared.Application.FileUtil;
using Shared.Application.FileUtil.Interfaces;

namespace ApiMarketHub.Application.Users.Edit;
public class EditUserCommandHandler : IBaseCommandHandler<EditUserCommand>
{
    private readonly IUserRepository _userRepository;
    private readonly IUserDomainService _domainService;
    private readonly IFileService _fileService;
    public EditUserCommandHandler(IUserDomainService domainService, IUserRepository userRepository, IFileService fileService)
    {
        _domainService = domainService;
        _userRepository = userRepository;
        _fileService = fileService;
    }

    public async Task<OperationResult> Handle(EditUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetTracking(request.UserId);
        if (user == null)
            return OperationResult.NotFound();

        var oldAvatar = user.AvatarName;

        user.Edit(request.Name, request.Family, request.PhoneNumber, request.Email, request.Gender, _domainService);

        if (request.Avatar != null)
        {
            var imageName = await _fileService.SaveFileAndGenerateName(request.Avatar, Directories.UserAvatars);
            user.SetAvatar(imageName);
        }

        DeleteOldAvatar(request.Avatar, oldAvatar);
        await _userRepository.Save();
        return OperationResult.Success();

    }

    private void DeleteOldAvatar(IFormFile? Imagefile, string oldImage)
    {
        if (oldImage == "avatar.png" || Imagefile == null)
            return;

        _fileService.DeleteFile(Directories.UserAvatars, oldImage);
    }
}