using bernamji.Core.Entities;
using Bernamji.DataAccess.Persistence;
using Bernamji.DataAccess.Repositories.Core;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Bernamji.DataAccess.Repositories.Implementation;

public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
{
    protected readonly BernamjiDbContext dbContext;

    public BaseRepository(BernamjiDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<TEntity> AddAsync(TEntity entity)
    {
        var addedEntity = await dbContext.Set<TEntity>().AddAsync(entity);
        
        return addedEntity.Entity;
    }

    public TEntity DeleteAsync(TEntity entity)
    {
        var removedEntity = dbContext.Set<TEntity>().Remove(entity);
        
        return removedEntity.Entity;
    }

    public async Task<List<TEntity>> GetAllAsync()
    {
        return await dbContext.Set<TEntity>().ToListAsync();
    }
    public TEntity UpdateAsync(TEntity entity)
    {
        var UpdatedEntity = dbContext.Set<TEntity>().Update(entity);

        return UpdatedEntity.Entity;
    }
}