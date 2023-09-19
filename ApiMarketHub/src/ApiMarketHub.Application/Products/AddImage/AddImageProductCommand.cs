using Microsoft.AspNetCore.Http;
using Shared.Application;

namespace ApiMarketHub.Application.Products.AddImage;
public class AddImageProductCommand : IBaseCommand
{
    public IFormFile ImageFile { get; set; }
    public long ProductId { get; set; }
    public int Sequence { get; set; }
}