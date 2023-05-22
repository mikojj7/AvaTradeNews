using AutoMapper;
using AvaTrade.News.Application.Models;
using AvaTrade.News.Domain.Entities;

namespace AvaTrade.News.Application.Mappings;

public class ArticleMapping: Profile
{
    public ArticleMapping()
    {
        CreateMap<Article, ArticleModel>();
    }
}
