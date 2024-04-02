using Leha.Data.Entities;
using Leha.Infrastructure.Context;
using Leha.Infrastructure.Repositories.Generic;
using Microsoft.EntityFrameworkCore;

namespace Leha.Infrastructure.Repositories.BoardMemberSpeeches;

public class BoardMemberSpeechRepository : GenericRepository<BoardMemberSpeech>, IBoardMemberSpeechRepository
{
    #region Fields
    private readonly DbSet<BoardMemberSpeech> _boardMemberSpeeches;
    #endregion

    #region Constructors
    public BoardMemberSpeechRepository(AppDbContext appDbContext) : base(appDbContext)
    {
        _boardMemberSpeeches = appDbContext.Set<BoardMemberSpeech>();
    }

    #endregion

    #region Handle Functions

    #endregion
}
