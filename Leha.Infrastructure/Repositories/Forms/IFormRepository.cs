using Leha.Data.Entities;
using Leha.Infrastructure.Repositories.Generic;

namespace Leha.Infrastructure.Repositories.Forms;

public interface IFormRepository : IGenericRepository<Form>
{
    public Task<List<Form>?> GetFormsListByJobId(int jobID);
}
