using AvaTrade.News.Application.Common;
using AvaTrade.News.Application.Interfaces;
using AvaTrade.News.Application.Interfaces.Repositories;
using AvaTrade.News.Application.Services;
using AvaTrade.News.Domain.Entities;
using MediatR;

namespace AvaTrade.News.Application.Modules.News.Commands;

public class ImportNewsCommand : IRequest<ServiceResult>
{
}

public class ImportNewsCommandHandler : IRequestHandler<ImportNewsCommand, ServiceResult>
{
    private readonly INewsFetcher _newsFetcher;
    private readonly IInstrumentMapper _instrumentMapper;
    private readonly IArticleRepository _articleRepository;

    public ImportNewsCommandHandler(
        INewsFetcher newsFetcher,
        IInstrumentMapper instrumentMapper,
        IArticleRepository articleRepository)
    {
        _newsFetcher = newsFetcher;
        _instrumentMapper = instrumentMapper;
        _articleRepository = articleRepository;
    }

    public async Task<ServiceResult> Handle(ImportNewsCommand request, CancellationToken cancellationToken)
    {
        var news = await _newsFetcher.Fetch();
        var persistedNewIds = await _articleRepository.GetAllRefIds();

        var newNews = news.ExceptBy(persistedNewIds, n => n.RefId);

        foreach (var article in newNews)
        {
            _articleRepository.Add(new Article()
            {
                RefId = article.RefId,
                Title = article.Title,
                ArticleUrl = article.ArticleUrl,
                Author = article.Author,
                PublishedDateTime = article.PublishedDateTime,
                FetchedDateTime = DateTime.UtcNow,
                InstrumentName = _instrumentMapper.GetInstrumentName(article.Title)
            });
        }

        //if the articles are too much, use batching - not save all at once
        if (newNews.Count() > 0)
        {   
            await _articleRepository.SaveChangesAsync();
        }

        //return propert status here - if there are no new news, if there is an error, etc. 
        return new ServiceResult()
        {
            Success = true
        };
    }
}
