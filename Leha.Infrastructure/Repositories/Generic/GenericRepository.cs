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


    public virtual async Task<bool> AddAsync(T pm)
    {
        await _dbContext.Set<T>().AddAsync(pm);
        return await _dbContext.SaveChangesAsync() == 1;

    }
    public virtual async Task<bool> AddRangeAsync(ICollection<T> pms)
    {
        await _dbContext.Set<T>().AddRangeAsync(pms);
        return await _dbContext.SaveChangesAsync() == pms.Count();
    }
    public virtual async Task<bool> UpdateAsync(T pm)
    {
        _dbContext.Set<T>().Update(pm);
        return await _dbContext.SaveChangesAsync() == 1;
    }
    public virtual async Task<bool> UpdateRangeAsync(ICollection<T> pms)
    {
        _dbContext.Set<T>().UpdateRange(pms);
        return await _dbContext.SaveChangesAsync() == pms.Count();
    }
    public virtual async Task<bool> DeleteAsync(T pm)
    {
        _dbContext.Set<T>().Remove(pm);
        return await _dbContext.SaveChangesAsync() == 1;
    }
    public virtual async Task<bool> DeleteRangeAsync(ICollection<T> pms)
    {
        foreach (var pm in pms)
        {
            _dbContext.Set<T>().Remove(pm);
        }
        return await _dbContext.SaveChangesAsync() == pms.Count();
    }
    public virtual void DetacheAsync(T pm)
    {
        _dbContext.Entry(pm).State = EntityState.Detached;
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
