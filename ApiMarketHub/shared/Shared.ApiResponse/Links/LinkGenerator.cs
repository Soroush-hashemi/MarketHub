using Shared.Application;

namespace Shared.ApiResponse.Links;
public static class LinkGenerator
{
    private static string Url = "https://localhost:7293/api/";
    public static List<LinkDto> AddLink<TData>(TData Result, string UrlPath)
    {
        var links = new List<LinkDto>()
        {
            new LinkDto($"{Url}/{UrlPath}/{Result}",$"update_{UrlPath}",HttpMethod.Put.Method),
            new LinkDto($"{Url}/{UrlPath}/{Result}",$"delete_{UrlPath}",HttpMethod.Delete.Method),
        };

        return links;
    }
}