using Leha.Data.Entities;

namespace Leha.Manager.Managers.BoardMemberSpeeches;

public interface IBoardMemberSpeechManager
{
    public IQueryable<BoardMemberSpeech?> GetBoardMemberSpeechesListAsync();
    public IQueryable<BoardMemberSpeech?> GetBoardMemberSpeechesListByBoardMemberId(int id);
    public Task<BoardMemberSpeech?> GetBoardMemberSpeechByIDAsync(int id);
    public Task<bool> AddBoardMemberSpeechAsync(BoardMemberSpeech pm);
    public Task<bool> UpdateBoardMemberSpeechAsync(BoardMemberSpeech pm);
    public Task<bool> DeleteBoardMemberSpeechAsync(BoardMemberSpeech pm);
}
