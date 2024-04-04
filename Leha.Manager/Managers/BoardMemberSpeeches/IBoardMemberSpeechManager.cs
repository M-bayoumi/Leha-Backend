using Leha.Data.Entities;

namespace Leha.Manager.Managers.BoardMemberSpeeches;

public interface IBoardMemberSpeechManager
{
    public IQueryable<BoardMemberSpeech?> GetBoardMemberSpeechesListAsync();
    public IQueryable<BoardMemberSpeech?> GetBoardMemberSpeechesListByBoardMemberId(int boardMemberID);
    public Task<BoardMemberSpeech?> GetBoardMemberSpeechByIDAsync(int boardMemberSpeechID);
    public Task<bool> AddBoardMemberSpeechAsync(BoardMemberSpeech boardMemberSpeech);
    public Task<bool> UpdateBoardMemberSpeechAsync(BoardMemberSpeech boardMemberSpeech);
    public Task<bool> DeleteBoardMemberSpeechAsync(BoardMemberSpeech boardMemberSpeech);
}
