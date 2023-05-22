
namespace AvaTrade.News.Application.Models;

public class ArticleModel
{
    public int Id { get; set; }
    public string RefId { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public DateTime PublishedDateTime { get; set; }
    public string ArticleUrl { get; set; }
    public string InstrumentName { get; set; }
}
