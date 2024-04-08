using Leha.Data.Entities;

namespace Leha.Manager.Managers.BoardMemberSpeeches;

public interface IBoardMemberSpeechManager
{
    public IQueryable<BoardMemberSpeech?> GetAll();
    public IQueryable<BoardMemberSpeech?> GetAllByBoardMemberID(int id);
    public Task<BoardMemberSpeech?> GetByIdAsync(int id);
    public Task<bool> AddAsync(BoardMemberSpeech pm);
    public Task<bool> UpdateAsync(BoardMemberSpeech pm);
    public Task<bool> DeleteAsync(BoardMemberSpeech pm);
}
