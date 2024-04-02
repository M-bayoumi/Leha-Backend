using Leha.Data.Entities;
using Leha.Infrastructure.Context;
using Leha.Infrastructure.Repositories.Generic;
using Microsoft.EntityFrameworkCore;

namespace Leha.Infrastructure.Repositories.Services;

public class BoardMemberRepository : GenericRepository<BoardMember>, IBoardMemberRepository
{
    #region Fields
    private readonly DbSet<BoardMember> _boardMembers;
    #endregion

    #region Constructors
    public BoardMemberRepository(AppDbContext appDbContext) : base(appDbContext)
    {
        _boardMembers = appDbContext.Set<BoardMember>();
    }

    #endregion

    #region Handle Functions

    #endregion
}
