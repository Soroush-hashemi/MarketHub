using Shared.Application;

namespace ApiMarketHub.Application.Categories.Delete;
public record DeleteCategoryCommand(long CategoryId) : IBaseCommand;