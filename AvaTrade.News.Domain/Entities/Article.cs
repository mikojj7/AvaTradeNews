using AvaTrade.News.Domain.Common;

namespace AvaTrade.News.Domain.Entities;

public class Article: IEntity
{
    public int Id { get; set; }
    public string RefId { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public DateTime PublishedDateTime { get; set; }
    public string ArticleUrl { get; set; }
    public string InstrumentName { get; set; }
    public DateTime FetchedDateTime { get; set; }
}
