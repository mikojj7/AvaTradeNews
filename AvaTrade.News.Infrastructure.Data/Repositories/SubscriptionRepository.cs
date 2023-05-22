using AvaTrade.News.Application.Interfaces.Repositories;
using AvaTrade.News.Domain.Entities;

namespace AvaTrade.News.Infrastructure.Data.Repositories;

public class SubscriptionRepository : GenericRepository<Subscription>, ISubscriptionRepository
{
    public SubscriptionRepository(NewsDbContext dbContext) : base(dbContext)
    {

    }
}
