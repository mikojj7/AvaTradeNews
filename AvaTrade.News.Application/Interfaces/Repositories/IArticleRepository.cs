using AvaTrade.News.Application.Common;
using AvaTrade.News.Application.Models;
using AvaTrade.News.Domain.Entities;

namespace AvaTrade.News.Application.Interfaces.Repositories;

public interface IArticleRepository : IRepository<Article>
{
    Task<List<ArticleModel>> GetAll(CancellationToken cancellationToken = default);
    Task<List<string>> GetAllRefIds(CancellationToken cancellationToken = default);
    Task<List<ArticleModel>> GetTodaysArticles(CancellationToken cancellationToken = default);
    Task<List<ArticleModel>> GetByInstrument(string instrumentName, int limit, CancellationToken cancellationToken = default);
    Task<List<ArticleModel>> Search(string text, CancellationToken cancellationToken = default);
    Task<List<ArticleModel>> GetLatestForInstruments(CancellationToken cancellationToken = default);
}
