using System.Text.Json.Serialization;

namespace AvaTrade.News.Infrastructure.PolygonNewsFetcher.Models;

public class PolygonArticle
{
    [JsonPropertyName("id")]
    public string RefId { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }

    [JsonPropertyName("published_utc")]
    public DateTime PublishedDateTime { get; set; }

    [JsonPropertyName("article_url")]
    public string ArticleUrl { get; set; }
    public IEnumerable<string> Keyword { get; set; }
    public IEnumerable<string> Tickers { get; set; }

}