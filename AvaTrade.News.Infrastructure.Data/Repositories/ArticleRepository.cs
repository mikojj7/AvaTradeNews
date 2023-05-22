using AutoMapper;
using AutoMapper.QueryableExtensions;
using AvaTrade.News.Application.Interfaces.Repositories;
using AvaTrade.News.Application.Models;
using AvaTrade.News.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AvaTrade.News.Infrastructure.Data.Repositories;

public class ArticleRepository : GenericRepository<Article>, IArticleRepository
{
    private readonly IMapper _mapper;

    public ArticleRepository(NewsDbContext dbContext, IMapper mapper) : base(dbContext)
    {
        _mapper = mapper;
    }

    public Task<List<ArticleModel>> GetAll(CancellationToken cancellationToken = default) =>
        DbContext.Set<Article>().ProjectTo<ArticleModel>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);

    public Task<List<string>> GetAllRefIds(CancellationToken cancellationToken = default) =>
        DbContext.Set<Article>().Select(a => a.RefId).ToListAsync();


    public Task<List<ArticleModel>> GetByInstrument(string instrumentName, int limit = 10, CancellationToken cancellationToken = default) =>
        DbContext.Set<Article>()
            .Where(a => a.InstrumentName == instrumentName)
            .Take(limit)
            .ProjectTo<ArticleModel>(_mapper.ConfigurationProvider)
            .ToListAsync();

    public Task<List<ArticleModel>> GetLatestForInstruments(CancellationToken cancellationToken = default)
    {
        //use TSQL here for better performance
        throw new NotImplementedException();
    }

    public Task<List<ArticleModel>> GetTodaysArticles(CancellationToken cancellationToken = default)
    {
        var date = DateTime.UtcNow.Date;

        return DbContext.Set<Article>()
            .Where(a => a.FetchedDateTime > DateTime.UtcNow.Date)
            .ProjectTo<ArticleModel>(_mapper.ConfigurationProvider)
            .ToListAsync();
    }

    public Task<List<ArticleModel>> Search(string text, CancellationToken cancellationToken = default) =>
        DbContext.Set<Article>()
            .Where(a => a.Title.Contains(text, StringComparison.InvariantCultureIgnoreCase))
            .ProjectTo<ArticleModel>(_mapper.ConfigurationProvider)
            .ToListAsync();

}
