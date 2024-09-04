using bernamji.Core.Entities;

namespace Bernamji.DataAccess.Repositories.Core;

public interface IBaseRepository<TEntity> where TEntity : BaseEntity
{
    Task<List<TEntity>> GetAllAsync();

    Task<TEntity> AddAsync(TEntity entity);

    TEntity UpdateAsync(TEntity entity);

    TEntity DeleteAsync(TEntity entity);
}