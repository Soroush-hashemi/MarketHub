using Shared.Application;
using Shared.Domain.ValueObjects;

namespace ApiMarketHub.Application.Categories.Create;
public record CreateCategoryCommand(string title, string slug, SeoData seoData) : IBaseCommand<long>;