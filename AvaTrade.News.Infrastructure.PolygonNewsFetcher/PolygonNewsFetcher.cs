using AvaTrade.News.Application.Interfaces;
using AvaTrade.News.Application.Models;
using AvaTrade.News.Infrastructure.PolygonNewsFetcher.Models;
using System.Net.Http.Json;

namespace AvaTrade.News.Infrastructure.PolygonNewsFetcher;

internal class PolygonNewsFetcher : INewsFetcher
{
    private readonly HttpClient _httpClient;

    public PolygonNewsFetcher(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<ArticleModel>> Fetch()
    {
        var polygonArticles = await _httpClient.GetFromJsonAsync<PolygonResult>("");

        return polygonArticles.Results.Select(p => new ArticleModel()
        {
            RefId = p.RefId,
            Title = p.Title,
            ArticleUrl = p.ArticleUrl,
            Author = p.Author,
            PublishedDateTime = p.PublishedDateTime,
        });
    }
}
