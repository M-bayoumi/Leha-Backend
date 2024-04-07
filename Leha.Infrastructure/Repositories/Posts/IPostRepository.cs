using Leha.Data.Entities;
using Leha.Infrastructure.Repositories.Generic;

namespace Leha.Infrastructure.Repositories.Posts;

public interface IPostRepository : IGenericRepository<Post>
{
    public IQueryable<Post?> GetPostsListByCompanyId(int id);

}