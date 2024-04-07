﻿using Microsoft.EntityFrameworkCore.Storage;

namespace Leha.Infrastructure.Repositories.Generic;

public interface IGenericRepository<T> where T : class
{
    IQueryable<T?> GetTableNoTracking();
    IQueryable<T?> GetTableAsTracking();
    Task<T?> GetByIdAsync(int id);
    Task<bool> AddAsync(T pm);
    Task<bool> AddRangeAsync(ICollection<T> pms);
    Task<bool> UpdateAsync(T pm);
    Task<bool> UpdateRangeAsync(ICollection<T> pms);
    Task<bool> DeleteAsync(T pm);
    Task<bool> DeleteRangeAsync(ICollection<T> pms);
    public void DetacheAsync(T pm);
    IDbContextTransaction BeginTransaction();
    void Commit();
    void RollBack();
    Task<int> SaveChangesAsync();
}
