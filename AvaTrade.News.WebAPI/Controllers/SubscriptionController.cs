using AvaTrade.News.Application.Modules.Subscriptions.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AvaTrade.News.WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class SubscriptionController: ControllerBase
{
    private readonly IMediator _mediator;

    public SubscriptionController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> SubscribeUser()
    {
        //load userId from httpContext through httpContextAccessor
        var userId = "";
        await _mediator.Send(new SubscribeUserCommand(userId));

        return Ok();
    }
}
