using Microsoft.EntityFrameworkCore.Storage;

namespace Leha.Infrastructure.Repositories.Generic;

public interface IGenericRepository<T> where T : class
{
    IQueryable<T?> GetTableNoTracking();
    IQueryable<T?> GetTableAsTracking();
    Task<T?> GetByIdAsync(int id);
    Task<bool> AddAsync(T entity);
    Task<bool> AddRangeAsync(ICollection<T> entities);
    Task<bool> UpdateAsync(T entity);
    Task<bool> UpdateRangeAsync(ICollection<T> entities);
    Task<bool> DeleteAsync(T entity);
    Task<bool> DeleteRangeAsync(ICollection<T> entities);
    IDbContextTransaction BeginTransaction();
    void Commit();
    void RollBack();
    Task<int> SaveChangesAsync();
}
