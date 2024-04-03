using Leha.Data.Entities;
using Leha.Infrastructure.Repositories.Generic;

namespace Leha.Infrastructure.Repositories.BoardMemberSpeeches;

public interface IBoardMemberSpeechRepository : IGenericRepository<BoardMemberSpeech>
{
    public Task<List<BoardMemberSpeech?>> GetBoardMemberSpeechesListByBoardMemberId(int boardMemberID);
}
