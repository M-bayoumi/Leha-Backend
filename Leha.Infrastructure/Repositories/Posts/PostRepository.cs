using Leha.Data.Entities;
using Leha.Infrastructure.Context;
using Leha.Infrastructure.Repositories.Generic;
using Microsoft.EntityFrameworkCore;

namespace Leha.Infrastructure.Repositories.Posts;


public class PostRepository : GenericRepository<Post>, IPostRepository
{
    #region Fields
    private readonly DbSet<Post> _posts;
    #endregion

    #region Constructors
    public PostRepository(AppDbContext appDbContext) : base(appDbContext)
    {
        _posts = appDbContext.Set<Post>();
    }

    #endregion

    #region Handle Functions

    public async Task<List<Post?>> GetPostsListByCompanyId(int companyID)
    {
        return await _posts.Where(x => x.CompanyID == companyID).ToListAsync();
    }

    #endregion
}
