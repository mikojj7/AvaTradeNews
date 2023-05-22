using AvaTrade.News.Application.Interfaces.Repositories;
using AvaTrade.News.Application.Models;
using MediatR;

namespace AvaTrade.News.Application.Modules.News.Queries;

public class GetAllArticlesQuery: IRequest<List<ArticleModel>>
{

}

internal class GetAllArticlesQueryHandler : IRequestHandler<GetAllArticlesQuery, List<ArticleModel>>
{
    private readonly IArticleRepository _articleRepository;

    public GetAllArticlesQueryHandler(IArticleRepository articleRepository)
    {
        _articleRepository = articleRepository;
    }

    public Task<List<ArticleModel>> Handle(GetAllArticlesQuery request, CancellationToken cancellationToken)
    {
        return _articleRepository.GetAll(cancellationToken);
    }
}
