using AvaTrade.News.Domain.Common;

namespace AvaTrade.News.Application.Common;

public interface IRepository<TEntity> where TEntity : IEntity
{
    TEntity Add(TEntity entity);
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
}
