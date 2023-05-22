using AvaTrade.News.Application.Common;
using AvaTrade.News.Application.Interfaces.Repositories;
using AvaTrade.News.Domain.Entities;
using MediatR;

namespace AvaTrade.News.Application.Modules.Subscriptions.Commands;

public class SubscribeUserCommand :  IRequest<ServiceResult>
{
    public SubscribeUserCommand(string userId)
    {
        UserId = userId;
    }

    public string UserId { get; protected set; }
}

public class SubscribeUserCommandHandler : IRequestHandler<SubscribeUserCommand, ServiceResult>
{
    private readonly ISubscriptionRepository _subscriptionRepository;

    public SubscribeUserCommandHandler(ISubscriptionRepository subscriptionRepository)
    {
        _subscriptionRepository = subscriptionRepository;
    }

    public async Task<ServiceResult> Handle(SubscribeUserCommand request, CancellationToken cancellationToken)
    {
        _subscriptionRepository.Add(new Subscription(request.UserId));
        await _subscriptionRepository.SaveChangesAsync();

        return new ServiceResult() { Success = true };
    }
}
