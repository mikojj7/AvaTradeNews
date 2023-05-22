using AvaTrade.News.Application.Common;
using AvaTrade.News.Domain.Common;

namespace AvaTrade.News.Infrastructure.Data;

public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
{
    protected readonly NewsDbContext DbContext;

    public GenericRepository(NewsDbContext dbContext) => DbContext = dbContext;
    
    public TEntity Add(TEntity entity)
    {
        DbContext.Set<TEntity>().Add(entity);
        return entity;
    }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) => DbContext.SaveChangesAsync(cancellationToken);    
}
