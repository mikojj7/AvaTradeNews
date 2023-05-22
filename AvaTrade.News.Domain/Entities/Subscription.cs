using AvaTrade.News.Domain.Common;

namespace AvaTrade.News.Domain.Entities;

public class Subscription : IEntity
{
    public int Id { get; protected set; }
    public string UserId { get; protected set; }

    public Subscription(string userId)
    {
        UserId = userId;
    }
}
