using AvaTrade.News.Application.Models;
using AvaTrade.News.Application.Modules.News.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AvaTrade.News.WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class NewsController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<NewsController> _logger;

    public NewsController(IMediator mediator, ILogger<NewsController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    [HttpGet]
    public async Task<List<ArticleModel>> GeAll()
    {
        var result = await _mediator.Send(new GetAllArticlesQuery());
        return result;  
    }
}