using AvaTrade.News.Application.Models;

namespace AvaTrade.News.Application.Interfaces;

public interface INewsFetcher
{
    Task<IEnumerable<ArticleModel>> Fetch();
}
