using Leha.Data.Entities;

namespace Leha.Manager.Managers.BoardMemberSpeeches;

public interface IBoardMemberSpeechManager
{
    public Task<List<BoardMemberSpeech?>> GetBoardMemberSpeechesListAsync();
    public Task<List<BoardMemberSpeech?>> GetBoardMemberSpeechesListByBoardMemberId(int boardMemberID);
    public Task<BoardMemberSpeech?> GetBoardMemberSpeechByIDAsync(int boardMemberSpeechID);
    public Task<bool> AddBoardMemberSpeechAsync(BoardMemberSpeech boardMemberSpeech);
    public Task<bool> UpdateBoardMemberSpeechAsync(BoardMemberSpeech boardMemberSpeech);
    public Task<bool> DeleteBoardMemberSpeechAsync(BoardMemberSpeech boardMemberSpeech);
}
