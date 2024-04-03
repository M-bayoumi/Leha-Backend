using Leha.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Leha.Infrastructure.Repositories.Generic;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    #region Fields
    protected readonly AppDbContext _dbContext;
    #endregion

    #region Constructors
    public GenericRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    #endregion

    #region Handle Functions
    public IQueryable<T?> GetTableNoTracking()
    {
        return _dbContext.Set<T>().AsNoTracking().AsQueryable();
    }
    public IQueryable<T?> GetTableAsTracking()
    {
        return _dbContext.Set<T>().AsQueryable();
    }

    public virtual async Task<T?> GetByIdAsync(int id)
    {
        return await _dbContext.Set<T>().FindAsync(id);
    }


    public virtual async Task<bool> AddAsync(T entity)
    {
        await _dbContext.Set<T>().AddAsync(entity);
        return await _dbContext.SaveChangesAsync() == 1;

    }
    public virtual async Task<bool> AddRangeAsync(ICollection<T> entities)
    {
        await _dbContext.Set<T>().AddRangeAsync(entities);
        return await _dbContext.SaveChangesAsync() == entities.Count();
    }
    public virtual async Task<bool> UpdateAsync(T entity)
    {
        _dbContext.Set<T>().Update(entity);
        return await _dbContext.SaveChangesAsync() == 1;
    }
    public virtual async Task<bool> UpdateRangeAsync(ICollection<T> entities)
    {
        _dbContext.Set<T>().UpdateRange(entities);
        return await _dbContext.SaveChangesAsync() == entities.Count();
    }
    public virtual async Task<bool> DeleteAsync(T entity)
    {
        _dbContext.Set<T>().Remove(entity);
        return await _dbContext.SaveChangesAsync() == 1;
    }
    public virtual async Task<bool> DeleteRangeAsync(ICollection<T> entities)
    {
        foreach (var entity in entities)
        {
            _dbContext.Set<T>().Remove(entity);
        }
        return await _dbContext.SaveChangesAsync() == entities.Count();
    }
    public IDbContextTransaction BeginTransaction()
    {
        return _dbContext.Database.BeginTransaction();
    }
    public void Commit()
    {
        _dbContext.Database.CommitTransaction();
    }
    public void RollBack()
    {
        _dbContext.Database.RollbackTransaction();
    }
    public async Task<int> SaveChangesAsync()
    {
        return await _dbContext.SaveChangesAsync();
    }
    #endregion
}
