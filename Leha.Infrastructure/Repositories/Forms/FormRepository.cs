using Leha.Data.Entities;
using Leha.Infrastructure.Context;
using Leha.Infrastructure.Repositories.Generic;
using Microsoft.EntityFrameworkCore;

namespace Leha.Infrastructure.Repositories.Forms;


public class FormRepository : GenericRepository<Form>, IFormRepository
{
    #region Fields
    private readonly DbSet<Form> _forms;
    #endregion

    #region Constructors
    public FormRepository(AppDbContext appDbContext) : base(appDbContext)
    {
        _forms = appDbContext.Set<Form>();
    }
    #endregion

    #region Handle Functions
    public IQueryable<Form?> GetAllByJobId(int id)
    {
        return _forms.Where(x => x.JobId == id)
            .AsNoTracking()
            .AsQueryable();
    }
    #endregion
}
