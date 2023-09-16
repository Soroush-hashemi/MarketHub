using Shared.Application;
using Shared.Domain.ValueObjects;

namespace ApiMarketHub.Application.Categories.Edit;
public record EditCategoryCommand(long Id, string title, string slug, SeoData seoData) : IBaseCommand;