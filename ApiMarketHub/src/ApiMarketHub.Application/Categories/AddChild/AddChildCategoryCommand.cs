using Shared.Application;
using Shared.Domain.ValueObjects;

namespace ApiMarketHub.Application.Categories.AddChild;
public record AddChildCategoryCommand(long parentId, string title, string slug, SeoData SeoData) : IBaseCommand<long>;